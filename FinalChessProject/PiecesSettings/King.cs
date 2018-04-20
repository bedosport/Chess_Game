using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalChessProject.BoardSettings;
namespace FinalChessProject.PiecesSettings
{
    class King : Piece
    {
        private int[] kingMovement = { 1, -1, 0, -1, -1, -1, -1, 0, -1, 1, 0, 1, 1, 1, 1, 0 };
        public King(Tuple<int, int> piecePosition, pieceType type, pieceColor color) : base(piecePosition, type, color)
        {

        }
        public override void firstMoveOccurred()
        {
            this.firstMove = true;
        }
        public override void setPiecePosition(int row, int col)
        {
            this.piecePosition = Tuple.Create(row, col);
        }
        public override List<Move> getLegalMovesWithCheck(Board board)
        {
            List<Move> kingMoves = new List<Move>();
            pieceColor currentPieceColor = board.getBoardPieces()[this.getPiecePosition().Item1, this.getPiecePosition().Item2].getPieceColor();
            for (int i = 0; i < kingMovement.Length; i += 2)
            {
                int DestinationRow = this.getPiecePosition().Item1 + kingMovement[i];
                int DestinationCol = this.getPiecePosition().Item2 + kingMovement[i + 1];
                if (Utility.isValidMove(DestinationRow, DestinationCol) &&
                        Utility.kingStillSafe(board, this.getPiecePosition(), Tuple.Create(DestinationRow, DestinationCol)))
                {

                    if (board.isEmptyCell(DestinationRow, DestinationCol))
                    {
                        kingMoves.Add(new NormalMove(Tuple.Create(DestinationRow, DestinationCol)));
                    }
                    else
                    {
                        pieceColor destinationPieceColor = board.getBoardPieces()[DestinationRow, DestinationCol].getPieceColor();
                        if (currentPieceColor != destinationPieceColor)
                            kingMoves.Add(new AttackMove(Tuple.Create(DestinationRow, DestinationCol)));

                    }
                }
            }
            return kingMoves;
        }
        public override List<Move> getLegalMovesWithoutCheck(Board board)
        {
            List<Move> kingMoves = new List<Move>();
            pieceColor currentPieceColor = board.getBoardPieces()[this.getPiecePosition().Item1, this.getPiecePosition().Item2].getPieceColor();
            for (int i = 0; i < kingMovement.Length; i += 2)
            {
                int DestinationRow = this.getPiecePosition().Item1 + kingMovement[i];
                int DestinationCol = this.getPiecePosition().Item2 + kingMovement[i + 1];
                if (Utility.isValidMove(DestinationRow, DestinationCol) )//&&
                {
                    if (board.isEmptyCell(DestinationRow, DestinationCol))
                    {
                        kingMoves.Add(new NormalMove(Tuple.Create(DestinationRow, DestinationCol)));
                    }
                    else
                    {
                        pieceColor destinationPieceColor = board.getBoardPieces()[DestinationRow, DestinationCol].getPieceColor();
                        if (currentPieceColor != destinationPieceColor)
                            kingMoves.Add(new AttackMove(Tuple.Create(DestinationRow, DestinationCol)));
                    }
                }
            }
            return kingMoves;
        }
    }
}
