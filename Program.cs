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
            const int STARTING_INDEX_OF_WORD = 0;
            const char UNDERLINE = '_';
            Random rng = new Random();
            //Fill a list with possible words
 
            var hangmanWords = new List<string>(){"jazz", "buzz", "lightyear", "cloud", "quiz", "scatter", "die", "excuse",
            "zinc", "number", "lucky", "amber", "cherish", "brisk", "bounty", "chili", "chilly", "chili", "ghost", "gross",
             "harvest", "mask", "musk", "must", "parade", "plenty", "savory", "season", "spicy", "trail", "zesty", "zebra",
            "ocean", "sea", "kingkong", "pingpong", "abruptly", "absurd", "abyss", "affix", "axiom", "cobweb", "askew",
             "avenue", "awkward", "azure", "bagpipes", "bandwagon", "beekeeper", "blizzard", "bookworm", "jest", "buffalo",
            "buffoon", "buzzing", "caliph", "cobweb", "croquet", "curacao", "crypt", "cycle", "daiquiri", "disavow", "duplex",
            "dwarves", "embezzle", "empty", "equip", "espionage", "exodus", "fakery", "faking", "fishhook", "flapjack",
            "flopping", "flyby", "foxglove", "fuchsia", "funny", "galaxy", "galvanize", "gazebo", "glamour", "grandeur",
            "gnarly", "gossip", "hyphen", "haphazard", "icebox", "injury", "ivory", "jackpot", "jaundice", "jaywalk", "jigsaw",
            "jockey", "joking", "juicy", "jumbo", "kayak", "kazoo", "keyhole", "knapsack", "lengths", "luxury", "lymph",
            "matrix", "mystify", "mighty", "numbskull", "nimrod", "onyx", "ovary", "oxidize", "oxygen", "pajama", "quartz",
             "quizzes", "rhythm", "rhino", "racecar", "scratch", "sphinx", "staff", "strength", "stretch", "stymied",
            "subway", "swindle", "swipe", "transcript", "testing", "transgress", "truckdriver", "twelfth", "twizzle",
             "twinkle", "unzip", "unwrap", "unworthy", "vixen", "vodka", "voodoo", "vortex", "wave", "wavy", "waxy", "wheel",
            "yellow", "yummy", "yacht", "zephyr", "zigzag", "zygote", "zipper", "zodiac", "zombie", "sprite", "eleven", "twelve",
            "wizard", "xylephone", "xantham", "xray", "xerox"};
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

            //print length of randomly chosen word to use as blueprint to create underlines;
            int length = chosenWord.Length;
            //create char array with for loop to create array of '_';
            char[] hiddenWord = new char[length];

            for (int indexOfUnderline = STARTING_INDEX_OF_UNDERLINE; indexOfUnderline < length; indexOfUnderline++)
            {
                hiddenWord[indexOfUnderline] = UNDERLINE;
            }
            Console.Write($"\nYou have {NUMBER_OF_TRIES} tries to guess all the letters of the chosen word!\n");

            //use while loop to track user's guesses
            //if user guesses a letter correctly, show letter in blank line
            //else, decrement Number of Tries
            //if user prints all letters before number of tries, say success!
            //if user reaches 0 tries before guessing every letter, print game over and show correct word!
            while (guessesLeft > NO_MORE_GUESSES_LEFT)
            {
                //show hiddenword as user inputs correct/incorrect letters
                Console.WriteLine(hiddenWord);
                Console.WriteLine("\nPlease enter a letter: \n");
                //read a single letter from user
                char userGuess = Char.ToLower(Console.ReadKey().KeyChar);
                //create newline when user enters letter, or else letter inputted will be adjacent to hiddenWord
                Console.WriteLine();

                //once user enters letter, check if letter is in the randomly chosen word by looping chosen word
                //if found replace underline with letter
                for (int indexOfWord = STARTING_INDEX_OF_WORD; indexOfWord < length; indexOfWord++)
                {
                    if (userGuess == chosenWord[indexOfWord])
                    {
                        hiddenWord[indexOfWord] = userGuess;
                    }
                }

                //if letter is not in the chosen word
                if (!chosenWord.Contains(userGuess))
                {
                    Console.WriteLine($"\nSorry, {userGuess} is not in the word!\n");
                    guessesLeft -= 1;
                    Console.WriteLine($"You have {guessesLeft} guesses left!\n");
                }

                //if there are no more underlines in hiddenWord, user has won the game
                if (!hiddenWord.Contains(UNDERLINE))
                {
                    Console.WriteLine($"The word is {chosenWord}. Congratulations, you won the game!\n");
                    break;
                }
            }

            //show correct word if user runs out of guesses
            if (guessesLeft == NO_MORE_GUESSES_LEFT)
            {
                Console.WriteLine("Sorry, Game Over!\n");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"The correct word is {chosenWord}.");
            }
        }
    }
}