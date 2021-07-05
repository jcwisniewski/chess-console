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
            Position position = new Position(0, 0);
            //upside
            position.setValues(position.Row - 1, position.Column);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.Row = position.Row - 1;
            }

            //ne
            position.setValues(position.Row - 1, position.Column + 1);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }
                position.Row = position.Row - 1;
                position.Column = position.Column + 1;
            }

            //right
            position.setValues(position.Row, position.Column + 1);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.Column = position.Column + 1;
            }

            //se
            position.setValues(position.Row + 1, position.Column + 1);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.Row = position.Row + 1;

                position.Column = position.Column + 1;
            }

            //down
            position.setValues(position.Row + 1, position.Column);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.Row = position.Row + 1;
            }

            //sw
            position.setValues(position.Row + 1, position.Column - 1);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.Row = position.Row + 1;

                position.Column = position.Column - 1;


            }


            //left
            position.setValues(position.Row, position.Column - 1);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.Column = position.Column - 1;
            }

            //nw
            position.setValues(position.Row - 1, position.Column - 1);
            while (board.PositionValid(position) && CanMove(position))
            {
                movementMatrix[position.Row, position.Column] = true;
                if (board.piece(position) != null && board.piece(position).color != color)
                {
                    break;
                }

                position.Column = position.Column - 1;
            }


            return movementMatrix;
        }
        public override string ToString()
        {
            return "Q";
        }

    }
}
