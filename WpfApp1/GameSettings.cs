using System.Windows.Media;

public class GameSettings
{
    public int CellSize { get; set; } = 20;
    public int InitialSpeed { get; set; } = 200;
    public int SpeedStep { get; set; } = 10;

    public Color SnakeHeadColor { get; set; } = Colors.Green;
    public Color SnakeBodyColor { get; set; } = Colors.DarkGreen;
    public Color BackgroundColor { get; set; } = Colors.Black;
    public Color FoodColor { get; set; } = Colors.Red;
}
