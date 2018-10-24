using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public abstract class MoveAble
    {
        public Field CurrentField { get; set; }
        public bool IsFull { get; set; }
        public int AmountOfGold { get; set; }

        public abstract String Print();
        public abstract void Move();

    }
}