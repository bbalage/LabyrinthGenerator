using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class Door : LObject
    {
        public static readonly int DoorSize = 2;
        public bool Horizontal { get; }
        public Door(int x, int y, bool horizontal) :
            base(x, y)
        {
            Horizontal = horizontal;
        }

        public override void Accept(LabyrinthVisitor visitor)
        {
            visitor.VisitDoor(this);
        }
    }
}
