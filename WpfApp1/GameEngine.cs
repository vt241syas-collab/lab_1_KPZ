using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SnakeGameWPF.GameCore.Logic
{
    public class GameEngine
    {
        public List<Point> Snake { get; private set; }
        public Point Food { get; private set; }
        public Direction CurrentDirection { get; set; }
        public int Score { get; private set; }
        public bool IsGameOver { get; private set; }

        private readonly Random random = new();
        private readonly int columns;
        private readonly int rows;

        public GameEngine(int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
            ResetGame();
        }

        public void ResetGame()
        {
            Snake = new List<Point>
            {
                new Point(10, 10),
                new Point(9, 10),
                new Point(8, 10)
            };
            CurrentDirection = Direction.Right;
            Score = 0;
            IsGameOver = false;
            GenerateFood();
        }

        public void Update()
        {
            if (IsGameOver) return;

            Point head = Snake[0];
            Point newHead = head;

            switch (CurrentDirection)
            {
                case Direction.Up:
                    newHead.Y -= 1;
                    break;
                case Direction.Down:
                    newHead.Y += 1;
                    break;
                case Direction.Left:
                    newHead.X -= 1;
                    break;
                case Direction.Right:
                    newHead.X += 1;
                    break;
            }

            if (newHead.X < 0 || newHead.Y < 0 || newHead.X >= columns || newHead.Y >= rows || Snake.Contains(newHead))
            {
                IsGameOver = true;
                return;
            }

            Snake.Insert(0, newHead);

            if (newHead == Food)
            {
                Score++;
                GenerateFood();
            }
            else
            {
                Snake.RemoveAt(Snake.Count - 1);
            }
        }
        private readonly GameSettings settings;

        public GameEngine(int columns, int rows, GameSettings settings)
        {
            this.columns = columns;
            this.rows = rows;
            this.settings = settings;
            ResetGame();
        }

        private void GenerateFood()
        {
            do
            {
                Food = new Point(random.Next(columns), random.Next(rows));
            } while (Snake.Contains(Food));
        }
    }
}
