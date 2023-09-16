using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class Room : LTraversable
    {
        public Room(int x, int y, int w, int h) :
            base(x, y, w, h)
        {
        }

        public (Vec2, Vec2) CalcTouchLine(Room other)
        {
            Vec2 mbr = bottomRight();
            Vec2 obr = other.bottomRight();
            Vec2 start, end;
            if (mbr.X == other.X)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(Y, mbr.Y, other.Y, obr.Y);
                end.X = start.X = mbr.X;
            }
            else if (mbr.Y == other.Y)
            {
                (start.X, end.X) = CalcIntervalOverlap(X, mbr.X, other.X, obr.X);
                end.Y = start.Y = mbr.Y;
            }
            else if (obr.X == X)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(Y, mbr.Y, other.Y, obr.Y);
                end.X = start.X = obr.X;
            }
            else if (obr.Y == Y)
            {
                (start.X, end.X) = CalcIntervalOverlap(X, mbr.X, other.X, obr.X);
                end.Y = start.Y = obr.Y;
            }
            else
            {
                start.X = start.Y = 0;
                end.X = end.Y = -1;
            }
            if (start.X > end.X || start.Y > end.Y) {
                throw new LabyrinthException("Rooms cannot connect, because they don't overlap.");
            }
            return (start, end);
        }

        public override void Accept(LabyrinthVisitor visitor)
        {
            visitor.VisitRoom(this);
        }

        public override bool IsTraversable(int x, int y)
        {
            return x >= 0 && x <= W && y >= 0 && y <= H;
        }

        private (int, int) CalcIntervalOverlap(int a1, int a2, int b1, int b2)
        {
            if (a1 <= b1 && b1 < a2)
                return (b1, Math.Min(a2, b2));
            else if (a1 > b1 && b2 > a1)
                return (a1, Math.Min(a2, b2));
            else return (1, -1);
        }
    }
}
