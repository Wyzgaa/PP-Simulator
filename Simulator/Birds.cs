using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Birds : Animals
{
    private bool canFly = true;
    public bool CanFly
    {
        get { return canFly; }
        init
        {
            value = canFly;
        }
    }
    private string CanFlyString 
    {
        get
        {
            if (canFly) return "fly+";
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
}
