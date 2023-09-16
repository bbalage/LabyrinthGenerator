using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public class TouchingRoomConnectingStrategy : RoomConnectingStrategy
    {
        public void ConnectRooms(Labyrinth labyrinth, string roomName1, string roomName2)
        {
            Room room1 = labyrinth.GetRoom(roomName1);
            Room room2 = labyrinth.GetRoom(roomName2);

            var (start, end) = room1.CalcTouchLine(room2);
            bool horizontal = start.X != end.X;
            int length = horizontal ? end.X - start.X : end.Y - start.Y;
            if (length < Door.DoorSize)
                throw new LabyrinthException("Cannot connect rooms because overlap size is not sufficient.");

            Vec2 doorPose = new Vec2(
                horizontal ? start.X + (length - Door.DoorSize) / 2 : start.X,
                horizontal ? start.Y : start.Y + (length - Door.DoorSize) / 2);
            labyrinth.addDoor(new Door(doorPose.X, doorPose.Y, horizontal));
        }
    }
}
