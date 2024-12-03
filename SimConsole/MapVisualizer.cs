using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    public Map Map { get; }
    private int size;
    public MapVisualizer(Map map)
    {
        Map = map;
    }
    public void Draw()
    {
        Console.Write(Box.TopLeft);
        for (int i = 0; i < Map.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.TopMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.TopRight);
        Console.WriteLine();

        for (int y = Map.SizeY - 1; y >= 0; y--)
        {
            DrawCreatureRow(y);
            if (y > 0)
                DrawMiddleRow();
        }

        Console.Write(Box.BottomLeft);
        for (int i = 0; i < Map.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.BottomMid);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.BottomRight);
        Console.WriteLine();
    }
    private void DrawCreatureRow(int y)
    {
        Console.Write(Box.Vertical);
        for (int x = 0; x < Map.SizeX; x++)
        {
            Console.Write(GetCreatureSymbol(new Point(x, y)));
            Console.Write(Box.Vertical);
        }
        Console.WriteLine();
    }

    private void DrawMiddleRow()
    {
        Console.Write(Box.MidLeft);
        for (int i = 0; i < Map.SizeX - 1; i++)
        {
            Console.Write(Box.Horizontal);
            Console.Write(Box.Cross);
        }
        Console.Write(Box.Horizontal);
        Console.Write(Box.MidRight);
        Console.WriteLine();
    }

    private char GetCreatureSymbol(Point p)
    {
        var creatures = Map.At(p);

        if (creatures == null || creatures.Count == 0)
        {
            return ' '; 
        }
        else if (creatures.Count == 1)
        {
            var creature = creatures[0];
            return creature.Symbol;
        }
        return 'X'; 
    }
}
