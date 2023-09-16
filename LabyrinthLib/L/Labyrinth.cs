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
        private Vec2 _topLeft = new Vec2(int.MaxValue, int.MaxValue);
        private Vec2 _bottomRight = new Vec2(int.MinValue, int.MinValue);
        private readonly Dictionary<string, int> _roomNameMap = new(); 

        public int addRoom(Room room, string name)
        {
            var len = _rooms.Count;
            _roomNameMap.Add(name, len);
            _rooms.Add(room);
            _topLeft.X = Math.Min(room.X, _topLeft.X);
            _topLeft.Y = Math.Min(room.Y, _topLeft.Y);
            Vec2 bottomRight = room.bottomRight();
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
            if (_rooms.Count == 0)
                return new Size(0, 0);
            return new Size(_bottomRight.X - _topLeft.X, _bottomRight.Y - _topLeft.Y);
        }

        public Vec2 GetTopLeft()
        { 
            return _topLeft;
        }

        public Vec2 GetBottomRight()
        {
            return _bottomRight;
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
