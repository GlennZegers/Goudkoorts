using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class EndManeuveringField : Field
    {
        public override void Move(MoveAble moveAble)
        {
            return;
        }

        public override string Print()
        {
            return " ";
        }
    }
}
