using System;

namespace GuessingGame
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Random random = new();
            List<int> list = new();
            bool playAgain = true;
            int min = 1;
            int max = 10;


            while (playAgain)
            {
                int guess = 0;
                int guesses = 0;
                int number = random.Next(min, max + 1);

                while (guess != number)
                {
                    Console.WriteLine("Guess a number between " + min + " - " + max + " : ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Guess: " + guess);

                    if (!list.Contains(guess))
                    {
                        if (guess > number)
                        {
                            Console.WriteLine(guess + " is to high!");
                        }
                        else if (guess < number)
                        {
                            Console.WriteLine(guess + " is to low!");
                        }

                        list.Add(guess);
                        guesses++;
                    }
                    else if (list.Contains(guess))
                    {
                        if (guess > number)
                        {
                            Console.WriteLine(guess + " is to high!");
                        }
                        else if (guess < number)
                        {
                            Console.WriteLine(guess + " is to low!");
                        }
                    }
                }
                Console.WriteLine("Number: " + number);
                Console.WriteLine("YOU WIN!");
                Console.WriteLine("Guesses: " + guesses);

                Console.WriteLine("Would you like to play again (Y/N): ");
                string response = Console.ReadLine() ?? String.Empty;
                response = response.ToUpper();

                if (response == "Y")
                {
                    playAgain = true;
                    list.Clear();
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