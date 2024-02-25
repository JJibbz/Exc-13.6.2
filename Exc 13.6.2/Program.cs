namespace Exc_13._6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\lino-\OneDrive\Рабочий стол\Text1.txt");
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            GetQuantityofWords(noPunctuationText);

        }

        static Dictionary<string, int> GetQuantityofWords(string text)
        {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = new HashSet<string>();
            var quantityOfWords = new Dictionary<string, int>();
            int counter;
            foreach (string word in words)
            {
                uniqueWords.Add(word);
            }
            
            foreach (string word in uniqueWords)
            {
                counter = 0;
                for (int i = 0; i < words.Length; i++)
                {
                    if (word == words[i])
                    {
                        counter++;
                    }
                }
                quantityOfWords.Add(word, counter);
            }
            return quantityOfWords;
        }

     
    }
}
