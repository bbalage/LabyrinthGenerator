﻿using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SL = SixLabors.ImageSharp;
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
    public class BitmapLDrawer : LabyrinthDrawer, LVisitor
    {
        private Image<Rgb24> _img;
        private Vec2 _topLeft;
        private readonly Vec2 pixelMultipliers = new Vec2(10, 10);
        private LIterator _lIterator;

        public BitmapLDrawer(LIterator lIterator)
        {
            _lIterator = lIterator;
        }

        public void Draw(Labyrinth labyrinth)
        {
            var size = labyrinth.GetSize();
            _img = new Image<Rgb24>(size.width * pixelMultipliers.X, size.height * pixelMultipliers.Y);
            _topLeft = labyrinth.GetTopLeft() * pixelMultipliers;

            _lIterator.Start();
            while (_lIterator.Next())
            {
                LObject lObject = _lIterator.Get();
                lObject.Accept(this);
            }
            _img.Save("labyrinth.bmp");
        }

        public void VisitDoor(Door door)
        {
            var points = new PointF[]
                {
                    new PointF(
                        door.X * pixelMultipliers.X - _topLeft.X,
                        door.Y * pixelMultipliers.Y - _topLeft.Y),
                    new PointF(
                        (door.Horizontal ? door.X + LTraversable.DoorSize : door.X) * pixelMultipliers.X - _topLeft.X,
                        (door.Horizontal ? door.Y : door.Y + LTraversable.DoorSize) * pixelMultipliers.Y - _topLeft.Y)
                };
            Pen pen = new SolidPen(SL.Color.Green, 5);
            _img.Mutate(x => x.DrawLine(pen, points));
        }

        public void VisitRoom(Room room)
        {
            var rect = new Rectangle(
                room.X * pixelMultipliers.X - _topLeft.X,
                room.Y * pixelMultipliers.Y - _topLeft.Y,
                room.W * pixelMultipliers.X,
                room.H * pixelMultipliers.Y);
            Pen pen = new SolidPen(SL.Color.Red, 5);
            _img.Mutate(x => x.Draw(pen, rect));
        }

        public void VisitColoredRoom(ColoredRoom room)
        {
            var rect = new Rectangle(
                room.X * pixelMultipliers.X - _topLeft.X,
                room.Y * pixelMultipliers.Y - _topLeft.Y,
                room.W * pixelMultipliers.X,
                room.H * pixelMultipliers.Y);
            SL.Color color = new SL.Color(new Rgb24(room.Color.R, room.Color.G, room.Color.B));
            Brush brushFill = new SolidBrush(color);
            Pen penWall = new SolidPen(SL.Color.Red, 5);
            _img.Mutate(x => x.Fill(brushFill, rect).Draw(penWall, rect));
        }
    }
}
