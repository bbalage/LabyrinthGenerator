using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class AllLIterator : LIterator
    {
        private Labyrinth _labyrinth;
        private int _index = -1;
        private int _listI = 0;
        public AllLIterator(Labyrinth labyrinth)
        { 
            _labyrinth = labyrinth;
        }
        public LObject Get()
        {
            if (_listI == 0)
                return _labyrinth.Rooms[_index];
            return _labyrinth.Doors[_index];
        }

        public bool Next()
        {
            if (_listI == 0)
            {
                if (_index < _labyrinth.Rooms.Count - 1)
                {
                    ++_index;
                    return true;
                } else
                {
                    _index = 0;
                    ++_listI;
                    return _labyrinth.Doors.Count > 0;
                }
            }
            if (_index < _labyrinth.Doors.Count - 1)
            {
                ++_index;
                return true;
            } else { return false; }
            
        }

        
    }
}
