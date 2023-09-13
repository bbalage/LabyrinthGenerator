using LabyrinthLib.Drawer;
using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LVis
{
    public abstract class RenderLVisitor : LabyrinthVisitor
    {
        public abstract void VisitLabyrinth(Labyrinth labyrinth);

        public abstract void VisitRoom(Room room);

        public abstract void VisitDoor(Door door);

        public abstract RenderMap GetRenderMap();
    }
}
