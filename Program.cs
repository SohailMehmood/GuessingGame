using System;

namespace GuessingGame
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Random random = new();
            List<int> previousGuesses = new();
            bool playAgain = true;
            int min = 1;
            int max = 10;

            while (playAgain)
            {
                int guess = 0;
                int guesses = 0;

                int number = random.Next(min, max); 

                while (guess != number)
                {
                    Console.WriteLine($"Guess a number between {min} - {max}:");
                    string input = Console.ReadLine() ?? String.Empty;
                    bool isNumber = Int32.TryParse(input, out guess);

                    if (!isNumber || guess < 1 || guess > 10)
                    {
                        Console.WriteLine("Sorry the value entered was not a valid number!");
                    }                  

                    if (!previousGuesses.Contains(guess))
                    {
                        if (guess > number && guess <= 10)
                        {
                            Console.WriteLine($"{guess} is to high!");
                        }
                        else if (guess < number && guess > 0)
                        {
                            Console.WriteLine($"{guess} is to low!");
                        }

                        previousGuesses.Add(guess);
                        guesses++;
                    }
                    else if (previousGuesses.Contains(guess))
                    {
                        if (guess > number)
                        {
                            Console.WriteLine($"{guess} is to high!");
                        }
                        else if (guess < number)
                        {
                            Console.WriteLine($"{guess} is to low!");
                        }
                    }
                }
                Console.WriteLine($"Number: {number}");
                Console.WriteLine("YOU WIN!");
                Console.WriteLine($"Guesses: {guesses}");

                Console.WriteLine("Would you like to play again (Y/N): ");
                string response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();

                if (response == "Y")
                {
                    playAgain = true;
                    previousGuesses.Clear();
                }
                else
                {
                    playAgain = false;
                }
            }

            Console.WriteLine("Thanks for playing! ");
        }
    }
}