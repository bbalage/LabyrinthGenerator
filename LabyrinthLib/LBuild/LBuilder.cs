using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    interface LBuilder
    {
        LBuilder addRoom(string roomName, int x, int y, int w, int h);
        LBuilder connectRooms(string roomName1, string roomName2); // TODO: Room connecting strategy
        Labyrinth build();
    }
}
