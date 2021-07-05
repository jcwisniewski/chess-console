using Tabuleiro;

namespace Xadrez
{
    class Bishop : Piece
    {
        public Bishop(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] movementMatrix = new bool[board.rows, board.columns];
            Position positions = new Position(0, 0);

            //upside right
            positions.setValues(position.Row - 1, position.Column + 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }




                positions.setValues(positions.Row - 1, positions.Column + 1);

            }

            //downside right
            positions.setValues(position.Row + 1, position.Column + 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.setValues(positions.Row + 1, positions.Column + 1);




            }

            //upside left 
            positions.setValues(position.Row - 1, position.Column - 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.setValues(positions.Row - 1, positions.Column - 1);




            }

            //downside left
            positions.setValues(position.Row +1, position.Column - 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.setValues(positions.Row + 1, positions.Column - 1);




            }

            return movementMatrix;
        }
        

    }
}
