using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthLib.L
{
    public interface LIterator
    {
        bool Next();
        LObject Get();
    }
}
