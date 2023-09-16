using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public struct Size
    {
        public float width;
        public float height;

        public Size(float width, float height)
        {
            this.width = width;
            this.height = height;
        }
    }

    public class Labyrinth
    {
        private readonly List<Room> _rooms = new();
        private readonly List<Door> _doors = new();
        private Vector2 _topLeft = new Vector2(0, 0);
        private Vector2 _bottomRight = new Vector2(0, 0);

        public int addRoom(Room room)
        {
            var len = _rooms.Count;
            _rooms.Add(room);
            _topLeft.X = Math.Min(room.X, _topLeft.X);
            _topLeft.Y = Math.Min(room.Y, _topLeft.Y);
            Vector2 bottomRight = room.bottomRight();
            _bottomRight.X = Math.Max(bottomRight.X, _bottomRight.X);
            _bottomRight.Y = Math.Max(bottomRight.Y, _bottomRight.Y);
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
            return new Size(_bottomRight.X - _topLeft.X, _bottomRight.Y - _topLeft.Y);
        }

        public Vector2 GetTopLeft()
        { 
            return _topLeft;
        }
        public void Accept(LabyrinthVisitor visitor)
        {
            visitor.VisitLabyrinth(this);
            foreach (var room in _rooms)
            {
                room.Accept(visitor);
            }
            foreach (var door in _doors)
            {
                door.Accept(visitor);
            }
        }
    }
}
