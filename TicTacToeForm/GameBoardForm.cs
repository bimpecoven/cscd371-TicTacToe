using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeForm {
    public partial class GameBoardForm : Form {

        private Graphics formGraphics;
        private int sqWidth = 60, sqHeight = 60;
        private string currentTurn = "    Flip the Coin!    ";
        private bool playerOneTurn = true;
        private bool computerPlayer = true;
        private int turnCount = 0;
        private bool gameOver = false;
        bool playAggressive = false;

        // Game grid coordinates and trackers
        private int[,] playingArea = new int[9, 2] { {25, 45}, {25, 115}, {25, 185},
                                                     {95, 45}, {95, 115}, {95, 185},
                                                     {165, 45}, {165, 115}, {165, 185} };
        private bool[] isEmpty = new bool[9] { true, true, true, true, true, true, true, true, true };
        private bool[] isX = new bool[9] { true, true, true, true, true, true, true, true, true };

        public GameBoardForm() {
            InitializeComponent();
            this.Size = new Size(265, 400);
            if (computerPlayer) {
                Random playStyle = new Random();
                if (playStyle.Next(1, 3) == 1) {
                    playAggressive = true;
                }// Coin flip - heads gives cpu aggressive behavior
            }// Set behavior if Player Two is Computer
        }

        private void Form1_Click(object sender, EventArgs e) {

            // this prevents click actions before the game has started.
            if (!gameOver && turnCount < 9) {

                int x = this.PointToClient(Cursor.Position).X;
                int y = this.PointToClient(Cursor.Position).Y;

                bool isValidPlay = locateSquare(x, y);

                if (isValidPlay) {
                    turnCount++;
                    switchTurns();
                    Invalidate();
                }//end if
                else if (playerOneTurn) {
                    MessageBox.Show("You can't make a move here, dummy!");
                }//end else
            }//end if

            checkWin();

            if (turnCount == 9 && !gameOver) {
                gameOver = true;
                currentTurn = "   Cats Game!   ";
            }

            if (computerPlayer && !gameOver) {
                computerTurn();
                checkWin();
            }// We need to tell the computer to play...
        }//end click handler

        private bool locateSquare(int x, int y) {
            int square = 0;

            while (square < 9) {
                if (x >= playingArea[square, 0] && x <= (playingArea[square, 0] + sqWidth) && y >= playingArea[square, 1] && y <= (playingArea[square, 1] + sqHeight)) {
                    if (isEmpty[square]) {
                        isEmpty[square] = false;
                        isX[square] = playerOneTurn;
                        return true;
                    }
                    else {
                        // the user's spot has already been played!
                        return false;
                    }
                }
                square++;
            }//end while

            // the user clicked a spot thats not valid, we need to not register this.
            return false;
        }//end locateSquare

        private void switchTurns() {
            if(playerOneTurn) {
                playerOneTurn = false;
                if (computerPlayer) {
                    currentTurn = " Computer's Turn. ";
                }//end if
                else {
                    currentTurn = "Player Two's Turn.";
                }//end else
            }
            else {
                playerOneTurn = true;
                currentTurn = "Player One's Turn.";
            }
        }//end switch turns

        private void computerTurn() {
            bool isValidPlay = false;
            while (!isValidPlay) {
                Random randomClick = new Random();
                int x = randomClick.Next(playingArea[0, 0], (playingArea[8, 0] + sqWidth));
                int y = randomClick.Next(playingArea[0, 1], (playingArea[8, 1] + sqHeight));

                isValidPlay = locateSquare(x, y);
                if (isValidPlay) {
                    turnCount++;
                    switchTurns();
                    Invalidate();
                }//end if
            }//end while

//            computerAI();
        }//end computer turn

        private void endGame(string winner) {
            gameOver = true;

            // lock controls
            BtnFlipCoin.Enabled = false;
            coinTossStartToolStripMenuItem.Enabled = false;
            BtnReset.Enabled = true;
            resetGameToolStripMenuItem.Enabled = true;

            currentTurn = winner;
            Invalidate();
        }//end game

        protected override void OnPaint(PaintEventArgs e) {
            // Building the playing area...
            // Background
            SolidBrush background = new SolidBrush(Color.Gray);
            formGraphics = this.CreateGraphics();
            int bgWidth = this.Size.Width, bgHeight = this.Size.Height;
            formGraphics.FillRectangle(background, new Rectangle(0, 0, bgWidth, bgHeight));

            // Squares & Border
            int squares, x = 25, y = 45, sqWidth = 60, sqHeight = 60;
            SolidBrush lines = new SolidBrush(Color.White);
            formGraphics.FillRectangle(lines, new Rectangle(x, y, 200, 200));

            //--------------------------------------------------------------------------------
            // if theres time i want to redo this. have x and o class and have an array of
            // play tiles that can be empty, x or o and store in there and redraw.
            //--------------------------------------------------------------------------------
            for (squares = 0; squares < 9; squares++) {
                formGraphics.FillRectangle(background, new RectangleF(playingArea[squares, 0], playingArea[squares, 1], sqWidth, sqHeight));
                if (!isEmpty[squares]) {
                    if (isX[squares]) {
                        formGraphics.DrawLine(Pens.Blue, playingArea[squares, 0], playingArea[squares, 1], playingArea[squares, 0] + sqWidth, playingArea[squares, 1] + sqHeight);
                        formGraphics.DrawLine(Pens.Blue, playingArea[squares, 0] + sqWidth, playingArea[squares, 1], playingArea[squares, 0], playingArea[squares, 1] + sqHeight);
                    }// end if
                    else {
                        formGraphics.DrawEllipse(Pens.Red, playingArea[squares, 0], playingArea[squares, 1], sqWidth, sqHeight);
                    }// end else
                }//end if
            }//end rows

            // Draw in labeling
            string playerLabels = "Player 1 is X's              Player 2 is O's";
            formGraphics.DrawString(playerLabels, new Font("Arial", 10), lines, 10, 25);

            // Draw player turn
            formGraphics.DrawString(currentTurn, new Font("Arial", 12), lines, 55, 250);

            // Clean up a bit
            background.Dispose();
            lines.Dispose();
            formGraphics.Dispose();
        }//end onPaint

        //--------------------------------------------------------------------------------
        // Menu Strip items, Check Boxes and Button handlers below
        //--------------------------------------------------------------------------------

        private void coinTossStartToolStripMenuItem_Click(object sender, EventArgs e) {
            Random coinToss = new Random();
            int result = coinToss.Next(1, 3);

            if(result == 1) {
                playerOneTurn = true;
                currentTurn = "Player One's Turn.";
            }
            else {
                playerOneTurn = false;
                if(computerPlayer) {
                    currentTurn = " Computer's Turn. ";
                    computerTurn();
                }
                else {
                    currentTurn = "Player Two's Turn.";
                }
            }
            Invalidate();

            BtnReset.Enabled = true;
            resetGameToolStripMenuItem.Enabled = true;
            BtnFlipCoin.Enabled = false;
            coinTossStartToolStripMenuItem.Enabled = false;
            checkFriend.Enabled = false;
            checkComputer.Enabled = false;
        }

        private void resetGameToolStripMenuItem_Click(object sender, EventArgs e) {

            // Enable/Disable Buttons
            BtnReset.Enabled = false;
            resetGameToolStripMenuItem.Enabled = false;
            BtnFlipCoin.Enabled = true;
            coinTossStartToolStripMenuItem.Enabled = true;
            checkComputer.Enabled = true;
            checkComputer.Checked = false;
            checkFriend.Enabled = true;
            checkFriend.Checked = false;
            gameOver = false;
            turnCount = 0;

            // Reset fields
            for(int x = 0; x < 9; x++) {
                isEmpty[x] = true;
            }//end for
            currentTurn = "    Flip the Coin.    ";

            Invalidate();
        }

        private void checkComputer_Click(object sender, EventArgs e) {
            if (checkFriend.Checked == true) {
                checkFriend.Checked = false;
            }
            checkComputer.Checked = true;
            computerPlayer = true;
        }

        private void checkFriend_Click(object sender, EventArgs e) {
            if (checkComputer.Checked == true) {
                checkComputer.Checked = false;
            }
            checkFriend.Checked = true;
            computerPlayer = false;
        }

        private void BtnRollDice_Click(object sender, EventArgs e) {
            coinTossStartToolStripMenuItem_Click(sender, e);
        }// This method delegates to the menu click corresponded with it's action.

        private void BtnReset_Click(object sender, EventArgs e) {
            resetGameToolStripMenuItem_Click(sender, e);
        } // This method delegates to the menu click corresponded with it's action.

        //--------------------------------------------------------------------------------
        // checkWin method is very ugly, thus it lives at the bottom.
        // Couldn't think of a better way to do this? 
        //--------------------------------------------------------------------------------

        private void checkWin() {

            // ------------------------------ Vertical Wins ------------------------------
            if (isX[0] == isX[1] && isX[0] == isX[2] && !isEmpty[0] && !isEmpty[1] && !isEmpty[2]) {
                if (isX[0]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// left vertical win
            else if (isX[3] == isX[4] && isX[3] == isX[5] && !isEmpty[3] && !isEmpty[4] && !isEmpty[5]) {
                if (isX[3]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// mid vertical win
            else if (isX[6] == isX[7] && isX[6] == isX[8] && !isEmpty[6] && !isEmpty[7] && !isEmpty[8]) {
                if (isX[6]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// right vertical win

            // ------------------------------ Horizontal Wins ------------------------------
            else if (isX[0] == isX[3] && isX[0] == isX[6] && !isEmpty[0] && !isEmpty[3] && !isEmpty[6]) {
                if (isX[0]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// top horizontal win
            else if (isX[1] == isX[4] && isX[1] == isX[7] && !isEmpty[1] && !isEmpty[4] && !isEmpty[7]) {
                if (isX[1]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// mid horizontal win
            else if (isX[2] == isX[5] && isX[2] == isX[8] && !isEmpty[2] && !isEmpty[5] && !isEmpty[8]) {
                if (isX[2]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// bottom horizontal win

            // ------------------------------ Diagonal Wins ------------------------------
            else if (isX[0] == isX[4] && isX[0] == isX[8] && !isEmpty[0] && !isEmpty[4] && !isEmpty[8]) {
                if (isX[0]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// top-left to bottom-right diagonal win
            else if (isX[2] == isX[4] && isX[2] == isX[6] && !isEmpty[2] && !isEmpty[4] && !isEmpty[6]) {
                if (isX[2]) {
                    endGame("Player One Wins!");
                }// player one
                else if (computerPlayer) {
                    endGame(" Computer Wins! ");
                }// Computer
                else {
                    endGame("Player Two Wins!");
                }// player two
            }// bottom-left to top-right diagonal win

        }//end checkwin

        //--------------------------------------------------------------------------------
        //                 Artificial Intelligence for Computer Player
        // -------------------------------------------------------------------------------
        // - Win the game if possible on that turn.
        // - Block 'Player One' from winning the game if 2 X's are in a line
        // - Will block 'Player One' from playing X's next to eachother (Early on in game)
        // - Checks gameboard for 2 O's in a row, if none attempts to line 2 up.
        // - If three in a row is impossible Computer will play for cats game.
        //--------------------------------------------------------------------------------
        //                                  Features
        //--------------------------------------------------------------------------------
        // - Randomized play style: Computer will either be aggressive or conservative.
        //--------------------------------------------------------------------------------

        public void ComputerAI() {
            bool canWinGame = false;
            bool willLoseGame = false;
            bool canPerformBlock = false; 
            bool positivePlay = false;
            bool playForCatsGame = false;

            // Check all possible scenario's (set bools)


            // Execute based on priority
            if ( canWinGame ) {

            }//
            else if ( willLoseGame ) {

            }//
            else if ( canPerformBlock ) {

            }//
            else if ( positivePlay ) {

            }//
            else if ( playForCatsGame ) {

            }//
        }//end ComputerAI
    }
}
