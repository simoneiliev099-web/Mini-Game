Console.WriteLine("GUESS THE NUMBER");
Console.WriteLine("Welcome to the game!");

int highScore = 0;
bool playAgain = true;

while (playAgain)
{
    Console.WriteLine();
    Console.WriteLine("1. Start Game");
    Console.WriteLine("2. Exit");
    Console.Write("Choose an option: ");

    if (!int.TryParse(Console.ReadLine(), out int number))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        continue;
    }

    if (number == 1)
    {
        int maxNumber = ChooseDifficulty();

        if (maxNumber == 0)
        {
            continue;
        }

        int attempts = PlayGame(maxNumber);

        if (highScore == 0 || attempts < highScore)
        {
            highScore = attempts;
            Console.WriteLine($"New high score: {highScore} attempts!");
        }
        else
        {
            Console.WriteLine($"Current high score: {highScore} attempts.");
        }

        Console.WriteLine();
        Console.Write("Play again? (y/n): ");

        string? answer = Console.ReadLine();

        if (answer?.ToLower() == "n")
        {
            playAgain = false;
        }
    }
    else if (number == 2)
    {
        Console.WriteLine("Goodbye!");
        playAgain = false;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 1 or 2.");
    }
}

Console.WriteLine("Thanks for playing!");


static int ChooseDifficulty()
{
    Console.WriteLine();
    Console.WriteLine("Choose difficulty:");
    Console.WriteLine("1. Easy (1-50)");
    Console.WriteLine("2. Medium (1-100)");
    Console.WriteLine("3. Hard (1-500)");
    Console.Write("Choose an option: ");

    if (!int.TryParse(Console.ReadLine(), out int difficulty))
    {
        Console.WriteLine("Invalid input. Please enter a number.");
        return 0;
    }

    if (difficulty == 1)
    {
        return 50;
    }
    else if (difficulty == 2)
    {
        return 100;
    }
    else if (difficulty == 3)
    {
        return 500;
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        return 0;
    }
}


static int PlayGame(int maxNumber)
{
    Random random = new Random();

    int secretNumber = random.Next(1, maxNumber + 1);

    Console.WriteLine();
    Console.WriteLine("Starting game...");
    Console.WriteLine($"I have chosen a number between 1 and {maxNumber}.");

    int attempts = 0;
    int guessNumber = 0;

    while (guessNumber != secretNumber)
    {
        Console.Write("Guess a number: ");

        if (!int.TryParse(Console.ReadLine(), out guessNumber))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }

        if (guessNumber < 1 || guessNumber > maxNumber)
        {
            Console.WriteLine($"Please enter a number between 1 and {maxNumber}.");
            continue;
        }

        attempts++;

        if (guessNumber < secretNumber)
        {
            Console.WriteLine("Too low! Try again.");
        }
        else if (guessNumber > secretNumber)
        {
            Console.WriteLine("Too high! Try again.");
        }
        else
        {
            Console.WriteLine("Congratulations! You guessed the number!");
            Console.WriteLine($"It took you {attempts} attempts.");
        }
    }

    return attempts;
}