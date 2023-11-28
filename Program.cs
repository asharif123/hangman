/*Each correct guess fills in that letter in the word. Guess too many wrong letters and the player loses.
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
            const int STARTING_INDEX_OF_UNDERLINE = 0;
            Random rng = new Random();

            //Fill a list with possible words
            var hangmanWords = new List<string>(){"jazz", "buzz", "lightyear", "cloud", "quiz", "scatter", "die", "excuse",
            "zinc", "number", "lucky", "amber", "cherish", "brisk", "bounty", "chili", "chilly", "chili", "ghost", "gross",
             "harvest", "mask", "musk", "must", "parade", "plenty", "savory", "season", "spicy", "trail", "zesty", "zebra",
            "ocean", "sea", "kingkong", "pingpong", "abruptly", "absurd", "abyss", "affix"};
            int randomIndex = rng.Next(0, hangmanWords.Count);

            Console.WriteLine("Welcome to Hangman!\n");
            //1 second delay
            System.Threading.Thread.Sleep(1000);
            int guessesLeft = NUMBER_OF_TRIES;

            //Get a random entry from the list
            Console.WriteLine("Selecting a random word...\n");
            //2 second delay
            System.Threading.Thread.Sleep(2000);

            //print random word
            //no need to store as array since it is not being modified
            string chosenWord = hangmanWords[randomIndex];
            
            //placeholder to store if user has guessed letters correctly
            int length = chosenWord.Length;
            char[] hiddenWord = new char[length];
            for (int startingIndex = STARTING_INDEX_OF_UNDERLINE; startingIndex < length; startingIndex++)
            {
                hiddenWord[startingIndex] = '_';
            }
            Console.WriteLine(hiddenWord);
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
                char userGuess = Char.ToLower(Console.ReadKey().KeyChar);

                //once user enters letter, check if letter is in the randomly chosen word
                //use foreach method to iterate through each element in an array
                foreach (char letter in chosenWord)
                {
                    if (letter == userGuess)
                    {
                        //if letter is found in chosenWord, get index of letter                        
                        int indexOfLetter = chosenWord.IndexOf(letter);
                        //replace the '_' with letter if guessed correctly
                        hiddenWord[indexOfLetter] = letter;
                        Console.WriteLine(hiddenWord);
                    }
                }

                //if letter is not in the chosen word
                if (!chosenWord.Contains(userGuess))
                {
                    Console.WriteLine($"\nSorry, {userGuess} is not in the word!\n");
                    guessesLeft -= 1;
                    Console.WriteLine($"You have {guessesLeft} guesses left!\n");
                }

                //if user guesses all letters correctly, compare array of hidden and chosen words
                bool isEqual = Enumerable.SequenceEqual(hiddenWord, chosenWord.ToCharArray());
                if (isEqual)
                {
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