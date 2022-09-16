namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int min = 1;
            int max = 100;

            // Instantiate random number generator and set an int randomly from 1 - 100.
            Random rand = new Random();
            int secretNum = rand.Next(min, max);

            int guessAttempts = selectDifficulty();

            Console.WriteLine($"I'm thinking of a number from {min} to {max}");
            Console.WriteLine($"You have {guessAttempts} guesses to get it right");

            int guessCount = 1;

            while (guessCount <= guessAttempts)
            {
                if (guessCount > 1)
                {
                    Console.WriteLine("Try again!");
                }

                Console.WriteLine($"\nEnter guess {guessCount}/{guessAttempts}: ");
                string? guessInput = Console.ReadLine();

                try
                {
                    int guessNum = int.Parse(guessInput);

                    if (guessNum == secretNum)
                    {
                        Console.WriteLine("Hm that's correct... How did you know that?");
                        break;
                    }
                    else if (guessNum > secretNum)
                    {
                        Console.WriteLine($"No, {guessNum} isn't it");
                        Console.WriteLine("My number is lower");
                        guessCount++;
                    }
                    else if (guessNum < secretNum)
                    {
                        Console.WriteLine($"No, {guessNum} isn't it");
                        Console.WriteLine("My number is higher");
                        guessCount++;
                    }
                }
                catch
                {
                    if (guessInput == "")
                    {
                        Console.WriteLine("You forgot to enter a number!");
                    }
                    else
                    {
                        Console.WriteLine($"\"{guessInput}\" isn't a valid guess. Did you enter a number? Try again.");
                    }
                }
            }
            Console.WriteLine($"My number was {secretNum}!");
        }
        public static int selectDifficulty()
        {
            string[] menuOptions = new string[] { "Easy ", "Medium ", "Hard ", "Cheater " };
            int menuSelect = 0;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("---- Guessing Game ----\n");
                Console.WriteLine("Select difficulty level");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine(menuOptions[i] + (i == menuSelect ? "<--" : ""));
                }

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                {
                    menuSelect++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                {
                    menuSelect--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    switch (menuSelect)
                    {
                        case 0:
                            return 8;
                        case 1:
                            return 6;
                        case 2:
                            return 4;
                        case 3:
                            return 100;
                        default:
                            return 6;
                    }
                }
            }
        }
    }
}
