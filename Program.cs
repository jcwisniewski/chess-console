using System;
using Tabuleiro;
using Xadrez;
using Exceptions;

namespace chess_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {

                
                ChessMatch chessmatch = new ChessMatch();

                while (!chessmatch.finishedMatch)
                {
                    try
                    {
                        Console.Clear();
                        View.PrintChessMatch(chessmatch);
                        Console.WriteLine("Origem: ");
                        Position source = View.ReadPositionKey().toPosition();
                        chessmatch.ValidateSourcePosition(source);


                        bool[,] possibleMoves = chessmatch.board.piece(source).PossibleMoves();

                        Console.Clear();
                        View.ShowBoardOnView(chessmatch.board, possibleMoves);

                        Console.WriteLine();
                        Console.WriteLine("Destino: ");
                        Position destiny = View.ReadPositionKey().toPosition();
                        chessmatch.ValidateDestinyPosition(source, destiny);

                        chessmatch.PerformPlay(source, destiny);

                    }catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                    
                }
                Console.Clear();

                View.PrintChessMatch(chessmatch);


                
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
          
        }

    
    }
}
