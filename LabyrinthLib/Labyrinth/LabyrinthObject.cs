using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.Labyrinth
{
    internal class LabyrinthObject
    {
        protected int X { get; set; }
        protected int Y { get; set; }
        protected int W { get; set; }
        protected int H { get; set; }

        public LabyrinthObject(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            W = w;
            H = h;
        }
    }
}
