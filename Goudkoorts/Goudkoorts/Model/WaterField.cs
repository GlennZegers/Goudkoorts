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

            if (LowerField != null)
            {
                //LowerField.Move(moveAble);

                if (LowerField.Ship == null)
                {
                    MoveAble = moveAble;
                    moveAble.MayNotMove = true;
                    Game.Points += 8;
                    LowerField.Ship = moveAble;
                }

                if (moveAble.MayNotMove)
                {
                    return true;
                }
            }

            MoveAble = moveAble;
            return true;
        }
    }
}