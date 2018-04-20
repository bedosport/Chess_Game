using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalChessProject.BoardSettings;
using FinalChessProject.PiecesSettings;
using System.Windows.Forms;
namespace FinalChessProject.PlayersSettings
{
    public class Computer
    {
        private static readonly int queenWeight = 900;
        private static readonly int rookWeight = 500;
        private static readonly int bishopWeight = 300;
        private static readonly int knightWeight = 300;
        private static readonly int pawnWeight = 100;
   

        private static int evaluateBestScore(Board board)
        {
           int[] piecesValues = new int[20];

            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                    if (!board.isEmptyCell(i, j))
                        ++piecesValues[board.getBoardPieces()[i, j].getPieceType()];

            int bestScore = rookWeight * (piecesValues[2] - piecesValues[1]) +
                knightWeight * (piecesValues[4] - piecesValues[3]) +
                bishopWeight * (piecesValues[6] - piecesValues[5]) +
                queenWeight * (piecesValues[8] - piecesValues[7]) +
                pawnWeight * (piecesValues[12] - piecesValues[11]);
            //MessageBox.Show(bestScore.ToString());
            return -bestScore;
        }
        public static Tuple<int, int, int, int> getBestMove(Board board,int depth)
        {
            int bestScore = -int.MaxValue,
                alphaValue = -int.MaxValue,
                betaValue = int.MaxValue;

            Tuple<int, int, int, int> bestMovePositions = Tuple.Create(-1, -1, -1, -1);
            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                {
                    if (board.isEmptyCell(i, j)) continue;
                    if (board.getBoardPieces()[i, j].getPieceColor() == pieceColor.BLack)
                    {
                        List<Move> currentPieceMove = board.getBoardPieces()[i, j].getLegalMovesWithCheck(board);
                        foreach (Move m in currentPieceMove)
                        {
                            Board tmpBoard = new Board(board);

                            Piece tmpPiece = tmpBoard.getBoardPieces()[i, j];

                            tmpPiece.setPiecePosition(m.getMovePosition().Item1, m.getMovePosition().Item2);
                            tmpBoard.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2] = tmpPiece;
                            tmpBoard.getBoardPieces()[i, j] = null;

                            int score = alphaBeta(new Board(tmpBoard), depth, alphaValue, betaValue, 1);

                            tmpPiece = tmpBoard.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2];
                            tmpPiece.setPiecePosition(i, j);
                            tmpBoard.getBoardPieces()[i, j] = tmpPiece;
                            tmpBoard.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2] = null;
                          //  MessageBox.Show(score.ToString());
                            if (score > bestScore)
                            {
                                bestScore = score;
                                bestMovePositions = Tuple.Create(i, j, m.getMovePosition().Item1, m.getMovePosition().Item2);

                            }
                        }
                    }
                }
            return bestMovePositions;
        }
        //0 white   1 black 
        private static int alphaBeta(Board board, int depth, int alphaValue, int betaValue, int player)
        {
            if (depth == 0)
                return evaluateBestScore(board);

            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                {
                    if (board.isEmptyCell(i, j) ||
                                          board.getBoardPieces()[i, j].getPieceColor() == pieceColor.White && player==0||
                                          board.getBoardPieces()[i, j].getPieceColor() == pieceColor.BLack && player==1)
                        continue;
                    List<Move> enemyLegalMoves = new List<Move>();
                    if (depth % 2 == 1)
                        enemyLegalMoves = board.getBoardPieces()[i, j].getLegalMovesWithoutCheck(board);
                    else
                        enemyLegalMoves = board.getBoardPieces()[i, j].getLegalMovesWithoutCheck(board);
                            

                    foreach (Move m in enemyLegalMoves)
                    {

                        Board tmpBoard = new Board(board);

                        Piece tmpPiece = tmpBoard.getBoardPieces()[i, j];

                        tmpPiece.setPiecePosition(m.getMovePosition().Item1, m.getMovePosition().Item2);
                        tmpBoard.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2] = tmpPiece;
                        tmpBoard.getBoardPieces()[i, j] = null;

                        if (player==0)
                        {
                            alphaValue = Math.Max(alphaValue, alphaBeta(new Board(tmpBoard), depth - 1, alphaValue, betaValue, 1));
                           
                        }
                        if (player==1)
                        {
                            betaValue = Math.Min(betaValue, alphaBeta(new Board(tmpBoard), depth - 1, alphaValue, betaValue, 0));
                        }

                        tmpPiece = tmpBoard.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2];
                        tmpPiece.setPiecePosition(i, j);
                        tmpBoard.getBoardPieces()[i, j] = tmpPiece;
                        tmpBoard.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2] = null;

                        if (alphaValue >= betaValue)
                            return player == 0 ? betaValue: alphaValue;
                    }
                }
            return player == 0 ? alphaValue : betaValue;
        }
    }
}
   
