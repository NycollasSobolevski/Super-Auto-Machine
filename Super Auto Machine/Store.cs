using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;

public class Store
{
    private Store() { }
    private Store(List<Machine> machines, List<Machine> team)
    {
        this.Machines = machines;
        this.Team = team;
    }
    private static Store crr = new();
    public static Store Current => crr;

    public List<Machine> Machines { get; set; }
    public List<Machine> Team { get; set; }
    public List<Machine> Sales { get; set; }
    public int Money { get; set; } = 10;
    public void Buy(Machine buy)
    {
        if (Team.Count < 5 && Money>=3)
        {
            Team.Add(buy);
            Sales.Remove(buy);
            Money -= 3;
        }

    }
    public void Shuffle()
    {
        Sales.Clear();
        var rand = new Random();
        for (int i = 0; i < 5; i++)
        {
            Sales[i] = Machines[rand.Next(Machines.Count)];
        }
    }
       
    public static void New(List<Machine> machines, List<Machine> team)
        => crr = new Store(machines, team);
}