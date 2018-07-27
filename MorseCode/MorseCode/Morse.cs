using System;
using System.Collections;
using System.IO;

/*
 * Nikolaus Kreiling (nkreilin)
 * ITCS 3112-080
 * July 23, 2018
 */

namespace MorseCode
{
    class Morse
    {
        static void Main(string[] args)
        {
            // Try-catch block for error handling
            try
            {
                // User input for Morse.txt file path
                Console.WriteLine("Please enter the path for the Morse Code file you would like to read from:");
                string morseFilePath = Console.ReadLine();

                // Reads all lines of Morse.txt into a string array
                string[] morseFile = System.IO.File.ReadAllLines(morseFilePath);

                // Stores letters from Morse.txt
                ArrayList morseKey = new ArrayList();
                // Stores morse values from Morse.txt
                ArrayList morseValue = new ArrayList();

                // Iterates through the string array Morse.txt was stored in
                // Stores the letters into the ArrayList morseKey and the morse values into the ArrayList morseValue
                foreach (string str in morseFile)
                {
                    string split = " ";
                    string[] morseSplit = str.Split(split);
                    morseKey.Add(morseSplit[0]);
                    morseValue.Add(morseSplit[1]);
                }

                // Creates new Code object from Code.cs
                Code codeObject = new Code(morseKey, morseValue);

                string userSentence = "";

                // Continues asking the user to input sentences to be converted to morse code until a sentinel value (0) is entered
                while (!userSentence.Equals("0"))
                {
                    Console.WriteLine("This program will continually request for a string to be converted to morse code.");
                    Console.WriteLine("Enter '0' to exit.");
                    userSentence = codeObject.TakeUserInput();
                    codeObject.ConvertToMorseCode(userSentence);
                }
            }
            // Catches a FileNotFoundException
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("An error occured. The file was not found. See StackTrace below:");
                Console.WriteLine(ex.ToString());
            }
            // Catches all errors that are not FileNotFoundException
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred. See StackTrace below:");
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Goodbye!");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
