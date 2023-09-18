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
        public void Connect(LBuilder builder, Labyrinth labyrinth, string roomName1, string roomName2)
        {
            LTraversable room1 = labyrinth.GetRoom(roomName1);
            LTraversable room2 = labyrinth.GetRoom(roomName2);
            string corrName = roomName1 + roomName2 + "Corridor";

            var (topLeft, bottomRight, horizontal) = room1.CalcDistantTouchLine(room2);
            if (bottomRight.X - topLeft.X < LTraversable.WallWidth + LTraversable.DoorSize
                && bottomRight.Y - topLeft.Y < LTraversable.WallWidth + LTraversable.DoorSize)
            {
                throw new LabyrinthException("Cannot connect rooms with a straight corridor. Not enough overlap.");
            }
            if (bottomRight.X - topLeft.X == 0)
            {
                builder.AddDoor(topLeft.X, topLeft.Y, false, roomName1, roomName2);
                return;
            } else if (bottomRight.Y - topLeft.Y == 0)
            {
                builder.AddDoor(topLeft.X, topLeft.Y, true, roomName1, roomName2);
                return;
            }
            int corrX = horizontal ? topLeft.X + (bottomRight.X - topLeft.X) / 2 - LTraversable.DoorSize / 2 - LTraversable.WallWidth * 2 : topLeft.X;
            int corrY = !horizontal ? topLeft.Y + (bottomRight.Y - topLeft.Y) / 2 - LTraversable.DoorSize / 2 - LTraversable.WallWidth * 2 : topLeft.Y;
            int corrW = horizontal ? LTraversable.DoorSize + LTraversable.WallWidth * 4 : bottomRight.X - topLeft.X;
            int corrH = !horizontal ? LTraversable.DoorSize + LTraversable.WallWidth * 4 : bottomRight.Y - topLeft.Y;

            builder.AddRoom(corrName, corrX, corrY, corrW, corrH);

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
