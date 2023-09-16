using LabyrinthLib.Drawer;
using LabyrinthLib.L;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Labyrinth labyrinth = new Labyrinth();
            labyrinth.addRoom(new Room(0, 0, 5, 5), "Room1");
            labyrinth.addRoom(new Room(10, 0, 5, 10), "Room2");
            labyrinth.addRoom(new Room(0, 10, 8, 3), "Room3");
            labyrinth.addRoom(new Room(-10, -5, 8, 4), "Room4");
            LabyrinthDrawer drawer = new BitmapLDrawer();
            // LabyrinthDrawer drawer = new CharacterLDrawer();
            drawer.Draw(labyrinth);
        }
    }
}