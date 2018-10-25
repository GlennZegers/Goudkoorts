using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class EndField : Field
    {
        public override bool Move(MoveAble moveAble)
        {
            moveAble.CurrentField.MoveAble = null;
            moveAble.CurrentField = null;
            moveAble = null;
            return true;
        }
    }
}