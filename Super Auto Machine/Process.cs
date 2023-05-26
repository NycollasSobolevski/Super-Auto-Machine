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
    public abstract void Apply(StoreArgs args);
}

public abstract class PlayerProcess : Process
{
    public abstract void Apply(StoreArgs args);
}
public abstract class StoreProcess : Process
{
    public abstract void Apply(StoreArgs args, int gold = 0);
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
        rand.Next(args.Enemies.Count);

        //AQUI
    }
}