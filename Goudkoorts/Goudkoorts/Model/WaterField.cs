using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class WaterField : Field
    {
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
            //if (lowerfield != null) 
            //{
            //    lowerfield(quay).Move(moveAble);
            //if lowerfield.ship == null >> ship = Moveable
            //}
            MoveAble = moveAble;
        }
    }
}