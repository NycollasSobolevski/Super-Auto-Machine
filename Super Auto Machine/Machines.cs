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

    public virtual void UP(Machine machine)
    {
        if (this.Level >= 3)
            return;

        this.Life = (Math.Max(this.Life, machine.Life)) + 1;
        this.Power = (Math.Max(this.Power, machine.Power)) + 1;
        this.Level = this.Exp / 3;
        this.Exp += machine.Exp;
    }
    public virtual void Atacked(Machine machine) => this.Life -= machine.Power;

    public virtual int getValue() => this.Tier;

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

}

public class Screwdriver : Machine
{
    public override int Life { get; protected set; } = 3;
    public override int Power { get; protected set; } = 2;
    public override int Tier { get; protected set; } = 1;

    public Screwdriver()
    {
        if (!Machines.Any(x => x.GetType() == typeof(Screwdriver)))
        {
            Machines.Add(new Screwdriver());
        }
    }
}

public class Belt : Machine
{
    public override int Life {  get; protected set; } 
    public override int Tier { get; protected set; } 
    public override int Power {  get; protected set; }
    public Belt()
    {
        if (!Machines.Any(x => x.GetType() == typeof(Belt)))
        {
            Machines.Add(new Belt());
        }
    }
}


public class ColumnDrill : Machine
{
    public override int Life { get; protected set; } = 5;
    public override int Tier { get; protected set; } = 2;
    public override int Power { get; protected set; } = 3;

    public ColumnDrill()
    {
        if (!Machines.Any(x => x.GetType() == typeof(ColumnDrill)))
        {
            Machines.Add(new ColumnDrill());
        }
    }
    public override int getValue() => this.Tier;
}

public class IndustrialGasOver : Machine
{
    public override int Life { get; protected set; } = 3;
    public override int Tier { get; protected set; } = 2;
    public override int Power { get; protected set; } = 1;

    public override int getValue() => this.Tier;
    public IndustrialGasOver()
    {
        if (!Machines.Any(x => x.GetType() == typeof(IndustrialGasOver)))
        {
            Machines.Add(new IndustrialGasOver());
        }
    }
}

public class FlatGrinder : Machine
{
    public override int Life { get; protected set; } = 4;
    public override int Tier { get; protected set; } = 2;
    public override int Power { get; protected set; } = 2;

    public override int getValue() => this.Tier;
    public FlatGrinder()
    {
        if (!Machines.Any(x => x.GetType() == typeof(FlatGrinder)))
        {
            Machines.Add(new FlatGrinder());
        }
    }
}


public class CooredenateDrill : Machine
{
    public override int Life { get; protected set; } = 3;
    public override int Tier { get; protected set; } = 3;
    public override int Power { get; protected set; } = 5;

    public override int getValue() => this.Tier;
    public CooredenateDrill()
    {
        if (!Machines.Any(x => x.GetType() == typeof(CooredenateDrill)))
        {
            Machines.Add(new CooredenateDrill());
        }
    }
}

public class IndustrialEletricOver : Machine
{
    public override int Life { get; protected set; } = 4;
    public override int Tier { get; protected set; } = 3;
    public override int Power { get; protected set; } = 3;

    public override int getValue() => this.Tier;
    public IndustrialEletricOver()
    {
        if (!Machines.Any(x => x.GetType() == typeof(IndustrialEletricOver)))
        {
            Machines.Add(new IndustrialEletricOver());
        }
    }
}

public class CylindricalGrinder : Machine
{
    public override int Life { get; protected set; } = 2;
    public override int Tier { get; protected set; } = 3;
    public override int Power { get; protected set; } = 6;

    public override int getValue() => this.Tier;
    public CylindricalGrinder()
    {
        if (!Machines.Any(x => x.GetType() == typeof(CylindricalGrinder)))
        {
            Machines.Add(new CylindricalGrinder());
        }
    }
}


public class MillingCutter : Machine
{
    public override int Life { get; protected set; } = 4;
    public override int Tier { get; protected set; } = 3;
    public override int Power { get; protected set; } = 5;

    public override int getValue() => this.Tier;
    public MillingCutter()
    {
        if (!Machines.Any(x => x.GetType() == typeof(MillingCutter)))
        {
            Machines.Add(new MillingCutter());
        }
    }
}
public class Lathe : Machine
{
    public override int Life { get; protected set; } = 5;
    public override int Tier { get; protected set; } = 4;
    public override int Power { get; protected set; } = 3;

    public override int getValue() => this.Tier;
    public Lathe()
    {
        if (!Machines.Any(x => x.GetType() == typeof(Lathe)))
        {
            Machines.Add(new Lathe());
        }
    }
}
public class CNCLathe : Machine
{
    public override int Life { get; protected set; } = 5;
    public override int Tier { get; protected set; } = 5;
    public override int Power { get; protected set; } = 8;

    public override int getValue() => this.Tier;
    public CNCLathe()
    {
        if (!Machines.Any(x => x.GetType() == typeof(CNCLathe)))
        {
            Machines.Add(new CNCLathe());
        }
    }
}
public class CNCMillingCutter : Machine
{
    public override int Life { get; protected set; } = 8;
    public override int Tier { get; protected set; } = 5;
    public override int Power { get; protected set; } = 4;

    public override int getValue() => this.Tier;
    public CNCMillingCutter()
    {
        if (!Machines.Any(x => x.GetType() == typeof(CNCMillingCutter)))
        {
            Machines.Add(new CNCMillingCutter());
        }
    }
}
public class CNCPlasmaCutting : Machine
{
    public override int Life { get; protected set; } = 6;
    public override int Tier { get; protected set; } = 6;
    public override int Power { get; protected set; } = 8;

    public override int getValue() => this.Tier;
    public CNCPlasmaCutting()
    {
        if (!Machines.Any(x => x.GetType() == typeof(CNCPlasmaCutting)))
        {
            Machines.Add(new CNCPlasmaCutting());
        }
    }
}