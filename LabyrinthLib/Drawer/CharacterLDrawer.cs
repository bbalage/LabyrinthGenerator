using LabyrinthLib.L;
using LabyrinthLib.LVis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.Drawer
{
    public class CharacterLDrawer : LabyrinthDrawer
    {
        private readonly RenderLVisitor _visitor;
        public CharacterLDrawer(RenderLVisitor visitor)
        {
            _visitor = visitor;
        }
        public void Draw(Labyrinth labyrinth)
        {
            labyrinth.Accept(_visitor);
            RenderMap renderMap = _visitor.GetRenderMap();
            for (int row = 0; row < renderMap.data.GetLength(0); ++row)
            {
                for (int col = 0; col < renderMap.data.GetLength(1); ++col)
                {
                    if (renderMap.data[row, col] != 0)
                        Console.Write('X');
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
