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
            for (int i = 0; i < 100; i++)
            {
                // Console.WriteLine(engine.getWord());
                string[] str = engine.getPuzzle();
                Console.WriteLine(str[0]+","+str[1]);
            }
        }        
        
    }
}
