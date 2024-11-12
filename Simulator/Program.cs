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
        var p1= new Point(1, 1);
        var p2 = new Point(1, 2);
        var p3 = new Point(1, 1);
        var p4 = new Point(5, 5);
        var e = new Rectangle(p1, p2);
        var f = new Rectangle(p3, p4);
        Console.WriteLine(f.ToString());
        var g = new Point(2, 5);
        var h = new Point(1,8);
        var i = new Point(1,1);
        var j = new Point(-1,4);
        Console.WriteLine(f.Contains(g));
        Console.WriteLine(f.Contains(h));
        Console.WriteLine(f.Contains(i));
        Console.WriteLine(f.Contains(j));
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        //Point p = new(10, 25);
        //Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        //Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)


        Lab5a();
    }
}
