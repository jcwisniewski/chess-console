using Tabuleiro;

namespace Xadrez
{
    class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece piece = board.piece(position);
            return piece == null || piece.color != color;
        }

       

        public override bool[,] PossibleMoves()
        {
            bool[,] movementMatrix = new bool[board.rows, board.columns];
          
             Position positions = new Position(0,0);
            //upside
            positions.setValues(position.Row - 1, position.Column);
                if(board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //ne
            positions.setValues(position.Row - 1, position.Column + 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //right
            positions.setValues(position.Row, position.Column + 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //se
            positions.setValues(position.Row + 1, position.Column + 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //downside
            positions.setValues(position.Row + 1, position.Column);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //sl
            positions.setValues(position.Row + 1, position.Column - 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //left
            positions.setValues(position.Row, position.Column - 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            //nl
            positions.setValues(position.Row - 1, position.Column - 1);
            if (board.PositionValid(positions) && CanMove(positions))
            {
                movementMatrix[positions.Row, positions.Column] = true;
            }

            return movementMatrix;



        }
       

    }
}
