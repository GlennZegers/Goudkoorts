using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class ManeuveringField : Field
    {
        public bool IsLast { get; set; }

        public override String Print()
        {
            return "_";
        }

        public override void Move()
        {
            //als op de volgende al een cart staat doet die niks, en als het de laatste is ook niet.
        }
    }
}