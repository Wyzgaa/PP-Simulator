using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Simulator;

public class Birds : Animals
{
    private bool canFly = true;
    public override char Symbol { get; }
    public bool CanFly { get; set; } = true;
    private string CanFlyString 
    {
        get
        {
            if (CanFly) return "fly+";
            else return "fly-";
        }
    }
    public override string Info
    {
        get
        {
            return $"{Description} ({CanFlyString})[{Size}]";
        }
    }
    public Birds(string descpription, uint size, bool canfly=true) :base(descpription, size)
    {
        Description = descpription;
        Size = size;
        CanFly = canfly;
        if(CanFly==false)
        {
            Symbol = 'b';
        }
        else
        {
            Symbol = 'B';
        }
    }
    public override void Go(Direction direction)
    {
        if (Map == null)
            throw new ArgumentNullException("Animal is not on the map");
        if (CanFly)
        {
            Point Temp = Map.Next(Position, direction);
            if (Temp.Equals(Position))
                return;
            Map.Move(this, Position, Temp);
            Position = Temp;
        }
        else
        {
            Point Temp = Map.NextDiagonal(Position, direction);
            if (Temp.Equals(Position))
                return;
            Map.Move(this, Position, Temp);
            Position = Temp;
        }
    }
}
