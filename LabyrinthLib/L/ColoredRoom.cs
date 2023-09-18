using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
    }
    public class ColoredRoom : Room
    {
        public Color Color { get; set; }
        public ColoredRoom(int x, int y, int w, int h, RoomType type, Color color) : base(x, y, w, h, type)
        {
            Color = color;
        }

        public override void Accept(LVisitor visitor)
        {
            visitor.VisitColoredRoom(this);
        }
    }
}
