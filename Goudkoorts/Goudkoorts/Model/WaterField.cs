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

        public override void Move(MoveAble moveAble)
        {
            if (MoveAble != null)
            {
                return;
            }

            if (LowerField != null)
            {
                //LowerField.Move(moveAble);

                if (LowerField.Ship == null)
                {
                    MoveAble = moveAble;
                    moveAble.MayNotMove = true;
                    LowerField.Ship = moveAble;
                }

                if (moveAble.MayNotMove)
                {
                    return;
                }
            }

            MoveAble = moveAble;
        }
    }
}