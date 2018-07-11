using System;
using System.Linq;

namespace Assignment1
{
    /*
     * Nikolaus Kreiling
     * nkreilin
     * ITCS 3112 - 048 
     * Summer 2 Session 2018
     */
    class Program
    {
        private static int Dice1;
        private static int Dice2;

        private static int[] FirstRollWinningNumbers = { 7, 11 };
        private static int[] FirstRollLosingNumbers = { 2, 3, 12 };
        private static int[] PointNumbers = { 4, 5, 6, 8, 9, 10 };
        private static int LosingNumber = 7;
        private static int Point;

        private static int Chips;

        private static string UserAnswer;

        // Stores user total diceroll
        private static int DiceRoll;

        private static void MakePoint(int wager)
        {
            //DiceRoll = diceroll;
            int chipWager = wager;
            Console.WriteLine("Your point is: " + Point);
            Console.WriteLine("If your dice roll equals your point you win! If it equals 7 you lose...");
            Console.WriteLine("Would you like to roll again? (y/n)");
            string ans = Convert.ToString(Console.ReadLine());
            if (!ans.Contains("y"))
            {
                Console.WriteLine("Subtracting wagered chips. Starting new Roll...");
                Chips -= chipWager;
                System.Threading.Thread.Sleep(1000);
                return;
            }
            Random rnd = new Random();
            Dice1 = rnd.Next(0, 7);
            Dice2 = rnd.Next(0, 7);
            DiceRoll = Dice1 + Dice2;
            Console.WriteLine(Dice1 + ", " + Dice2 + ", " + DiceRoll);
            if (DiceRoll == Point)
            {
                Console.WriteLine("You won!");
                Chips += chipWager;
                Console.WriteLine("Would you like to play again? (y/n)");
                UserAnswer = Convert.ToString(Console.ReadLine());
            }
            else if (DiceRoll == LosingNumber)
            {
                Console.WriteLine("You lost!");
                Chips -= chipWager;
                Console.WriteLine("Your current chip count: " + Chips);
                Console.WriteLine("Would you like to play again? (y/n)");
                UserAnswer = Convert.ToString(Console.ReadLine());
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                MakePoint(chipWager);
            }
        }


        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Would you like to Crap in my hands? (y/n)");
            Chips = 100;

            UserAnswer = Convert.ToString(Console.ReadLine());
            while (UserAnswer.Contains("y") && Chips > 0)
            {
                Console.WriteLine("Chip count: " + Chips);
                Console.WriteLine("How many chips would you like to wager?");
                int chipWager = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("You will wager " + chipWager + " chips.");
                Console.WriteLine("First roll:");
                Dice1 = rnd.Next(0, 7);
                Dice2 = rnd.Next(0, 7);
                DiceRoll = Dice1 + Dice2;

                Console.WriteLine("Your first die landed on " + Dice1 + " and your second die landed on " + Dice2);
                Console.WriteLine("Your total dice roll was: " + DiceRoll);

                

                if (FirstRollWinningNumbers.Contains(DiceRoll))
                {
                    Console.WriteLine("You won!");
                    Chips += chipWager;
                    Console.WriteLine("Would you like to play again? (y/n)");
                    UserAnswer = Convert.ToString(Console.ReadLine());
                }
                else if (PointNumbers.Contains(DiceRoll))
                {
                    Point = DiceRoll;
                    MakePoint(chipWager);
                }
                else if (FirstRollLosingNumbers.Contains(DiceRoll))
                {
                    Console.WriteLine("You lost!");
                    Chips -= chipWager;
                    Console.WriteLine("Your current chip count: " + Chips);
                    Console.WriteLine("Would you like to play again? (y/n)");
                    UserAnswer = Convert.ToString(Console.ReadLine());
                }
                
            }

            if (Chips == 0)
            {
                Console.WriteLine("You ran out of chips and can no longer play. Please leave this establishment.");
            }

            Console.WriteLine("Goodbye and have a nice day!");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
