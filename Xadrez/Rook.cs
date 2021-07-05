using Tabuleiro;

namespace Xadrez
{
    class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {


        }

        public override string ToString()
        {
            return "R";
        }
        private bool CanMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != this.color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] movementMatrix = new bool[board.rows, board.columns];
     
            Position positions = new Position(0, 0);

            //upside
            positions.setValues(position.Row - 1, position.Column);
            while(board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if(board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.Row = positions.Row - 1;
            }

            //down
            positions.setValues(position.Row + 1, position.Column);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.Row = positions.Row + 1;
            }

            //right
            positions.setValues(position.Row, position.Column + 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.Column = positions.Column + 1;
            }

            //left
            positions.setValues(position.Row, position.Column - 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.Column = positions.Column - 1;
            }

            return movementMatrix;
        }
      

    }
}
