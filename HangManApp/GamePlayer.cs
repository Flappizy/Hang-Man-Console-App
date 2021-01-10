using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HangManApp
{
    class GamePlayer
    {
        public static int ChooseGamePlayer()
        {
            Console.WriteLine("Choose player to play with, enter [0] for computer or [1] for human player");
            int player = int.Parse(Console.ReadLine());
            Console.Clear();
            if ((player != 0) && (player != 1))
            {
                Console.WriteLine("Player does not exist for such input. Check input");
                ChooseGamePlayer();
                Console.Clear();
            }
            return player;
        }
    }    
}