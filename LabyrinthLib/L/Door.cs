using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public class Door : LabyrinthObject
    {
        private int Room1 { get; }
        private int Room2 { get; }

        public Door(int x, int y, int w, int h, int room1, int room2) :
            base(x, y, w, h)
        {
            Room1 = room1;
            Room2 = room2;
        }

        public override void Accept(LabyrinthVisitor visitor)
        {
            visitor.VisitDoor(this);
        }
    }
}
