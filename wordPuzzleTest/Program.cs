// See https://aka.ms/new-console-template for more information
//using System.Data;
//using wordPuzzleEngine.wordPuzzleEngine;
using wordPuzzle;
namespace Program
{
    class Program
    {
        public static void Main(string[] args)
        {
            wordPuzzleEngine engine = new wordPuzzleEngine();
            engine.setLevel(puzzleLevel.Beginner);
            Console.WriteLine("Engine Started");
            for (int i = 0; i < 10; i++)
            {
                // Console.WriteLine(engine.getWord());
                string[] str = engine.getPuzzle();
                Console.WriteLine(str[0] + "," + str[1]);
            }

            bool continueGame = true;
            while (continueGame)
            {
                string[] str = engine.getPuzzle();
                Console.WriteLine(str[0]);
                string puzzle = str[1];
                Console.WriteLine(puzzle);
                do
                {
                    Console.Write(puzzle + " Enter Key: ");
                    char guess = char.Parse(Console.ReadLine());
                    int index = puzzle.IndexOf('_');
                    try
                    {
                        puzzle = puzzle.Remove(index, 1);
                        puzzle = puzzle.Insert(index, guess.ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine(puzzle);
                } while (!engine.checkPuzzle(puzzle));
                Console.WriteLine("Continue?? (Press 0 to exit)");
                int i = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    continueGame = false;
                }
            }
        }

    }
}
