using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Warehouse : Field
    {

        public Cart SpawnCart()
        {
            Cart tempCart = new Cart();
            NextField.MoveAble = tempCart;
            tempCart.CurrentField = NextField;
            return tempCart;
        }

        public override String Print()
        {
            return "█";
        }


    }
}