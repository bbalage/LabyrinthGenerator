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

        public override void Accept(LVisitor visitor)
        {
            visitor.VisitRoom(this);
        }

        public override bool IsTraversable(int x, int y)
        {
            return x >= 0 && x <= W && y >= 0 && y <= H;
        }
    }
}
