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
    public abstract void Apply(StoreArgs args);
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
public abstract class AddLifeInStoreProcess : StoreProcess
{
    public override void Apply(StoreArgs args)
    {
        foreach (var machine in args.Store.Sales)
            machine.UpLife(1);
    }
}
public abstract class AddLifeRandTeamProcess : StoreProcess
{
    public override void Apply(StoreArgs args)
    {
        Random rand = new();
        int index = rand.Next(args.Machines.Count);
        args.Machines[index].UpLife(1);
    }
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
public abstract class OnDied : BattleProcess
{
    public override void Apply(BattleArgs args)
    {
        Random rand = new();
        int index = rand.Next(args.Allies.Count);
        args.Allies[index].UpLife(1);
        args.Allies[index].UpPower(2);
    }
}