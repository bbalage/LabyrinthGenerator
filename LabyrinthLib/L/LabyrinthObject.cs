using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public abstract class LabyrinthObject
    {
        protected float x;
        protected float y;
        protected float w;
        protected float h;
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        public float W { get { return w; } set { w = value; } }
        public float H { get { return h; } set { h = value; } }

        public LabyrinthObject(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public abstract void Accept(LabyrinthVisitor visitor);
    }
}
