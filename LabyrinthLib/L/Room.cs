using LabyrinthLib.LVis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class Room : LabyrinthObject
    {
        public Room(int x, int y, int w, int h) :
            base(x, y, w, h)
        {
        }

        public override void Accept(LabyrinthVisitor visitor)
        {
            visitor.VisitRoom(this);
        }

        internal Point bottomRight()
        {
            return new Point(X + W, Y + H);
        }

    }
}
