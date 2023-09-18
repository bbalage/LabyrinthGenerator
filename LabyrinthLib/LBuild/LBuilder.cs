using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public interface LBuilder
    {
        LBuilder AddRoom(string roomName, int x, int y, int w, int h);

        LBuilder AddDoor(int x, int y, bool horizontal, string roomName1, string roomName2);
        LBuilder Connect(string roomName1, string roomName2);
        LBuilder PushConnectingStrategy(ConnectingStrategy roomConnectingStrategy);
        LBuilder PopConnectingStrategy();
        Labyrinth Build();
    }
}
