namespace SpielParadies
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            startButton = new Button();
            picCanvas = new PictureBox();
            txtScore = new Label();
            txtHighScore = new Label();
            button1 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lblZeit = new Label();
            gametimer = new System.Windows.Forms.Timer(components);
            lblGameOver = new Label();
            button2 = new Button();
            dataGridViewHighscores = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHighscores).BeginInit();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            startButton.Location = new Point(595, 75);
            startButton.Name = "startButton";
            startButton.Size = new Size(119, 84);
            startButton.TabIndex = 0;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += StartGame;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = SystemColors.ButtonHighlight;
            picCanvas.Location = new Point(1, 1);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(580, 692);
            picCanvas.TabIndex = 1;
            picCanvas.TabStop = false;
            picCanvas.Paint += UpdatePictureBoxGraphics;
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtScore.Location = new Point(604, 181);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(105, 32);
            txtScore.TabIndex = 2;
            txtScore.Text = "Score: 0";
            // 
            // txtHighScore
            // 
            txtHighScore.AutoSize = true;
            txtHighScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtHighScore.Location = new Point(595, 236);
            txtHighScore.Name = "txtHighScore";
            txtHighScore.Size = new Size(138, 32);
            txtHighScore.TabIndex = 3;
            txtHighScore.Text = "High Score";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(585, 635);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 4;
            button1.Text = "Zurück";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lblZeit
            // 
            lblZeit.AutoSize = true;
            lblZeit.Font = new Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblZeit.Location = new Point(585, 370);
            lblZeit.Name = "lblZeit";
            lblZeit.Size = new Size(152, 37);
            lblZeit.TabIndex = 5;
            lblZeit.Text = " Zeit 00:00";
            lblZeit.Click += lblZeit_Click;
            // 
            // gametimer
            // 
            gametimer.Tick += gametimer_Tick;
            // 
            // lblGameOver
            // 
            lblGameOver.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblGameOver.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGameOver.ForeColor = Color.Red;
            lblGameOver.ImageAlign = ContentAlignment.TopCenter;
            lblGameOver.Location = new Point(179, 287);
            lblGameOver.MaximumSize = new Size(250, 175);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(250, 175);
            lblGameOver.TabIndex = 6;
            lblGameOver.Text = "GAME OVER";
            lblGameOver.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.CornflowerBlue;
            button2.Location = new Point(225, 406);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 7;
            button2.Text = "Restart";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridViewHighscores
            // 
            dataGridViewHighscores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHighscores.Location = new Point(46, 635);
            dataGridViewHighscores.Name = "dataGridViewHighscores";
            dataGridViewHighscores.RowHeadersWidth = 82;
            dataGridViewHighscores.Size = new Size(480, 300);
            dataGridViewHighscores.TabIndex = 8;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(738, 693);
            Controls.Add(dataGridViewHighscores);
            Controls.Add(button2);
            Controls.Add(lblGameOver);
            Controls.Add(lblZeit);
            Controls.Add(button1);
            Controls.Add(txtHighScore);
            Controls.Add(txtScore);
            Controls.Add(startButton);
            Controls.Add(picCanvas);
            Name = "Form2";
            Text = "Snake_Game";
            Load += Form2_Load;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHighscores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private PictureBox picCanvas;
        private Label txtScore;
        private Label txtHighScore;
        private Button button1;
        private System.Windows.Forms.Timer timer1;
        private Label lblZeit;
        private System.Windows.Forms.Timer gametimer;
        private Label lblGameOver;
        private Button button2;
        private DataGridView dataGridViewHighscores;
    }
}