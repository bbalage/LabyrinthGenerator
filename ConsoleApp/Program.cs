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
            Labyrinth lab = builder.SetRoomConnectingStrategy(new TouchingRoomConnectingStrategy())
                .AddRoom("Room1", 0,0,5,5)
                .AddRoom("Room2", 5,0,10,10)
                .AddRoom("Room3", 0,-10,5,10)
                .ConnectRooms("Room1", "Room2")
                .ConnectRooms("Room1", "Room3")
                .Build();
            LabyrinthDrawer drawer = new BitmapLDrawer();
            // LabyrinthDrawer drawer = new CharacterLDrawer();
            drawer.Draw(lab);
        }
    }
}