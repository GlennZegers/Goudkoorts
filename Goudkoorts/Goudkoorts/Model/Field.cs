using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Field
    {
        public Field NextField { get; set; }
        public MoveAble MoveAble { get; set; }
        
        public virtual void Move(MoveAble moveAble)
        {
            MoveAble = moveAble;
        }

        public virtual String Print()
        {
            if(MoveAble != null)
            {
                return MoveAble.Print();
            }
            return ".";
        }
    }
}