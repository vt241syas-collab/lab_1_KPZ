namespace SnakeGameWPF.GameCore.Logic
{
    public class Food
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Food(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
