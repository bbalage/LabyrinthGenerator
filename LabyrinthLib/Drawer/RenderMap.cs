using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.Drawer
{
    public struct RenderMap
    {
        public readonly int[,] data;
        
        public RenderMap(int rows, int cols) {
            data = new int[rows,cols];
        }
    }
}
