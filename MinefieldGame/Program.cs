namespace MinefieldGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            try
            {
                int mines = 16;
                int size = 8;
                int lives = 6;

                Game game = new Game(size);

                while (true)
                {
                    game.Help();
                    game.ReadyGame(lives, mines);

                    GameState result = game.Play();

                    if (!result.gameOver)  // existed game in progress
                    {
                        Console.WriteLine("Thanks for playing!");
                    }
                    else if (result.lives == 0) // lost all lives
                    {
                        Console.WriteLine("Unfortunately you run out of lives!");

                    }
                    else if (lives == result.lives)
                    {
                        Console.WriteLine("Amazing, you completed the game in {0} moves without losing any lives!", result.moves);
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You completed the game in {0} moves.", result.moves);
                    }

                    Console.WriteLine();
                    Console.Write("Play Again (y/n)? ");
                    char command = ' ';
                    while (command != 'y' && command != 'n')
                    {
                        command = Console.ReadKey().KeyChar;
                    }
                    Console.WriteLine();

                    if (command == 'n')
                        break;

                    Console.WriteLine();
                    Console.WriteLine("New game stated!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
