using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthTests.L
{
    class RectTest
    {
        [Test]
        public void CalcTouchLineHor()
        {
            Rect rect1 = new Rect() { X1 = 3, Y1 = -9, X2 = 8, Y2 = -5 };
            Rect rect2 = new Rect() { X1 = 8, Y1 = -8, X2 = 10, Y2 = -6 };
            Vec2 expectedV1 = new Vec2() { X = 8, Y = -8 };
            Vec2 expectedV2 = new Vec2() { X = 8, Y = -6 };

            var (actualV1, actualV2) = rect1.CalcTouchLine(rect2);
            var (actualV1_rev, actualV2_rev) = rect2.CalcTouchLine(rect1);

            Assert.AreEqual(expectedV1.X, actualV1.X);
            Assert.AreEqual(expectedV1.Y, actualV1.Y);
            Assert.AreEqual(expectedV2.X, actualV2.X);
            Assert.AreEqual(expectedV2.Y, actualV2.Y);
            Assert.AreEqual(expectedV1.X, actualV1_rev.X);
            Assert.AreEqual(expectedV1.Y, actualV1_rev.Y);
            Assert.AreEqual(expectedV2.X, actualV2_rev.X);
            Assert.AreEqual(expectedV2.Y, actualV2_rev.Y);
        }


        [Test]
        public void CalcTouchLineVer()
        {
            Rect rect1 = new Rect() { X1 = 3, Y1 = -9, X2 = 8, Y2 = -5 };
            Rect rect2 = new Rect() { X1 = 4, Y1 = -5, X2 = 6, Y2 = -2 };
            Vec2 expectedV1 = new Vec2() { X = 4, Y = -5 };
            Vec2 expectedV2 = new Vec2() { X = 6, Y = -5 };

            var (actualV1, actualV2) = rect1.CalcTouchLine(rect2);
            var (actualV1_rev, actualV2_rev) = rect2.CalcTouchLine(rect1);


            Assert.AreEqual(expectedV1.X, actualV1.X);
            Assert.AreEqual(expectedV1.Y, actualV1.Y);
            Assert.AreEqual(expectedV2.X, actualV2.X);
            Assert.AreEqual(expectedV2.Y, actualV2.Y);
            Assert.AreEqual(expectedV1.X, actualV1_rev.X);
            Assert.AreEqual(expectedV1.Y, actualV1_rev.Y);
            Assert.AreEqual(expectedV2.X, actualV2_rev.X);
            Assert.AreEqual(expectedV2.Y, actualV2_rev.Y);
        }

        [Test]
        public void CalcDistantTouchLineHor()
        {
            Rect rect1 = new Rect() { X1 = 3, Y1 = -9, X2 = 8, Y2 = -5 };
            Rect rect2 = new Rect() { X1 = 80, Y1 = -8, X2 = 100, Y2 = -6 };
            Vec2 expectedV1 = new Vec2() { X = 8, Y = -8 };
            Vec2 expectedV2 = new Vec2() { X = 80, Y = -6 };

            var (actualV1, actualV2, actualHorizontal) = rect1.CalcDistantTouchLine(rect2);
            var (actualV1_rev, actualV2_rev, actualHorizontal_rev) = rect2.CalcDistantTouchLine(rect1);

            Assert.IsFalse(actualHorizontal);
            Assert.IsFalse(actualHorizontal_rev);
            Assert.AreEqual(expectedV1.X, actualV1.X);
            Assert.AreEqual(expectedV1.Y, actualV1.Y);
            Assert.AreEqual(expectedV2.X, actualV2.X);
            Assert.AreEqual(expectedV2.Y, actualV2.Y);
            Assert.AreEqual(expectedV1.X, actualV1_rev.X);
            Assert.AreEqual(expectedV1.Y, actualV1_rev.Y);
            Assert.AreEqual(expectedV2.X, actualV2_rev.X);
            Assert.AreEqual(expectedV2.Y, actualV2_rev.Y);
        }

        [Test]
        public void CalcDistantTouchLineVer()
        {
            Rect rect1 = new Rect() { X1 = 3, Y1 = -9, X2 = 8, Y2 = -5 };
            Rect rect2 = new Rect() { X1 = 4, Y1 = -5, X2 = 6, Y2 = -2 };
            Vec2 expectedV1 = new Vec2() { X = 4, Y = -5 };
            Vec2 expectedV2 = new Vec2() { X = 6, Y = -5 };

            var (actualV1, actualV2, actualHorizontal) = rect1.CalcDistantTouchLine(rect2);
            var (actualV1_rev, actualV2_rev, actualHorizontal_rev) = rect2.CalcDistantTouchLine(rect1);

            Assert.IsTrue(actualHorizontal);
            Assert.IsTrue(actualHorizontal_rev);
            Assert.AreEqual(expectedV1.X, actualV1.X);
            Assert.AreEqual(expectedV1.Y, actualV1.Y);
            Assert.AreEqual(expectedV2.X, actualV2.X);
            Assert.AreEqual(expectedV2.Y, actualV2.Y);
            Assert.AreEqual(expectedV1.X, actualV1_rev.X);
            Assert.AreEqual(expectedV1.Y, actualV1_rev.Y);
            Assert.AreEqual(expectedV2.X, actualV2_rev.X);
            Assert.AreEqual(expectedV2.Y, actualV2_rev.Y);
        }
    }
}
