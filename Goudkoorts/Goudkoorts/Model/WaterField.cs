using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class WaterField : Field
    {
        public Quay LowerField { get; set;}
        public Game Game { get; set; }

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
                return true;
            }
            if (moveAble.MayNotMove)
            {
                return true;
            }

            if (LowerField != null)
            {
                if (LowerField.Ship == null)
                {
                    moveAble.CurrentField.MoveAble = null;
                    MoveAble = moveAble;
                    moveAble.CurrentField = this;
                    moveAble.MayNotMove = true;
                    LowerField.Ship = moveAble;
                    return true;
                }
            }
            moveAble.CurrentField.MoveAble = null;
            MoveAble = moveAble;
            moveAble.CurrentField = this;
            return true;
        }
    }
}