using Tabuleiro;
using System;

namespace chess_console
{
     class View
    {
        public static void ShowBoardOnView(Board board)
        {
            for(int i=0; i < board.rows; i++)
            {
                Console.Write(8 - i + " ");
                for(int j=0; j < board.columns; j++)
                {
                    if(board.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ShowPieceOnView((board.piece(i, j)));
                        Console.Write(" ");

                    }
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
        }

        public static void ShowPieceOnView(Piece piece)
        {
            if(piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor consoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = consoleColor;
            }
        }
    }
}
