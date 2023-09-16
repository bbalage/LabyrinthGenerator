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
        Vec2 _topLeft;

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
            int bottomRightX = room.bottomRight().X;
            int bottomRightY = room.bottomRight().Y;
            int row = (room.Y - _topLeft.Y);
            int col;
            for (col = room.X - _topLeft.X; col < bottomRightX - _topLeft.X; ++col)
            {
                _renderMap[row, col] = 1;
            }
            row = bottomRightY - _topLeft.Y;
            for (col = room.X - _topLeft.X; col < bottomRightX - _topLeft.X; ++col)
            {
                _renderMap[row, col] = 1;
            }
            col = room.X - _topLeft.X;
            for (row = room.Y - _topLeft.Y; row < bottomRightY - _topLeft.Y; ++row)
            {
                _renderMap[row, col] = 1;
            }
            col = bottomRightX - _topLeft.X;
            for (row = room.Y - _topLeft.Y; row < bottomRightY - _topLeft.Y; ++row)
            {
                _renderMap[row, col] = 1;
            }
        }

        public void VisitDoor(Door door) { }

        public void VisitLabyrinth(Labyrinth labyrinth)
        {
            var size = labyrinth.GetSize();
            _renderMap = new int[size.height + 1, size.width + 1];
            _topLeft = labyrinth.GetTopLeft();
        }
    }
}
