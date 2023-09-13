using LabyrinthLib.Drawer;
using LabyrinthLib.L;
using LabyrinthLib.LVis;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Labyrinth labyrinth = new Labyrinth();
            labyrinth.addRoom(new Room(0, 0, 5, 5));
            labyrinth.addRoom(new Room(10, 0, 5, 10));
            labyrinth.addRoom(new Room(0, 10, 8, 3));
            labyrinth.addRoom(new Room(-10, -5, 8, 4));
            RenderLVisitor visitor = new BlankRenderLVisitor();
            LabyrinthDrawer drawer = new CharacterLDrawer(visitor);
            drawer.Draw(labyrinth);
        }
    }
}