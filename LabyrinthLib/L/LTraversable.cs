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
        public static readonly int WallWidth = 1;
        public static readonly int DoorSize = 3;
        public int W { get; }
        public int H { get; }

        protected LTraversable(int x, int y, int w, int h) : base(x, y)
        {
            W = w;
            H = h;
        }

        public abstract bool IsTraversable(Vec2 p);

        public Vec2 bottomRight()
        {
            return new Vec2(X + W, Y + H);
        }
    }
}
