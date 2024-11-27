using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }
    private List<Direction> ListOfMoves;

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    private int CurrentMappableIndex = 0;
    public IMappable CurrentMappable { get { return Mappables[CurrentMappableIndex % Mappables.Count()]; } }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public int CurrentMoveIndex = 0;
    public string CurrentMoveName { get { return ListOfMoves[CurrentMoveIndex].ToString().ToLower();  } }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    { 
        Map = map;
        Mappables = mappables;
        Positions = positions;
        ListOfMoves = DirectionParser.Parse(moves);
        for (int i=0;i<Mappables.Count();i++)
        {
            Mappables[i].PlaceOnMap(Map, Positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished) return;
        CurrentMappable.Go(ListOfMoves[CurrentMoveIndex]);
        CurrentMappableIndex++;
        CurrentMoveIndex++;
        if(CurrentMoveIndex==ListOfMoves.Count())
            Finished = true;
    }
}
