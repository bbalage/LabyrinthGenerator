using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.Labyrinth
{
    class Labyrinth
    {
        private List<Room> rooms = new();
        private List<Door> doors = new();

        public int addRoom(Room room)
        {
            var len = rooms.Count;
            rooms.Add(room);
            return len;
        }

        public int addDoor(Door door)
        {
            // TODO: Add connection matrix handling here
            var len = doors.Count;
            doors.Add(door);
            return len;
        }
    }
}
