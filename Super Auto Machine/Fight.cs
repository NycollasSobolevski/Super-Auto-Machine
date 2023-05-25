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
    private Fight(List<Machine> mymachines, List<Machine> enemiemachines)
    {
        this.MyMachines = mymachines; 
        this.EnemieMachines = enemiemachines;
    }

    private static Fight crr = new Fight();
    public static Fight Current => crr;

    public List<Machine> MyMachines {get;set;}
    public List<Machine> EnemieMachines {get;set;}
    

    public void VerifyMachine(Machine mymachine, Machine enemiemachine){
        if(enemiemachine.Life <= 0){
            EnemieMachines.RemoveAt(0);
        }
        else if(mymachine.Life <= 0){
            MyMachines.RemoveAt(0);
        }
    }


    public void FightTurn(){
        while(MyMachines != null || EnemieMachines != null){
            VerifyMachine(MyMachines[0],EnemieMachines[0]);
            MyMachines[0].Atacked(EnemieMachines[0]);
            EnemieMachines[0].Atacked(MyMachines[0]);
            Thread.Sleep(3000);
        }
    }

    public static void New() => crr = new Fight();
    public static void New(List<Machine> mymachines, List<Machine> enemiemachines) => crr = new Fight(mymachines,enemiemachines);

}