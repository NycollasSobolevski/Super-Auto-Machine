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
    public static int Hearts { get; set; } = 5;
    public static int Trophies { get; set; } = 0;
    public static int Round { get; set; } = 0;
    public static List<Machine> Team { get;set;} = new List<Machine>();
    public static List<Machine> Enemy { get; set; } = new List<Machine>();

}