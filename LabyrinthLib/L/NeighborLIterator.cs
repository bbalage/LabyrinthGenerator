using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class NeighborLIterator : LIterator
    {
        private Labyrinth _labyrinth;
        private Vec2 _pos;
        private int _currentRoomI = -1;
        private readonly List<LObject> neighbors = new();
        private int _index = -1;
        
        public NeighborLIterator(Labyrinth labyrinth, Vec2 pos)
        {
            _labyrinth = labyrinth;
            _pos = pos;
        }

        public void Start()
        {
            for (int i = 0; i < _labyrinth.Rooms.Count; ++i)
            {
                var room = _labyrinth.Rooms[i];
                if (room.IsIn(_pos))
                {
                    _currentRoomI = i;
                    break;
                }
            }
            neighbors.Clear();
            _index = -1;
            if (_currentRoomI == -1)
            {
                return;
            }
            neighbors.Add(_labyrinth.Rooms[_currentRoomI]);
            List<Door> doors = new();
            for (int colI = 0; colI < _labyrinth.ConnMatrix[_currentRoomI].Count; ++colI)
            {
                var connI = _labyrinth.ConnMatrix[_currentRoomI][colI];
                if (connI == -1)
                    continue;
                doors.Add(_labyrinth.Doors[connI]);
                neighbors.Add(_labyrinth.Rooms[colI]);
                foreach (var connectedRoomDoorI in _labyrinth.ConnMatrix[colI])
                {
                    if (connectedRoomDoorI == -1 || connectedRoomDoorI == connI)
                        continue;
                    doors.Add(_labyrinth.Doors[connectedRoomDoorI]);
                }
            }
            foreach(var door in doors)
            {
                neighbors.Add(door);
            }
        }

        public bool Next()
        {
            ++_index;
            return _index < neighbors.Count;
        }

        public LObject Get()
        {
            return neighbors[_index];
        }
    }
}
