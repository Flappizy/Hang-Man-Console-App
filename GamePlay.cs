using System;
using System.Collections.Generic;
using System.Text;

namespace HangManApp
{
    class GamePlay
    {
        private const int Size_Of_HangMan_Array = 11;
        private static StringBuilder guessedLetters = new StringBuilder();
       
        //This method checks if a letter passed to it is present in a set of letters that is also passed to it as argument
        private static Dictionary<int, char> CompareLetters(char[] word, char letter)
        {
            Dictionary<int, char> tempIndexArchive = new Dictionary<int, char>();
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == letter)
                {

                    tempIndexArchive.Add(i, letter);
                }
            }
            return tempIndexArchive;
        }

        private static void DrawHangMan(int guessNumber)
        {
            string topOfGallow = "________________";
            Console.WriteLine(topOfGallow);

            string[] hangman = {"|              | \n", "|              | \n", "|              O \n", "|              | \n",
                "|              | \n", "|             / ",  "\\             \n", "|              | \n",  "|              | \n",
                "|             / ", "\\ \n" };

            for (int i = 0; i < guessNumber; i++)
            {
                Console.Write(hangman[i]);
            }
            string bottomOfgallow = "_______";
            Console.WriteLine(bottomOfgallow);
        }

        //This Method keeps track of the letters guessed by the user corect or not
        private static string GuessedLetters(char letter)
        {
            guessedLetters.Append(letter);
            guessedLetters.Append(" ");
            string word = guessedLetters.ToString();
            return word;
        }

        //This method fills a collection passed to it with underscore
        private static void FillCollectionWithUnderscore(List<char> correctGuessedLetters)
        {
            for (int i = 0; i < correctGuessedLetters.Capacity; i++)
            {
                correctGuessedLetters.Add('_');
            }
        }
        public static void PlayGame(string word)
        {
            char[] letters = word.ToCharArray();
            List<char> guessedLetters = new List<char>(letters.Length);
            FillCollectionWithUnderscore(guessedLetters);

            int hangManIndex = 1; //This variable keeps track of what part of the hang man to draw next
            int added = 0; //this variable helps to monitor the count of correctly guessed letters

            while (hangManIndex < 12)
            {

                Console.WriteLine("Start Guessing : ");
                char letter = Console.ReadKey().KeyChar; //reads each letter guessed by user
                if (guessedLetters.Contains(letter))
                {
                    Console.WriteLine(" Letter is already present in your words");
                    Console.WriteLine();
                    continue;
                }
                Console.Clear();
                Dictionary<int, char> currentLetter = CompareLetters(letters, letter); // checks if letter is present in word

                if (currentLetter.Count == 0)   
                {
                    Console.WriteLine("Oops wrong guess");
                    Console.WriteLine("Player's guesses so far --> " + GuessedLetters(letter)); // writes out guessed letters so far, correct or not
                    PrintCorrectlyGuessedLettersSoFar(guessedLetters);

                    if (hangManIndex == Size_Of_HangMan_Array)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, You lost this round");
                        string lettersInString = new string(letters);
                        Console.WriteLine("The correct word is {0}", lettersInString);
                    }
                    else
                    {
                        DrawHangMan(hangManIndex);
                        Console.WriteLine();
                    }

                    CheckGameStatus(hangManIndex);
                    hangManIndex++;
                }
                else
                {
                    int count = FillLetterInBlankSpace(currentLetter, guessedLetters);
                    added = added + count;
                    Console.WriteLine("Correct Guess, keep going");
                    Console.WriteLine("Player's guesses so far --> " + GuessedLetters(letter)); // writes out guessed letters so far, correct or not
                    PrintCorrectlyGuessedLettersSoFar(guessedLetters);

                    Console.WriteLine();
                    if (added == letters.Length)
                    {
                        Console.WriteLine("CONGRATS!!! YOU HAVE WON THIS ROUND!!!");
                        break;
                    }
                    else if (CheckGameStatus(hangManIndex))
                    {
                        Console.WriteLine("Sorry, You lost this round");
                        Console.WriteLine("The correct word is {0}", letters.ToString());
                        break;
                    }
                }
            }
        }

        //This method keeps count of correctly guessed letters
        private static int FillLetterInBlankSpace(Dictionary<int, char> correctLetters, List<char> guessedLetters)
        {
            int added = 0; //this variable helps to monitor the count of correctly guessed letters
            foreach (var item in correctLetters)
            {
                guessedLetters[item.Key] = item.Value;
                added++;
            }
            return added;
        }

        //This method checks if the game have been won or lost
        private static bool CheckGameStatus(int hangMan)
        {
            if (hangMan == Size_Of_HangMan_Array)
            {
                DrawHangMan(hangMan);
                return true;
            }
            return false;
        }
        
        //This method takes a collection and prints its content
        private static void PrintCorrectlyGuessedLettersSoFar(List<char> word)
        {
            Console.Write("Correct guessed letters so far : ");
            foreach (char item in word)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
