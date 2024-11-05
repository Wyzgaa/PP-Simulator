using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {
        private int rage=0;
        private int rageCounter = 0;
        public int Rage 
        {
            get => rage;
            init
            {
                if (value < 0) value = 0;
                else if (value > 10) value = 10;
                rage = value;
            }
        }
        
        public void Hunt()
        {
            Console.WriteLine($"{Name} is hunting.");
            rageCounter++;
            if (rageCounter % 3 == 0 && rage<10) rage++;
        }
        public override int Power => 7 * Level + 3 * Rage;
        public Orc() { }
        public Orc(string name="Unknown", int level = 1, int rage = 0) : base(name, level)
        {
            Rage = rage;
        }
        public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }
}
