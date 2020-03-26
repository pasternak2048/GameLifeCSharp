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
            int xaxis = 0;
            int yaxis = 0;
            bool cycleParameter = true;
            while (cycleParameter)
            {
                Console.WriteLine("Enter first axis");
                if (int.TryParse(Console.ReadLine(), out xaxis))
                {
                    f1.xAxis = xaxis;
                    cycleParameter = false;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }

            cycleParameter = true;

            while (cycleParameter)
            {
                Console.WriteLine("Enter second axis");
                if (int.TryParse(Console.ReadLine(), out yaxis))
                {
                    f1.yAxis = yaxis;
                    cycleParameter = false;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
        }
    }
}
