using LabyrinthLib.Drawer;
using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LVis
{
    public class BlankRenderLVisitor : RenderLVisitor
    {
        private RenderMap _renderMap;
        private Vector2 _topLeft;

        public override void VisitLabyrinth(Labyrinth labyrinth)
        {
            var size = labyrinth.GetSize();
            _renderMap = new RenderMap((int)(size.height + 1.0F), (int)(size.width + 1.0F));
            _topLeft = labyrinth.GetTopLeft();

        }

        public override void VisitRoom(Room room)
        {
            int bottomRightX = (int)(room.bottomRight().X);
            int bottomRightY = (int)(room.bottomRight().Y);
            int roomX = (int)room.X;
            int roomY = (int)room.Y;
            int topLeftX = (int)_topLeft.X;
            int topLeftY = (int)_topLeft.Y;
            int row = (int)(room.Y - _topLeft.Y);
            int col;
            for (col = roomX; col <= bottomRightX; ++col)
            {
                _renderMap.data[row, col - topLeftX] = 1;
            }
            row = bottomRightY - topLeftY;
            for (col = roomX; col <= bottomRightX; ++col)
            {
                _renderMap.data[row, col - topLeftX] = 1;
            }
            col = roomX - topLeftX;
            for (row = roomY + 1; row <= bottomRightY - 1; ++row)
            {
                _renderMap.data[row - topLeftY, col] = 1;
            }
            col = bottomRightX - topLeftX;
            for (row = roomY + 1; row <= bottomRightY - 1; ++row)
            {
                _renderMap.data[row - topLeftY, col] = 1;
            }
        }

        public override void VisitDoor(Door door) { }

        public override RenderMap GetRenderMap()
        {
            return _renderMap;
        }
    }
}
