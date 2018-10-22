using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Quay : Field
    {
        public Ship Ship { get; set; }

        public override string Print()
        {
            if(MoveAble != null)
            {
                return MoveAble.Print();
            }
            return "▄";
        }

        public override void Move(MoveAble moveAble)
        {
            MoveAble = moveAble;
            Ship.AmountOfGold++;
            MoveAble.IsFull = false;

            if (Ship != null)
            {
                if (Ship.IsFull)
                {
                    NextField.Move(moveAble);
                }
            }
        }
    }
}