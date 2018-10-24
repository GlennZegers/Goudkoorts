using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Quay : Field
    {
        public MoveAble Ship { get; set; }
        public Game Game { get; set; }

        public override string Print()
        {
            if(MoveAble != null)
            {
                return MoveAble.Print();
            }
            return "▄";
        }

        public override bool Move(MoveAble moveAble)
        {
            MoveAble = moveAble;
            if (Ship != null)
            {
                Ship.AmountOfGold += moveAble.AmountOfGold;

                if (Ship.AmountOfGold >= 8)
                {
                    Ship.IsFull = true;
                    Ship.MayNotMove = false;
                }
                MoveAble.IsFull = false;
                MoveAble.AmountOfGold = 0;


                //if (Ship.IsFull)
                //{
                //    NextField.Move(moveAble);
                //}
            }
            return true;
        }
    }
}