using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameLifeCSharp
{
   public class Game
    {
        FieldOfLife f1 = new FieldOfLife();
        public void StartGame ()
        {
           
            EnterAxis();
            int[,] mas = f1.CreateField();
            mas = f1.GenerateField(mas);
            Console.Clear();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                f1.OutputMassive(mas);
                mas = f1.KillingCells(mas);
                //Thread.Sleep(500);
            }

        }

        void EnterAxis()
        {
            Console.WriteLine("Enter first axis"); 
            f1.xAxis = IsNumberPositiveAndInteger();
            Console.WriteLine("Enter second axis");
            f1.yAxis = IsNumberPositiveAndInteger();
            
        }


        int IsNumberPositiveAndInteger()
        {
            int userValue = 0;
            bool cycleParameter = true;
            while(cycleParameter)
            {
                if (!(int.TryParse(Console.ReadLine(), out userValue)))
                {
                    Console.WriteLine("Wrong value. Value must be numeric(integer). Try again.");
                }
                else if (userValue <= 0)
                {
                    Console.WriteLine("Wrong value. Value must be a positive (integer). Try again.");
                }
                else
                {
                    cycleParameter = false;
                }
            }
            
            return userValue;
        }
    }
}
