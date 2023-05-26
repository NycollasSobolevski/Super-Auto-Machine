using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;

public abstract class Process
{
    public abstract string Title { get; }
}

public abstract class BattleProcess : Process 
{
    public abstract void Apply(BattleArgs args);
}

public abstract class PlayerProcess : Process
{
    public abstract void Apply(StoreArgs args);
}
public abstract class StoreProcess : Process
{
    public abstract void Apply(StoreArgs args, int gold = 0);
}
public abstract class EndStoreProcess : Process
{
    public abstract void Apply(StoreArgs args);
}

public abstract class GoldOnSaleProcess : StoreProcess
{
    public override void Apply(StoreArgs args, int gold=0)
        => args.Store.Money += gold;
}
public abstract class AddGoldProcess : StoreProcess
{
    public override void Apply(StoreArgs args, int gold = 0)
        => args.Store.Money += gold;
}

public abstract class OnHurt : BattleProcess
{
    public override void Apply(BattleArgs args)
    {
        Random rand= new();
        int index = rand.Next(args.Enemies.Count);

        args.Enemies[index].Atacked(args.Machine);
    }
}
public abstract class UpLifeAtackProcess : EndStoreProcess
{
    public override void Apply(StoreArgs args)
    {
        bool IsLevel3 = false;
        foreach (var machine in args.Machines)
            if (machine.Level == 3)
                IsLevel3 = true;

        args.Machine.UpLife(2);
        args.Machine.UpPower(2);
    }
}
