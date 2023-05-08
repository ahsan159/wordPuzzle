
namespace wordPuzzle
{
    public enum puzzleLevel
    {
        Novice,
        Beginner,
        Intermadiate,
        Expert
    }
    public class wordPuzzleEngine
    {
        private List<string> words = new List<string>();        
        public int max = -1;
        Random rnd = new Random();
        puzzleLevel level = puzzleLevel.Beginner;
        int maxWordLength = 4;
        public wordPuzzleEngine()
        {
            Console.WriteLine("Engine Constructor");
            words.Clear();
            loadDictionary("./oeDictionaryWords.txt");
            max = words.Count;
            level = puzzleLevel.Beginner;
            maxWordLength = 4;
        }
        ~wordPuzzleEngine()
        {
            Console.WriteLine("Engine Destructor");
        }
       public void setLevel(puzzleLevel lvl)
        {
            if(lvl==puzzleLevel.Novice)
            {
                maxWordLength = 4;
            }
            else if(lvl==puzzleLevel.Beginner)
            {
                maxWordLength = 10;
            }
            else if(lvl==puzzleLevel.Intermadiate)
            {
                maxWordLength = 20;
            }
            else if(lvl==puzzleLevel.Expert)
            {
                maxWordLength = 50;
            }
        }
        public void loadDictionary(string str)
        {
            words.Clear();
            string[] strWords = File.ReadAllLines(str);
            foreach(string s in strWords)
            {
                words.Add(s);
            }
        }

        public string getWord()
        {
            int length = 100;
            string retWord = "";
            while (length > maxWordLength) {
                int wInt = rnd.Next(max);
                retWord = words.ElementAt(wInt);
                length = retWord.Length;
            }            
            return retWord;
        }
    }
}