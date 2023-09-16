using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public class BlankLBuilder : LBuilder
    {
        private Labyrinth _labyrinth = new Labyrinth();
        private RoomConnectingStrategy ?_roomConnectingStrategy;

        public LBuilder AddRoom(string roomName, int x, int y, int w, int h)
        {
            _labyrinth.addRoom(new Room(x, y, w, h), roomName);
            return this;
        }

        public LBuilder ConnectRooms(string roomName1, string roomName2)
        {
            if (_roomConnectingStrategy == null)
                throw new LabyrinthException("No room connecting strategy configured.");
            _roomConnectingStrategy.ConnectRooms(_labyrinth, roomName1, roomName2);
            return this;
        }

        public LBuilder SetRoomConnectingStrategy(RoomConnectingStrategy roomConnectingStrategy)
        {
            _roomConnectingStrategy = roomConnectingStrategy;
            return this;
        }

        public Labyrinth Build()
        {
            var lab = _labyrinth;
            _labyrinth = new Labyrinth();
            return lab;
        }
    }
}
