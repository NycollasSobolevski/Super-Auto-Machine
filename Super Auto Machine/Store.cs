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
    private Store(string text)
        => this.SomeProperty = text;
    private static Store crr = new Store();
    public static Store Current => crr;

    public List<Machine> Team { get; set; }
    public List<Machine> Random { get; set; }
    public int OtherProperty { get; set; }
    public void Buy(Machine buy)
    {
        if (Team.Count() < 5)
        {
            Team.Add(buy);
        }
    }
    public static void New()
        => crr = new Store();
    public static void New(string text)
        => crr = new Store(text);
}