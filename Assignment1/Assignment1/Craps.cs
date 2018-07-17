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
    class Craps
    {
        // Store dice roll values
        private static int Dice1;
        private static int Dice2;

        // Store winning, losing numbers etc.
        private static int[] FirstRollWinningNumbers = { 7, 11 };
        private static int[] FirstRollLosingNumbers = { 2, 3, 12 };
        private static int[] PointNumbers = { 4, 5, 6, 8, 9, 10 };
        private static int LosingNumber = 7;

        // Store user's point value
        private static int Point;

        // Store user's chip count
        private static int Chips;

        // Store user's response
        private static string UserAnswer;

        // Stores user total diceroll
        private static int DiceRoll;

        /*
         * Roll dice until user either makes their point or the user rolls a 7 and loses
         * 
         */
        private static void MakePoint(int wager)
        {
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
            Dice1 = rnd.Next(1, 6);
            Dice2 = rnd.Next(1, 6);
            DiceRoll = Dice1 + Dice2;
            Console.WriteLine("You rolled a " + DiceRoll + " (" + Dice1 + ", " + Dice2 + ")");
            if (DiceRoll == Point)
            {
                Console.WriteLine("You won!");
                Chips += chipWager * 2;
                Console.WriteLine("Your current chip count: " + Chips);
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
            Console.WriteLine("Would you like to play Craps? (y/n)");
            Chips = 100;

            UserAnswer = Convert.ToString(Console.ReadLine());

            // Loop through this until the user answers "n"
            while (UserAnswer.Contains("y") && Chips > 0)
            {
                Console.WriteLine("Chip count: " + Chips);
                Console.WriteLine("How many chips would you like to wager?");
                int chipWager = 0;
                try
                {
                    chipWager = Convert.ToInt16(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please respond with an integer.");
                }

                Console.WriteLine("You will wager " + chipWager + " chips.");
                Console.WriteLine("First roll:");
                Dice1 = rnd.Next(1, 6);
                Dice2 = rnd.Next(1, 6);
                DiceRoll = Dice1 + Dice2;

                Console.WriteLine("You rolled a " + DiceRoll + " (" + Dice1 + ", " + Dice2 + ")");


                // If the first roll is a winning number
                if (FirstRollWinningNumbers.Contains(DiceRoll))
                {
                    Console.WriteLine("You won!");
                    Chips += chipWager * 2;
                    Console.WriteLine("Your current chip count: " + Chips);
                    Console.WriteLine("Would you like to play again? (y/n)");
                    UserAnswer = Convert.ToString(Console.ReadLine());
                }
                // If the user rolls something other than the winning or losing numbers their dice roll is assigned
                // to the point value and the user rolls until they quit, roll their point, or lose
                else if (PointNumbers.Contains(DiceRoll))
                {
                    Point = DiceRoll;
                    MakePoint(chipWager);
                }
                // If the user rolls a losing number on the first roll they lose and the chip wager is subtracted
                else if (FirstRollLosingNumbers.Contains(DiceRoll))
                {
                    Console.WriteLine("You lost!");
                    Chips -= chipWager;
                    Console.WriteLine("Your current chip count: " + Chips);
                    Console.WriteLine("Would you like to play again? (y/n)");
                    UserAnswer = Convert.ToString(Console.ReadLine());
                }
                
            }

            // If you're out of chips, display this message
            if (Chips == 0)
            {
                Console.WriteLine("You ran out of chips and can no longer play. Please leave this establishment.");
            }

            Console.WriteLine("Goodbye and have a nice day!");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
