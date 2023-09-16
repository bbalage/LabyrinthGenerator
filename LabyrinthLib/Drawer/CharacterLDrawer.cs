using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.Drawer
{
    public class CharacterLDrawer : LabyrinthDrawer, LabyrinthVisitor
    {
        private int[,] _renderMap = new int[0,0];
        Vector2 _topLeft;

        public void Draw(Labyrinth labyrinth)
        {
            labyrinth.Accept(this);

            for (int row = 0; row < _renderMap.GetLength(0); ++row)
            {
                for (int col = 0; col < _renderMap.GetLength(1); ++col)
                {
                    if (_renderMap[row, col] != 0)
                        Console.Write('X');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void VisitRoom(Room room)
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
                _renderMap[row, col - topLeftX] = 1;
            }
            row = bottomRightY - topLeftY;
            for (col = roomX; col <= bottomRightX; ++col)
            {
                _renderMap[row, col - topLeftX] = 1;
            }
            col = roomX - topLeftX;
            for (row = roomY + 1; row <= bottomRightY - 1; ++row)
            {
                _renderMap[row - topLeftY, col] = 1;
            }
            col = bottomRightX - topLeftX;
            for (row = roomY + 1; row <= bottomRightY - 1; ++row)
            {
                _renderMap[row - topLeftY, col] = 1;
            }
        }

        public void VisitDoor(Door door) { }

        public void VisitLabyrinth(Labyrinth labyrinth)
        {
            var size = labyrinth.GetSize();
            _renderMap = new int[(int)(size.width) + 1, (int)(size.height) + 1];
            _topLeft = labyrinth.GetTopLeft();
        }
    }
}
