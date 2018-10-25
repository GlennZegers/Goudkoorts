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

        public virtual bool Move(MoveAble moveAble)
        {
            if(MoveAble != null)
            {
                return false;
            }
            moveAble.CurrentField.MoveAble = null;
            moveAble.CurrentField = this;
            this.MoveAble = moveAble;
            return true;
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