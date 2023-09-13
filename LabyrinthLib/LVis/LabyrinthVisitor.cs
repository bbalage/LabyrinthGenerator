using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LVis
{
    public interface LabyrinthVisitor
    {
        void VisitLabyrinth(Labyrinth labyrinth);
        void VisitRoom(Room room);
        void VisitDoor(Door door);
    }
}
