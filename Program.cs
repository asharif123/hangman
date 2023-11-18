///Hangman is a game where a word is secretly chosen and the player guesses letters to fill in the word.
/*Each correct guess fills in that letter in the word. Guess too many wrong letters and the player loses.
Tips: It is all a matter of taking the letter the player guesses and looping through the word comparing it to
each letter in the word character by character. If the letters match, you show that letter to the player. 
If you reach the end of the word and no letters have been matched, it is a wrong guess.
Remember that strings are often treated as an array of characters. 
Most languages have a function to fetch a single letter from a string.
Keep track of how many wrong guesses the player has done and use this number to determine if the game has been won or lost.
Added Difficulty: Increase the length of the words and choose more complex unknown words to have the player guess.

//STEPS:

//Get a random entry from the list
//write a block to determine if a character is part of a string
//write a block that outputs current state  of game (ex: _ _ N _ E _). Console.Clear() can help make things look better
//Look at Console.Readkey() to make things look nicer
//Pack all this in a loop and keep track of tries
*/
namespace hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Fill a list with possible words
            var hangmanWords = new List<string>(){"jazz", "buzz", "lightyear", "cloud", "quiz", "scatter", "die", "excuse",
            "zinc", "number", "lucky", "amber", "cherish", "brisk", "bounty", "chili", "chilly", "chili", "ghost", "gross", 
             "harvest", "mask", "musk", "must", "parade", "plenty", "savory", "season", "spicy", "trail", "zesty", "zebra",
            "ocean", "sea"};
        }
    }
}