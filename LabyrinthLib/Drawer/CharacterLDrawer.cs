using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.Drawer
{
    internal enum RenderMapFieldType
    {
        NONE, WALL, HORIZONTAL_DOOR, VERTICAL_DOOR
    }
    public class CharacterLDrawer : LabyrinthDrawer, LVisitor
    {
        private RenderMapFieldType[,] _renderMap = new RenderMapFieldType[0,0];
        Vec2 _topLeft;
        LIterator _lItertator;

        public CharacterLDrawer(LIterator lItertator)
        {
            _lItertator = lItertator;
        }

        public void Draw(Labyrinth labyrinth)
        {
            var size = labyrinth.GetSize();
            _renderMap = new RenderMapFieldType[size.height + 1, size.width + 1];
            _topLeft = labyrinth.GetTopLeft();

            _lItertator.Start();
            while (_lItertator.Next())
            {
                LObject lObject = _lItertator.Get();
                lObject.Accept(this);
            }

            for (int row = 0; row < _renderMap.GetLength(0); ++row)
            {
                for (int col = 0; col < _renderMap.GetLength(1); ++col)
                {
                    switch(_renderMap[row, col])
                    {
                        case RenderMapFieldType.NONE:
                            Console.Write(' ');
                            break;
                        case RenderMapFieldType.WALL:
                            Console.Write('X');
                            break;
                        case RenderMapFieldType.HORIZONTAL_DOOR:
                            Console.Write('-');
                            break;
                        case RenderMapFieldType.VERTICAL_DOOR:
                            Console.Write('|');
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public void VisitRoom(Room room)
        {
            int bottomRightX = room.BottomRight().X;
            int bottomRightY = room.BottomRight().Y;
            int row = (room.Y - _topLeft.Y);
            int col;
            for (col = room.X - _topLeft.X; col < bottomRightX - _topLeft.X; ++col)
            {
                _renderMap[row, col] = RenderMapFieldType.WALL;
            }
            row = bottomRightY - _topLeft.Y;
            for (col = room.X - _topLeft.X; col < bottomRightX - _topLeft.X; ++col)
            {
                _renderMap[row, col] = RenderMapFieldType.WALL;
            }
            col = room.X - _topLeft.X;
            for (row = room.Y - _topLeft.Y; row < bottomRightY - _topLeft.Y; ++row)
            {
                _renderMap[row, col] = RenderMapFieldType.WALL;
            }
            col = bottomRightX - _topLeft.X;
            for (row = room.Y - _topLeft.Y; row < bottomRightY - _topLeft.Y; ++row)
            {
                _renderMap[row, col] = RenderMapFieldType.WALL;
            }
        }

        public void VisitColoredRoom(ColoredRoom room)
        {
            VisitRoom(room);
        }

        public void VisitDoor(Door door)
        {
            if (door.Horizontal)
            {
                int row = door.Y - _topLeft.Y;
                for (int col = door.X - _topLeft.X; col < door.X - _topLeft.X + LTraversable.DoorSize; ++col)
                    _renderMap[row, col] = RenderMapFieldType.HORIZONTAL_DOOR;
            }
            else
            {
                int col = door.X - _topLeft.X;
                for (int row = door.Y - _topLeft.Y; row < door.Y - _topLeft.Y + LTraversable.DoorSize; ++row)
                    _renderMap[row, col] = RenderMapFieldType.VERTICAL_DOOR;
            }
        }
    }
}
