using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Goudkoorts
{
    public class Game
    {
        public Warehouse Warehouse { get; set; }
        public OutputView OutputView { get; set; }
        public InputView InputView { get; set; }
        public Field[,] FieldArray { get; set; }
        public Ship Ship { get; set; }
        public Thread GameThread { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Switch> Switches { get; set; } 
        public int Points { get; set; }
        public WaterField ShipField { get; set; }
        public int Max { get; set; }

        public Game()
        {
            Points = 0;
            Max = 0;
            Switches = new List<Switch>();
            Warehouses = new List<Warehouse>();
            Carts = new List<Cart>();
            FieldArray = new Field[12, 10];
            Ship = new Ship();
            GenerateFields();
            LinkFields();
            OutputView = new OutputView(FieldArray, this);
            InputView = new InputView(this);
            OutputView.WelcomeMessage();
            GameThread = new Thread(Play);
            GameThread.Start();
        }

        public void SpawnShip()
        {
            Ship = new Ship();
            ShipField.MoveAble = Ship;
            Ship.CurrentField = ShipField;

        }

        public void Play()
        {
            Carts.Add( Warehouses.ElementAt(0).SpawnCart());

            OutputView.StandardScreen();
            while (true)
            {

                Random r = new Random();

                if (Points == 0)
                {
                    Max = 10;
                }
                else
                {
                    double MaxDouble = (10 / Points) * 1.5;
                    Max = (Int32)MaxDouble;
                }

                double Seconds = Max / 2;
                int ExtraSeconds = (Int32)Seconds;
                InputView.ChangeSwitch(ExtraSeconds);
                OutputView.StandardScreen();
                
                foreach (var c in Carts.ToList())
                {
                    if (!c.Move())
                    {
                        EndGame();
                    }
               
                }
                Ship.Move();

                foreach (var w in Warehouses)
                {
                    if (r.Next(Max) == Max - 1)
                    {
                        Carts.Add(w.SpawnCart());
                    }
                }

                OutputView.StandardScreen();
            }

        }

        private void EndGame()
        {
            OutputView.ShowEndScreen();
            Console.ReadKey();
            Environment.Exit(0);
        }

        public void CommuteASwitch(int number)
        {
            Switches.ElementAt(number).Commute();
        }

        private void LinkFields()
        {
            for (int i =11; i > 0; i--)
            {
                FieldArray[i, 0].NextField = FieldArray[i - 1, 0];
            }
            for (int i = 11; i > 0; i--)
            {
                FieldArray[i, 1].NextField = FieldArray[i - 1, 1];
            }
            FieldArray[11, 2].NextField = FieldArray[11, 1];
            FieldArray[11, 3].NextField = FieldArray[11, 2];
            FieldArray[11, 4].NextField = FieldArray[11, 3];

            for(int i = 0; i < 3; i++)
            {
                FieldArray[i, 3].NextField = FieldArray[i + 1, 3];
            }

            for (int i = 5; i < 10; i++)
            {
                FieldArray[i, 3].NextField = FieldArray[i + 1, 3];
            }

            for (int i = 0; i < 3; i++)
            {
                FieldArray[i, 5].NextField = FieldArray[i + 1, 5];
            }

            FieldArray[3, 3].NextField = FieldArray[3, 4];
            FieldArray[3, 5].NextField = FieldArray[3, 4];
            FieldArray[3, 4].NextField = FieldArray[4, 4];
            FieldArray[4, 4].NextField = FieldArray[5, 4];
            FieldArray[5, 4].NextField = FieldArray[5, 3];
            FieldArray[9, 3].NextField = FieldArray[9, 4];
            FieldArray[9, 4].NextField = FieldArray[10, 4];
            FieldArray[10, 4].NextField = FieldArray[11, 4];
            FieldArray[5, 5].NextField = FieldArray[6, 6];
            FieldArray[6, 6].NextField = FieldArray[6, 7];
            FieldArray[8, 6].NextField = FieldArray[9, 5];
            FieldArray[9, 5].NextField = FieldArray[9, 4];
            FieldArray[6, 7].NextField = FieldArray[7, 7];
            FieldArray[7, 7].NextField = FieldArray[8, 7];
            FieldArray[8, 7].NextField = FieldArray[8, 8];

            for (int i = 0; i < 6; i++)
            {
                FieldArray[i, 8].NextField = FieldArray[i + 1, 8];
            }
            FieldArray[6, 8].NextField = FieldArray[6, 7];
            FieldArray[8, 8].NextField = FieldArray[9, 8];
            FieldArray[9, 8].NextField = FieldArray[10, 8];
            FieldArray[10, 8].NextField = FieldArray[11, 8];
            FieldArray[11, 8].NextField = FieldArray[11, 9];

            for(int i = 11; i > 0; i--)
            {
                FieldArray[i, 9].NextField = FieldArray[i - 1, 9];
            }
        }

        private void GenerateFields()
        {
            WaterField TempWaterField2 = null;
            FieldArray[0, 0] = new EndWaterField { Game = this};
            for(int i = 1; i < 12; i++)
            {
                WaterField TempWaterField =  new WaterField { Game = this };
                FieldArray[i, 0] = TempWaterField;
                if (i == 9)
                {
                    TempWaterField2 = TempWaterField;

                }
                if(i == 11)
                {
                    TempWaterField.MoveAble = this.Ship;
                    Ship.CurrentField = TempWaterField;
                    ShipField = TempWaterField;
                }
            }
            FieldArray[0, 1] = new EndField();
            for (int i = 1; i < 12; i++)
            {
                FieldArray[i, 1] = new Field();
                if( i == 9)
                {   
                    Quay TempQuay = new Quay { Game = this };
                    FieldArray[i, 1] = TempQuay;
                    TempWaterField2.LowerField = TempQuay;
                }
            }
            FieldArray[11, 2] = new Field();
            Warehouse TempHouse = new Warehouse { Game = this };
            FieldArray[0, 3] = TempHouse;
            Warehouses.Add(TempHouse);
            for (int i = 1; i< 12; i++)
            {
                if(i!= 4 && i != 10)
                {
                    FieldArray[i, 3] = new Field();
                }
            }
            FieldArray[3, 5] = new Field();
            FieldArray[4, 4] = new Field();
            FieldArray[10, 4] = new Field();
            FieldArray[11, 4] = new Field();
            TempHouse = new Warehouse {Game = this };
            FieldArray[0, 5] = TempHouse;
            Warehouses.Add(TempHouse);
            FieldArray[1, 5] = new Field();
            FieldArray[2, 5] = new Field();
            FieldArray[5, 5] = new Field();
            FieldArray[9, 5] = new Field();
            FieldArray[6, 6] = new Field();
            FieldArray[8, 6] = new Field();
            FieldArray[7, 7] = new Field();
            TempHouse = new Warehouse { Game = this };
            FieldArray[0, 8] = TempHouse;
            Warehouses.Add(TempHouse);
            for (int i = 1; i < 12; i++)
            {
                if( i != 7)
                {
                    FieldArray[i, 8] = new Field();
                }
            }
            FieldArray[1, 9] = new ManeuveringField();
            FieldArray[0, 9] = new EndManeuveringField();
            for(int i = 2; i< 12; i++)
            {
                FieldArray[i, 9] = new ManeuveringField();
                if(i == 9 || i == 10 || i == 11)
                {
                    FieldArray[i, 9] = new Field();
                }
            }
            Switch TempSwitch = new Switch { UpperField = FieldArray[5, 3], LowerField = FieldArray[5, 5], MayChangeNextField = true };
            FieldArray[5, 4] = TempSwitch;
            Switches.Add(TempSwitch);
            TempSwitch = new Switch { UpperField = FieldArray[9, 3], LowerField = FieldArray[9, 5] };
            FieldArray[9, 4] = TempSwitch;
            Switches.Add(TempSwitch);
            TempSwitch = new Switch { UpperField = FieldArray[8, 6], LowerField = FieldArray[8, 8], MayChangeNextField = true};
            FieldArray[8, 7] = TempSwitch;
            Switches.Add(TempSwitch);
            TempSwitch = new Switch { UpperField = FieldArray[6, 6], LowerField = FieldArray[6, 8] };
            FieldArray[6, 7] = TempSwitch;
            Switches.Add(TempSwitch);
            TempSwitch = new Switch { UpperField = FieldArray[3, 3], LowerField = FieldArray[3, 5] };
            FieldArray[3, 4] = TempSwitch;
            Switches.Add(TempSwitch);
        }
    }
}