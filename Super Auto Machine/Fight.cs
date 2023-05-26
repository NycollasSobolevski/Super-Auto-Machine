using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;

public class Fight
{
    private Fight() {}

    private static Fight crr = new Fight();
    public static Fight Current => crr;

    public List<Machine> MyMachines {get;set;} = Player.Team.ToList();
    public List<Machine> EnemieMachines { get; set; } = Player.Enemy.ToList();
    

    public void VerifyMachine(Machine mymachine, Machine enemiemachine){
        if(!enemiemachine.IsAlive())
            EnemieMachines.RemoveAt(0);

        if(!mymachine.IsAlive())
            MyMachines.RemoveAt(0);
    }


    public int FightTurn(){
        while(true){
            if(MyMachines.Count == 0 && EnemieMachines.Count == 0){
                return 0;
            }
            else if(EnemieMachines.Count == 0){
                return 1;
            }
            else if(MyMachines.Count == 0){
                return 2;
            }


            MyMachines[0].Atacked(EnemieMachines[0]);
            EnemieMachines[0].Atacked(MyMachines[0]);
            MyMachines[0].DamageHability(Player.Enemy);

            VerifyMachine(MyMachines[0],EnemieMachines[0]);
            Thread.Sleep(3000);
        }
    }


    public static void New() 
        => crr = new Fight();

}