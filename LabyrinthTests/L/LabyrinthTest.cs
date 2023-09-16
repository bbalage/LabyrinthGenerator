using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthTests.L
{
    class LabyrinthTest
    {
        [Test]
        public void LabyrinthSingleRoomTopLeftTest()
        {
            Room room = new Room(10, 10, 10, 10);
            Labyrinth lab = new Labyrinth();
            lab.addRoom(room, "Room");
            Vec2 expectedTopLeft = new Vec2(10, 10);

            Vec2 actualTopLeft = lab.GetTopLeft();

            Assert.AreEqual(expectedTopLeft.X, actualTopLeft.X);
            Assert.AreEqual(expectedTopLeft.Y, actualTopLeft.Y);
        }

        [Test]
        public void LabyrinthSingleRoomTopLeftNegativeTest()
        {
            Room room = new Room(-10, -15, 10, 10);
            Labyrinth lab = new Labyrinth();
            lab.addRoom(room, "Room");
            Vec2 expectedTopLeft = new Vec2(-10, -15);

            Vec2 actualTopLeft = lab.GetTopLeft();

            Assert.AreEqual(expectedTopLeft.X, actualTopLeft.X);
            Assert.AreEqual(expectedTopLeft.Y, actualTopLeft.Y);
        }

        [Test]
        public void LabyrinthSingleRoomGetBottomRightTest()
        {
            Room room = new Room(-10, -15, 15, 10);
            Labyrinth lab = new Labyrinth();
            lab.addRoom(room, "Room");
            Vec2 expectedBottomRight = new Vec2(5, -5);

            Vec2 actualBottomRight = lab.GetBottomRight();

            Assert.AreEqual(expectedBottomRight.X, actualBottomRight.X);
            Assert.AreEqual(expectedBottomRight.Y, actualBottomRight.Y);
        }

        [Test]
        public void LabyrinthSingleRoomGetSizeTest()
        {
            Room room = new Room(-10, -15, 15, 10);
            Labyrinth lab = new Labyrinth();
            lab.addRoom(room, "Room");
            Size expectedSize = new Size(15, 10);

            Size actualSize = lab.GetSize();

            Assert.AreEqual(expectedSize.width, actualSize.width);
            Assert.AreEqual(expectedSize.height, actualSize.height);
        }

        [Test]
        public void LabyrinthMultiRoomGetSizeTest()
        {
            Room room1 = new Room(-10, -15, 15, 10);
            Room room2 = new Room(0, 5, 10, 15);
            Room room3 = new Room(-20, 5, 10, 15);
            Labyrinth lab = new Labyrinth();
            lab.addRoom(room1, "Room1");
            lab.addRoom(room2, "Room2");
            lab.addRoom(room3, "Room3");
            Size expectedSize = new Size(30, 35);

            Size actualSize = lab.GetSize();

            Assert.AreEqual(expectedSize.width, actualSize.width);
            Assert.AreEqual(expectedSize.height, actualSize.height);
        }

        [Test]
        public void LabyrinthMultiRoomVar2GetSizeTest()
        {
            
            Labyrinth lab = new Labyrinth();
            lab.addRoom(new Room(0, 0, 5, 5), "Room1");
            lab.addRoom(new Room(10, 0, 5, 10), "Room2");
            lab.addRoom(new Room(0, 10, 8, 3), "Room3");
            lab.addRoom(new Room(-10, -5, 8, 4), "Room4");
            Size expectedSize = new Size(25, 18);

            Size actualSize = lab.GetSize();

            Assert.AreEqual(expectedSize.width, actualSize.width);
            Assert.AreEqual(expectedSize.height, actualSize.height);
        }
    }
}
