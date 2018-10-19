﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Ship : MoveAble
    {
        public int AmountOfGold { get; set; }

        public Ship()
        {
            IsFull = false;

        }

        public override string Print()
        {
            if (IsFull)
            {
                return "@";
            }
            return "O";
        }
    }
}