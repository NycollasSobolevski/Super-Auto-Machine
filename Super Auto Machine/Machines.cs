using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Auto_Machine;
public class Machine
{
    public virtual int Life { get; set; }
    public int Level { get; set; }
    public int Exp { get; set; }
    public virtual int Tier { get; set; }
    public int Power { get; set; }
    public void Atack() { }

    public class MachineBuilder
    {
        private Machine machine = new Machine();
        public Machine Build()
        {
            
            return null;
        }
    }
}

public class Composite : Machine
{
    
}

public interface IBuilder
{
    
}


public class Hammer : Machine
{
    this.Life = 3;
    public override int Power { get; set; } = 2;
    public override int Level { get; set ; }
    public override int Exp { get ; set; }
    public override int Tier { get; set; } = 2;

    public override void Atack()
    {
        throw new NotImplementedException();
    }
}