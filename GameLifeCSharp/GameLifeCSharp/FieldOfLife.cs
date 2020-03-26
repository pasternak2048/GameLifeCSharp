using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLifeCSharp
{
    class FieldOfLife
    {
        private int xaxis = 0;
        private int yaxis = 0;
        private int sumGuests = 0;
        public int xAxis
        {
            set
            {
                if (value % 1 != 0)
                {
                    Console.WriteLine("The number is not an integer. ");
                }
                else
                {
                    xaxis = value;
                }
            }
        }


        public int yAxis
        {
            set
            {
                if (value % 1 != 0)
                {
                    Console.WriteLine("The value is not an integer number. ");
                }
                else
                {
                    yaxis = value;
                }
            }
        }

        public int[,] CreateField()
        {
            int[,] field = new int[xaxis, yaxis];
            return field;
        }

        public int[,] GenerateField(int[,] massive)
        {
            Random rnd = new Random();

            for (int i = 0; i < massive.GetLength(0); i++)
            {
                for (int j = 0; j < massive.GetLength(1); j++)
                {
                    massive[i, j] = Convert.ToInt32(rnd.Next(0, 2)); // Fill an array with 0 and 1 in random order
                }

            }

            return massive;
        }



        public void OutputMassive(int[,] targetMassive)
        {
            Console.CursorVisible = false;
            for (int i = 1; i < targetMassive.GetLength(0) - 1; i++)
            {
                Console.WriteLine();
                for (int j = 1; j < targetMassive.GetLength(1) - 1; j++)
                {
                    switch (targetMassive[i, j])
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;// the color of living cells
                            Console.Write(" ");
                            Console.Write(targetMassive[i, j]);  // output
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Black; //the color of the dead cells
                            Console.Write(" ");
                            Console.Write(targetMassive[i, j]);  //output
                            break;
                    }

                }

            }
        }


        public int[,] KillingCells(int[,] targetMassive)
        {
            int[,] newMassive = new int[targetMassive.GetLength(0), targetMassive.GetLength(1)];



            for (int i = 1; i < targetMassive.GetLength(0) - 2; i++) // perimeter zero
            {
                for (int j = 1; j < targetMassive.GetLength(1) - 2; j++)// perimeter zero
                {
                    sumGuests = targetMassive[i - 1, j - 1] + targetMassive[i - 1, j] + targetMassive[i - 1, j + 1] + targetMassive[i, j - 1] + targetMassive[i, j + 1] + targetMassive[i + 1, j - 1] + targetMassive[i + 1, j] + targetMassive[i + 1, j + 1];

                    if (targetMassive[i, j] == 1)
                    {
                        if ((sumGuests == 2) || (sumGuests == 3))
                        {
                            newMassive[i, j] = 1;
                        }

                    }
                    else if (targetMassive[i, j] == 0)
                    {
                        if (sumGuests == 3)
                            newMassive[i, j] = 1;

                    }
                    else
                    {
                        newMassive[i, j] = 0;
                    }


                }
            }
            return newMassive;
        }
    }
}
