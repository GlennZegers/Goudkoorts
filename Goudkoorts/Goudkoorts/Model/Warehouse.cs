using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Warehouse : Field
    {
        public Field StartField { get; set; }

        public void SpawnCart()
        {
            StartField.MoveAble = new Cart();
        }

        public override String Print()
        {
            return "█";
        }


    }
}