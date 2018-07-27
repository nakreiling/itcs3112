using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/*
 * Nikolaus Kreiling (nkreilin)
 * ITCS 3112-080
 * July 23, 2018
 */ 

namespace MorseCode
{
    class Code
    {
        // Stores the letters from Morse.txt
        private static ArrayList morseKey;
        // Stores the morse values from Morse.txt
        private static ArrayList morseValue;

        // Default constructor
        public Code() { }

        public Code(ArrayList keys, ArrayList values)
        {
            morseKey = keys;
            morseValue = values;
        }

        /* 
         * Requests a string to be input by the user
         * @return input - the string entered by the user
         */
        public String TakeUserInput()
        {
            Console.WriteLine("Please enter a sentance (containing only letters and numbers) " +
                "that you would like to convert to morse code.");
            string input = Console.ReadLine();

            return input;
        }

        /*
         * Converts a string into morse code by iterating through the string and checking if values are in
         * the ArrayList of letters from Morse.txt
         * Prints the morse code output of the converted string at end of method
         * Exits the method if a character that cannot be converted to morse code is entered
         * @param userSentence - a sentence entered by the user to be converted to morse code
         */ 
        public void ConvertToMorseCode(string userSentence)
        {
            string morseCodeOutput = "";
            foreach (char ch in userSentence)
            {
                if (Char.IsWhiteSpace(ch))
                {
                    morseCodeOutput += "   ";
                }
                else if (morseKey.Contains(ch.ToString().ToUpper()))
                {
                    int index = morseKey.IndexOf(ch.ToString().ToUpper());
                    morseCodeOutput += morseValue[index] + " ";
                }
                else
                {
                    Console.WriteLine(ch + "  You entered a character that could not be converted to morse code...");
                    return;
                }
            }
            Console.WriteLine(morseCodeOutput);
        }


    }
}
