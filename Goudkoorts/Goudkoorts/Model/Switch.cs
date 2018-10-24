using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Switch : Field
    {
        public Field UpperField { get; set; }
        public Field LowerField { get; set; }
        public bool DirectionIsUp { get; set; }
        public bool MayChangeNextField { get; set; }

        public override bool Move(MoveAble moveAble)
        {
            if (MoveAble != null)
            {
                return false;
            }

            if (!MayChangeNextField)
            {
                if (DirectionIsUp)
                {
                    if(moveAble.CurrentField == UpperField)
                    {
                        moveAble.CurrentField = this;
                        this.MoveAble = moveAble;
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if(moveAble.CurrentField == LowerField)
                    {
                        moveAble.CurrentField = this;
                        this.MoveAble = moveAble;
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                moveAble.CurrentField = this;
                this.MoveAble = moveAble;
                return true;
            }
        }

        public void Commute()
        {
            if (DirectionIsUp)
            {
                DirectionIsUp = false;
                if (MayChangeNextField)
                {
                    NextField = LowerField;
                }
            }
            else
            {
                DirectionIsUp = true;
                if (MayChangeNextField)
                {
                    NextField = UpperField;
                }
            }
        }

        public override string Print()
        {
            if (MoveAble != null)
            {
                return MoveAble.Print();
            }
            if (MayChangeNextField)
            {
                if (DirectionIsUp)
                {
                    return "/";
                }
                return "\\";
            }
            else
            {
                if (DirectionIsUp)
                {
                    return "\\";
                }
                return "/";
            }
          
        }
    }
}