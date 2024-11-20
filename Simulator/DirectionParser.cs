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
        public static List<Direction> Parse(string directions) 
        {
            int tablesize = 0;
            foreach (char a in directions.ToLower())
            {
                if (a == 'u' ||  a == 'd' || a=='l' || a=='r')
                    tablesize++;
            }
            var result = new List<Direction>();
            int counter = 0;
            for (int i = 0; i<directions.Length; i++)
            {
                switch (char.ToLower(directions[i]))
                {
                    case 'u':
                        result.Add(Direction.Up);
                        counter++;
                        break;

                    case 'd':
                        result.Add(Direction.Down);
                        counter++;
                        break;

                    case 'l':
                        result.Add(Direction.Left);
                        counter++;
                        break;

                    case 'r':
                        result.Add(Direction.Right);
                        counter++;
                        break;
                }
            }
            return result;
        }
    }
}
