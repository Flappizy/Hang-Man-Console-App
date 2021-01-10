using System;
using System.Collections.Generic;
using System.Text;

namespace HangManApp
{
    class HumanGamePlayer
    {
        public static string PlayWithHuman()
        {
            string wordToBeGuessed = String.Empty;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                wordToBeGuessed += key.KeyChar;
            }
            return wordToBeGuessed.ToLower();
        }
    }
}
