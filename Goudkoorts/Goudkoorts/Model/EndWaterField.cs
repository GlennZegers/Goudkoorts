using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class EndWaterField : Field
    {
        public Game Game { get; set; }
        public override bool Move(MoveAble moveAble)
        {
            moveAble.CurrentField.MoveAble = null;
            moveAble.CurrentField = null;
            moveAble = null;
            Game.SpawnShip();
            return true;
        }

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
