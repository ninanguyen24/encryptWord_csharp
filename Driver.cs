/*Author: Nina Nguyen
 *Filename: Driver.cs in C#
 *Date: 4/22/2018
 *Version: 1
 * 
 */

/*Description and anticipated use: This program ask the user for a word and 
 * generate a random shift key to encrypt the word. The user can choose to 
 * guess what the shift key was or not. Statistics will be generated if they 
 * chose to guess. The user can then choose to decode (return original word), 
 * reset (clear the object and stats), encrypt a new word, or quit the 
 * encryption program. 
 * 
 * Data Stucture used: List for EncryptWord objects and Array for string comparison
Class used: Encryptword and Main class for intro and getting valid input from user

Assumptions: Program is used to encrypt a valid word by ultilizing the 
encapsulated EncryptWord class. User input through Console.ReadLine should 
be entered as asked even with defensive programming in placed. For valid word
size of string has to be more than 4, does not include spaces or punctuations. 
For responses, "yes" or "no" should be entered, case sensitive. And input 
integers when asked.

Public functions that are explicitly called by the driver are shift(),
queryShift(), stat(), reset(), and decode()
Can have many objects added to list, no size limit.

Error Handling: There are defensive programming in placed to prevent incorrect inputs.
However, user should enter in inputs as required.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptWord
{
    class Driver
    {
        static void Main(string[] args)
        {
            Main_Ew mainInDriver = new Main_Ew();
            EncryptWord ew = new EncryptWord();
            mainInDriver.intro();
           

            List<EncryptWord> encryptWord = new List<EncryptWord>();

            int i = 0;
            bool keepPlaying = true;
            while (keepPlaying)
            {
                encryptWord.Add(ew);
                string wordToEncrypt = mainInDriver.validWord(); //Get valid word from Main Class
                //********testing, remove after
                Console.WriteLine("state: " + encryptWord[i].isOn());
                Console.Write("The encrypted word is: ");
                Console.WriteLine(encryptWord[i].shift(wordToEncrypt));
                //*******testing, remove after
                Console.WriteLine("state: " + encryptWord[i].isOn());
                //cout << "Shift Value: " << encryptWord[i].getShiftValue() << endl; //For testing only

                string userResponse;

                Console.WriteLine("Do you you want to guess what the key value that was " +
                    "used in the shift? (Enter \"yes\" or \"no\"): ");
                userResponse = Console.ReadLine();

                if (userResponse == "yes" || userResponse == "Yes")
                {
                    if (encryptWord[i].isOn())
                    { //if the state is "on"
                        
                        Console.WriteLine("What do you think the shift value is?");
                        Console.WriteLine("Hint, it's between 1-26. (input -1 to quit): ");
                        var validGuess = Console.ReadLine();
                        var guessValue = int.Parse(validGuess);

                        bool guessNotValid = true;
                        while (guessNotValid) {

                            if (guessValue < 0 && guessValue != -1)
                            {//make sure the user input an integer
                                Console.WriteLine("Invalid input. Please enter a postive integer: ");
                                validGuess = Console.ReadLine();
                                guessValue = int.Parse(validGuess);
                            }
                            else
                            {
                                guessNotValid = false;
                            }
                        }
                        while (!encryptWord[i].queryShift(guessValue))
                        {
                            Console.WriteLine("It's wrong, please try again (input -1 to quit): ");
                            validGuess = Console.ReadLine();
                            guessValue = int.Parse(validGuess);
                        }
                        encryptWord[i].stats();
                    }
                    else
                    { //if the state is "off"
                        Console.WriteLine("There are no stats to report.");
                    }
                }
                else if (userResponse == "no" || userResponse == "No")
                {
                    Console.WriteLine("Okay, that's fine.");
                    encryptWord[i].stats();
                }
                else
                {
                    Console.WriteLine("Invalid response. The program will continue without guessing.");
                    encryptWord[i].stats();
                }

                Console.WriteLine("Do you want to decode or reset?");
                Console.WriteLine("Enter \"1\" for decode, \"2\" for reset or \"3\" to create a new encrypt word.");
                Console.WriteLine("Enter anything else to quit.");
                userResponse = Console.ReadLine();
                if (userResponse == "1")
                {
                    Console.WriteLine("The decode word is: " + encryptWord[i].decode());
                }
                else if (userResponse == "2")
                {
                    Console.WriteLine("Reset has been triggered.");
                    encryptWord[i].reset();
                    encryptWord[i].stats();//to show that stats were also reset
                }
                else if (userResponse == "3")
                {
                    Console.WriteLine("Let's start over and create a new word.");
                }
                else
                {
                    keepPlaying = false;
                }
                i++;
                Console.WriteLine();
            }
        }
    }
}
