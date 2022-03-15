using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    class UserInterface
    {
        /* Font info. */
        internal const string fontType = "Arial";
        internal const int fontSize = 10;
        internal const FontStyle fontStyle = FontStyle.Bold;

        internal static void updateGameScore(Label lbl, int gameScore)
        {
            lbl.Text = String.Format("{0:D3}", gameScore);
        }

        internal static void updateGameTime(Label lbl, int gameTime)
        {
            lbl.Text = String.Format("{0:D3}", gameTime);
        }

        internal static void revealButton(Button btn, int matrixVal)
        {
            btn.Image = null;
            btn.Text = matrixVal != 0 ? matrixVal.ToString() : " ";

            switch (matrixVal)
            {
                case 1:
                    btn.ForeColor = Color.Blue;
                    break;
                case 2:
                    btn.ForeColor = Color.Green;
                    break;
                case 3:
                    btn.ForeColor = Color.Red;
                    break;
                case 4:
                    btn.ForeColor = Color.BlueViolet;
                    break;
                default:
                    btn.ForeColor = Color.Black;
                    break;
            }

            btn.BackColor = Color.White;
        }

        internal static void revealMatrix(int[,] mineMatrix, Button[,] btnMatrix)
        {
            for (int i = 0; i < MineSweeper.dim_Width; i++)
            {
                for (int j = 0; j < MineSweeper.dim_Height; j++)
                {
                    if (mineMatrix[i, j] == MineSweeper.bombEncode)
                    {
                        btnMatrix[i, j].Image = System.Drawing.Image.FromFile("Minesweeper/bomb.png");
                        btnMatrix[i, j].BackColor = Color.IndianRed;
                    }
                    else
                    {
                        UserInterface.revealButton(btnMatrix[i, j], mineMatrix[i, j]);
                    }
                }
            }
        }

        internal static void revealBoundedWhiteSpaces(int [,] mineMatrix, Button[,] btnMatrix, int clickX, int clickY)
        {
            if(clickX < 0 || clickX >= MineSweeper.dim_Width || clickY < 0 || clickY >= MineSweeper.dim_Height)
            {
                return;
            }
            if(btnMatrix[clickX, clickY].Text == " " || mineMatrix[clickX, clickY] != 0)
            {
                return;
            }

            UserInterface.revealButton(btnMatrix[clickX, clickY], 0);

            for(int i = -1; i <= 1; i++)
            {
                for(int j = -1; j <= 1; j += (i != 0 ? 1 : 2))
                {
                    revealBoundedWhiteSpaces(mineMatrix, btnMatrix, clickX + i, clickY + j);
                }
            }
        }

        internal static void setButtonStyle(FlowLayoutPanel mainFlow, Button btn, int i, int j)
        {
            btn.Name = "btnMine(" + i + ", " + j + ")";
            btn.Tag = i + " " + j;

            btn.Width = mainFlow.Size.Width / (MineSweeper.dim_Width + 2);
            btn.Height = (int)(btn.Width / 1.6);
            btn.Font = new Font(UserInterface.fontType, UserInterface.fontSize, UserInterface.fontStyle);
            btn.BackColor = Color.LightGray;
        }
    }
}
