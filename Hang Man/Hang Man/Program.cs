using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hang_Man
{
    class Program
    {
        static void Main(string[] args)
        {
            //call the greetplayer function, and check to see if he or she wants to play
            GreetPlayer();

            //call the hangman function to start game
            HangMan();

            Console.ReadKey();
        }

        static void HangMan()
        {
            //an empty string to store the randomly selected word
            string wordPick = "";
            //a list string variable to hold the user input
            //List<string> userInput = new List<string>();
            //a boolean value to store false for gameSolved            
           // bool wordGuessed = false;
            //an integer variable to store the number of tries player has to guess right word 
            int numTries = wordPick.Length + 3;
            //call the Random constructor 
            Random rwg = new Random();
            bool keepPlaying = true;
            //declare a new variable List string data type that holds our list of items
            string[] storedWords = new string[] { "function", "result", "random", "display" };
            //store the value of the randomly selected word from List in the empty string variable
            wordPick = storedWords[rwg.Next(0, storedWords.Length)];
            //declare an empty string to store the characters entered by the user
            string userGuess = "";
            //a for loop to loop through the given word and add _ for ever letter found.
            //for (int i = 0; i < wordPick.Length; i++)
            //{
            //    hidWord.Add('_');
            //    Console.Write(" " + hidWord);
            //}

            while (keepPlaying)
            {
                Console.WriteLine(DisplayMaskedWord(wordPick, userGuess));
                Console.WriteLine("Guess a letter");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput.Length == 1)
                {
                    userGuess += userInput;
                    if (wordPick.Contains(userInput))
                    {
                        Console.WriteLine("Good job");
                        if (LettersGuessed(DisplayMaskedWord(wordPick, userGuess)))
                        {
                            keepPlaying = false;
                            Console.WriteLine("You won!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bad job");
                        numTries--;
                    }
                }
                else
                {
                    if (wordPick == userInput)
                    {
                        Console.WriteLine("You won!");
                        keepPlaying = false;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect");
                        numTries--;
                    }
                }
                if (numTries == 0)
                {
                    keepPlaying = false;
                    Console.WriteLine();
                }
            }


        }

        static string DisplayMaskedWord(string word, String letterGuessed)
        {
            //declare an empty string variable to store the final string to be returned by the function
            string returnedWord = "";

            //a while loop to loop through the picked word and check for match with the player picked letter
            //loop from 0 until i is less than the value of the length of the word
            for (int i = 0; i < word.Length; i++)
            {
                //take the first letter from the word in the loop, change it to string and store it in 
                //the string variable letter
                char letter = word[i];
                //check if the condition that the letter from the loop is contained in the letter guessed
                if (letterGuessed.ToUpper().Contains(Char.ToUpper(letter)))
                {
                    //if the above condition is true add that letter to the empty string returnedWord
                    returnedWord += letter;
                }
                //if the above condition is false execute else
                else
                {
                    //if else is executed instead of if add _ to the string returnedWord
                    returnedWord += "_ ";
                }
            }
            //after the loop end return this string value to the HangMan function
            return returnedWord;

        }

        static bool LettersGuessed(string displayMaskedWord)
            {
                if (displayMaskedWord.Contains("_"))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

            static void GreetPlayer()
            {
                //greet player, ask for name and print to console a personalized greeting with 
                //the input from player returned with the greeting
                Console.WriteLine("What is your name, friend?");
                //take the input from player and store in the string variable input
                string input = Console.ReadLine();
                Console.WriteLine("Welcome to my game " + input + "!");
                Console.WriteLine();
                //take the input from player and print on to the console if they want to play or no
                Console.WriteLine("\nDo you want to play HangMan, " + input + "? Yes/No");
                //Give player the choice of whethere to play or not, and depending on the choice run the following if/else statement
                if (Console.ReadLine() == "yes".ToString().ToLower())
                {
                    //if they choose to play give them the following instructions on how to play hangman
                    Console.WriteLine();
                    Console.WriteLine("***************************");
                    Console.WriteLine("Great! Let's play then!" +
                        "\n***************************" +
                        "\nHere are the rules: " +
                        "\nYou will be guessing a word" +
                        "\nEither guess the correct word or" +
                        "\nGuess the letters one a time.");
                    Console.WriteLine("***************************");
                    Console.WriteLine("If you're ready Press any key to continue");
                    Console.WriteLine("Guess the word, or enter a letter to play." +
                        "\nYou have " + "numsGuess" + " tries to get it right");
                    Console.WriteLine();
                }
            }
    }
       

}


