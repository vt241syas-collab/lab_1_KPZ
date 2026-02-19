using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnakeGameWPF.GameCore.Models
{
    public abstract class GameObject
    {
        public Point Position { get; set; }
        public int Size { get; set; }
        public UIElement Visual { get; protected set; }

        protected GameObject(Point position, int size)
        {
      
        }

        public abstract void Draw(Canvas canvas);
    }
}
