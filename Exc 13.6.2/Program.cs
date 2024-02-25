using System.Collections;
using System.Collections.Generic;

namespace Exc_13._6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\lino-\OneDrive\Рабочий стол\Text1.txt");
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            GetTenMostUsedWords(GetQuantityofWords(noPunctuationText));

        }

        static Dictionary<string, int> GetQuantityofWords(string text)
        {
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var uniqueWords = new HashSet<string>();
            var quantityOfWords = new Dictionary<string, int>();
            int counter;
            foreach (string word in words) // получаем уникальные слова
            {
                uniqueWords.Add(word);
            }
            
            foreach (string word in uniqueWords) // находим уникальное слово в тексте, получаем частоту его использование в переменную counter и добавляем его в словарь.
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
        
        static void GetTenMostUsedWords(Dictionary<string, int> words)
        {
            var sortedDict = from entry in words orderby entry.Value descending select entry; // сортируем словарь по частоте использования слов (по убыванию)
            int counter = 0;
            foreach (var word in sortedDict) // выводим в консоль первые десять значений отсортированного словаря.
            {
                counter++;
                Console.WriteLine($"Слово {word.Key}, использовано {word.Value}");
                if (counter >= 10)
                    break;
            }
        }
    }
}
