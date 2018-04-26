/*Author: Nina Nguyen
 *Filename: EncryptWord in C#
 *Date: 4/22/2018
 *Version: 2 
 * 
 */

/*
 Description: This program ask the user for a word and generate a random shift
 key to encrypt the word. The user can choose to guess what the shift key was
 or not. Statistics will be generated if they chose to guess.
 The user can then choose to decode (return original word), reset (clear the 
 object and stats), encrypt a new word, or quit the encryption program.
 
 The user can make as many queries as they like to guess what the shift value
 is. They will enter "-1" to quit guessing. The program will return 
 statistics (# of guesses made, high guesses, low guesses, and the average
 guess value).

 Anticipated use: To take in a valid word and encrypted it. A little game may
                  be played to guess shift key.

 Legal states: On (true) - when a valid word is pass through the shift function after
              object is initialize. Cannot change to a different word during 
              the run of Object.
			  
                Off (false) - Object is in an off state until shift function is called 
                with valid word passed through.  It is also off when the user 
                wants the original word returned by calling decode or when the 
                object is reset. Decode will retain any guessing stats but reset 
                will return the object to it's original state. The field "state" 
                is set to false once decode() or reset() is called.
                
State transition: Goes from "on" to "off" when shift(), decode(), or reset()
                   is called.
                   Goes from "off" to "on" when object is first created.

Legal and illegal input (condition enforced by complier): 
			Word to encrypt - only a valid word can be passed to constructor and 
            return the correct encryption according to Shift Key. Program will 
            encrypt with invalid words but can't guarantee expected/correct output. 
			queryShift() - Only positive integers will be passed through driver 
            program, except -1 is used as SENTINEL value. QueryShift is not designed 
            to handle illegal inputs. Stat() will print the statistics. decode() 
            and reset() only called from the driver. 

Class Invariants: the field member "state" keeps track of the state of the object
                  throughout the lifetime of the run. It is set to true (on) after
                  shift(string) and false (off) during construction and after
                  decode().
			
Assumptions: Constructor will initilize all private fields - ints to 0 and string to
            empty. Fields increase or reset according to public functions call in the 
            driver.
            Object can only encrypt one word at a time, may be reset. 
			Array used to store alphabet is set in size, will not be able to add 
            or remove elements.
			State transitions goes from off to on after shift() and on to off 
            after reset() and decode().
			reset() can be called anytime, will only reset the state from on to
            off once no matter the initial state.
			reset() should only be called in constructor and toggle after the 
            encryption.
			decode() and queryshift(int) can't be called unless state is "on",
            after the shift(string) is called. Will rely on 
			isOn() to determine state. Will allow client class to access if 
            isOn() returns "true".
			stat() can only be called when numOfGuess is not 0 and state is "off"
			getShiftValue() is only used for testing
            */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encryptWord
{
    class EncryptWord
    {

        //constructor, initialize private fields by calling reset(). Initial 
        //state is off.
        //all int and strings are empty after every construction call
        public EncryptWord()
        {
            reset();
        }

        //take a string parameter and shift the word by the shift value
        //pre: state has to be off, will encrypt the passed string. String 
        //     validity done in client program
        //post: state becomes on after word gets encrypted
        public string shift(string wordToShift) //doing the actual shift
        {
      
            Random random = new Random();
            shiftValue = random.Next(1, 26); //generate number from 1 to 26
            
            word = wordToShift;
            string temp = startEncrypt(wordToShift); //shift word to lowercase
            for (int i = 0; i <= temp.Length - 1; i++)
            {
                for (int j = 0; j < ALPHABET_INDEX; j++)
                {
                    if (temp[i] == ALPHABET[j])
                    {
                        StringBuilder sb = new StringBuilder(temp);
                        sb[i] = ALPHABET[(j + shiftValue) % 26]; //the actual encrypting
                        temp = sb.ToString();
                        break;//need it to break "if" loop after finding match
                    }
                }
            }
            state = true;
            return temp;
        }

        //takes an int from client program to guess the shift value generated
        //by the program
        //pre: states has to be on to guess
        //post: none - doesn't change state, update member variables accordingly
        public bool queryShift(int guess)
        {
            //if guess does not equal the random number used to shift the alphabet, return false
            if (guess == -1)
            { //doesn't increase number of guesses
                Console.WriteLine("Thank you for playing.");
                return true;
            }
            if (highGuess == 0 && lowGuess == 0)
            { //set initial highGuess and lowGuess value to first guess value
                highGuess = guess;
                lowGuess = guess;
            }

            if (guess == shiftValue)
            {
                Console.WriteLine("You guessed the shift key!");
                if (highGuess < guess)
                {
                    highGuess = guess;
                }
                else if (lowGuess > guess)
                {
                    lowGuess = guess;
                }
                averageValue += guess;
                numOfGuesses++;
                return true;
            }
            else
            {//(guess != shiftValue)
                if (highGuess < guess)
                {
                    highGuess = guess;
                }
                else if (lowGuess > guess)
                {
                    lowGuess = guess;
                }
                averageValue += guess;
                numOfGuesses++;
                return false;
            }
        }

        //return shift value generated by program. Used for testing purposes
        //pre: none
        //post: none
        public int getShiftValue()
        {
            return shiftValue;
        }

        //allow user to get the original word. Change the state of the the program to "off"
        //pre: encrypt state to be on to call this function
        //post: return orginal word, change of state to off
        public string decode()
        {
            state = false;
            return word;
        }

        //print out the high guess, low guess, and average value of guesses
        //pre: Can be called during on or off states, or when numOfGuesses is 0. 
        //     Assuming the state to be off when numOfGuesses is 0.
        //post: no changes to state, prints out stat
        public void stats()
        {
            if (numOfGuesses != 0)
            {
                Console.WriteLine("Correct shift key is: {0}", shiftValue);
                Console.WriteLine("Highest guess is: {0}", highGuess);
                Console.WriteLine("Lowest guess is: {0}", lowGuess);
                Console.WriteLine("Average shift value guess rounded is: {0}", averageValue / numOfGuesses);
            }

        }

        //clear the current object, reset all stats
        //pre: state can be on or off
        //post: legal state becomes off, all fields are reset, becomes initial 
        //      state when object was created
        public void reset()
        {
            word = "";
            lowGuess = 0;
            highGuess = 0;
            averageValue = 0;
            numOfGuesses = 0;
            shiftValue = 0;
            state = false;
        }

        //allow user to get the state of the object - return true or false
        //pre: none
        //post: none
        public bool isOn()
        {
            return state;
        }

        //make word all lowercase
        //pre: none
        //post: none
        private string startEncrypt(string wordToLower)
        {
            return wordToLower.ToLower();
        }

        private string word; //word passed through constructor
        private int shiftValue; //random number between 1-26 generated by the program
        private int highGuess; //hold the highest guess value from user
        private int lowGuess; //hold the lowest guess value from user
        private int numOfGuesses; //count the number of guesses conducted by user
        private int averageValue; //total up all the value of guesses to get average guess value
        private const int ALPHABET_INDEX = 26; //number of letters in the alphabet
        private const string ALPHABET = "abcdefghijklmnopqrstuvwxyz"; //string of alphabet
        private bool state; //keeps track of the current object state

    }
}
