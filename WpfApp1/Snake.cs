using System.Collections.Generic;
using System.Windows;

namespace SnakeGameWPF.GameCore.Logic
{
    public class Snake
    {
        public List<Point> Body { get; private set; }

        public Snake(int startX, int startY)
        {
            Body = new List<Point>
            {
                new Point(startX, startY),
                new Point(startX - 1, startY),
                new Point(startX - 2, startY)
            };
        }

        public void Move(Direction direction)
        {
            Point newHead = Body[0];

            switch (direction)
            {
                case Direction.Up:
                    newHead = new Point(newHead.X, newHead.Y - 1);
                    break;
                case Direction.Down:
                    newHead = new Point(newHead.X, newHead.Y + 1);
                    break;
                case Direction.Left:
                    newHead = new Point(newHead.X - 1, newHead.Y);
                    break;
                case Direction.Right:
                    newHead = new Point(newHead.X + 1, newHead.Y);
                    break;
            }

            Body.Insert(0, newHead);
            Body.RemoveAt(Body.Count - 1);
        }

     
    }
}
