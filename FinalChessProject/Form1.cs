
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalChessProject.BoardSettings;
using FinalChessProject.PiecesSettings;
using FinalChessProject.PlayersSettings;
namespace FinalChessProject
{
    public partial class Form1 : Form
    {

        private Board board = new Board();
        private HumanPlayer player;
        private List<Move> whitePlayerLegalMoves, blackPlayerLegalMoves;
        private List<Piece> whitePlayerActivePieces, blackPlayerActivePieces;
        private List<Move> tmp = new List<Move>();
        private int mouseClickCounter = 0, bCol = 0, bRow = 0, wCol = 0, wRow = 0;
        private Tuple<int, int> originalPiecePosition;
        private Bitmap piecesImage, killedImageFromBlack, killedImageFromWhite;
        private Graphics graphics, killedGraphFromWhite, killedGraphFromBlack;
        private bool whiteMoveOccurred, blackMoveOccurred, humanVsHuman;
        private int gameDifficulty;
        private Dictionary<int, Bitmap> pieceImage = new Dictionary<int, Bitmap>
                  {
                    {11, new Bitmap(Properties.Resources.bPawn)},
                    {1, new Bitmap(Properties.Resources.bRock)},
                    {3, new Bitmap(Properties.Resources.bKnight)},
                    {5, new Bitmap(Properties.Resources.bBishop)},
                    {7, new Bitmap(Properties.Resources.bQueen)},
                    {9, new Bitmap(Properties.Resources.bKing)},
                    {12, new Bitmap(Properties.Resources.wPawn)},
                    {2, new Bitmap(Properties.Resources.wRock)},
                    {4, new Bitmap(Properties.Resources.wKnight)},
                    {6, new Bitmap(Properties.Resources.wBishop)},
                    {8, new Bitmap(Properties.Resources.wQueen)},
                    {10, new Bitmap(Properties.Resources.wKing)}
                };


        public Form1()
        {
            InitializeComponent();
            panel2.Hide();
            pictureBox1.Parent = boardBox;
        }

        private void updateBoard()
        {
            if (piecesImage == null)
                piecesImage = new Bitmap(512, 512);
            if (graphics == null)
                graphics = Graphics.FromImage(piecesImage);
            else
                graphics.Clear(Color.Transparent);

            int[,] boardTypes = board.getBoard();
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (boardTypes[r, c] != 0)
                        graphics.DrawImage(pieceImage[boardTypes[r, c]], new Rectangle(c * 64, r * 64, 64, 64));
                }
            }

            pictureBox1.Image = piecesImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
           
            panel1.Visible = true;
            killedpiecesofwhiteplayer.Visible = true;
            killedpiecesofblackplayer.Visible = true;
            humanVsHuman = false;
            blackPlayerLegalMoves = initBlackPlayerMoves();
            whitePlayerLegalMoves = initWhitePlayerMoves();
            player = new WhitePlayer();
            updateBoard();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gameDifficulty = 1;
            label2.Visible = false;
            boardBox.Visible = true;
            pictureBox1.Visible = true;
            panel2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gameDifficulty = 2;
            label2.Visible = false;
            boardBox.Visible = true;
            pictureBox1.Visible = true;
            panel2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gameDifficulty = 3;
            label2.Visible = false;
            boardBox.Visible = true;
            pictureBox1.Visible = true;
            panel2.Visible = false;
        }

        private void KilledFromWhite(int ptype)
        {
            if (killedImageFromWhite == null)
                killedImageFromWhite = new Bitmap(192, 448);
            if (killedGraphFromWhite == null)
                killedGraphFromWhite = Graphics.FromImage(killedImageFromWhite);
            killedGraphFromWhite.DrawImage(pieceImage[ptype], new Rectangle(wCol * 64, wRow * 64, 64, 64));
            killedpiecesofwhiteplayer.Image = killedImageFromWhite;
            ++wCol;
            if (wCol == 3)
            { wCol = 0; ++wRow; }
        }

        private void KilledFromBlack(int ptype)
        {
            if (killedImageFromBlack == null)
                killedImageFromBlack = new Bitmap(192, 448);
            if (killedGraphFromBlack == null)
                killedGraphFromBlack = Graphics.FromImage(killedImageFromBlack);
            killedGraphFromBlack.DrawImage(pieceImage[ptype], new Rectangle(bCol * 64, bRow * 64, 64, 64));
            killedpiecesofblackplayer.Image = killedImageFromBlack;
            ++bCol;
            if (bCol == 3)
            { bCol = 0; ++bRow; }
        }

        private void hightlightLegalMoves(List<Move> legalMoves)
        {
            foreach (Move m in legalMoves)
            {
                int r = m.getMovePosition().Item1, c = m.getMovePosition().Item2;
                graphics.DrawImage(Properties.Resources.Select, new Rectangle(c * 64, r * 64, 64, 64));
            }
            pictureBox1.Image = piecesImage;
        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            int x = e.Y / 64, y = e.X / 64;
            if (humanVsHuman)
            {
                if (player.getPlayerColor() == playerColor.White)
                {
                    if (mouseClickCounter == 0 && !board.isEmptyCell(x, y) && board.getBoardPieces()[x, y].getPieceColor() == pieceColor.BLack)
                        MessageBox.Show("It is white player turn");
                    else if (!board.isEmptyCell(x, y) && mouseClickCounter == 0 && e.Button == MouseButtons.Left)
                    {
                        ++mouseClickCounter;
                        tmp = board.getBoardPieces()[x, y].getLegalMovesWithCheck(board);
                        originalPiecePosition = Tuple.Create(x, y);
                        hightlightLegalMoves(tmp);

                    }
                    else if (mouseClickCounter == 1 && e.Button == MouseButtons.Left)
                    {
                        foreach (Move m in tmp)
                        {
                            if (m.getMovePosition().Item1 == x && m.getMovePosition().Item2 == y)
                            {

                                Piece tmpPiece = board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2];

                                if (tmpPiece.getPieceType() == (int)pieceType.whitePawn)
                                {
                                    tmpPiece.firstMoveOccurred();
                                    //this part handles pawn promotion 
                                    if (x == 0)
                                    {
                                        if (m.isAttackMove())
                                        {
                                            KilledFromBlack(board.getBoardPieces()[x, y].getPieceType());
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                            playersound.Play();
                                        }
                                        else
                                        {
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                            playersound.Play();
                                        }
                                        board.getBoardPieces()[x, y] = new Queen(Tuple.Create(x, y), pieceType.whiteQueen, pieceColor.White);
                                        board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                        whiteMoveOccurred = true;
                                        break;
                                    }
                                    //this part handles  pawn move
                                    else
                                    {
                                        if (m.isAttackMove())
                                        {
                                            KilledFromBlack(board.getBoardPieces()[x, y].getPieceType());
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                            playersound.Play();
                                        }
                                        else
                                        {
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                            playersound.Play();
                                        }
                                        tmpPiece.setPiecePosition(x, y);
                                        board.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2] = tmpPiece;
                                        board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                        whiteMoveOccurred = true;
                                        break;
                                    }

                                }
                                // this is for other pieces movements
                                else
                                {
                                    if (m.isAttackMove())
                                    {
                                        KilledFromBlack(board.getBoardPieces()[x, y].getPieceType());
                                        System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                        playersound.Play();
                                    }
                                    else {
                                        System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                        playersound.Play();
                                    }
                                    tmpPiece.setPiecePosition(x, y);
                                    board.getBoardPieces()[x, y] = tmpPiece;
                                    board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                    whiteMoveOccurred = true;
                                    break;
                                }

                            }
                        }
                        updateBoard();
                        if (whiteMoveOccurred)
                        {

                            whitePlayerActivePieces = player.getActivePlayerPieces(board);
                            whitePlayerLegalMoves = player.getActivePlayerMoves(board, whitePlayerActivePieces);
                            player = new BlackPlayer();
                            blackPlayerActivePieces = player.getActivePlayerPieces(board);
                            blackPlayerLegalMoves = player.getActivePlayerMoves(board, blackPlayerActivePieces);

                            if (blackPlayerActivePieces.Count() == 0)
                                MessageBox.Show("The game is over white player wins");

                            Tuple<int, int> blackPlayerKingPosition = board.getPlayerKingPosition(pieceColor.BLack);

                            if (player.kingInCheck(blackPlayerKingPosition, whitePlayerLegalMoves))
                            {
                                System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record2M_mp3cut);
                                playersound.Play();
                            }

                            whiteMoveOccurred = false;
                        }
                        mouseClickCounter = 0;
                    }
                }
                else
                {
                    if (mouseClickCounter == 0 && !board.isEmptyCell(x, y) && board.getBoardPieces()[x, y].getPieceColor() == pieceColor.White)
                        MessageBox.Show("It is black player turn");
                    else if (!board.isEmptyCell(x, y) && mouseClickCounter == 0 && e.Button == MouseButtons.Left)
                    {
                        ++mouseClickCounter;
                        tmp = board.getBoardPieces()[x, y].getLegalMovesWithCheck(board);
                        originalPiecePosition = Tuple.Create(x, y);
                        hightlightLegalMoves(tmp);
                    }
                    else if (mouseClickCounter == 1 && e.Button == MouseButtons.Left)
                    {
                        foreach (Move m in tmp)
                        {
                            if (m.getMovePosition().Item1 == x && m.getMovePosition().Item2 == y)
                            {

                                Piece tmpPiece = board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2];

                                if (tmpPiece.getPieceType() == (int)pieceType.blackPawn)
                                {
                                    tmpPiece.firstMoveOccurred();

                                    if (x == 7)
                                    {
                                        if (m.isAttackMove())
                                        {
                                            KilledFromWhite(board.getBoardPieces()[x, y].getPieceType());
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                            playersound.Play();
                                        }
                                        else {
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                            playersound.Play();
                                        }
                                        board.getBoardPieces()[x, y] = new Queen(Tuple.Create(x, y), pieceType.blackQueen, pieceColor.BLack);
                                        board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                        blackMoveOccurred = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (m.isAttackMove())
                                        {
                                            KilledFromWhite(board.getBoardPieces()[x, y].getPieceType());
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                            playersound.Play();
                                        }
                                        else {
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                            playersound.Play();
                                        }
                                        tmpPiece.setPiecePosition(x, y);
                                        board.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2] = tmpPiece;

                                        board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                        blackMoveOccurred = true;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (!board.isEmptyCell(x, y))
                                    {
                                        KilledFromWhite(board.getBoardPieces()[x, y].getPieceType());
                                        System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                        playersound.Play();
                                    }
                                    else {
                                        System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                        playersound.Play();
                                    }
                                    tmpPiece.setPiecePosition(x, y);
                                    board.getBoardPieces()[x, y] = tmpPiece;
                                    board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                    blackMoveOccurred = true;
                                    break;
                                }

                            }
                        }
                        updateBoard();
                        if (blackMoveOccurred)
                        {
                            blackPlayerActivePieces = player.getActivePlayerPieces(board);
                            blackPlayerLegalMoves = player.getActivePlayerMoves(board, blackPlayerActivePieces);
                            player = new WhitePlayer();
                            whitePlayerActivePieces = player.getActivePlayerPieces(board);
                            whitePlayerLegalMoves = player.getActivePlayerMoves(board, whitePlayerActivePieces);
                            if (whitePlayerLegalMoves.Count() == 0)
                                MessageBox.Show("The game is over black player wins");

                            Tuple<int, int> whitePlayerKingPosition = board.getPlayerKingPosition(pieceColor.White);
                            if (player.kingInCheck(whitePlayerKingPosition, blackPlayerLegalMoves))
                            {
                                System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record2M_mp3cut);
                                playersound.Play();
                            }

                            blackMoveOccurred = false;
                        }
                        mouseClickCounter = 0;
                    }
                }
            }
            else if(!humanVsHuman)
            {
                if (player.getPlayerColor() == playerColor.White)
                {
                    if (mouseClickCounter == 0 && !board.isEmptyCell(x, y) && board.getBoardPieces()[x, y].getPieceColor() == pieceColor.BLack)
                        MessageBox.Show("It is white player turn");
                    else if (!board.isEmptyCell(x, y) && mouseClickCounter == 0 && e.Button == MouseButtons.Left)
                    {
                        ++mouseClickCounter;
                        tmp = board.getBoardPieces()[x, y].getLegalMovesWithCheck(board);
                        originalPiecePosition = Tuple.Create(x, y);
                        hightlightLegalMoves(tmp);

                    }
                    else if (mouseClickCounter == 1 && e.Button == MouseButtons.Left)
                    {
                        foreach (Move m in tmp)
                        {
                            if (m.getMovePosition().Item1 == x && m.getMovePosition().Item2 == y)
                            {

                                Piece tmpPiece = board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2];

                                if (tmpPiece.getPieceType() == (int)pieceType.whitePawn)
                                {
                                    tmpPiece.firstMoveOccurred();
                                    //this part handles pawn promotion 
                                    if (x == 0)
                                    {
                                        if (m.isAttackMove())
                                        {
                                            KilledFromBlack(board.getBoardPieces()[x, y].getPieceType());
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                            playersound.Play();
                                        }
                                        else
                                        {
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                            playersound.Play();
                                        }
                                        board.getBoardPieces()[x, y] = new Queen(Tuple.Create(x, y), pieceType.whiteQueen, pieceColor.White);
                                        board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                        whiteMoveOccurred = true;
                                        break;
                                    }
                                    //this part handles  pawn move
                                    else
                                    {
                                        if (m.isAttackMove())
                                        {
                                            KilledFromBlack(board.getBoardPieces()[x, y].getPieceType());
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                            playersound.Play();
                                        }
                                        else
                                        {
                                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                            playersound.Play();
                                        }
                                        tmpPiece.setPiecePosition(x, y);
                                        board.getBoardPieces()[m.getMovePosition().Item1, m.getMovePosition().Item2] = tmpPiece;
                                        board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                        whiteMoveOccurred = true;
                                        break;
                                    }

                                }
                                // this is for other pieces movements
                                else
                                {
                                    if (m.isAttackMove())
                                    {
                                        KilledFromBlack(board.getBoardPieces()[x, y].getPieceType());
                                        System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                        playersound.Play();
                                    }
                                    else {
                                        System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                        playersound.Play();
                                    }
                                    tmpPiece.setPiecePosition(x, y);
                                    board.getBoardPieces()[x, y] = tmpPiece;
                                    board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                                    whiteMoveOccurred = true;
                                    break;
                                }

                            }
                        }
                        updateBoard();
                        if (whiteMoveOccurred)
                        {

                            whitePlayerActivePieces = player.getActivePlayerPieces(board);
                            whitePlayerLegalMoves = player.getActivePlayerMoves(board, whitePlayerActivePieces);
                            player = new BlackPlayer();
                            blackPlayerActivePieces = player.getActivePlayerPieces(board);
                            blackPlayerLegalMoves = player.getActivePlayerMoves(board, blackPlayerActivePieces);

                            if (blackPlayerActivePieces.Count() == 0)
                                MessageBox.Show("The game is over white player wins");

                            Tuple<int, int> blackPlayerKingPosition = board.getPlayerKingPosition(pieceColor.BLack);

                            if (player.kingInCheck(blackPlayerKingPosition, whitePlayerLegalMoves))
                            {
                                System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record2M_mp3cut);
                                playersound.Play();
                            }

                            whiteMoveOccurred = false;

                        }
                        mouseClickCounter = 0;
                    }
                }
                else
                {
                    //this part handles Computer Play
                    Tuple<int, int, int, int> nextMove = Computer.getBestMove(board,gameDifficulty);
                    if (nextMove.Item1 == -1)
                        MessageBox.Show("THE GAME IS OVER YOU WIN");
                    //MessageBox.Show(nextMove.Item1.ToString() + nextMove.Item2.ToString() + nextMove.Item3.ToString() + nextMove.Item4.ToString());
                    Piece tmpPiece1 = board.getBoardPieces()[nextMove.Item1, nextMove.Item2];

                    if (tmpPiece1.getPieceType() == (int)pieceType.blackPawn)
                    {
                        tmpPiece1.firstMoveOccurred();
                        //this part handles pawn promotion 
                        if (nextMove.Item3 == 7)
                        {
                            if (!board.isEmptyCell(nextMove.Item3, nextMove.Item4))
                            {
                                KilledFromWhite(board.getBoardPieces()[x, y].getPieceType());
                                System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                playersound.Play();
                            }
                            else
                            {
                                System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                playersound.Play();
                            }
                            board.getBoardPieces()[nextMove.Item3, nextMove.Item4] = new Queen(Tuple.Create(nextMove.Item3, nextMove.Item4), pieceType.blackQueen, pieceColor.BLack);
                            board.getBoardPieces()[originalPiecePosition.Item1, originalPiecePosition.Item2] = null;
                        }
                        //this part handles  pawn move
                        else
                        {
                            if (!board.isEmptyCell(nextMove.Item3, nextMove.Item4))
                            {
                                KilledFromWhite(board.getBoardPieces()[nextMove.Item3, nextMove.Item4].getPieceType());
                                System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                                playersound.Play();
                            }
                            else
                            {
                                System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                                playersound.Play();
                            }
                            tmpPiece1.setPiecePosition(nextMove.Item3, nextMove.Item4);
                            board.getBoardPieces()[nextMove.Item3, nextMove.Item4] = tmpPiece1;
                            board.getBoardPieces()[nextMove.Item1, nextMove.Item2] = null;
                        }

                    }
                    // this is for other pieces movements
                    else
                    {
                        if (!board.isEmptyCell(nextMove.Item3, nextMove.Item4))
                        {
                            KilledFromWhite(board.getBoardPieces()[nextMove.Item3, nextMove.Item4].getPieceType());
                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record20160425102455PM_mp3cut);
                            playersound.Play();
                        }
                        else {
                            System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.recordM_mp3cut);
                            playersound.Play();
                        }
                        tmpPiece1.setPiecePosition(nextMove.Item3, nextMove.Item4);
                        board.getBoardPieces()[nextMove.Item3, nextMove.Item4] = tmpPiece1;
                        board.getBoardPieces()[nextMove.Item1, nextMove.Item2] = null;
                    }

                    updateBoard();
                    blackPlayerActivePieces = player.getActivePlayerPieces(board);
                    blackPlayerLegalMoves = player.getActivePlayerMoves(board, blackPlayerActivePieces);
                    player = new WhitePlayer();
                    whitePlayerActivePieces = player.getActivePlayerPieces(board);
                    whitePlayerLegalMoves = player.getActivePlayerMoves(board, whitePlayerActivePieces);

                    Tuple<int, int> whitePlayerKingPosition = board.getPlayerKingPosition(pieceColor.White);
                    if (player.kingInCheck(whitePlayerKingPosition, blackPlayerLegalMoves))
                    {
                        System.Media.SoundPlayer playersound = new System.Media.SoundPlayer(Properties.Resources.record2M_mp3cut);
playersound.Play();
                                            }
                }
            }
        }
    
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Run(new Form1());
        } 

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            boardBox.Visible = true;
            pictureBox1.Visible = true;
            panel1.Visible = true;
            killedpiecesofwhiteplayer.Visible = true;
            killedpiecesofblackplayer.Visible = true;

            board = new Board();
            player = new WhitePlayer();
            bCol = bRow = wRow = wCol = 0;
            killedImageFromBlack = new Bitmap(192, 448);

            killedGraphFromBlack = Graphics.FromImage(killedImageFromBlack);
            killedpiecesofblackplayer.Image = killedImageFromBlack;
            killedImageFromWhite = new Bitmap(192, 448);
            killedGraphFromWhite = Graphics.FromImage(killedImageFromWhite);
            killedpiecesofwhiteplayer.Image = killedImageFromWhite;
            updateBoard();
        }


        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("      version 0.0        Chess Game developed by team el2sater ");
        }
        private List<Move> initBlackPlayerMoves()
        {
            List<Move> tmp = new List<Move>();
            tmp.Add(new NormalMove(Tuple.Create(2, 0)));
            tmp.Add(new NormalMove(Tuple.Create(3, 0)));
            tmp.Add(new NormalMove(Tuple.Create(2, 1)));
            tmp.Add(new NormalMove(Tuple.Create(3, 1)));
            tmp.Add(new NormalMove(Tuple.Create(2, 2)));
            tmp.Add(new NormalMove(Tuple.Create(3, 2)));
            tmp.Add(new NormalMove(Tuple.Create(2, 3)));
            tmp.Add(new NormalMove(Tuple.Create(3, 3)));
            tmp.Add(new NormalMove(Tuple.Create(2, 4)));
            tmp.Add(new NormalMove(Tuple.Create(3, 4)));
            tmp.Add(new NormalMove(Tuple.Create(2, 5)));
            tmp.Add(new NormalMove(Tuple.Create(3, 5)));
            tmp.Add(new NormalMove(Tuple.Create(2, 6)));
            tmp.Add(new NormalMove(Tuple.Create(3, 6)));
            tmp.Add(new NormalMove(Tuple.Create(2, 7)));
            tmp.Add(new NormalMove(Tuple.Create(3, 7)));
            tmp.Add(new NormalMove(Tuple.Create(2, 0)));
            tmp.Add(new NormalMove(Tuple.Create(2, 2)));
            tmp.Add(new NormalMove(Tuple.Create(2, 7)));
            tmp.Add(new NormalMove(Tuple.Create(2, 5)));
            return tmp;
        }
        private List<Move> initWhitePlayerMoves()
        {
            List<Move> tmp = new List<Move>();
            tmp.Add(new NormalMove(Tuple.Create(4, 0)));
            tmp.Add(new NormalMove(Tuple.Create(5, 0)));
            tmp.Add(new NormalMove(Tuple.Create(4, 1)));
            tmp.Add(new NormalMove(Tuple.Create(5, 1)));
            tmp.Add(new NormalMove(Tuple.Create(4, 2)));
            tmp.Add(new NormalMove(Tuple.Create(5, 2)));
            tmp.Add(new NormalMove(Tuple.Create(4, 3)));
            tmp.Add(new NormalMove(Tuple.Create(5, 3)));
            tmp.Add(new NormalMove(Tuple.Create(4, 4)));
            tmp.Add(new NormalMove(Tuple.Create(5, 4)));
            tmp.Add(new NormalMove(Tuple.Create(4, 5)));
            tmp.Add(new NormalMove(Tuple.Create(5, 5)));
            tmp.Add(new NormalMove(Tuple.Create(4, 6)));
            tmp.Add(new NormalMove(Tuple.Create(5, 6)));
            tmp.Add(new NormalMove(Tuple.Create(4, 7)));
            tmp.Add(new NormalMove(Tuple.Create(5, 7)));
            tmp.Add(new NormalMove(Tuple.Create(5, 0)));
            tmp.Add(new NormalMove(Tuple.Create(5, 2)));
            tmp.Add(new NormalMove(Tuple.Create(5, 5)));
            tmp.Add(new NormalMove(Tuple.Create(5, 7)));
            return tmp;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Visible = false;
            
            button2.Visible = false;
            button3.Visible = false;
            boardBox.Visible = true;
            pictureBox1.Visible = true;
            panel1.Visible = true;
            killedpiecesofwhiteplayer.Visible = true;
            killedpiecesofblackplayer.Visible = true;
            humanVsHuman = true;
            blackPlayerLegalMoves = initBlackPlayerMoves();
            whitePlayerLegalMoves = initWhitePlayerMoves();
            player = new WhitePlayer();
            updateBoard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
