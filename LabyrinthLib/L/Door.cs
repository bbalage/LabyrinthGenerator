using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class Door : LObject
    {
        public float Size { get; }
        public bool Horizontal { get; }
        public Door(int x, int y, int size, bool horizontal) :
            base(x, y)
        {
            Size = size;
            Horizontal = horizontal;
        }

        public override void Accept(LabyrinthVisitor visitor)
        {
            visitor.VisitDoor(this);
        }
    }
}
