using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class ManeuveringField : Field
    {
        public override String Print()
        {
            return "_";
        }

        public override bool Move(MoveAble moveAble)
        {
            if (MoveAble == null)
            {
                MoveAble = moveAble;
            }
            return true;
        }
    }
}