using LabyrinthLib.LVis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public struct Size
    {
        public int width;
        public int height;

        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }

    public class Labyrinth
    {
        private readonly List<Room> _rooms = new();
        private readonly List<Door> _doors = new();
        private Point _topLeft = new Point(0, 0);
        private Point _bottomRight = new Point(0, 0);

        public int addRoom(Room room)
        {
            var len = _rooms.Count;
            _rooms.Add(room);
            _topLeft.x = Math.Min(room.X, _topLeft.x);
            _topLeft.y = Math.Min(room.Y, _topLeft.y);
            Point bottomRight = room.bottomRight();
            _bottomRight.x = Math.Max(bottomRight.x, _bottomRight.x);
            _bottomRight.y = Math.Max(bottomRight.y, _bottomRight.y);
            return len;
        }

        public int addDoor(Door door)
        {
            var len = _doors.Count;
            _doors.Add(door);
            return len;
        }

        public Size GetSize()
        {
            return new Size(_bottomRight.x - _topLeft.x, _bottomRight.y - _topLeft.y);
        }

        public Point GetTopLeft()
        { 
            return _topLeft;
        }
        public void Accept(LabyrinthVisitor visitor)
        {
            visitor.VisitLabyrinth(this);
            foreach(var room in _rooms)
            {
                room.Accept(visitor);
            }
            foreach(var door in _doors)
            {
                door.Accept(visitor);
            }
        }
    }
}
