using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public abstract class ConnectingStrategy
    {
        protected List<Room> _rooms = new();
        public abstract void Connect(LBuilder builder, Labyrinth labyrinth, string roomName1, string roomName2);

        protected void EmptyLists()
        {
            _rooms.Clear();
        }

        protected (Vec2, Vec2) CalcTouchLine()
        {
            if (_rooms.Count == 2)
                return CalcTouchLine(_rooms[0], _rooms[1]);
            throw new NotImplementedException("Unexpected room types.");
        }

        protected (Vec2, Vec2) CalcTouchLine(Room room1, Room room2)
        {
            Vec2 mbr = room1.BottomRight();
            Vec2 obr = room2.BottomRight();
            Vec2 start, end;
            if (mbr.X == room2.X)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(room1.Y, mbr.Y, room2.Y, obr.Y);
                end.X = start.X = mbr.X;
            }
            else if (mbr.Y == room2.Y)
            {
                (start.X, end.X) = CalcIntervalOverlap(room1.X, mbr.X, room2.X, obr.X);
                end.Y = start.Y = mbr.Y;
            }
            else if (obr.X == room1.X)
            {
                (start.Y, end.Y) = CalcIntervalOverlap(room1.Y, mbr.Y, room2.Y, obr.Y);
                end.X = start.X = obr.X;
            }
            else if (obr.Y == room1.Y)
            {
                (start.X, end.X) = CalcIntervalOverlap(room1.X, mbr.X, room2.X, obr.X);
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
