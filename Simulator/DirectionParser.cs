using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class DirectionParser
    {
        public static Direction[] Parse(string directions) 
        {
            int tablesize = 0;
            foreach (char a in directions.ToLower())
            {
                if (a == 'u' ||  a == 'd' || a=='l' || a=='r')
                    tablesize++;
            }
            Direction[] result = new Direction[tablesize];
            int counter = 0;
            for (int i = 0; i<directions.Length; i++)
            {
                switch (char.ToLower(directions[i]))
                {
                    case 'u':
                        result[counter] = Direction.Up;
                        counter++;
                        break;

                    case 'd':
                        result[counter] = Direction.Down;
                        counter++;
                        break;

                    case 'l':
                        result[counter] = Direction.Left;
                        counter++;
                        break;

                    case 'r':
                        result[counter] = Direction.Right;
                        counter++;
                        break;
                }
            }
            return result;
        }
    }
}
