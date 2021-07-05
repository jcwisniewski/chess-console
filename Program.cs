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
                    Console.Clear();
                    View.ShowBoardOnView(chessmatch.board);

                    Console.WriteLine("Origem: ");
                    Position source = View.ReadPositionKey().toPosition();

                    Console.WriteLine("Destino: ");
                    Position destiny = View.ReadPositionKey().toPosition();

                    chessmatch.PerformMove(source, destiny);
                }


                
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
          
        }

    
    }
}
