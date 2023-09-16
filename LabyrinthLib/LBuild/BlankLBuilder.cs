using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    class BlankLBuilder : LBuilder
    {
        private Labyrinth _labyrinth = new Labyrinth();

        public LBuilder addRoom(string roomName, int x, int y, int w, int h)
        {
            
            return this;
        }

        public LBuilder connectRooms(string roomName1, string roomName2)
        {
            throw new NotImplementedException();
        }

        public Labyrinth build()
        {
            throw new NotImplementedException();
        }
    }
}
