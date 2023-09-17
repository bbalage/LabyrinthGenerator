using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public interface LVisitor
    {
        void VisitRoom(Room room);
        void VisitDoor(Door door);
        void VisitCorridor(Corridor corridor);
    }
}
