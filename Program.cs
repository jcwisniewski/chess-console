using System;
using Tabuleiro;

namespace chess_console
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Board bd = new Board(8, 8);
            View.ShowBoardOnView(bd);
        }

    
    }
}
