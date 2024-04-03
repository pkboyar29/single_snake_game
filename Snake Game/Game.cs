using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_Game
{
    class Game
    {
        // булевые переменные, которые отвечают за то, можем ли мы двигаться в противоположную сторону от нашего текущего направления (например, когда goLeft true, тогда мы можем двигаться влево, вверх и вниз; при это вправо мы не можем позволить двигаться благодаря этим переменным)
        private bool goLeft, goRight, goDown, goUp;

        private List<Point> snake = new List<Point>();
        private List<Point> barriers = new List<Point>();
        private Point food = new Point();
        private Point booster = new Point();

        // длина и высота плоскости, на которой мы играем
        private int _maxwidth, _maxheight;

        public Game()
        {

        }

        public Game(int maxwidth, int maxheight)
        {
            _maxwidth = maxwidth;
            _maxheight = maxheight;
        }

        public List<Point> Snake
        {
            get { return snake; }
        }

        public List<Point> Barriers
        {
            get { return barriers; }
        }

        public Point Food
        {
            get { return food; }
        }

        public Point Booster
        {
            get { return booster; }
        }

        Random rand = new Random();

        /// <summary>
        /// Генерирует изначальную длину змейки
        /// </summary>
        public void GenerateSnake()
        {
            Point head = new Point { X = 2, Y = 2 };
            snake.Add(head);
            for (int i = 0; i < 10; i++)
            {
                Point body = new Point();
                snake.Add(body);
            }
        }

        /// <summary>
        /// Генерирует барьеры по всей плоскости
        /// </summary>
        public void GenerateBarriers(bool howSpawn)
        {
            if (howSpawn)
            {
                for (int i = 0; i < 10; i++)
                {
                    Point barrier = new Point { X = rand.Next(8, _maxwidth), Y = rand.Next(6, _maxheight) };
                    barriers.Add(barrier);
                }
            } else
            {
                for (int i = 0; i <= _maxheight; i++)
                {
                    Point barrier = new Point { X = 0, Y = i };
                    barriers.Add(barrier);
                }
                for (int i = 0; i <= _maxwidth; i++)
                {
                    Point barrier = new Point { X = i, Y = 0 };
                    barriers.Add(barrier);
                }
                for (int i = 0; i <= _maxheight; i++)
                {
                    Point barrier = new Point { X = _maxwidth, Y = i };
                    barriers.Add(barrier);
                }
                for (int i = 0; i <= _maxwidth; i++)
                {
                    Point barrier = new Point { X = i, Y = _maxheight };
                    barriers.Add(barrier);
                }
            }
        }

        /// <summary>
        /// Проверяет координаты на совпадение с координатами других элементов
        /// </summary>
        /// <param name="randX"></param>
        /// <param name="randY"></param>
        /// <returns></returns>
        private bool CheckCoords(int randX, int randY)
        {
            for (int j = 0; j < snake.Count; j++)
                if (snake[j].X == randX && snake[j].Y == randY)
                    return false;

            for (int j = 0; j < barriers.Count; j++)
                if (barriers[j].X == randX && barriers[j].Y == randY)
                    return false;

            if (booster.X == randX && booster.Y == randY)
                return false;

            if (food.X == randX && food.Y == randY)
                return false;

            return true;
        }

        /// <summary>
        /// Генерирует еду
        /// </summary>
        public void GenerateFood()
        {
            while (true)
            {
                int randX = rand.Next(2, _maxwidth);
                int randY = rand.Next(2, _maxheight);

                if (CheckCoords(randX, randY))
                {
                    food = new Point { X = randX, Y = randY };
                    break;
                }
            }
        }

        /// <summary>
        /// Генерирует бустер
        /// </summary>
        public void GenerateBooster()
        {
            while (true)
            {
                int randX = rand.Next(2, _maxwidth);
                int randY = rand.Next(2, _maxheight);

                if (CheckCoords(randX, randY))
                {
                    booster = new Point { X = randX, Y = randY };
                    break;
                }
            }
        }

        /// <summary>
        /// Увеличивает длину змейки на единицу
        /// </summary>
        public void AddBody()
        {
            Point body = new Point
            {
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };

            snake.Add(body);
        }

        /// <summary>
        /// Перемещение змейки
        /// </summary>
        /// <returns>возвращает значение, относительно которого мы поймём, что произошло со змейкой после перемещения</returns>
        public int SnakeMove()
        {
            if (goLeft) Settings.directions = "left";
            if (goRight) Settings.directions = "right";
            if (goDown) Settings.directions = "down";
            if (goUp) Settings.directions = "up";

            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            snake[0].X--;
                            break;
                        case "right":
                            snake[0].X++;
                            break;
                        case "down":
                            snake[0].Y++;
                            break;
                        case "up":
                            snake[0].Y--;
                            break;
                    }

                    // если выходим за границы плоскости
                    if (snake[i].X < 0)
                        snake[i].X = _maxwidth;
                    if (snake[i].X > _maxwidth)
                        snake[i].X = 0;
                    if (snake[i].Y < 0)
                        snake[i].Y = _maxheight;
                    if (snake[i].Y > _maxheight)
                        snake[i].Y = 0;

                    if (snake[i].X == food.X && snake[i].Y == food.Y)
                        return 1;

                    if (snake[i].X == booster.X && snake[i].Y == booster.Y)
                        return 2;

                    for (int j = 1; j < snake.Count; j++)
                    {
                        if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y)
                            return 0;
                    }
                    for (int j = 0; j < barriers.Count; j++)
                    {
                        if (snake[i].X == barriers[j].X && snake[i].Y == barriers[j].Y)
                            return 0;
                    }
                }
                else
                {
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
            return 3;
        }

        /// <summary>
        /// очищает змейку и убирает все барьеры
        /// </summary>
        public void ClearAll()
        {
            snake.Clear();
            barriers.Clear();
        }

        /// <summary>
        /// тут определяем, можем ли мы двигаться в любую из сторон, потом при тике таймера мы уже определяем направление змейки в зависимости от этой переменной
        /// </summary>
        /// <param name="keyCode"></param>
        public void ChangeDirection(Keys keyCode)
        {
            if (keyCode == Keys.Left && Settings.directions != "right")
                goLeft = true;
            if (keyCode == Keys.Right && Settings.directions != "left")
                goRight = true;
            if (keyCode == Keys.Up && Settings.directions != "down")
                goUp = true;
            if (keyCode == Keys.Down && Settings.directions != "up")
                goDown = true;
        }

        public void ClearDirections(Keys keycode)
        {
            if (keycode == Keys.Left) goLeft = false;
            if (keycode == Keys.Right) goRight = false;
            if (keycode == Keys.Up) goUp = false;
            if (keycode == Keys.Down) goDown = false;
        }
    }
}
