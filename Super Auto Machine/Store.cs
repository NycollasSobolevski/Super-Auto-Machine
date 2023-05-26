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

    private static Store crr = new();
    public static Store Current => crr;
    public List<Machine> Sales { get; set; }
    public int Money { get; set; } = 10;
    public void Buy(Machine buy)
    {
        if (Player.Team.Count < 5 && Money>=3)
        {
            Player.Team.Add(buy);
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
            Sales[i] = Machine.Machines[rand.Next(Machine.Machines.Count)];
        }
    }
    public void OpenStore()
    {
        Shuffle();
        foreach(Machine m in Player.Team)
        {
            m.StoreHability(Current);
        }
    }
    public void UpgradeMachine(Machine selected, Machine selected2)
    {
        if (selected.GetType() == selected2.GetType())
        {
            selected.UP(selected2);
        }
    }
    public void Sell(Machine selected)
    {
        Player.Team.Remove(selected);
        Money-= selected.Level;
        selected.SaleHability(Current);
    }
    public static void New()
        => crr = new Store();
}