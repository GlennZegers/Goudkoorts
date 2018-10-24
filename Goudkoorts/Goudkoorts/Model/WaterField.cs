using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class WaterField : Field
    {
        public Quay LowerField { get; set;}

        public override string Print()
        {
            if(MoveAble != null)
            {
                return MoveAble.Print();
            }
            return "~";
        }

        public override bool Move(MoveAble moveAble)
        {
            if (MoveAble != null)
            {
                return;
            }

            if (LowerField != null)
            {
                LowerField.Move(moveAble);

                if (LowerField.Ship == null)
                {
                    LowerField.Ship = moveAble;
                }
            }
            MoveAble = moveAble;
        }
    }
}