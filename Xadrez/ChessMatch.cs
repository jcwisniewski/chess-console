using Tabuleiro;

namespace Xadrez
{
    class ChessMatch
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public  Color currentPlayer { get; private set; }
        public bool finishedMatch {get; private set;}

        public ChessMatch()
        {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finishedMatch = false;
            AddPiecesOnBoard();
        }

        private void ChangePlayer()
        {
            if(currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }
        }

        public void PerformMove(Position source, Position destiny)
        {
            Piece piece = board.RemovePiece(source);
            piece.MovementIncrementation();
            Piece capturedPiece = board.RemovePiece(destiny);
            board.AddPiece(piece, destiny);
        }

        public  void PerformPlay(Position source, Position destiny)
        {
            PerformMove(source, destiny);
            turn++;
            ChangePlayer();
        }

        private void AddPiecesOnBoard()
        {
           
            board.AddPiece(new King(Color.White, board), new ChessPosition('c', 1).toPosition());
            board.AddPiece(new Bishop(Color.White, board), new ChessPosition('c', 2).toPosition());
            board.AddPiece(new Rook(Color.White, board), new ChessPosition('d', 2).toPosition());
            board.AddPiece(new Knight(Color.White, board), new ChessPosition('f', 1).toPosition());
            board.AddPiece(new Queen(Color.White, board), new ChessPosition('g', 1).toPosition());
            board.AddPiece(new Pawn(Color.White, board), new ChessPosition('h', 1).toPosition());






            board.AddPiece(new King(Color.Black, board), new ChessPosition('c', 8).toPosition());
            board.AddPiece(new Bishop(Color.Black, board), new ChessPosition('c', 7).toPosition());
            board.AddPiece(new Rook(Color.Black, board), new ChessPosition('d', 8).toPosition());
            board.AddPiece(new Knight(Color.Black, board), new ChessPosition('c', 6).toPosition());
            board.AddPiece(new Queen(Color.Black, board), new ChessPosition('g', 8).toPosition());
            board.AddPiece(new Pawn(Color.Black, board), new ChessPosition('h', 8).toPosition());






        }

    }
}
