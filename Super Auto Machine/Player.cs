using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public int Hearts {get;set;}
    public int Trophies {get;set;}
    public int Levels {get;set;}

    public Player(int Hearts, int Trophies, int levels){
        this.Hearts = Hearts;
        this.Trophies = Trophies;
        this.Levels = levels;
    }
}