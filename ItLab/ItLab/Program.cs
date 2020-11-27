using System;
using System.Collections.Generic;
using System.IO;

namespace ItLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ukoliko se pokrece u VS code-u, tad ide ova adresa!
            //string filePath = Directory.GetCurrentDirectory() + "/Test/test.txt";

            //Ukoliko se pokrece u VS, tad ide ova adresa!
            //string filePath = Directory.GetCurrentDirectory() + "/../../../Test/test.txt";
            Console.WriteLine("Insert file path");
            string filePath = Console.ReadLine();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine().Trim();
                        char[] delimiterChars = { ' ', '\t', ',', ':', ';', '!', '?', '.', '"', '\'' };
                        string[] words = line.Split(delimiterChars);

                        foreach (var word in words)
                        {
                            if (word.Length > 1)
                                if (dictionary.ContainsKey(word.ToLower()))
                                    dictionary[word.ToLower()]++;
                                else
                                    dictionary.Add(word.ToLower(), 1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            foreach (KeyValuePair<string, int> word in dictionary)
            {
                Console.WriteLine("{0} - {1}", word.Key, word.Value);
            }
            return;
        }
    }
}
