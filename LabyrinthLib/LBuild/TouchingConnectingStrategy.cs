using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public class TouchingConnectingStrategy : ConnectingStrategy, LVisitor
    {
        
        // private List<Room> _corridors;
        // private Corridor? _corridor;

        public override void Connect(LBuilder builder, Labyrinth labyrinth, string roomName1, string roomName2)
        {
            EmptyLists();
            LTraversable room1 = labyrinth.GetRoom(roomName1);
            LTraversable room2 = labyrinth.GetRoom(roomName2);
            room1.Accept(this);
            room2.Accept(this);

            var (start, end) = CalcTouchLine();
            // CalcTouchLine
            // - Room-Room
            // - Room-Corridor
            // - Corridor-Corridor
            // - NonRectRoom-Room
            // - NonRectRoom-Corridor
            // - ...
            bool horizontal = start.X != end.X;
            int length = horizontal ? end.X - start.X : end.Y - start.Y;
            if (length < LTraversable.DoorSize)
                throw new LabyrinthException("Cannot connect rooms because overlap size is not sufficient.");

            Vec2 doorPose = new Vec2(
                horizontal ? start.X + (length - LTraversable.DoorSize) / 2 : start.X,
                horizontal ? start.Y : start.Y + (length - LTraversable.DoorSize) / 2);
            labyrinth.addDoor(new Door(doorPose.X, doorPose.Y, horizontal));
        }

        public void VisitRoom(Room room)
        {
            _rooms.Add(room);
        }

        public void VisitDoor(Door door)
        {
            throw new LabyrinthException("Unexpected error. Door should not be considered in this connection strategy.");
        }

        public void VisitCorridor(Corridor corridor)
        {
            // TODO: Implement
        }
    }
}
