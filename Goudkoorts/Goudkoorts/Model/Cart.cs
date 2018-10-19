﻿using System;
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
        }

        public override string Print()
        {
            if (IsFull)
            {
                return "$";
            }
            return "S";
        }
    }
}