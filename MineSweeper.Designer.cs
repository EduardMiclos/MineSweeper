
namespace Lab3
{
    partial class MineSweeper
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MineSweeper));
            this.imgMineSweeper = new System.Windows.Forms.PictureBox();
            this.mainFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTimeText = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.imgRestart = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScoreText = new System.Windows.Forms.Label();
            this.mineTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgMineSweeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRestart)).BeginInit();
            this.SuspendLayout();
            // 
            // imgMineSweeper
            // 
            this.imgMineSweeper.BackgroundImage = global::Lab3.Properties.Resources.minesweeperBk;
            this.imgMineSweeper.Image = global::Lab3.Properties.Resources.minesweeperBk;
            this.imgMineSweeper.ImageLocation = "";
            this.imgMineSweeper.Location = new System.Drawing.Point(-2, 0);
            this.imgMineSweeper.Name = "imgMineSweeper";
            this.imgMineSweeper.Size = new System.Drawing.Size(560, 128);
            this.imgMineSweeper.TabIndex = 0;
            this.imgMineSweeper.TabStop = false;
            // 
            // mainFlow
            // 
            this.mainFlow.Location = new System.Drawing.Point(12, 134);
            this.mainFlow.Name = "mainFlow";
            this.mainFlow.Size = new System.Drawing.Size(533, 379);
            this.mainFlow.TabIndex = 1;
            // 
            // lblTimeText
            // 
            this.lblTimeText.AutoSize = true;
            this.lblTimeText.Font = new System.Drawing.Font("Robot_Font", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimeText.Location = new System.Drawing.Point(439, 500);
            this.lblTimeText.Name = "lblTimeText";
            this.lblTimeText.Size = new System.Drawing.Size(58, 22);
            this.lblTimeText.TabIndex = 0;
            this.lblTimeText.Text = "TIME";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Robot_Font", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblTime.Location = new System.Drawing.Point(423, 529);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(90, 42);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "000";
            // 
            // imgRestart
            // 
            this.imgRestart.Image = global::Lab3.Properties.Resources.smiley1;
            this.imgRestart.Location = new System.Drawing.Point(202, 509);
            this.imgRestart.Name = "imgRestart";
            this.imgRestart.Size = new System.Drawing.Size(148, 62);
            this.imgRestart.TabIndex = 4;
            this.imgRestart.TabStop = false;
            this.imgRestart.Click += new System.EventHandler(this.imgRestart_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Robot_Font", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScore.ForeColor = System.Drawing.Color.Maroon;
            this.lblScore.Location = new System.Drawing.Point(39, 529);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(90, 42);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "000";
            // 
            // lblScoreText
            // 
            this.lblScoreText.AutoSize = true;
            this.lblScoreText.Font = new System.Drawing.Font("Robot_Font", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScoreText.Location = new System.Drawing.Point(46, 500);
            this.lblScoreText.Name = "lblScoreText";
            this.lblScoreText.Size = new System.Drawing.Size(77, 22);
            this.lblScoreText.TabIndex = 5;
            this.lblScoreText.Text = "SCORE";
            // 
            // mineTimer
            // 
            this.mineTimer.Interval = 1000;
            this.mineTimer.Tick += new System.EventHandler(this.mineTimer_Tick);
            // 
            // MineSweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(557, 585);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblScoreText);
            this.Controls.Add(this.imgRestart);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeText);
            this.Controls.Add(this.mainFlow);
            this.Controls.Add(this.imgMineSweeper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MineSweeper";
            this.Text = "MineSweeper";
            this.Load += new System.EventHandler(this.MineSweeper_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgMineSweeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRestart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgMineSweeper;
        private System.Windows.Forms.FlowLayoutPanel mainFlow;
        private System.Windows.Forms.Label lblTimeText;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox imgRestart;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScoreText;
        private System.Windows.Forms.Timer mineTimer;
    }
}