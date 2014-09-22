using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {

        static void Main(string[] args)
        {

            DisplayHighScores();
            //call the greetplayer function, and check to see if he or she wants to play
            GreetPlayer();

            //call the hangman function to start game
           // HangMan();

            Console.ReadKey();
        }

        static void HangMan()
        {
            //declare a new variable List string data type that holds our list of items
            List<string> storedWords = new List<string> { "function", "result", "random", "display" };
            //call the Random constructor 
            Random rng = new Random();
            //declare an integer variable randomPick to store the randomly picked index from the List
            int randomPick = rng.Next(0, storedWords.Count);
            //declare a string variable to store the value of the randomly selected word from List
            string wordPick = storedWords[randomPick];
       
          
            //a boolean value to store false for gameSolved            
            bool gameSolved = false;            
            //an integer variable to store the number of tries player has to guess right word 
            int numTries = wordPick.Length + 3;   
            
            //play while the bool value gameSolved is false.
            //when it becomes true the game has been solved and therefore true, so game ends.              
            while (gameSolved == false)              
            {                
                string userGuess = Console.ReadLine();    
                string DisplayWord = DisplayMaskedWord(userGuess, wordPick);
      
                if (!DisplayWord.Contains("_ "))
                
                {         
                    gameSolved = true;                   
                    Console.WriteLine("You win");                 
                }                
                else               
                {                
                    Console.WriteLine("Lose");                    
                }                
            }
        }
        //create a function named DisplayMaskedWord that accepts two string values as parameters
        static string DisplayMaskedWord(string letterGuessed, string word)
        {
            //declare an empty string variable to store the final string to be returned by the function
            string returnedWord = "";

            //a while loop to loop through the picked word and check for match with the player picked letter
            int i = 0;
            //loop from 0 until i is less than the value of the length of the word
            while (i < word.Length)
            {
                //take the first letter from the word in the loop, change it to string and store it in 
                //the string variable letter
                string letter = word[i].ToString();
                //check if the condition that the letter from the loop is contained in the letter guessed
                if (letterGuessed.Contains(letter))
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
                
                //increment i by 1 
                i++;
            }

            //after the loop end return this string value to the HangMan function
            return returnedWord;


        }

        //create a GreetPlayer function to greet player and pass on instructions
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
                HangMan();
            }
               
            //if they choose to not play print goodbye to the console 
            else
            {
                Console.WriteLine("Well, that's too bad! Maybe next time! GOOD BYE!");
            }
           

        }


        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("Your Name");
                string playerName = Console.ReadLine();
            OwenEntities db = new OwenEntities();
            HighScore newHighScore = new HighScore();
            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Game = "HangMan";
            newHighScore.Name = playerName;
            newHighScore.Score = playerScore;

            db.HighScores.Add(newHighScore);
            db.SaveChanges();
        }

        static void DisplayHighScores()
        {
            Console.Clear();
            Console.WriteLine("HangMan");
            Console.WriteLine("-------");
            OwenEntities db = new OwenEntities();
            List<HighScore>highScoresList = db.HighScores.Where(x => x.Game == "HangMan").OrderByDescending(x => x.Score).Take(10).ToList();
            foreach (HighScore highScore in highScoresList)
	{
		 Console.WriteLine("{0}, {1} - {2} on {3}", highScoresList.IndexOf(highScore) + 1 , highScore.Name, highScore.Score);
	}
        }

    }
        
}

    
