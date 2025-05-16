using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Microsoft.Data.Sqlite;
namespace SpielParadies
{


   



    public partial class Form2 : Form
    {


        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;
        int normalFoodCounter = 0;


        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;

        SpielAuswahl parent;
        private string spielername;
        public Form2(SpielAuswahl parent, string spielername)
        {
            InitializeComponent();
            this.parent = parent;
            this.KeyPreview = true;
            this.spielername = spielername;
        

            this.KeyPreview = true; // Wichtig für Tasteneingabe
            this.KeyDown += KeyIsDown; // Das VERBINDET die Tasten mit dem Code


            using (var connection = new Microsoft.Data.Sqlite.SqliteConnection("Data Source=C:\\Users\\Amar0\\source\\repos\\SpielParadies\\SpielParadies\\bin\\Debug\\net8.0-windows\\GamersParadise.db"))
            {
                
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Snake (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Player TEXT NOT NULL,
            Score INTEGER NOT NULL,
            Time INTEGER NOT NULL,
            Date TEXT NOT NULL
        );";
                command.ExecuteNonQuery();
            }



        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {


            // Zusätzlich: WASD-Steuerung
            if (e.KeyCode == Keys.A && Settings.directions != "right")
            {
                Settings.directions = "left";
            }
            else if (e.KeyCode == Keys.D && Settings.directions != "left")
            {
                Settings.directions = "right";
            }
            else if (e.KeyCode == Keys.W && Settings.directions != "down")
            {
                Settings.directions = "up";
            }
            else if (e.KeyCode == Keys.S && Settings.directions != "up")
            {
                Settings.directions = "down";
            }

        }












        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
            this.Focus(); // Das sorgt dafür, dass Tasten funktionieren

            Settings.directions = "right"; // Startrichtu
            spielSekunden = 0;
            lblZeit.Text = "Zeit: 00:00";
            timer1.Start();
            gametimer.Start();


        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            Console.WriteLine($"Kopf: {Snake[0].X},{Snake[0].Y} | Apfel: {food.X},{food.Y}");

            // end of directions
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;

                    }
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;

                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)

                    {
                        Snake[i].Y = 0;
                    }


                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                    {
                        EatFood(1, "normal");

                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }

                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
                if (megaFood != null && Snake[0].X == megaFood.X && Snake[0].Y == megaFood.Y)
                {
                    EatFood(5, "mega");
                }

            }
            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;



            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Red;
                }
                else
                {
                    snakeColour = Brushes.Pink;
                }
                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width, Settings.Height
            ));
            Brush foodColor = megaFood != null ? Brushes.Gold : Brushes.Turquoise;
            // mega Apfel zeichnen
            if (megaFood != null)
            {
                canvas.FillEllipse(Brushes.Gold, new Rectangle(
                    megaFood.X * Settings.Width,
                    megaFood.Y * Settings.Height,
                    Settings.Width, Settings.Height));
            }


        }




        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;
            Snake.Clear();
            startButton.Enabled = false;

            score = 0;
            txtScore.Text = "Score: " + score;
            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); // adding the head part of the snake to the list

            for (int i = 0; i < 5; i++) // z. B. 2 Körperteile
            {
                Snake.Add(new Circle
                {
                    X = Snake[0].X,
                    Y = Snake[0].Y
                });
            }
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            megaFood = new Circle
            {
                X = rand.Next(2, maxWidth),
                Y = rand.Next(2, maxHeight)

            };
            megaFood = new Circle
            {
                X = 5,
                Y = 5
            };


            // ❗ Game Over Label & Restart Button verstecken
            lblGameOver.Visible = false;
            button2.Visible = false;
        }

        private void EatFood(int wachstum, string typ)
        {
            score += wachstum;
            txtScore.Text = "Score: " + score;

            // Schlange verlängern
            for (int i = 0; i < wachstum; i++)
            {
                Circle body = new Circle
                {
                    X = Snake[Snake.Count - 1].X,
                    Y = Snake[Snake.Count - 1].Y
                };
                Snake.Add(body);
            }

            if (typ == "normal")
            {
                normalFoodCounter++; // Hochzählen bei normalen Äpfeln

                // Neuen normalen Apfel platzieren
                bool validFood = false;
                while (!validFood)
                {
                    food = new Circle
                    {
                        X = rand.Next(2, maxWidth),
                        Y = rand.Next(2, maxHeight)
                    };

                    validFood = true;
                    foreach (var part in Snake)
                    {
                        if (part.X == food.X && part.Y == food.Y)
                        {
                            validFood = false;
                            break;
                        }
                    }
                }

                // Nach jedem 5. normalen Apfel: megaFood setzen
                if (normalFoodCounter >= 5)
                {
                    megaFood = new Circle
                    {
                        X = rand.Next(2, maxWidth),
                        Y = rand.Next(2, maxHeight)
                    };

                    normalFoodCounter = 0;
                }
            }
            else if (typ == "mega")
            {
                // mega Apfel wurde gegessen → löschen
                megaFood = null;
            }
        }


        Circle megaFood = new Circle(); // oder: = null; (dann später initialisieren)


        private void GameOver()
        {
            InsertHighscore(spielername, score, spielSekunden, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            startButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;


            }
            timer1.Stop();
            gametimer.Stop();


            lblGameOver.Visible = true;
            button2.Visible = true;  //



        }


        private void InsertHighscore(string player, int score, int time, string date)
        {
            try
            {
                using (var connection = new Microsoft.Data.Sqlite.SqliteConnection("Data Source=GamersParadise.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"
                INSERT INTO Snake (Player, Score, Time, Date)
                VALUES ($player, $score, $time, $date);
            ";

                    command.Parameters.AddWithValue("$player", player);
                    command.Parameters.AddWithValue("$score", score);
                    command.Parameters.AddWithValue("$time", time);
                    command.Parameters.AddWithValue("$date", date);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Speichern des Highscores: " + ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }


        public static class Settings
        {
            public static int Width { get; set; } = 25;
            public static int Height { get; set; } = 25;
            public static string directions { get; set; } = "left";
        }

        int spielSekunden = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            spielSekunden++;

            int minuten = spielSekunden / 60;
            int sekunden = spielSekunden % 60;

            lblZeit.Text = $"Zeit: {minuten:D2}:{sekunden:D2}";
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            GameTimerEvent(sender, e); // oder direkt dein Spiel-Code
        }

        private void lblZeit_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestartGame();
            lblGameOver.Visible = false; // "Game Over" ausblenden
            button2.Visible = false;  // Restart-Button ausblenden

            timer1.Start();     // Timer für Spielzeit
            gametimer.Start();  // Timer für Snake-Bewegung

        }





        private List<(string Player, int Score, int Time, string Date)> GetHighscores()
        {
            var highscores = new List<(string, int, int, string)>();
            using (var conn = new SqliteConnection("Data Source=GamersParadise.db"))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Player, Score, Time, Date FROM Snake ORDER BY Score DESC LIMIT 10";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highscores.Add((
                            reader.GetString(0),    // Player
                            reader.GetInt32(1),     // Score
                            reader.GetInt32(2),     // Time
                            reader.GetString(3)     // Date
                        ));
                    }
                }
            }
            return highscores;
        }


        private void btnShowHighscores_Click(object sender, EventArgs e)
        {
            var highscores = GetHighscores();
            var dt = new DataTable();
            dt.Columns.Add("Player");
            dt.Columns.Add("Score");
            dt.Columns.Add("Time");
            dt.Columns.Add("Date");

            foreach (var hs in highscores)
            {
                dt.Rows.Add(hs.Player, hs.Score, hs.Time, hs.Date);
            }

            dataGridViewHighscores.DataSource = dt;
        }


       



    }
}


