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
    }
}