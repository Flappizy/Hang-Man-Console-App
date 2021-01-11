using System;
using System.Collections.Generic;
using System.Text;

namespace HangManApp
{
    class TestProgram
    {
        static void Main()
        {
            int player = GamePlayer.ChooseGamePlayer();
            string wordToBeGuessed = string.Empty;
            switch (player)
            {
                case 0:
                    wordToBeGuessed = GamePlayerComputer.PlayWithComputer();
                    break;
                case 1:
                    wordToBeGuessed = HumanGamePlayer.PlayWithHuman();
                    break;
            }

            GamePlay.PlayGame(wordToBeGuessed);
        }
    }
}
