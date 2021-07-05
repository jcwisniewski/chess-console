﻿using Tabuleiro;

namespace Xadrez
{
    class ChessMatch
    {
        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool finishedMatch {get; private set;}

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finishedMatch = false;
            AddPiecesOnBoard();
        }

        public void PerformMove(Position source, Position destiny)
        {
            Piece piece = board.RemovePiece(source);
            piece.MovementIncrementation();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);
        }

        private void AddPiecesOnBoard()
        {
            board.AddPiece(new Rook(Color.White, board), new ChessPosition('a',1).toPosition());
            board.AddPiece(new Knight(Color.White, board), new ChessPosition('b', 1).toPosition());
      
            board.AddPiece(new Rook(Color.Black, board), new ChessPosition('a', 8).toPosition());
            board.AddPiece(new Knight(Color.Black, board), new ChessPosition('b', 8).toPosition());
       


        }

    }
}
