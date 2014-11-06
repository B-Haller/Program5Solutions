using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {   //global vars to allow other functions to use
        //new list containg letterguesses
        static List<string> lettersGuess = new List<string>();
        //new random number generator
        static Random rng = new Random();
        //new list with words to use
        static List<string> wordList = new List<string>(){"comrade", "vodka", "russia", "tank", "communism", "homeland", "soviet", "sacrafice", "red", "hammer","sickle"};
        //new var that takes word randomly from word list
        static string wordToBeGuessed = wordList[rng.Next(0,wordList.Count())];


        static void Main(string[] args)
        {
            Hangman();
        }
        /// <summary>
        /// plays hangman
        /// </summary>
        static void Hangman()
        {
            //set vars including bool and guess attempts
            bool isPlaying = true;
            var guessAttempts = 7;
            //this var is added for additional flex later on if I choose
            var totalGuesses = 0;
            //greet and read and store player's name, then clear
            Console.WriteLine("Welcome Comrade.\nTo the Soviet Re-education System, Version Perfect.\nPlease enter your Glorious name:\n");
            var userName = Console.ReadLine();
            Console.Clear();
            //instructions
            Console.WriteLine("Welcome Comrade {0}!\n\nThis simulator is similar to that of the inferior American Hangman. " +
            "\nExcept, in this version, you have {1} attempts to be reintegrated into\n\n\t\t\t" +
            "Glorious Soviet Union!\n\nThere are words that every great citizen must have in their vocabulary." +
            "\nYou may attempt to guess whole word or letter.\nAnd, if applicable, your brain function will be studied."+
            "\n\nOtherwise, Comrade {0}, I hear Siberia is...how you say...\nunpleasant."+
            "\n\nPress enter Comrade if you have been educated to read.", userName, guessAttempts);
            Console.ReadLine();
            Console.Clear();
            //display mask letter and number of attempts remaining
            Console.WriteLine(MaskedLetter());
            Console.WriteLine("Number of attempts left: {0}\n\n", guessAttempts);
            //will keep playing until satified
            while (isPlaying == true)
            {
                //will keep guessing until guesses are 0 or until guessed letters equal word
                while (guessAttempts > 0 || MaskedLetter().Contains(wordToBeGuessed))
                {
                    //clear console, display masked letter, give prompt
                    Console.Clear();
                    Console.WriteLine(MaskedLetter() + "\n");
                    Console.WriteLine("\nPlease try and prove an example of Soviet Patriotism and guess either a letter\nor a word. Then enter.\n");
                    //keep letters guessed on screen
                    lettersGuess.ForEach(Console.Write);
                    //space
                    Console.WriteLine();
                    //assign user input
                    var userInput = Console.ReadLine();
                    //checking if character or word
                    if (userInput.Length == 1)
                    {   //it does, check user input against word
                        if (wordToBeGuessed.Contains(userInput.ToLower()))
                        {   //increment guesses, telling player it was correct, adding user input to list
                            totalGuesses++;
                            Console.WriteLine("\nCongratulations, Comrade {0}! You have guessed correctly.\n", userName);
                            lettersGuess.Add(userInput.ToLower());
                            //setting conditions to break loop if word was guessed
                            if (MaskedLetter().Contains(wordToBeGuessed))//(lettersGuess.ToString().Contains(wordToBeGuessed))
                            {
                                //it was guess, so tell user and break out of loop
                                Console.WriteLine(wordToBeGuessed + " was correct!\n\nPress enter to recieve important message.");
                                Console.ReadLine();
                                break;
                            }
                            //press enter to return to top of loop
                            Console.WriteLine("\nPress enter to continue training.\n");
                            Console.ReadLine();
                            
                           
                        }
                        //user input did not contain letter
                        else
                        {
                            //increment guesses, and subtract attempt
                            totalGuesses++;
                            guessAttempts--;
                            //add input to guess list
                            lettersGuess.Add(userInput.ToLower());
                            //results and attempts left
                            Console.WriteLine("\nComrade {0}, you have failed. You have {1} attempts left.\n" +
                            "I hear Siberia is...how you say...\ngetting closer.", userName, guessAttempts);                            
                            Console.WriteLine("\n\nPress enter to confirm brain function\n");
                            Console.ReadLine();
                            
                            
                        }
                        //write list of guessed words
                        lettersGuess.ForEach(Console.Write);
                        Console.WriteLine();
                        
                    
                    }
                    //was not a letter
                    else
                    {   //checking to see if word guessed equals word to be guessed
                        if(userInput.Equals(wordToBeGuessed))
                        {
                            //it does, tell user, increment guesses, change bool to false
                            Console.WriteLine("\nComrade {0}!\n\nYou have performed according to the standards set forth!\nNo Siberia for you! Your word was: {1}", userName, wordToBeGuessed);
                            totalGuesses++;
                            isPlaying = false;
                            Console.WriteLine("\n\nPress enter to confirm your acceptance of Citizenship!\n");
                            Console.ReadLine();
                            Console.Clear();
                            //break out of loop
                            break;
                            
                        }
                        //it was not the right word
                        else
                        {
                            //increment total guesses, decrease attempts, tell user
                            totalGuesses++;
                            guessAttempts--;
                            Console.WriteLine("\nIt is a sad day in Mother Russia.\nYour Re-education is failing expectations.\n" +
                            "\n\nYou have {0} attempts remaining before you...how you say...\nyou get bitten by frost in Siberia.", guessAttempts);
                            Console.WriteLine("\n\nPress enter to confirm administrator has not used emergency gun.\n");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                 
               }
                //clear console
                Console.Clear();
                //conditions to tell if win or lose, if guesss left is zero, player loses
                 if (guessAttempts == 0)
                 {
                     //is playing becomes false, display fail message
                     isPlaying = false;
                     Console.WriteLine("It is Siberia for you!\nYou American Spy Pig.\nHow you say...\nyou will freeze in cold place for long time!");
                     Console.ReadLine();       
                 }
                 //player won
                 else
                 {
                     //is playing become false, display success kid message
                     isPlaying = false;
                     Console.WriteLine("Remember Comrade {0}:\n{1} is an important word in good citizen lexicon.\n\n", userName, wordToBeGuessed);
                     Console.WriteLine("You are good Soviet citizen! Stalin will think of you.\nPerhaps.\n\nNow no more game!\n\nBack to factory, Comrade {0}!", userName);
                     Console.ReadLine();      
                 }
                 
            }

            
       }

            

            
        
        /// <summary>
        /// masks our guessed word
        /// </summary>
        /// <returns>masked word</returns>
        static string MaskedLetter()
        {
            //create string and making it empty
            var stringReturn = "";
            //loop through our word to be guessed
            for (int i = 0; i < wordToBeGuessed.Length; i++)
            {
                //if our list of guessed letters contains a letter in word to be guess
                if (lettersGuess.Contains(wordToBeGuessed[i].ToString()))
                {
                    //it does, so add that letter to string
                    stringReturn += (wordToBeGuessed[i]);
                    
                }
                else
                {
                    //it does not, so populate with dashes
                    stringReturn += "-";
                    
                }
            }
            return stringReturn;
        }
    }
}
