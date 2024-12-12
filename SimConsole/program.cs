using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class program
{
    public void PoprzednieTesty()
    {
        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals("Mamut", 30), new Birds("Orzeł", 10), new Birds("Pingwin", 20, false)];
        List<Point> points = [new(2, 3), new(3, 3), new(1, 1), new(0, 0), new(1, 2)];
        string moves = "rrufdrurudrl";
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);


        Console.WriteLine("Starting Positions: ");
        mapVisualizer.Draw();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        Animals Mamuty = new Animals("Mamut", 50);
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        BigBounceMap map = new(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals("Królik", 30), new Birds("Orzeł", 5), new Birds("Struś", 10, false)];
        List<Point> points = [new(2, 3), new(7, 3), new(1, 1), new(5, 5), new(7, 0)];
        string moves = "rrufdrurudrl";
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        mapVisualizer.Draw();
        while (!simulation.Finished)
        {
            Console.WriteLine($"Turn {simulation.CurrentMoveIndex + 1}");
            Console.WriteLine($"{simulation.CurrentMappable.GetType().Name.ToUpper()}: {simulation.CurrentMappable.Info} " +
                $"({simulation.CurrentMappable.Position.X}, " + $"{simulation.CurrentMappable.Position.Y}) goes {simulation.CurrentMoveName}:");
            simulation.Turn();
            
            mapVisualizer.Draw();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
        }
    }
}
