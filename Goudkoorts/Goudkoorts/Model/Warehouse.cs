using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Warehouse
    {
        public Field StartField { get; set; }

        public void SpawnCart()
        {
            StartField.MoveAble = new Cart();
        }

        public String Print()
        {
            return "⏏";
        }


    }
}