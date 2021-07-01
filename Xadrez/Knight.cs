﻿using Tabuleiro;

namespace Xadrez
{
    class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {

        }
        public override string ToString()
        {
            return "Kn";
        }

    }
}
