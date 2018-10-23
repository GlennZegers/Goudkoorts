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

        public override void Move()
        {
            CurrentField.MoveAble = null;
            CurrentField.NextField.Move(this);
        }
    }
}