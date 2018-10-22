using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class EndWaterField : EndField
    {
        public override string Print()
        {
            if (MoveAble != null)
            {
                return MoveAble.Print();
            }
            return "~";
        }
    }
}
