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

        public override void Move(MoveAble moveAble)
        {
            if (!MayChangeNextField)
            {
                if (DirectionIsUp)
                {
                    if(moveAble.CurrentField == UpperField)
                    {
                        moveAble.CurrentField = this;
                        this.MoveAble = moveAble;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if(moveAble.CurrentField == LowerField)
                    {
                        moveAble.CurrentField = this;
                        this.MoveAble = moveAble;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                moveAble.CurrentField = this;
                this.MoveAble = moveAble;
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