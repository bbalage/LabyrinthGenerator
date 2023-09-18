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
        private readonly Stack<ConnectingStrategy> _roomConnectingStrategies = new();

        public LBuilder AddRoom(string roomName, int x, int y, int w, int h)
        {
            _labyrinth.AddRoom(new Room(x, y, w, h), roomName);
            return this;
        }

        public LBuilder AddDoor(int x, int y, bool horizontal, int room1, int room2)
        {
            _labyrinth.AddDoor(new Door(x, y, horizontal), room1, room2);
            return this;
        }

        public LBuilder Connect(string roomName1, string roomName2)
        {
            if (_roomConnectingStrategies.Count == 0)
                throw new LabyrinthException("No room connecting strategy configured.");
            _roomConnectingStrategies.Peek().Connect(this, _labyrinth, roomName1, roomName2);
            return this;
        }

        public Labyrinth Build()
        {
            var lab = _labyrinth;
            _labyrinth = new Labyrinth();
            return lab;
        }

        public LBuilder PushConnectingStrategy(ConnectingStrategy roomConnectingStrategy)
        {
            _roomConnectingStrategies.Push(roomConnectingStrategy);
            return this;
        }

        public LBuilder PopConnectingStrategy()
        {
            _roomConnectingStrategies.Pop();
            return this;
        }
    }
}
