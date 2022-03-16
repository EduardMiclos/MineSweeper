using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Lab3
{    
    public partial class MineSweeper : Form
    {

        /* Setting the board dimensions. */
        public const int dim_Width = 12, dim_Height = 12;
        private int numBombs;

        /*
         > mineMatrix - main game matrix.
         > btnMatrix - matrix of buttons corresponding to mineMatrix.
         > bombPosition - array of Positions containing the (x, y) coordinates
                          of the randomly generated bomb positions. 
         > firstClickposition - the position of the first click.
        */
        private int[,] mineMatrix;
        private Position[] bombPositions;
        private Position firstClickPosition;

        private Button[,] btnMatrix;

        /* Empirically obtained. */
        private float bombRatio = 4.85f;

        /* General game info. */
        private bool GAME_STARTED = false;
        int gameTime, gameScore;

        internal const int bombEncode = -1;
        int correctlyPlacedFlags;

        private const int initialGameScore = 29;

        public MineSweeper()
        {
            InitializeComponent();
        }

        private int getAdjacentBombsNumber(int i, int j)
        {
            int countBombs = 0;
            if(i != 0)
            {
                if (this.mineMatrix[i - 1, j] == MineSweeper.bombEncode)
                {
                    countBombs++;
                }

                if(j != 0 && this.mineMatrix[i - 1, j - 1] == MineSweeper.bombEncode)
                {
                    countBombs++;
                }

                if(j != (MineSweeper.dim_Height - 1) && this.mineMatrix[i - 1, j + 1] == MineSweeper.bombEncode)
                {
                    countBombs++;
                }
            }


            if(i != (MineSweeper.dim_Width - 1))
            {
                if (this.mineMatrix[i + 1, j] == MineSweeper.bombEncode) {
                    countBombs++;
                }

                if(j != 0 && this.mineMatrix[i + 1, j - 1] == MineSweeper.bombEncode)
                {
                    countBombs++;
                }

                if(j != (MineSweeper.dim_Height - 1) && this.mineMatrix[i + 1, j + 1] == MineSweeper.bombEncode)
                {
                    countBombs++;
                }
            }


           if(j != 0 && this.mineMatrix[i, j - 1] == MineSweeper.bombEncode)
            {
                countBombs++;
            }
            
           if(j != (MineSweeper.dim_Height - 1) && this.mineMatrix[i, j + 1] == MineSweeper.bombEncode)
            {
                countBombs++;
            }

            return countBombs;
        }

        private void generateMineMatrix()
        {
            this.mineMatrix = new int[MineSweeper.dim_Width, MineSweeper.dim_Height];

            this.numBombs = (int)(MineSweeper.dim_Width * MineSweeper.dim_Height / this.bombRatio);
            this.bombPositions = new Position[this.numBombs];

            for(int i = 0; i < this.numBombs; i++)
            {
                this.bombPositions[i] = new Position();
            }

            Random rnd = new Random();

            for(int i = 0; i < this.numBombs; i++)
            {
                Position auxPos = new Position();
                do
                {
                    auxPos.x = rnd.Next(MineSweeper.dim_Width);
                    auxPos.y = rnd.Next(MineSweeper.dim_Height);
                } while (Array.Exists<Position>(this.bombPositions, pos => pos == auxPos || this.firstClickPosition == auxPos));

                this.bombPositions[i].x = auxPos.x;
                this.bombPositions[i].y = auxPos.y;
            }

            for(int i = 0; i < this.numBombs; i++)
            {
                this.mineMatrix[this.bombPositions[i].x, this.bombPositions[i].y] = MineSweeper.bombEncode;
            }

            for(int i = 0; i < MineSweeper.dim_Width; i++)
            {
                for(int j = 0; j < MineSweeper.dim_Height; j++)
                {
                    if(this.mineMatrix[i, j] != MineSweeper.bombEncode)
                    {
                        this.mineMatrix[i, j] = this.getAdjacentBombsNumber(i, j);
                    }
                }
            }

        }
       
        private void btnMine_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = (MouseEventArgs) e;
            Button btn = (Button)sender;

            String[] posStr = btn.Tag.ToString().Split(" ");
            Position clickPosition = new Position(int.Parse(posStr[0]), int.Parse(posStr[1]));

            if (this.GAME_STARTED == false)
            {
                this.firstClickPosition = clickPosition;
                this.GAME_STARTED = true;

                this.generateMineMatrix();
                mineTimer.Start();
            }

            int matrixVal = this.mineMatrix[clickPosition.x, clickPosition.y];

            if (mouseEvent.Button == MouseButtons.Left && btn.Image == null)
            {
                if (matrixVal == MineSweeper.bombEncode)
                {
                    UserInterface.revealMatrix(this.mineMatrix, this.btnMatrix);
                    this.endGame("Game finished!\nYour total score: " + this.gameScore);
                    return;
                }

                if(matrixVal != 0)
                {
                    UserInterface.revealButton(btn, matrixVal);
                }
                else
                {
                    UserInterface.revealBoundedWhiteSpaces(this.mineMatrix, this.btnMatrix, clickPosition.x, clickPosition.y);
                }

                if (hasWon() == true)
                {
                    this.endGame("You won!\nYour total score: " + this.gameScore);
                }
            }
            else if (mouseEvent.Button == MouseButtons.Right)
            {
                if (btn.Text != "")
                {
                    return;
                }

                if (btn.Image == null)
                {
                    btn.Image = System.Drawing.Image.FromFile("Minesweeper/flag.png");

                    if (matrixVal == MineSweeper.bombEncode)
                    {
                        this.correctlyPlacedFlags++;
                    }

                    this.gameScore--;
                    UserInterface.updateGameScore(lblScore, this.gameScore);
                }
                else
                {
                    btn.Image = null;

                    if (matrixVal == MineSweeper.bombEncode)
                    {
                        this.correctlyPlacedFlags--;
                    }

                    this.gameScore++;
                    UserInterface.updateGameScore(lblScore, this.gameScore);
                }
            }
        }

        private void generateButtons()
        {
            this.btnMatrix = new Button[MineSweeper.dim_Width, MineSweeper.dim_Height];

            for (int i = 0; i < MineSweeper.dim_Width; i++)
            {
                for (int j = 0; j < MineSweeper.dim_Height; j++)
                {
                    Button btnMine = new Button();
                    btnMine.MouseUp += this.btnMine_Click;

                    UserInterface.setButtonStyle(mainFlow, btnMine, i, j);
                    mainFlow.Controls.Add(btnMine);

                    this.btnMatrix[i, j] = btnMine;
                }
            }
        }

        private void imgRestart_Click(object sender, EventArgs e)
        {
            this.endGame("Game finished!\nYour total score: " + this.gameScore);
        }

        private void mineTimer_Tick(object sender, EventArgs e)
        {
            this.gameTime++;
            UserInterface.updateGameTime(lblTime, this.gameTime);
        }

        private void endGame(string messageBoxText)
        {
            this.resetVariables();
            UserInterface.updateGameTime(lblTime, this.gameTime);

            mineTimer.Stop();

            if (DialogResult.OK == MessageBox.Show(messageBoxText))
            {
                mainFlow.Controls.Clear();
                this.restartGame();
            }
        }

        private void resetVariables()
        {
            this.btnMatrix = null;
            this.mineMatrix = null;
            this.bombPositions = null;

            this.gameTime = 0;
            this.GAME_STARTED = false;
            this.numBombs = 0;
            this.correctlyPlacedFlags = 0;

            this.gameScore = MineSweeper.initialGameScore;
        }

        private void restartGame()
        {
            this.resetVariables();
            UserInterface.updateGameScore(lblScore, this.gameScore);
            this.generateButtons();
        }

        private bool hasWon()
        {
            if(this.numBombs != this.correctlyPlacedFlags)
            {
                return false;
            }

            for(int i = 0; i < MineSweeper.dim_Width; i++)
            {
                for(int j = 0; j < MineSweeper.dim_Height; j++)
                {
                    if (this.btnMatrix[i, j].Text != " " || this.btnMatrix[i, j].Image != null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void MineSweeper_Load(object sender, EventArgs e)
        {
            this.restartGame();
        }
    }
}
