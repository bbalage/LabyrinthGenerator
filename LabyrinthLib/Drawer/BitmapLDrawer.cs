using LabyrinthLib.L;
using LabyrinthLib.LVis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Drawing;
using Path = SixLabors.ImageSharp.Drawing.Path;
using Microsoft.VisualBasic.FileIO;

namespace LabyrinthLib.Drawer
{
    public class BitmapLDrawer : LabyrinthDrawer
    {
        private readonly RenderLVisitor _visitor;
        public BitmapLDrawer(RenderLVisitor visitor)
        {
            _visitor = visitor;
        }

        public void Draw(Labyrinth labyrinth)
        {
            labyrinth.Accept(_visitor);
            RenderMap renderMap = _visitor.GetRenderMap();
            Image<Rgb24> image = new(renderMap.data.GetLength(0) * 10, renderMap.data.GetLength(1) * 10);
            var rect = new Rectangle(50, 50, 50, 50);
            //Pen pen = Pens.Dash(Color.Green, 5);
            Pen pen = new SolidPen(Color.Red, 5);
            image.Mutate(x => x.Draw(pen, rect));
            image.Save("something.bmp");
        }
    }
}
