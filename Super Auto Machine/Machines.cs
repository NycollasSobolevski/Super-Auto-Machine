using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;



public abstract class Machine
{
    public static List<Machine> Machines { get; set; }
    public abstract int Life { get; protected set; }
    public int Level { get; protected set; } = 0;
    public int Exp { get; protected set; } = 1;
    public abstract int Tier { get; protected set; }
    public abstract int Power { get; protected set; }

    public abstract void UP(Machine machine);
    public abstract void Atacked(Machine machine);

}

public class Hammer : Machine
{
    public override int Life { get; protected set; } = 3;
    public override int Power { get; protected set; } = 2;
    public override int Tier { get; protected set; } = 1;

    public Hammer()
    {
        if (!Machines.Any(x => x.GetType() == typeof(Hammer)))
        {
            Machines.Add(new Hammer());
        }
    }

    public override void UP(Machine hammer) 
    {
        if (this.Level >= 3)
            return;

        this.Life = (Math.Max(this.Life, hammer.Life)) + 1;
        this.Power = (Math.Max(this.Power, hammer.Power)) + 1;
        this.Level = this.Exp / 3;
        this.Exp += hammer.Exp;
    }
    public override void Atacked(Machine machine)
        => this.Life -= machine.Power;
}

public class Screwdriver : Machine
{
    public override int Life { get; protected set; }
    public override int Tier { get ; protected set ; }
    public override int Power { get ; protected set ; }

    public override void Atacked(Machine machine) => this.Life -= machine.Power;

    public override void UP(Machine machine)
    {
        if (this.Level >= 3)
            return;

        this.Life = (Math.Max(this.Life, machine.Life)) + 1;
        this.Power = (Math.Max(this.Power, machine.Power)) + 1;
        this.Level = this.Exp / 3;
        this.Exp += machine.Exp;
    }
}
