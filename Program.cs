﻿/*Each correct guess fills in that letter in the word. Guess too many wrong letters and the player loses.
Tips: It is all a matter of taking the letter the player guesses and looping through the word comparing it to
each letter in the word character by character. If the letters match, you show that letter to the player. 
If you reach the end of the word and no letters have been matched, it is a wrong guess.
Remember that strings are often treated as an array of characters. 
Most languages have a function to fetch a single letter from a string.
Keep track of how many wrong guesses the player has done and use this number to determine if the game has been won or lost.
Added Difficulty: Increase the length of the words and choose more complex unknown words to have the player guess.

//STEPS:
//write a block to determine if a character is part of a string
//write a block that outputs current state  of game (ex: _ _ N _ E _). Console.Clear() can help make things look better
//Look at Console.Readkey() to make things look nicer
//Pack all this in a loop and keep track of tries
*/
///Hangman is a game where a word is secretly chosen and the player guesses letters to fill in the word.
namespace hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //user has 6 tries to guess the word correctly
            const int NUMBER_OF_TRIES = 6;
            const int NO_MORE_GUESSES_LEFT = 0;
            Random rng = new Random();

            //Fill a list with possible words
            var hangmanWords = new List<string>(){"jazz", "buzz", "lightyear", "cloud", "quiz", "scatter", "die", "excuse",
            "zinc", "number", "lucky", "amber", "cherish", "brisk", "bounty", "chili", "chilly", "chili", "ghost", "gross",
             "harvest", "mask", "musk", "must", "parade", "plenty", "savory", "season", "spicy", "trail", "zesty", "zebra",
            "ocean", "sea", "kingkong", "pingpong", "abruptly", "absurd", "abyss", "affix"};
            int randomIndex = rng.Next(0, hangmanWords.Count + 1);

            Console.WriteLine("Welcome to Hangman!\n");
            //1 second delay
            System.Threading.Thread.Sleep(1000);
            int guessesLeft = NUMBER_OF_TRIES;

            //Get a random entry from the list
            Console.WriteLine("Selecting a random word...\n");
            //2 second delay
            System.Threading.Thread.Sleep(2000);

            //print random word
            string chosenWord = hangmanWords[randomIndex];

            //placeholder to store if user has guessed letters correctly
            string hiddenWord = string.Empty;
            int CHOSEN_WORD_INDEX = 0;
            while (CHOSEN_WORD_INDEX < chosenWord.Length)
            {
                hiddenWord += '_';
                CHOSEN_WORD_INDEX++;
            }

            Console.Write($"\nYou have {NUMBER_OF_TRIES} tries to guess all the letters of the chosen word!\n");

            //use while loop to track user's guesses
            //if user guesses a letter correctly, show letter in blank line
            //else, decrement Number of Tries
            //if user prints all letters before number of tries, say success!
            //if user reaches 0 tries before guessing every letter, print game over and show correct word!
            while (guessesLeft > NO_MORE_GUESSES_LEFT)
            {
                Console.WriteLine("\nPlease enter a letter: \n");
                //read a single letter from user
                char userGuess = Console.ReadKey().KeyChar;
                //once user enters letter, check if letter is in the randomly chosen word
                //if letter exists in the chosen word, find that specific letter in chosen word
                //then place that word in specific position of the string
                if (chosenWord.Contains(userGuess))
                {
                    Console.WriteLine(chosenWord.IndexOf(userGuess));
                }
                else
                {
                    //decrement guessesLeft if user enters incorrect letter
                    guessesLeft -= 1;
                    Console.WriteLine(hiddenWord);
                    Console.WriteLine($"\nSorry, the letter {userGuess} is not in the word!");
                    Console.WriteLine($"\nYou have {guessesLeft} guesses left!\n");
                }
                //if user guessed the correct word
                if (hiddenWord == chosenWord)
                {
                    Console.WriteLine(hiddenWord + "\n");
                    Console.WriteLine("Congratulations, you won the game!\n");
                    break;
                }
            }
            //show correct word if user runs out of guesses
            if (guessesLeft == 0)
            {
                Console.WriteLine("Sorry, Game Over!\n");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"The correct word is {chosenWord}.");
            }
        }
    }
}