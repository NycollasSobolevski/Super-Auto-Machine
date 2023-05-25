using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;
public class Machine
{
    public virtual int Life { get; set; }
    public virtual int Level { get; set; }
    public virtual int Exp { get; set; }
    public virtual int Tier { get; set; }
    public virtual int Power { get; set; }

    public virtual void UP(Machine machine) { }
    public virtual void Atacked(Machine machine) { }

}

public class Hammer : Machine
{
    public override int Life { get; set; } = 3;
    public override int Power { get; set; } = 2;
    public override int Level { get; set ; }
    public override int Exp { get; set; } = 0;
    public override int Tier { get; set; }

    public override void UP(Machine hammer) 
    {
        this.Life = (Math.Max(this.Life, hammer.Life)) + 1;
        this.Power = (Math.Max(this.Power, hammer.Power)) + 1;
        this.Exp += hammer.Exp;
    }
    public override void Atacked(Machine machine)
        => this.Life -= machine.Power
}