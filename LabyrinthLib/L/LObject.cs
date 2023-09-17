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

        public static Vec2 operator +(Vec2 v1, Vec2 v2) => new Vec2(v1.X + v2.X, v1.Y + v2.Y);
        public static Vec2 operator -(Vec2 v1, Vec2 v2) => new Vec2(v1.X - v2.X, v1.Y - v2.Y);
        public static Vec2 operator *(Vec2 v, int s) => new Vec2(v.X * s, v.Y * s);
        public static Vec2 operator *(Vec2 v1, Vec2 v2) => new Vec2(v1.X * v2.X, v1.Y * v2.Y);
        public static Vec2 operator /(Vec2 v, int s) => new Vec2(v.X / s, v.Y / s);
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
