using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goudkoorts
{
    public class OutputView
    {
        public Field[,] FieldArray { get; set; }

        public OutputView(Field[,] f)
        {
            FieldArray = f;
        }

        public void WelcomeMessage()
        {
            Console.WriteLine("Welkom bij Goudkoorts!");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Probeer zoveel mogelijk schepen te vullen met goud. Let op, je kunt de schakelaars alleen wijzigen");
            Console.WriteLine("zolang de tijd loopt.");
            Console.WriteLine("");
            Console.WriteLine("┌─────────────────────────────┐");
            Console.WriteLine("| Betekenis van de symbolen   |");
            Console.WriteLine("|                             |");
            Console.WriteLine("|     - : rails               |");
            Console.WriteLine("|     _ : rangeerveld         |");
            Console.WriteLine("|     $ : volle kar           |");
            Console.WriteLine("|     S : lege kar            |");
            Console.WriteLine("|     @ : vol schip           |");
            Console.WriteLine("|     O : leeg schip          |");
;           Console.WriteLine("|     ▄ : kade                |");
            Console.WriteLine("|     ^ : schakelaar omhoog   |");
            Console.WriteLine("|       : schakelaar omlaag   |");
            Console.WriteLine("|     █ : loods               |");
            Console.WriteLine("|     ~ : water               |");
            Console.WriteLine("└─────────────────────────────┘");
            Console.WriteLine("");
            Console.WriteLine("Druk op een toets om naar het spel te gaan");
            Console.ReadKey();
        }

        public void StandardScreen()
        {
            Console.Clear();
            Console.WriteLine("Tijd over: *getal* seconden");
            Console.WriteLine("Aantal punten: *getal*");
            Console.WriteLine("");
            PrintGame();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Gebruik de toetsen 1 t/m 5 op je numpad om de schakelaars te veranderen");
        }

        private void PrintGame()
        {
            String printString = "";
            for(int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    if (FieldArray[x, y] != null)
                    {
                        printString += FieldArray[x, y].Print();
                    }
                    else
                    {
                        printString += " ";
                    }
                }
                Console.WriteLine(printString);
                printString = "";
            }
        }
    }
}