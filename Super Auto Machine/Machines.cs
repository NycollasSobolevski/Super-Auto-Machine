using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;
public abstract class Machine
{
    public abstract int Life { get; set; }
    public abstract int Level { get; set; }
    public abstract int Exp { get; set; }
    public abstract int Tier { get; set; }
    public abstract int Power { get; set; }
    public abstract void Atack();
}

public interface IBuilder
{
    
}


public class Hammer : Machine
{
    public override int Life { get; set; } = 3;
    public override int Power { get; set; } = 2;
    public override int Level { get; set ; }
    public override int Exp { get ; set; }
    public override int Tier { get; set ; }

    public override void Atack()
    {
        throw new NotImplementedException();
    }
}