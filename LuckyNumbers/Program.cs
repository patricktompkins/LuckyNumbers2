using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            // variables
            string again = "Yes";
            int lower = 0;
            int upper = -1;
            int input = 0;
            int[] randomArray = new int[6];
            int size = 6;
            int[] userArray = new int[6];
            bool gotIt = false;
            int cnt = 0;
            decimal jackPotAmount = 1000000;



            do
            {
                // get user input
                // store input
                while (lower <= 0) // range checking
                {

                    Console.WriteLine("Please enter your lowest lucky number.");
                    lower = int.Parse(Console.ReadLine());
                }

                while (lower >= upper)
                {
                    Console.WriteLine("Please enter your highest lucky number.");
                    upper = int.Parse(Console.ReadLine());
                }


                // input the six value to compare later
                // check for duplicates and in range
                do
                {
                    Console.WriteLine("You are entering 1 of " + size + " values ");
                    Console.WriteLine("Please enter a number in the range of " + lower + " to " + upper + " : ");

                    input = int.Parse(Console.ReadLine());

                    if (input < lower || input > upper)
                    {
                        Console.WriteLine("Out of range 1 of " + size + " - value enter: " + input);

                    }
                } while (input < lower || input > upper);

                userArray[0] = input;

                for (int l = 1; l < size; l++)
                {
                    Console.WriteLine("You are entering " + (l + 1) + " of " + size + " values ");
                    Console.WriteLine("Please enter a number in the range of " + lower + " to " + upper + " : ");
                    input = int.Parse(Console.ReadLine());
                    // check the input for duplicates in the array, if duplicate get another 
                    // number, do until you have a good 

                    for (int p = 0; p < l; p++)
                    {
                        if (input == userArray[p])
                        {
                            while (!gotIt)
                            {
                                Console.WriteLine("You have enter a duplicate number for " + l + " of " + size + " values ");
                                Console.WriteLine("Please enter a number in the range of " + lower + " to " + upper + " : ");
                                input = int.Parse(Console.ReadLine());

                                if (input != userArray[p])
                                {
                                    gotIt = true;
                                }

                            }
                            gotIt = false;
                        }

                    }
                    if (input >= lower && input <= upper)
                    {
                        userArray[l] = input;
                    }
                    else
                    {
                        Console.WriteLine("Out of range " + lower + " to " + upper + "...value entered: " + input);
                        l--;
                    }

                }

                // generate random numbers
                Random rn = new Random();
                int rInput = rn.Next(lower, upper + 1);
                randomArray[0] = rInput;
                for (int l = 1; l < size; l++)
                {
                    rInput = rn.Next(lower, upper + 1);
                    // check the input for duplicates in the array, if duplicate get another 
                    // number, do until you have a good 

                    for (int p = 0; p < l; p++)
                    {
                        if (rInput == randomArray[p])
                        {
                            while (!gotIt && cnt < 1000)
                            {
                                rInput = rn.Next(lower, upper + 1);


                                if (rInput != randomArray[p])
                                {
                                    gotIt = true;
                                }
                                cnt++;

                            }
                            gotIt = false;
                            if (cnt >= 1000)
                            {
                                Console.WriteLine("Error in random genertor");
                            }
                            cnt = 0;
                        }
                        randomArray[l] = rInput;
                    }

                }




                // compare numbers
                int gotMatchCnt = 0;

                for (int l = 0; l < size; l++)
                {
                    for (int p = 0; p < size; p++)
                    {
                        if (userArray[l] == randomArray[p])
                        {
                            gotMatchCnt++;
                        }
                    }
                }


                // calculate jackpot amount
                

                if (gotMatchCnt == 1)
                {
                    jackPotAmount = jackPotAmount + 1000m;
                }
                    else if (gotMatchCnt == 2)
                {
                    jackPotAmount = jackPotAmount + 2000m;
                }
                    else if (gotMatchCnt == 3)
                {
                    jackPotAmount = jackPotAmount + 3000m;
                }
                    else if (gotMatchCnt == 4)
                {
                    jackPotAmount = jackPotAmount + 4000m;
                }
                    else if (gotMatchCnt == 5)
                {
                    jackPotAmount = jackPotAmount + 5000m;
                }
                    else if (gotMatchCnt == 6)
                {
                    
                }
                    else
                {
                    jackPotAmount = jackPotAmount + 10m; 
                }

                string ftm = "$0000.00"; 
                

                    // display output ( correct guess and jackpot amount)
                Console.WriteLine("\nCurrent Jack Pot: " + jackPotAmount.ToString(ftm));

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine("Lucky Number: " + userArray[i]);
                }

 
                Console.WriteLine("You guessed correctly " + gotMatchCnt + " Lucky Numbers");
                if (gotMatchCnt == 1)
                {
                    Console.WriteLine("You won $1000.00");
                    
                }

                else if (gotMatchCnt == 2)
                {
                    Console.WriteLine("You won $2000.00");
                    
                }

                else if (gotMatchCnt == 3)
                {
                    Console.WriteLine("You won $3000.00");
                }
                else if (gotMatchCnt == 4)
                {
                    Console.WriteLine("You won $4000.00");
                }
                else if (gotMatchCnt == 5)
                {
                    Console.WriteLine("You won $5000.00");
                }
                else if (gotMatchCnt == 6)
                {
                    Console.WriteLine("You won : " + jackPotAmount.ToString(ftm));
                    jackPotAmount = 0;
                }
                else
                {
                    Console.WriteLine("You did not win! Please try again!");
                }

                // repeat
                Console.WriteLine("\nDo you want to guess again? Please enter 'Yes' to guess again ");
                again = Console.ReadLine();
                again = again.ToUpper();
                // reset conditional values
                lower = 0;
                upper = -1;
                size = 6;
                gotIt = false;
                cnt = 0;

            } while (again.Equals("YES"));
        }
    }
}
