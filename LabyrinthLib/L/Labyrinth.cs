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
        private readonly List<LTraversable> _traversables = new();
        private readonly List<Door> _doors = new();
        private Vec2 _topLeft = new Vec2(int.MaxValue, int.MaxValue);
        private Vec2 _bottomRight = new Vec2(int.MinValue, int.MinValue);
        private readonly Dictionary<string, int> _roomNameMap = new();
        private readonly List<List<int>> _connMatrix = new();

        public List<LTraversable> Rooms { get { return _traversables; } }
        public List<Door> Doors { get { return _doors; } }
        public List<List<int>> ConnMatrix { get { return _connMatrix; } }

        public int AddRoom(LTraversable room, string name)
        {
            var len = _traversables.Count;
            _roomNameMap.Add(name, len);
            _traversables.Add(room);
            _topLeft.X = Math.Min(room.X, _topLeft.X);
            _topLeft.Y = Math.Min(room.Y, _topLeft.Y);
            Vec2 bottomRight = room.BottomRight();
            _bottomRight.X = Math.Max(bottomRight.X, _bottomRight.X);
            _bottomRight.Y = Math.Max(bottomRight.Y, _bottomRight.Y);
            _connMatrix.Add(new List<int>());
            foreach (var row in _connMatrix)
                for (int i = row.Count; i <= len; ++i)
                    row.Add(-1);
            return len;
        }

        public int AddDoor(Door door, string roomName1, string roomName2)
        {
            var len = _doors.Count;
            _connMatrix[_roomNameMap[roomName1]][_roomNameMap[roomName2]] = len;
            _connMatrix[_roomNameMap[roomName2]][_roomNameMap[roomName1]] = len;
            _doors.Add(door);
            return len;
        }

        public Size GetSize()
        {
            if (_traversables.Count == 0)
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

        public LTraversable GetRoom(string name)
        {
            return _traversables[_roomNameMap[name]];
        }
    }
}
