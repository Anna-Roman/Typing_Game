using System.Diagnostics;

namespace Typing_Game
{
    internal class Program
    {
        // Define your sentences in an array at the class level
        static string[] sentences = {
            "There's a method to this madness",
            "Go back to the drawing board",
            "Long story short",
            "Your guess is as good as mine",
            "Birds of a feather flock together",
            "Live and learn",
            "Curiosity killed the cat"
        };
        static void Main(string[] args)
        {
            //Game rules and sentence to type
            
            int n = 0;
            
            Console.WriteLine("\n Typing Game!\n");
            do
            {
                // Call the method to get the sentence based on index 'n'
                string testSentence = GetSentence(n);

                Console.WriteLine("\nType the following sentence as fast as you can.");
                Console.WriteLine($"\n{testSentence}\n");

                //Wait for the user to start typing
                Console.WriteLine("Press any key to start!");
                Console.ReadKey();

                //Clear the screen, show the sentence
                Console.Clear();
                Console.WriteLine($"\n{testSentence}\n");
                Console.WriteLine("Start typing here: ");

                //Start a timer and capture the user's input
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                string userInput = Console.ReadLine() ?? "";

                //Stop the timer when the user finishes typing
                stopwatch.Stop();
                TimeSpan timeTaken = stopwatch.Elapsed;

                //Compare the sentences and count mistakes
                int errorCount = CountErrors(testSentence, userInput);

                //Show the time and the errors
                Console.WriteLine("\n--- Results ---");
                Console.WriteLine($"Time: {timeTaken.TotalSeconds:F2} seconds");
                Console.WriteLine($"Errors: {errorCount}");
                n++;
            } while (n < sentences.Length);
                       

            Console.WriteLine("\nThank you for playing!");
        }

        //method for choosing a sentence
        static string GetSentence(int index)
        {
            // Safety check to prevent out-of-bounds errors
            if (index >= 0 && index < sentences.Length)
            {
                return sentences[index];
            }
            return sentences[0]; // Fallback default
        }
        //method for counting errors
        static int CountErrors(string original, string typed)
        {
            int errors = 0;
            int minLength = Math.Min(original.Length, typed.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (original[i] != typed[i])
                    errors++;
            }
            errors += Math.Abs(original.Length - typed.Length);
            return errors;
        }
    }
}
