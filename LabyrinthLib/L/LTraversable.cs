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

        public abstract (Vec2, Vec2) CalcTouchLine(LTraversable room);

        public abstract (Vec2, Vec2) CalcDistantTouchLine(LTraversable room);

        public abstract bool IsTraversable(Vec2 p);

        public Vec2 BottomRight()
        {
            return new Vec2(X + W, Y + H);
        }
        protected (int, int) CalcIntervalOverlap(int a1, int a2, int b1, int b2)
        {
            if (a1 <= b1 && b1 < a2)
                return (b1, Math.Min(a2, b2));
            else if (a1 > b1 && b2 > a1)
                return (a1, Math.Min(a2, b2));
            else return (1, -1);
        }
    }
}
