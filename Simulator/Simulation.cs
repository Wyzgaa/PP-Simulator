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
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }
    private List<Direction> ListOfMoves;

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    private int CurrentCreatureIndex = 0;
    public Creature CurrentCreature { get { return Creatures[CurrentCreatureIndex % Creatures.Count()]; } }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public int CurrentMoveIndex = 0;
    public string CurrentMoveName { get { return ListOfMoves[CurrentMoveIndex].ToString().ToLower();  } }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    { 
        Map = map;
        Creatures = creatures;
        Positions = positions;
        ListOfMoves = DirectionParser.Parse(moves);
        for (int i=0;i<Creatures.Count();i++)
        {
            Creatures[i].PlaceOnMap(Map, Positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() 
    {
        if (Finished) return;
        CurrentCreature.Go(ListOfMoves[CurrentMoveIndex]);
        CurrentCreatureIndex++;
        CurrentMoveIndex++;
        if(CurrentMoveIndex==ListOfMoves.Count())
            Finished = true;
    }
}
