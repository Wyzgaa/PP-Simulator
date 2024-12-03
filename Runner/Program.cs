using Simulator.Maps;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace Simulator;

internal class Program
{
    static void Lab5a()
    {
        var a = new Rectangle(5, 7, 1, 2);
        Console.WriteLine(a.ToString());
        var b = new Rectangle(1, 7, 1, 2);
        var c = new Rectangle(5, 7, 1, 7);
        var d = new Rectangle(1, 2, 5, 4);
        Console.WriteLine(d.ToString());
        var p1 = new Point(1, 1);
        var p2 = new Point(1, 2);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);
        var e = new Rectangle(p1, p2);
        var f = new Rectangle(p3, p4);
        Console.WriteLine(f.ToString());
        var g = new Point(2, 5);
        var h = new Point(1, 8);
        var i = new Point(1, 1);
        var j = new Point(-1, 4);
        Console.WriteLine(f.Contains(g));
        Console.WriteLine(f.Contains(h));
        Console.WriteLine(f.Contains(i));
        Console.WriteLine(f.Contains(j));
    }
    static void Lab5b()
    {
        var a = new SmallSquareMap(10);

        try 
        { 
            var b = new SmallSquareMap(21); 
        }
        catch (Exception exept)
        { 
            Console.WriteLine($"{exept.Message}"); 
        }

        try
        {
            var c = new SmallSquareMap(4);
        }
        catch (Exception exe)
        {
            Console.WriteLine($"{exe.Message}");
        }

        Console.WriteLine(a.Exist(new Point(4, 4))); //T
        Console.WriteLine(a.Exist(new Point(10, 6))); //F
        Console.WriteLine(a.Exist(new Point(4, 10))); //F
        Console.WriteLine(a.Exist(new Point(1, 9))); //T
        Console.WriteLine(a.Exist(new Point(0, 8))); //T

        Console.WriteLine(a.Next(new Point(5, 5), Direction.Up));
        Console.WriteLine(a.Next(new Point(5, 5), Direction.Down));
        Console.WriteLine(a.Next(new Point(5, 5), Direction.Left)); 
        Console.WriteLine(a.Next(new Point(5, 5), Direction.Right));
        Console.WriteLine(a.Next(new Point(9, 9), Direction.Right));
        
        Console.WriteLine(a.NextDiagonal(new Point(5, 5), Direction.Left));
        Console.WriteLine(a.NextDiagonal(new Point(5, 5), Direction.Right));
    }
    //static void TestMapy()
    //{
    //    var mapa = new SmallSquareMap(10);
    //    var creature2 = new Orc("Mejoza");
    //    var creature1 = new Elf("Mitoza");
    //    var creature3 = new Elf("Git");
    //    var startPosition = new Point(1, 1);
    //    var startPosition2 = new Point(4, 4);
    //    var startPosition6 = new Point(5, 4);
    //    creature1.PlaceOnMap(mapa, startPosition);
    //    creature2.PlaceOnMap(mapa, startPosition);
    //    creature3.PlaceOnMap(mapa, startPosition2);
    //    List<Creature> creaturesAtPoint = mapa.At(startPosition);
    //    List<Creature> creaturesAtPoint3 = mapa.At(startPosition2);
        
    //    if (creaturesAtPoint.Count > 0)
    //    {
    //        Console.WriteLine("Stworzenia w punkcie:");
    //        foreach (var creature in creaturesAtPoint3)
    //        {
    //            Console.WriteLine(creature.Name);
    //        }
    //    }
    //    creature3.Go(Direction.Right);
    //    List<Creature> creaturesAtPoint4 = mapa.At(startPosition6);
    //    if (creaturesAtPoint.Count > 0)
    //    {
    //        Console.WriteLine("Stworzenia w punkcie:");
    //        foreach (var creature in creaturesAtPoint3)
    //        {
    //            Console.WriteLine(creature.Name);
    //        }
    //    }
    //    if (creaturesAtPoint.Count > 0)
    //    {
    //        Console.WriteLine("Stworzenia w punkcie:");
    //        foreach (var creature in creaturesAtPoint4)
    //        {
    //            Console.WriteLine(creature.Name);
    //        }
    //    }
    //    if (creaturesAtPoint.Count > 0)
    //    {
    //        Console.WriteLine("Stworzenia w punkcie:");
    //        foreach (var creature in creaturesAtPoint)
    //        {
    //            Console.WriteLine(creature.Name);
    //        }
    //    }
    //    creature1.Go(Direction.Right);
    //    Console.WriteLine(creature1.Position);//2,1
    //    var tempPoint = new Point(2, 1);
    //    List<Creature> creaturesAtPoint2 = mapa.At(tempPoint);
    //    if (creaturesAtPoint2.Count > 0)
    //    {
    //        Console.WriteLine("Stworzenia w punkcie:");
    //        foreach (var creature in creaturesAtPoint2)
    //        {
    //            Console.WriteLine(creature.Name);
    //        }
    //    }
    //}
    //static void SilulationTest()
    //{
    //    List<Creature> creatures = new List<Creature>() { new Elf("A"), new Elf("B"), new Elf("C"), new Elf("D")};
    //    SmallSquareMap mapa = new SmallSquareMap(10);
    //    var positions = new List<Point>() { new Point(1, 1), new Point(1, 2), new Point(1, 3), new Point(1, 4), };
    //    var simulation = new Simulation(mapa, creatures, positions, "rrdduull");
    //    while(!simulation.Finished)
    //    {
    //        simulation.Turn();
    //    }
    //}
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        //Point p = new(10, 25);
        //Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        //Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
        //zła nazwa ostatniego commita
        //Lab5a();
        //Lab5b();
        //TestMapy();
        //SilulationTest();
    }
}
