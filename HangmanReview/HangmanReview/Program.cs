using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanReview
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman();
        }

        static void Hangman()
        {
            //declare variables
            var numberOfGuessessLeft = 7;
            List<string> wordBank = new List<string>() { "nickelback", "carrot" };
            Random rng = new Random();
            var wordToGuess = wordBank[rng.Next(0, wordBank.Count())];
            var lettersGuessed = string.Empty;
            bool isPlaying = true;

            //drives the game
            while (isPlaying == true)
            {
                DisplayRoundInfo(lettersGuessed, wordToGuess, numberOfGuessessLeft);
                string userInput = GetUserInput(lettersGuessed);
                if (userInput.Length == 1)
                {
                    lettersGuessed += userInput;
                    if (wordToGuess.Contains(userInput.ToLower()))
                    {
                        Console.WriteLine("That was right!");
                        if (!GetMaskedWord(lettersGuessed, wordToGuess).Contains("_"))
                        {
                            isPlaying = false;
                        }
                    }
                    else
                    {
                        numberOfGuessessLeft--;
                        Console.WriteLine("That was wrong!");
                        if (numberOfGuessessLeft == 0)
                        {
                            isPlaying = false;
                        }
                    }
                }
                else
                {
                    if (userInput.ToLower() == wordToGuess.ToLower())
                    {
                        isPlaying = false;
                        Console.WriteLine("Guessed right!");
                    }
                    else
                    {
                       numberOfGuessessLeft--;
                       Console.WriteLine("Wrong!");
                    }
                }
            }
            if (numberOfGuessessLeft != 0)
            {
                Console.Clear();
                Console.WriteLine("Word was: {0}\nYou Win!", wordToGuess);
                Console.ReadLine();
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("Word was: {0}\nYou fail!", wordToGuess);
                Console.ReadLine();
            }

                
        }

        static void DisplayRoundInfo(string lettersGuessed, string wordToGuess, int numberOfGuessesLeft)
        {
            Console.Clear();
            Console.WriteLine(GetMaskedWord(lettersGuessed, wordToGuess));
            Console.WriteLine("# of guesses left: {0}", numberOfGuessesLeft);
            Console.WriteLine("Letters guessed: {0}", lettersGuessed);
            Console.WriteLine("Your guess: ");
        }

        static string GetMaskedWord(string lettersGuessed, string wordToGuess)
        {
            string returnString = string.Empty;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                string currentLetter = wordToGuess[i].ToString().ToLower();
                if (lettersGuessed.Contains(currentLetter))
                {
                    returnString += currentLetter + " ";
                }
                else
                {
                    returnString += "_"+ " ";
                }
            }

            return returnString;

        }

        static string GetUserInput(string lettersGuessed)
        {
            string returnString;
            bool isValid = true;
            do
            {
                returnString = Console.ReadLine();
                if (returnString.Length == 0)
                {
                    isValid = false;
                }
                else if (returnString.Length == 1)
                {
                    isValid = (char.IsLetter(returnString[0]));
                    if (isValid)
                    {
                        isValid = !(lettersGuessed.Contains(returnString));
                    }
                }
            }

            while (isValid == false);
            {

            }
            return returnString;
        }
    }
}
