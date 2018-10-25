using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class InputView
    {
        public Game Game { get; set; }

        public InputView(Game game)
        {
            Game = game;
        }

        public void ChangeSwitch()
        {
            bool IsValid = false;
            DateTime MaxTime = DateTime.Now.AddSeconds(5);
            while (DateTime.Now <= MaxTime)
            {
                IsValid = false;
                while (!IsValid)
                {
                    //if (DateTime.Now.Second >= MaxTime)
                    //{
                    //    break;
                    //}
                    var Input = Console.ReadKey(false).Key;

                    switch (Input)
                    {
                        case ConsoleKey.NumPad1:
                            Game.CommuteASwitch(0);
                            IsValid = true;
                            break;
                        case ConsoleKey.NumPad2:
                            Game.CommuteASwitch(1);
                            IsValid = true;
                            break;
                        case ConsoleKey.NumPad3:
                            Game.CommuteASwitch(2);
                            IsValid = true;
                            break;
                        case ConsoleKey.NumPad4:
                            Game.CommuteASwitch(3);
                            IsValid = true;
                            break;
                        case ConsoleKey.NumPad5:
                            Game.CommuteASwitch(4);
                            IsValid = true;
                            break;
                        default:
                            //do nothing
                            break;
                    }
                }
                IsValid = false;
                Game.OutputView.StandardScreen();
            }
        }
    }
}