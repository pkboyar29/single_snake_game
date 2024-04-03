using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            new Settings();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            rbtnB1.Checked = true;
            picCanvas.BackColor = Color.FromArgb(184, 134, 39);

            label3.Text = Properties.Settings.Default.time.ToLocalTime().ToString();
            label2.Text = Properties.Settings.Default.score.ToString();
        }

        // максимальная длина/высота, которая может себе позволить змея преодолеть
        int maxWidth;
        int maxHeight;

        Game Game = new Game();

        int score;
        int highScore;

        // эти параметры нужны для высчитывания длительности игры
        int s = 0;
        int m = 0;
        int sm;

        Random rand = new Random();

        // тут запоминаем скорость змейки
        int gameinterval = 0;

        // флаг, который равен true, когда мы не можем останавливать игру
        bool f_stop = true;

        // флаг, который равен true, когда мы съедаем бустер
        bool f_eatbooster = false;

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            Game.ChangeDirection(e.KeyCode);
            if (e.KeyCode == Keys.Space)
                StopGame();
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            Game.ClearDirections(e.KeyCode);
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        /// <summary>
        /// скриншот
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "Я заработал следующее количество очков: " + score + " в игре Змейка";
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Black;
            caption.BackColor = Color.Transparent;
            caption.AutoSize = false;
            caption.Width = picCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            picCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game Snapshot";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picCanvas.Width);
                int height = Convert.ToInt32(picCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
            }
            picCanvas.Controls.Remove(caption);
        }

        /// <summary>
        /// тик таймера, который определяет длительность игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void durationGameEvent(object sender, EventArgs e)
        {
            s++;
            if (s > 59)
            {
                s = 0;
                m++;
            }
            if (m < 10) durationOfGameLabel.Text = "Длительность: 0" + m + ":";
            else durationOfGameLabel.Text = "Длительность: " + m + ":";
            if (s < 10) 
                durationOfGameLabel.Text = durationOfGameLabel.Text + "0" + s;
            else durationOfGameLabel.Text = durationOfGameLabel.Text + s;
        }

        /// <summary>
        /// тик нашего основного таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTimerEvent(object sender, EventArgs e)
        {
            switch (Game.SnakeMove())
            {
                case 0:
                    GameOver();
                    break;
                case 1:
                    EatFood();
                    break;
                case 2:
                    EatBooster();
                    break;
                default:
                    break;
            }

            if (f_eatbooster)
            {
                if (m * 60 + s == sm + 5)
                {
                    boosterLabel.Text = "";
                    gameTimer.Interval = gameinterval;
                }
                if (m * 60 + s == sm + 10)
                {
                    f_eatbooster = false;
                    Game.GenerateBooster();
                }
            }

            picCanvas.Invalidate();
        }
        
        /// <summary>
        /// прорисовка всех элементов игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            // прорисовка змейки
            for (int i = 0; i < Game.Snake.Count; i++)
            {
                if (i == 0) snakeColor = Brushes.DarkGreen;
                else snakeColor = Brushes.Green;

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                    Game.Snake[i].X * Settings.Width,
                    Game.Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }

            // прорисовка барьеров
            for (int i = 0; i < Game.Barriers.Count; i++)
            {
                canvas.FillEllipse(Brushes.Black, new Rectangle
                (
                Game.Barriers[i].X * Settings.Width,
                Game.Barriers[i].Y * Settings.Height,
                Settings.Width, Settings.Height
                ));
            }

            // прорисовка еды
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                (
                Game.Food.X * Settings.Width,
                Game.Food.Y * Settings.Height,
                Settings.Width, Settings.Height
                ));

            // прорисовка бустеров
            canvas.FillEllipse(Brushes.DarkBlue, new Rectangle(
                Game.Booster.X * Settings.Width,
                Game.Booster.Y * Settings.Height,
                Settings.Width, Settings.Height
                ));
        }

        /// <summary>
        /// когда начинается игра
        /// </summary>
        private void RestartGame()
        {
            if (radioButton1.Checked) gameTimer.Interval = 80;
            if (radioButton2.Checked) gameTimer.Interval = 70;
            if (radioButton3.Checked) gameTimer.Interval = 60;

            gameinterval = gameTimer.Interval;

            f_stop = false;

            pauseLabel.Text = "";
            GameOverLabel.Text = "";
            boosterLabel.Text = "";

            durationOfGameLabel.Text = "Длительность: 00:00";
            s = 0;
            m = 0;

            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            Game = new Game(maxWidth, maxHeight);

            Game.ClearAll();

            startButton.Enabled = false;
            snapButton.Enabled = false;
            groupBoxSettings.Enabled = false;
            groupBoxBarriersSettings.Enabled = false;

            score = 0;
            txtScore.Text = "Счёт: " + score;

            Game.GenerateSnake();

            if (rbtnB1.Checked) Game.GenerateBarriers(true);
            else if (rbtnB2.Checked) Game.GenerateBarriers(false);

            Game.GenerateFood();
            Game.GenerateBooster();

            Settings.directions = "right";

            durationOfGameTimer.Start();
            gameTimer.Start();
        }
        private void EatFood()
        {
            score += 1;
            txtScore.Text = "Счёт: " + score;

            Game.AddBody();

            Game.GenerateFood();
        }
        private void EatBooster()
        {
            Game.Booster.X = -50;
            Game.Booster.Y = -50;
            sm = m * 60 + s;
            f_eatbooster = true;

            if (rand.Next(0, 2) == 0)
            {
                boosterLabel.Text = "Змейка ускорилась!";
                gameTimer.Interval = gameinterval - 20;
            } else
            {
                boosterLabel.Text = "Змейка замедлилась!";
                gameTimer.Interval = gameinterval + 40;
            }
        }

        // когда игра заканчивается
        private void GameOver()
        {
            durationOfGameTimer.Stop();
            gameTimer.Stop();

            f_stop = true;

            startButton.Text = "Снова начать игру";
            GameOverLabel.Text = "Game Over!";
            boosterLabel.Text = "";

            startButton.Enabled = true;
            snapButton.Enabled = true;
            groupBoxSettings.Enabled = true;
            groupBoxBarriersSettings.Enabled = true;

            Properties.Settings.Default.score = score;
            Properties.Settings.Default.time = DateTime.Now;
            Properties.Settings.Default.Save();

            label3.Text = Properties.Settings.Default.time.ToLocalTime().ToString();
            label2.Text = Properties.Settings.Default.score.ToString();

            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "Макс. счёт: " + highScore;
                txtHighScore.ForeColor = Color.Maroon;
            }

            picCanvas.Invalidate();

            MessageBox.Show("Вы проиграли!", "Game Over");
        }

        // когда игра останавливается
        private void StopGame()
        {
            if (!f_stop)
            {
                if (gameTimer.Enabled == true)
                {
                    pauseLabel.Text = "Игра остановлена";
                    gameTimer.Enabled = false;
                    durationOfGameTimer.Enabled = false;
                }
                else
                {
                    pauseLabel.Text = "";
                    gameTimer.Enabled = true;
                    durationOfGameTimer.Enabled = true;
                }
            }
        }

        private void информацияОИгреToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled) StopGame();
            Rules rules = new Rules();
            rules.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void начатьНовуюИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled) StopGame();
            if (MessageBox.Show("Уверены, что хотите начать новую игру?", "Начать новую игру", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RestartGame();
            }
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopGame();
        }
        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled) StopGame();
            AboutProgram aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog();
        }

        private void управлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled) StopGame();
            Managment managment = new Managment();
            managment.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gameTimer.Enabled) StopGame();
            if (MessageBox.Show("Уверены, что вы хотите выйти?", "Выход из игры", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
