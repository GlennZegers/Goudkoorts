using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Cart : MoveAble
    {
        public Game Game { get; set; }
        public Cart(Game Game)
        {
            this.Game = Game;
            IsFull = true;
            AmountOfGold = 1;
        }

        public override string Print()
        {
            if (IsFull)
            {
                return "$";
            }
            return "S";
        }

        public override bool Move()
        {
            if(CurrentField == null)
            {
                Game.Carts.Remove(this);
                return true;
            }
            return CurrentField.NextField.Move(this);

        }
    }
}