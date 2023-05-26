using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

using Super_Auto_Machine;

public class Player
{
    public int Hearts {get;set;}
    public int Trophies {get;set;}
    public int Levels {get;set;}
    public static List<Machine> Team { get;set;} = new List<Machine>();
    public static List<Machine> Enemy { get; set; } = new List<Machine>();

    public Player(int Hearts, int Trophies, int levels)
    {
        this.Hearts = Hearts;
        this.Trophies = Trophies;
        this.Levels = levels;
    }
}