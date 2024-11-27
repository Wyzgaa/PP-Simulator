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
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 3), new(3, 3)];
        string moves = "rrufdru";
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);


        Console.WriteLine("Starting Positions: ");
        mapVisualizer.Draw();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();

        while (!simulation.Finished)
        {
            Console.WriteLine($"Turn {simulation.CurrentMoveIndex + 1}");
            Console.WriteLine($"{simulation.CurrentCreature.GetType().Name.ToUpper()}: { simulation.CurrentCreature.Info } ({simulation.CurrentCreature.Position.X}, " +
                $"{simulation.CurrentCreature.Position.Y}) goes {simulation.CurrentMoveName}:");
            simulation.Turn();
            
            mapVisualizer.Draw();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.WriteLine();
        }
    }
}
