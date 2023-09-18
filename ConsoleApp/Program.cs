using LabyrinthLib.Drawer;
using LabyrinthLib.L;
using LabyrinthLib.LBuild;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LBuilder builder = new BlankLBuilder();
            Dictionary<RoomType, (Color, Color)> colorDict = new();
            colorDict.Add(RoomType.BLANK, (new Color { R = 255, G = 255, B = 255 }, new Color { R = 255, G = 255, B = 255 }));
            colorDict.Add(RoomType.FACTORY, (new Color { R = 122, G = 122, B = 122 }, new Color { R = 150, G = 150, B = 150 }));
            colorDict.Add(RoomType.SAWMILL, (new Color { R = 255, G = 100, B = 100 }, new Color { R = 255, G = 150, B = 150 }));
            colorDict.Add(RoomType.HOSPITAL, (new Color { R = 255, G = 255, B = 255 }, new Color { R = 255, G = 255, B = 255 }));
            LBuilder builder = new ColoredLBuilder(colorDict);
            //Labyrinth lab = builder.PushConnectingStrategy(new TouchingConnectingStrategy())
            //    .AddRoom("Room1", 0,0,5,5)
            //    .AddRoom("Room2", 5,0,10,10)
            //    .AddRoom("Room3", 0,-10,5,10)
            //    .Connect("Room1", "Room2")
            //    .Connect("Room1", "Room3")
            //    .Build();
            Labyrinth lab = builder.PushConnectingStrategy(new StraightCorridorConnectingStrategy())
                .AddRoom("Room1", 0, 0, 50, 50, RoomType.FACTORY)
                .AddRoom("Room2", 100, 0, 100, 100, RoomType.SAWMILL)
                .AddRoom("Room3", 0, -200, 50, 100, RoomType.SAWMILL)
                .AddRoom("Room4", 210, 25, 200, 50, RoomType.HOSPITAL)
                .AddRoom("Room5", 100, -150, 100, 50, RoomType.FACTORY)
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