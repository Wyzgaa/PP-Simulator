using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {
        private int agility = 0;
        private int singCounter = 0;
        public int Agility
        {
            get => agility;
            init
            {
                if (value < 0) value = 0;
                else if (value > 10) value = 10;
                agility = value;
            }
        }
        public void Sing()
        {
            singCounter++;
            if (singCounter % 3 == 0 && agility<10) agility++;
        }
        public override int Power => 8 * Level + 2 * Agility;

        public Elf() { }
        public Elf(string name="Unknown", int level = 1, int agility = 0) : base(name, level)
        {
            Agility = agility;
        }
        public override string Greeting()
        {
            return ($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
        }
        public override string Info
        {
            get
            {
                return $"{Name} [{Level}][{Agility}]";
            }
        }
    }
}
