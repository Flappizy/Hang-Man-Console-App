using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HangManApp
{
    class GamePlayerComputer
    {
        public static string PlayWithComputer()
        {
            List<string> listOfWords = new List<string>();
            string filePath = "TextFile1.txt";
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    listOfWords.Add(line);
                    line = reader.ReadLine();
                }
            }
            Random random = new Random();
            int randomIndex = random.Next(0, listOfWords.Count);
            string randomWord = listOfWords[randomIndex];
            return randomWord;
        }
    }
}
