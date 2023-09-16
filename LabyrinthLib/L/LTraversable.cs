using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public abstract class LTraversable : LObject
    {
        public int W { get; }
        public int H { get; }

        protected LTraversable(int x, int y, int w, int h) : base(x, y)
        {
            W = w;
            H = h;
        }

        public abstract bool IsTraversable(int x, int y);
        
        public Vec2 bottomRight()
        {
            return new Vec2(X + W, Y + H);
        }
    }
}
