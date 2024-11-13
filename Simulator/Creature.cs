using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public abstract class Creature
    {
        private string? name = "Unknown";
        private int level=1;
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
        public abstract string Greeting();

        public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

        public string[] Go(Direction[] directions)
        {
            string[] tab = new string[directions.Length];
            for (int i=0; i < directions.Length; i++)
            {
                tab[i] = Go(directions[i]);
            }
            return tab;
        }
        public string[] Go(string directions)
        {
            return Go(DirectionParser.Parse(directions));
        }
        public abstract int Power { get; }
        public abstract string Info { get; }
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}

