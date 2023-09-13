using LabyrinthLib.LVis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public abstract class LabyrinthObject
    {
        protected int x;
        protected int y;
        protected int w;
        protected int h;
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int W { get { return w; } set { w = value; } }
        public int H { get { return h; } set { h = value; } }

        public LabyrinthObject(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public abstract void Accept(LabyrinthVisitor visitor);
    }
}
