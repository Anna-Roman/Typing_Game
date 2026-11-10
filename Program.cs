using System.Diagnostics;

namespace Typing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game rules and sentence to type
            string testSentence = "";
            int n = 0;
            
            Console.WriteLine("\n Typing Game!\n");
            do
            {
                switch (n)
                {
                    case 0:
                        testSentence = "There's a method to this madness";
                        break;
                    case 1:
                        testSentence = "Go back to the drawing board";
                        break;
                    case 2:
                        testSentence = "Long story short";
                        break;
                    case 3:
                        testSentence = "Your guess is as good as mine";
                        break;
                    case 4:
                        testSentence = "Birds of a feather flock together";
                        break;
                    case 5:
                        testSentence = "Live and learn";
                        break;
                    case 6:
                        testSentence = "Curiosity killed the cat";
                        break;
                }
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
            } while (n < 7);

            


            Console.WriteLine("\nThank you for playing!");
        }

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
