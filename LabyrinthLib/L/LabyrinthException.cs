using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    class LabyrinthException : Exception
    {
        public LabyrinthException(string message) : base(message)
        {
        }
    }
}
