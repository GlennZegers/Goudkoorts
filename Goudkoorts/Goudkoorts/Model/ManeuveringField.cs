using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class ManeuveringField : Field
    {
        public bool IsLast { get; set; }

        public override String Print()
        {
            return "_";
        }

        public override void Move(MoveAble moveAble)
        {
            if (MoveAble != null || IsLast)
            {
                return;
            }

            MoveAble = moveAble;
        }
    }
}