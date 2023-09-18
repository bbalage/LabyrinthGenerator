using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public struct Vec2
    {
        public int X, Y;

        public Vec2(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int AxisAlignedDistance(Vec2 v)
        {
            if (v.X == X)
                return Math.Abs(v.Y - Y);
            else if (v.Y == Y)
                return Math.Abs(v.X - X);
            else
                return int.MaxValue;
        }

        public static Vec2 operator +(Vec2 v1, Vec2 v2) => new Vec2(v1.X + v2.X, v1.Y + v2.Y);
        public static Vec2 operator -(Vec2 v1, Vec2 v2) => new Vec2(v1.X - v2.X, v1.Y - v2.Y);
        public static Vec2 operator *(Vec2 v, int s) => new Vec2(v.X * s, v.Y * s);
        public static Vec2 operator *(Vec2 v1, Vec2 v2) => new Vec2(v1.X * v2.X, v1.Y * v2.Y);
        public static Vec2 operator /(Vec2 v, int s) => new Vec2(v.X / s, v.Y / s);
    }

    public struct Rect
    {
        public int X1, Y1, X2, Y2;
        public int W { get { return X2 - X1; } }
        public int H { get { return Y2 - Y1; } }

        public (Vec2, Vec2) CalcTouchLine(Rect rect)
        {
            Vec2 start, end;
            if (X2 == rect.X1)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(Y1, Y2, rect.Y1, rect.Y2);
                end.X = start.X = X2;
            }
            else if (Y2 == rect.Y1)
            {
                (start.X, end.X) = CalcIntervalOverlap(X1, X2, rect.X1, rect.X2);
                end.Y = start.Y = Y2;
            }
            else if (rect.X2 == X1)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(Y1, Y2, rect.Y1, rect.Y2);
                end.X = start.X = rect.X2;
            }
            else if (rect.Y2 == Y1)
            {
                (start.X, end.X) = CalcIntervalOverlap(X1, X2, rect.X1, rect.X2);
                end.Y = start.Y = rect.Y2;
            }
            else
            {
                start.X = start.Y = 0;
                end.X = end.Y = -1;
            }
            if (start.X > end.X || start.Y > end.Y)
            {
                throw new LabyrinthException("Rooms cannot connect, because they don't overlap.");
            }
            return (start, end);
        }

        public (Vec2, Vec2, bool) CalcDistantTouchLine(Rect rect)
        {
            var (x1, x2) = CalcIntervalOverlap(X1, X2, rect.X1, rect.X2);
            var (y1, y2) = CalcIntervalOverlap(Y1, Y2, rect.Y1, rect.Y2);
            if (x2 - x1 > 0)
            {
                int topY = Y1 < rect.Y1 ? Y2 : rect.Y2;
                int bottomY = Y1 < rect.Y1 ? rect.Y1 : Y1;
                return (new Vec2 { X = x1, Y = topY }, new Vec2 { X = x2, Y = bottomY }, true);
            }
            else if (y2 - y1 > 0)
            {
                int topX = X1 < rect.X1 ? X2 : rect.X2;
                int bottomX = X1 < rect.X1 ? rect.X1 : X1;
                return (new Vec2 { X = topX, Y = y1 }, new Vec2 { X = bottomX, Y = y2 }, false);
            }
            return (new Vec2 { X = 0, Y = 0 }, new Vec2 { X = -1, Y = -1 }, false);
        }

        public (int, int) CalcIntervalOverlap(int a1, int a2, int b1, int b2)
        {
            if (a1 <= b1 && b1 < a2)
                return (b1, Math.Min(a2, b2));
            else if (a1 > b1 && b2 > a1)
                return (a1, Math.Min(a2, b2));
            else return (1, -1);
        }
    }

    public abstract class LObject
    {
        protected Vec2 _pos;
        public int X { get { return _pos.X; } }
        public int Y { get { return _pos.Y; } }

        public LObject(int x, int y)
        {
            _pos.X = x;
            _pos.Y = y;
        }

        public abstract void Accept(LVisitor visitor);
    }
}
