using LabyrinthLib.L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.LBuild
{
    public interface ConnectingStrategy
    {
        public abstract void Connect(LBuilder builder, Labyrinth labyrinth, string roomName1, string roomName2);
    }
}
