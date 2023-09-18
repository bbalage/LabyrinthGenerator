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

            var (topLeft, bottomRight) = room1.CalcDistantTouchLine(room2);
            if (bottomRight.X - topLeft.X < LTraversable.WallWidth * 4 + LTraversable.DoorSize
                && bottomRight.Y - topLeft.Y < LTraversable.WallWidth * 4 + LTraversable.DoorSize)
            {
                throw new LabyrinthException("Cannot connect rooms with a straight corridor. Not enough overlap.");
            }
            builder.AddRoom(corrName, topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);

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
