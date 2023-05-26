using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;

public class ProcessArgs
{
    private static ProcessArgs empty = new();
    public static ProcessArgs Empty => empty;
}

public class StoreArgs : ProcessArgs
{
    public List<Machine> Machines{ get; set; }
    public Store Store { get; set; }
    public Machine Machine { get; set; }
}

public class PlayerArgs : ProcessArgs
{
    public Player Player { get; set; }
    public Machine Machine { get; set; }
}

public class BattleArgs : ProcessArgs
{
    public Machine Machine { get; set; }
    public List<Machine> Enemies { get; set; }
}
