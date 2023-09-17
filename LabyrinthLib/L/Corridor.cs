using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public enum CorridorDirectionType
    {
        HORIZONTAL, VERTICAL, LU_CORNER, LD_CORNER, RU_CORNER, RD_CORNER
    }
    public class Corridor : LTraversable
    {
        public static readonly int Stretch = DoorSize + 4 * WallWidth;
        public static readonly int TraversableDistanceFromLine = (Stretch - 2 * WallWidth) / 2;

        static Corridor()
        {
            if (Stretch % 2 == 0)
                throw new LabyrinthException("Corridor width must be an odd number.");
        }

        private Vec2[] _line;
        public Vec2[] Line { get { return _line; } } 
        
        public Corridor(int x, int y, int w, int h, Vec2[] line) : base(x, y, w, h)
        {
            _line = line;
        }

        // TODO: Corridor should be simplified! No curving corridors allowed!
        public CorridorDirectionType DirectionType(int i)
        {
            Vec2 v;
            if (i == _line.Length - 1)
            {
                v = _line[i] - _line[i - 1];
                if (v.X == 0)
                {
                    return CorridorDirectionType.VERTICAL;
                }
                else return CorridorDirectionType.HORIZONTAL;
            }
            v = _line[i + 1] - _line[i];
            if (v.X == 0)
                return CorridorDirectionType.VERTICAL;
            else if (v.Y == 0)
                return CorridorDirectionType.HORIZONTAL;
            else if (v.X > 0 && v.Y > 0)
                return CorridorDirectionType.LD_CORNER;
            else if (v.X > 0 && v.Y < 0)
                return CorridorDirectionType.LU_CORNER;
            else if (v.X < 0 && v.Y > 0)
                return CorridorDirectionType.RD_CORNER;
            else
                return CorridorDirectionType.RU_CORNER;
        }

        public override bool IsTraversable(Vec2 p)
        {
            foreach (Vec2 lineV in _line)
            {
                if (lineV.AxisAlignedDistance(p) <= TraversableDistanceFromLine)
                    return true;
            }
            return false;
        }
        public override void Accept(LVisitor visitor)
        {
            visitor.VisitCorridor(this);
        }
    }
}
