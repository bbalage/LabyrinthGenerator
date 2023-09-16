using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthTests.L
{
    public class RoomTest
    {
        [Test]
        public void SimpleRoomBottomRightTest()
        {
            Room room = new Room(10, 10, 10, 10);
            Vec2 expectedBottomRight = new Vec2(20, 20);
                
            Vec2 actualBottomRight = room.bottomRight();

            Assert.AreEqual(expectedBottomRight, actualBottomRight);
        }
    }
}
