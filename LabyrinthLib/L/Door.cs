using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class Door : LObject
    {
        public bool Horizontal { get; }
        public Door(int x, int y, bool horizontal) :
            base(x, y)
        {
            Horizontal = horizontal;
        }

        public override void Accept(LVisitor visitor)
        {
            visitor.VisitDoor(this);
        }
    }
}
