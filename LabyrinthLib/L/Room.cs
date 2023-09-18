using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public enum RoomType
    {
        BLANK, FACTORY, HOSPITAL, SAWMILL
    }
    public class Room : LTraversable
    {
        public RoomType Type { get; set; }
        public Room(int x, int y, int w, int h, RoomType type) :
            base(x, y, w, h)
        {
            Type = type;
        }


        public override (Vec2, Vec2) CalcTouchLine(LTraversable other)
        {
            Rect rect = new Rect() { X1 = X, Y1 = Y, X2 = BottomRight().X, Y2 = BottomRight().Y };
            return rect.CalcTouchLine(other.Rect);
        }
        public override (Vec2, Vec2, bool) CalcDistantTouchLine(LTraversable other)
        {
            Rect rect = new Rect() { X1 = X, Y1 = Y, X2 = BottomRight().X, Y2 = BottomRight().Y };
            return rect.CalcDistantTouchLine(other.Rect);
        }

        public override void Accept(LVisitor visitor)
        {
            visitor.VisitRoom(this);
        }

        public override bool IsIn(Vec2 p)
        {
            return p.X >= 0 && p.X <= W && p.Y >= 0 && p.Y <= H;
        }
    }
}
