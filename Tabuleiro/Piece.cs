
namespace Tabuleiro
{
     abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movementQuantity { get; protected set; }
        public Board board { get; protected set; }


        public Piece( Color color, Board board)
        {
            this.position = null;
            this.color = color;
            this.board = board;
            this.movementQuantity = 0;
        }

        public void MovementIncrementation()
        {
            movementQuantity++;
        }

        public abstract bool[,] PossibleMoves(); 
    } 


}
