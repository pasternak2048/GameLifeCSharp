using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //лічильник

namespace GameLife
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] genOne = new int[40, 40]; //Generation 1
            int[,] genTwo = new int[40, 40]; //Generation 2, generated on the basis of Generation 1
            int sumGuests; // Sum of neighboring cells

            Random rnd = new Random(); 

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    genOne[i, j] = Convert.ToInt32(rnd.Next(0, 2)); // Fill an array with 0 and 1 in random order
                }

            }

        Start: 

            Console.SetCursorPosition(0, 0); //Recording without clearing the console, move the cursor to the top

            /*MATRIX OUTPUT*/

            for (int i = 1; i < 39; i++)
            {
                Console.WriteLine();
                for (int j = 1; j < 39; j++)
                {
                    switch (genOne[i, j])
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;// the color of living cells
                            Console.Write(" ");
                            Console.Write(genOne[i, j]);  // output
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Black; //the color of the dead cells
                            Console.Write(" ");
                            Console.Write(genOne[i, j]);  //output
                            break;
                    }

                }

            }
           
            /*CHECK OF ALL CELLS*/

            for (int i = 1; i < 39; i++) // perimeter zero
                for (int j = 1; j < 39; j++)// perimeter zero
                {
                    sumGuests = genOne[i - 1, j - 1] + genOne[i - 1, j] + genOne[i - 1, j + 1] + genOne[i, j - 1] + genOne[i, j + 1] + genOne[i + 1, j - 1] + genOne[i + 1, j] + genOne[i + 1, j + 1];


                    if (genOne[i, j] == 1)  //If the cell is alive
                        if (sumGuests == 2) //If living neighbors 2
                            genTwo[i, j] = 1; //The cell is alive. 1 - means alive
                        else if (sumGuests == 3) //Else If living neighbors 3
                            genTwo[i, j] = 1;//The cell is alive. 1 - means alive
                        else genTwo[i, j] = 0;//Else The cell is dead. 0 - means dead
                    else if (sumGuests == 3)//Else if the cell is dead and living neighbors 3
                        genTwo[i, j] = 1;//The cell is alive. 1 - means is alive
                    else genTwo[i, j] = 0;//Else The cell is dead. 0 - means dead
                }

            for (int i = 0; i < 40; i++)
            {

                for (int j = 0; j < 40; j++)
                {
                    genOne[i, j] = genTwo[i, j]; //Generation 2 I write in Generation 1

                }

            }

            //Thread.Sleep(10); 

            goto Start;

        }

    }


}

