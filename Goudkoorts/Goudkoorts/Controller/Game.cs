using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class Game
    {
        public Warehouse Warehouse { get; set; }
        public OutputView OutputView { get; set; }
        public InputView InputView { get; set; }
        public Field[,] FieldArray { get; set; }
        public Ship Ship { get; set; }

        public Game()
        {
            FieldArray = new Field[12, 10];
            Ship = new Ship();
            GenerateFields();
            OutputView = new OutputView(FieldArray);
            
        }

        private void LinkFields()
        {
            for (int i =12; i > 0; i--)
            {
                FieldArray[i, 0].NextField = FieldArray[i + 1, 0];
            }
        }

        private void GenerateFields()
        {
            FieldArray[0, 0] = new EndWaterField();
            for(int i = 1; i < 12; i++)
            {
                FieldArray[i, 0] = new WaterField();
                if(i == 9)
                {
                    FieldArray[i, 0].MoveAble = this.Ship;
                    Ship.CurrentField = FieldArray[i, 0];
                }
            }
            FieldArray[0, 1] = new EndField();
            for (int i = 1; i < 12; i++)
            {
                FieldArray[i, 1] = new Field();
                if( i == 9)
                {
                    FieldArray[i, 1] = new Quay { Ship = this.Ship};
                }
            }
            FieldArray[11, 2] = new Field();
            FieldArray[0, 3] = new Warehouse();
            for(int i = 1; i< 12; i++)
            {
                if(i!= 4 && i != 10)
                {
                    FieldArray[i, 3] = new Field();
                }
            }
            FieldArray[3, 4] = new Switch();
            FieldArray[4, 4] = new Field();
            FieldArray[5, 4] = new Switch();
            FieldArray[9, 4] = new Switch();
            FieldArray[10, 4] = new Field();
            FieldArray[11, 4] = new Field();
            FieldArray[0, 5] = new Warehouse();
            FieldArray[1, 5] = new Field();
            FieldArray[2, 5] = new Field();
            FieldArray[3, 5] = new Field();
            FieldArray[5, 5] = new Field();
            FieldArray[9, 5] = new Field();
            FieldArray[6, 6] = new Field();
            FieldArray[8, 6] = new Field();
            FieldArray[6, 7] = new Switch();
            FieldArray[7, 7] = new Field();
            FieldArray[8, 7] = new Switch();
            FieldArray[0, 8] = new Warehouse();
            for(int i = 1; i < 12; i++)
            {
                if( i != 8)
                {
                    FieldArray[i, 8] = new Field();
                }
            }
            FieldArray[1, 9] = new ManeuveringField { IsLast = true };
            for(int i = 2; i< 11; i++)
            {
                FieldArray[i, 9] = new ManeuveringField();
                if(i == 9 || i == 10 || i == 11)
                {
                    FieldArray[i, 9] = new Field();
                }
            }
        }
    }
}