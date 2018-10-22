using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class InputView
    {
        public void ChangeSwitch()
        {
            bool IsValid = false;

            while (!IsValid)
            {
                var Input = Console.ReadKey(false).Key;

                switch (Input)
                {
                    case ConsoleKey.NumPad1:
                        //switch methode
                        IsValid = true;
                        break;
                    case ConsoleKey.NumPad2:
                        //switch methode
                        IsValid = true;
                        break;
                    case ConsoleKey.NumPad3:
                        //switch methode
                        IsValid = true;
                        break;
                    case ConsoleKey.NumPad4:
                        //switch methode
                        IsValid = true;
                        break;
                    case ConsoleKey.NumPad5:
                        //switch methode
                        IsValid = true;
                        break;
                    default:
                        //do nothing
                        break;
                }
            }
        }
    }
}