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

        public override void Move()
        {
            //deze moet hem of aan de upperfield geven of aan de lowerfield
        }

        public void Commute()
        {
            if (DirectionIsUp)
            {
                DirectionIsUp = false;
            }
            else
            {
                DirectionIsUp = true;
            }
        }
    }
}