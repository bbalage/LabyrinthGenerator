using LabyrinthLib.Drawer;
using LabyrinthLib.L;
using LabyrinthLib.LBuild;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // LBuilder builder = new BlankLBuilder();
            Dictionary<RoomType, (Color, Color)> colorDict = new();
            colorDict.Add(RoomType.BLANK, (new Color { R = 255, G = 255, B = 255 }, new Color { R = 255, G = 255, B = 255 }));
            colorDict.Add(RoomType.FACTORY, (new Color { R = 122, G = 122, B = 122 }, new Color { R = 150, G = 150, B = 150 }));
            colorDict.Add(RoomType.SAWMILL, (new Color { R = 255, G = 100, B = 100 }, new Color { R = 255, G = 150, B = 150 }));
            colorDict.Add(RoomType.HOSPITAL, (new Color { R = 255, G = 255, B = 255 }, new Color { R = 255, G = 255, B = 255 }));
            LBuilder builder = new ColoredLBuilder(colorDict);
            ConnectingStrategy connectingStrategy = new StraightCorridorConnectingStrategy();
            // ConnectingStrategy connectingStrategy = new TouchingConnectingStrategy();
            //Labyrinth lab = builder.PushConnectingStrategy(connectingStrategy)
            //    .AddRoom("Room1", 0, 0, 50, 50, RoomType.FACTORY)
            //    .AddRoom("Room2", 100, 0, 100, 100, RoomType.SAWMILL)
            //    .AddRoom("Room3", 0, -200, 50, 100, RoomType.SAWMILL)
            //    .AddRoom("Room4", 210, 25, 200, 50, RoomType.HOSPITAL)
            //    .AddRoom("Room5", 100, -150, 100, 50, RoomType.FACTORY)
            //    .Connect("Room1", "Room2")
            //    .Connect("Room1", "Room3")
            //    .Connect("Room2", "Room4")
            //    .Connect("Room3", "Room5")

            //    .Connect("Room2", "Room5")
            //    .Build();
            Labyrinth lab = builder.PushConnectingStrategy(connectingStrategy)
                .AddRoom("Room1", 0, 0, 25, 25, RoomType.FACTORY)
                .AddRoom("Room2", 40, 0, 10, 20, RoomType.SAWMILL)
                .AddRoom("Room3", 0, -30, 30, 15, RoomType.SAWMILL)
                .Connect("Room1", "Room2")
                .Connect("Room1", "Room3")
                .Build();
            LIterator iterator = new AllLIterator(lab);
            // LIterator iterator = new NeighborLIterator(lab, new Vec2 { X = 50, Y = 50});
            LabyrinthDrawer drawer = new BitmapLDrawer(iterator);
            LabyrinthDrawer drawer2 = new CharacterLDrawer(iterator);
            drawer.Draw(lab);
            drawer2.Draw(lab);
        }
    }
}