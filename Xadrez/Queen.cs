using Tabuleiro;

namespace Xadrez
{
    class Queen : Piece
    {
        public Queen(Color color, Board board) : base(color, board)
        {

        }

        public bool CanMove(Position position)
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
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.setValues(positions.Row - 1, positions.Column);

            }

            //ne
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

            //right
            positions.setValues(position.Row, position.Column + 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.setValues(positions.Row, positions.Column + 1);

            }

            //se
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

            //down
            positions.setValues(position.Row + 1, position.Column);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.setValues(positions.Row + 1, positions.Column);

            }

            //sw
            positions.setValues(position.Row + 1, position.Column - 1);
            while (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
                if (board.piece(positions) != null && board.piece(positions).color != color)
                {
                    break;
                }

                positions.setValues(positions.Row + 1, positions.Column - 1);



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

                positions.setValues(positions.Row, positions.Column - 1);

            }

            //nw
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


            return movementMatrix;
        }
        public override string ToString()
        {
            return "Q";
        }

    }
}
