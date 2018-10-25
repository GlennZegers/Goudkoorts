using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Cart : MoveAble
    {

        public Cart()
        {
            IsFull = true;
            AmountOfGold = 1;
        }

        public override string Print()
        {
            if (IsFull)
            {
                return "$";
            }
            return "S";
        }

        public override bool Move()
        {
            return CurrentField.NextField.Move(this);

        }
    }
}