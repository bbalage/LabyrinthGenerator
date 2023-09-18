using LabyrinthLib.L;
using SixLabors.ImageSharp.Drawing.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public class StraightCorridorConnectingStrategy : ConnectingStrategy, LVisitor
    {
        public override void Connect(LBuilder builder, Labyrinth labyrinth, string roomName1, string roomName2)
        {
            LTraversable room1 = labyrinth.GetRoom(roomName1);
            LTraversable room2 = labyrinth.GetRoom(roomName2);
            string corrName = roomName1 + roomName2 + "Corridor";

            var (x1, x2) = CalcIntervalOverlap(room1.X, room1.BottomRight().X, room2.X, room2.BottomRight().X);
            var (y1, y2) = CalcIntervalOverlap(room1.Y, room1.BottomRight().Y, room2.Y, room2.BottomRight().Y);
            if (x2 - x1 >= LTraversable.DoorSize)
            {
                int corrX = (x1 + (x1 + x2) / 2) - LTraversable.WallWidth * 2;
                int corrY = room1.Y < room2.Y ? room1.BottomRight().Y : room2.BottomRight().Y;
                int corrW = LTraversable.WallWidth * 4 + LTraversable.DoorSize;
                int corrH = room1.Y < room2.Y ? room2.Y - room1.BottomRight().Y : room1.Y - room2.BottomRight().Y;
                builder.AddRoom(corrName, corrX, corrY, corrW, corrH);
            }
            else if (y2 - y1 >= LTraversable.DoorSize)
            {
                int corrX = room1.X < room2.X ? room1.BottomRight().X : room2.BottomRight().X;
                int corrY = (y1 + (y1 + y2) / 2) - LTraversable.WallWidth * 2;
                int corrW = room1.X < room2.X ? room2.X - room1.BottomRight().X : room1.X - room2.BottomRight().X;
                int corrH = LTraversable.WallWidth * 4 + LTraversable.DoorSize;
                builder.AddRoom(corrName, corrX, corrY, corrW, corrH);
            }

            builder.PushConnectingStrategy(new TouchingConnectingStrategy());
            builder.Connect(roomName1, corrName);
            builder.Connect(corrName, roomName2);
            builder.PopConnectingStrategy();
        }

        public void VisitRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public void VisitDoor(Door door)
        {
            throw new NotImplementedException();
        }
    }
}
