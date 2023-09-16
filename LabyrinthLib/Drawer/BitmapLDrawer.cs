using LabyrinthLib.L;
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
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace LabyrinthLib.Drawer
{
    public class BitmapLDrawer : LabyrinthDrawer, LabyrinthVisitor
    {
        private Image<Rgb24> _img;
        private Vec2 _topLeft;
        private readonly Vec2 pixelMultipliers = new Vec2(10, 10);

        public void Draw(Labyrinth labyrinth)
        {
            labyrinth.Accept(this);
            _img.Save("labyrinth.bmp");
        }

        public void VisitDoor(Door door)
        {
            //var rect = new Rectangle(
            //    (int)(_topLeft.X + door.X * pixelMultipliers.X),
            //    (int)(_topLeft.Y + door.Y * pixelMultipliers.Y),
            //    (int)(door.W * pixelMultipliers.X),
            //    (int)(door.H * pixelMultipliers.Y));
            //Pen pen = new SolidPen(Color.Green, 5);
            //_img.Mutate(x => x.Draw(pen, rect));
        }

        public void VisitLabyrinth(Labyrinth labyrinth)
        {
            var size = labyrinth.GetSize();
            _img = new Image<Rgb24>(size.width * pixelMultipliers.X, size.height * pixelMultipliers.Y);
            _topLeft = labyrinth.GetTopLeft() * pixelMultipliers;
        }

        public void VisitRoom(Room room)
        {
            var rect = new Rectangle(
                room.X * pixelMultipliers.X - _topLeft.X,
                room.Y * pixelMultipliers.Y - _topLeft.Y,
                room.W * pixelMultipliers.X,
                room.H * pixelMultipliers.Y);
            Pen pen = new SolidPen(Color.Red, 5);
            _img.Mutate(x => x.Draw(pen, rect));
        }
    }
}
