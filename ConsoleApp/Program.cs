using LabyrinthLib.Drawer;
using LabyrinthLib.L;
using LabyrinthLib.LBuild;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LBuilder builder = new BlankLBuilder();
            //Labyrinth lab = builder.PushConnectingStrategy(new TouchingConnectingStrategy())
            //    .AddRoom("Room1", 0,0,5,5)
            //    .AddRoom("Room2", 5,0,10,10)
            //    .AddRoom("Room3", 0,-10,5,10)
            //    .Connect("Room1", "Room2")
            //    .Connect("Room1", "Room3")
            //    .Build();
            Labyrinth lab = builder.PushConnectingStrategy(new StraightCorridorConnectingStrategy())
                .AddRoom("Room1", 0, 0, 50, 50)
                .AddRoom("Room2", 100, 0, 100, 100)
                .AddRoom("Room3", 0, -200, 50, 100)
                .AddRoom("Room4", 210, 25, 200, 50)
                .AddRoom("Room5", 100, -150, 100, 50)
                .Connect("Room1", "Room2")
                .Connect("Room1", "Room3")
                .Connect("Room2", "Room4")
                .Connect("Room3", "Room5")
                .Connect("Room2", "Room5")
                .Build();
            LabyrinthDrawer drawer = new BitmapLDrawer();
            // LabyrinthDrawer drawer2 = new CharacterLDrawer();
            drawer.Draw(lab);
            // drawer2.Draw(lab);
        }
    }
}