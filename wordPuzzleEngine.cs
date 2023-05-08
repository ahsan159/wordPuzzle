
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
        //puzzleLevel level = puzzleLevel.Beginner;
        int maxWordLength = 4;
        int missingChars = 1;
        public wordPuzzleEngine()
        {
            Console.WriteLine("Engine Constructor");
            words.Clear();
            loadDictionary("./oeDictionaryWords.txt");
            max = words.Count;
            //level = puzzleLevel.Novice;
            maxWordLength = 10;
            missingChars = 3;
        }
        ~wordPuzzleEngine()
        {
            Console.WriteLine("Engine Destructor");
        }
        public void setLevel(puzzleLevel lvl)
        {
            if (lvl == puzzleLevel.Novice)
            {
                maxWordLength = 4;
                missingChars = 1;
            }
            else if (lvl == puzzleLevel.Beginner)
            {
                maxWordLength = 10;
                missingChars = 3;
            }
            else if (lvl == puzzleLevel.Intermadiate)
            {
                maxWordLength = 20;
                missingChars = 5;
            }
            else if (lvl == puzzleLevel.Expert)
            {
                maxWordLength = 50;
                missingChars = 10;
            }
        }
        public void loadDictionary(string str)
        {
            words.Clear();
            string[] strWords = File.ReadAllLines(str);
            foreach (string s in strWords)
            {
                words.Add(s);
            }
        }

        public string getWord()
        {
            int length = 100;
            string retWord = "";
            while (length > maxWordLength)
            {
                int wInt = rnd.Next(max);
                retWord = words.ElementAt(wInt);
                length = retWord.Length;
            }
            return retWord;
        }
        public string[] getPuzzle()
        {
            string wordCorrect = getWord();
            string[] retPuzzle = new string[2];
            int minMissingChars = missingChars<wordCorrect.Length?missingChars:wordCorrect.Length-1;
            int[] missingPositions = new int[minMissingChars];
            string wordPuzzle = wordCorrect;
            retPuzzle[0] = wordCorrect;
            int wordLen = wordCorrect.Length;
            bool distinct = false;
            while (!distinct)
            {
                for (int i = 0; i < minMissingChars; i++)
                {
                    missingPositions[i] = rnd.Next(wordLen);
                }
                if (missingPositions.Distinct().Count() == missingPositions.Count())
                {
                    distinct = true;
                }
            }
            foreach (int i in missingPositions)
            {
                wordPuzzle = wordPuzzle.Remove(i,1);
                wordPuzzle = wordPuzzle.Insert(i,"_");
            }
            retPuzzle[1] = wordPuzzle;
            return retPuzzle;
        }
    }
}