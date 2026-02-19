using System.Windows.Media;

public class ColorOptions
{
    public List<KeyValuePair<string, Color>> GetSnakeHeadColors() => new()
    {
        new KeyValuePair<string, Color>("Зелений", Colors.Green),
        new KeyValuePair<string, Color>("Синій", Colors.Blue),
        new KeyValuePair<string, Color>("Червоний", Colors.Red)
    };

    public List<KeyValuePair<string, Color>> GetSnakeBodyColors() => new()
    {
        new KeyValuePair<string, Color>("Світло-зелений", Colors.LightGreen),
        new KeyValuePair<string, Color>("Помаранчевий", Colors.Orange),
        new KeyValuePair<string, Color>("Синій", Colors.Blue),
        new KeyValuePair<string, Color>("Фіолетовий", Colors.Purple)
    };

    public List<KeyValuePair<string, Color>> GetBackgroundColors() => new()
    {
        new KeyValuePair<string, Color>("Чорний", Colors.Black),
        new KeyValuePair<string, Color>("Сірий", Colors.Gray),
        new KeyValuePair<string, Color>("Білий", Colors.White),
        new KeyValuePair<string, Color>("Зелений", Colors.LimeGreen)
    };
}
