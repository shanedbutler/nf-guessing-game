namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int guessCount = 1;

            // Instantiate random number generator and set an int randomly from 1 - 100.
            var rand = new Random();
            int secretNum = rand.Next(1, 100);

            int guessAttempts = selectDifficulty();

            Console.WriteLine("I'm thinking of a number from 1 to 100");
            Console.WriteLine($"You have {guessAttempts} guesses to get it right");

            while (guessCount <= guessAttempts)
            {
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
                        Console.WriteLine("Try again, but maybe lower");
                        guessCount++;
                    }
                    else if (guessNum < secretNum)
                    {
                        Console.WriteLine($"No, {guessNum} isn't it");
                        Console.WriteLine("Try again, but maybe higher");
                        guessCount++;
                    }
                }
                catch
                {
                    Console.WriteLine($"This \"{guessInput}\" isn't a valid guess. Did you enter a number? Try again.");
                }
            }
        }
        public static int selectDifficulty()
        {
            string[] menuOptions = new string[] { "Easy\t", "Medium\t", "Hard\t", "Cheater\t" };
            int menuSelect = 0;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("---- Guessing Game ----\n");
                Console.WriteLine("Select difficulty level");

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine((i == menuSelect ? "* " : "") + menuOptions[i] + (i == menuSelect ? "<--" : ""));
                }

                var keyPressed = Console.ReadKey();

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
