using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class EndManeuveringField : Field
    {
        public override bool Move(MoveAble moveAble)
        {
            return true;
        }

        public override string Print()
        {
            return " ";
        }
    }
}
