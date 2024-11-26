using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature
    {
        private string? name = "Unknown";
        private int level=1;
        public Map? Map { get; private set; }
        public Point Position { get; private set; }
        public string? Name
        {
            get
            {
                return name;
            }
            init
            {
                if (value == null) { return;}
                name = Validator.Shortener(value,3,25,'#');
            }
        }
        public int Level
        {
            get => level;
            init
            {
                level = Validator.Limiter(value,1,10);
            }
        }
        public void Upgrade()
        {
            if(level <10)
            {
                level++;
            }
        }
        public Creature() { }

        public Creature(string name, int level=1)
        {
            Name=name;
            Level = level;
        }
        public void PlaceOnMap(Map map, Point p)
        {
            Map = map;
            Position = p;
            map.Add(this, p);
        }
        public abstract string Greeting();

        public void Go(Direction direction)
        {
            if (Map == null)
                throw new ArgumentNullException("Creature is not on the map");
            Point Temp = Map.Next(Position, direction);
            if(Temp.Equals(Position))
                return;
            Position = Temp;
            Map.Move(this, Position, Temp);
        }


        public abstract int Power { get; }
        public abstract string Info { get; }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}

