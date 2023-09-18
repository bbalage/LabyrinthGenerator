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

        public override (Vec2, Vec2) CalcTouchLine(LTraversable room)
        {
            Vec2 mbr = BottomRight();
            Vec2 obr = room.BottomRight();
            Vec2 start, end;
            if (mbr.X == room.X)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(Y, mbr.Y, room.Y, obr.Y);
                end.X = start.X = mbr.X;
            }
            else if (mbr.Y == room.Y)
            {
                (start.X, end.X) = CalcIntervalOverlap(X, mbr.X, room.X, obr.X);
                end.Y = start.Y = mbr.Y;
            }
            else if (obr.X == X)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(Y, mbr.Y, room.Y, obr.Y);
                end.X = start.X = obr.X;
            }
            else if (obr.Y == Y)
            {
                (start.X, end.X) = CalcIntervalOverlap(X, mbr.X, room.X, obr.X);
                end.Y = start.Y = obr.Y;
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



        public override void Accept(LVisitor visitor)
        {
            visitor.VisitRoom(this);
        }

        public override bool IsTraversable(Vec2 p)
        {
            return p.X >= 0 && p.X <= W && p.Y >= 0 && p.Y <= H;
        }

        public override (Vec2, Vec2) CalcDistantTouchLine(LTraversable room)
        {
            var (x1, x2) = CalcIntervalOverlap(X, BottomRight().X, room.X, room.BottomRight().X);
            var (y1, y2) = CalcIntervalOverlap(Y, BottomRight().Y, room.Y, room.BottomRight().Y);
            if (x2 - x1 >= DoorSize)
            {
                int corrX = (x1 + (x1 + x2) / 2) - WallWidth * 2;
                int corrY = Y < room.Y ? BottomRight().Y : room.BottomRight().Y;
                int corrW = WallWidth * 4 + DoorSize;
                int corrH = Y < room.Y ? room.Y - BottomRight().Y : Y - room.BottomRight().Y;
                return (new Vec2 { X = corrX, Y = corrY }, new Vec2 { X = corrX + corrW, Y = corrY + corrH });
            }
            else if (y2 - y1 >= DoorSize)
            {
                int corrX = X < room.X ? BottomRight().X : room.BottomRight().X;
                int corrY = (y1 + (y1 + y2) / 2) - WallWidth * 2;
                int corrW = X < room.X ? room.X - BottomRight().X : X - room.BottomRight().X;
                int corrH = WallWidth * 4 + DoorSize;
                return (new Vec2 { X = corrX, Y = corrY }, new Vec2 { X = corrX + corrW, Y = corrY + corrH });
            }
            return (new Vec2 { X = 0, Y = 0 }, new Vec2 { X = -1, Y = -1 });
        }
    }
}
