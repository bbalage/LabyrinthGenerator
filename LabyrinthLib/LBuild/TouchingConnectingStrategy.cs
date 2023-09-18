using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public class TouchingConnectingStrategy : ConnectingStrategy
    {
        public void Connect(LBuilder builder, Labyrinth labyrinth, string roomName1, string roomName2)
        {
            LTraversable room1 = labyrinth.GetRoom(roomName1);
            LTraversable room2 = labyrinth.GetRoom(roomName2);

            var (start, end) = room1.CalcTouchLine(room2);
            bool horizontal = start.X != end.X;
            int length = horizontal ? end.X - start.X : end.Y - start.Y;
            if (length < LTraversable.DoorSize)
                throw new LabyrinthException("Cannot connect rooms because overlap size is not sufficient.");

            Vec2 doorPose = new Vec2(
                horizontal ? start.X + (length - LTraversable.DoorSize) / 2 : start.X,
                horizontal ? start.Y : start.Y + (length - LTraversable.DoorSize) / 2);
            builder.AddDoor(doorPose.X, doorPose.Y, horizontal, 0, 0);
        }
    }
}
