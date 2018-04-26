/*Author: Nina Nguyen
 *Filename: Main_EW.cs in C#
 *Date: 4/22/2018
 *Version: 1 
 * 
 */

/*Description and anticipated use: This program provides the intro about
 * the EW clasa and how it will function. The Main class will ask for 
 * a valid word from the user to pass to the Driver class.
 * 
 * Valid word: Word has to be 4 letters or more. Cannot contain spaces,
 * numbers, or punctuations. The program will continue to ask for input
 * until a valid word is entered.
 * 
 *Error handling: The program uses a defensive programming to ensure 
 * the correct input is entered to get a valid word.
  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptWord
{
    class Main_Ew
    {
        //Prints out a short description of how the encryption program works.
        public void intro()
        {
            Console.WriteLine("Welcome to the encrypter! The machine will choose a key from 1-26 to encrypt " +
                "the word of your choice. \nPlease input a single word without spaces or punctuations " +
                "that is at least 4 letters. " +
                "You'll have the option to guess what the shift key was that was used to encrypt your word. " +
                "You also have the option to reset the encryption or decode to get your original word back. " +
                "You can encrypt as many words as you like. Let's Begin!");
            Console.WriteLine();
        }

        /*validWord()************************************************************************
        Input (cin): Ask user for a word to encrypt. Assuming the word is 4 letters or more with no
        spaces or punctuations. Uses defensive programming to ask user for another word
        if it doesn't meet requirements.
        Output: return a string if word passes all requirements.
        Design: Uses string methods to check for validity of word. */
        public string validWord()
        {
            string userWord;

            Console.WriteLine("What word would you like to encrypt? (Close program to quit): ");
            userWord = Console.ReadLine();
            int i = 0;

            while (userWord.Length < 4)
            {
                Console.WriteLine("Please input a word with at least 4 characters: ");
                userWord = Console.ReadLine();
            }

            bool isNotValid = true;
            while (isNotValid)
            {
                if (userWord.Any(char.IsDigit) || userWord.Any(char.IsPunctuation) || userWord.Contains(" "))
                {
                    Console.WriteLine("Please don't include punctuations or spaces. Try again: ");
                    userWord = Console.ReadLine();
                } else {
                    isNotValid = false;
                }
            }
            return userWord;
        }
    }
}
