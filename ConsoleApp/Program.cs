using LabyrinthLib.Drawer;
using LabyrinthLib.L;

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
            labyrinth.addDoor(new Door(5, 1, 1, 1, 0, 1));
            LabyrinthDrawer drawer = new BitmapLDrawer();
            drawer.Draw(labyrinth);
        }
    }
}