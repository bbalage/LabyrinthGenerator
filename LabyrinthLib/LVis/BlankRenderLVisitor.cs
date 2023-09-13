using LabyrinthLib.Drawer;
using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LVis
{
    public class BlankRenderLVisitor : RenderLVisitor
    {
        private RenderMap _renderMap;
        private Point _topLeft;

        public override void VisitLabyrinth(Labyrinth labyrinth)
        {
            var size = labyrinth.GetSize();
            _renderMap = new RenderMap(size.height + 1, size.width + 1);
            _topLeft = labyrinth.GetTopLeft();

        }

        public override void VisitRoom(Room room)
        {
            Point bottomRight = room.bottomRight();
            int row = room.Y - _topLeft.y;
            int col;
            for (col = room.X; col <= bottomRight.x; ++col)
            {
                _renderMap.data[row, col - _topLeft.x] = 1;
            }
            row = bottomRight.y - _topLeft.y;
            for (col = room.X; col <= bottomRight.x; ++col)
            {
                _renderMap.data[row, col - _topLeft.x] = 1;
            }
            col = room.X - _topLeft.x;
            for (row = room.Y + 1; row <= bottomRight.y - 1; ++row)
            {
                _renderMap.data[row - _topLeft.y, col] = 1;
            }
            col = bottomRight.x - _topLeft.x;
            for (row = room.Y + 1; row <= bottomRight.y - 1; ++row)
            {
                _renderMap.data[row - _topLeft.y, col] = 1;
            }
        }

        public override void VisitDoor(Door door) { }

        public override RenderMap GetRenderMap()
        {
            return _renderMap;
        }
    }
}
