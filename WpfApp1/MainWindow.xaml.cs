using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using SnakeGameWPF.GameCore.Logic;
using SnakeGameWPF.Helpers;

namespace SnakeGameWPF
{
    public partial class MainWindow : Window
    {
        private GameEngine engine;
        private DispatcherTimer timer;
        private int highScore = 0;

        private GameSettings gameSettings;
        private ColorOptions colorOptions;
        private ColorSettingsManager colorManager;

        public MainWindow()
        {
            InitializeComponent();

            gameSettings = new GameSettings();
            colorOptions = new ColorOptions();
            colorManager = new ColorSettingsManager(colorOptions, gameSettings);

            colorManager.InitializeColorPickers(
                 SnakeHeadColorPicker,
                 SnakeBodyColorPicker,
                 BackgroundColorPicker);

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(gameSettings.InitialSpeed)
            };
            timer.Tick += GameTick;

            Loaded += (_, _) => GameCanvas.Focus();
        }

        private void StartNewGame()
        {
            ApplyColors();

            int columns = (int)GameCanvas.ActualWidth / gameSettings.CellSize;
            int rows = (int)GameCanvas.ActualHeight / gameSettings.CellSize;
            engine = new GameEngine(columns, rows, gameSettings);

            GameOverOverlay.Visibility = Visibility.Collapsed;
            StartButton.Visibility = Visibility.Collapsed;

            timer.Interval = TimeSpan.FromMilliseconds(gameSettings.InitialSpeed);
            timer.Start();
        }

       private void GameTick(object sender, EventArgs e)
{
    engine.Update();
    
    if (engine.IsGameOver)
    {
        ProcessGameOver();
        return;
    }

    RefreshDisplay();
    UpdateGameSpeed();
}

private void ProcessGameOver()
{
    timer.Stop();
    FinalScoreText.Text = $"Ваш рахунок: {engine.Score}";
    GameOverOverlay.Visibility = Visibility.Visible;
    StartButton.Visibility = Visibility.Visible;
}

private void RefreshDisplay()
{
    DrawGame();
    ScoreText.Text = $"Рахунок: {engine.Score}";
    if (engine.Score > highScore)
    {
        highScore = engine.Score;
        HighScoreText.Text = $"Рекорд: {highScore}";
    }
}

        private void DrawGame()
        {
            GameCanvas.Children.Clear();

            foreach (var point in engine.Snake)
            {
                var rect = new Rectangle
                {
                    Width = gameSettings.CellSize,
                    Height = gameSettings.CellSize,
                    Fill = new SolidColorBrush(point == engine.Snake[0]
                        ? gameSettings.SnakeHeadColor
                        : gameSettings.SnakeBodyColor)
                };
                Canvas.SetLeft(rect, point.X * gameSettings.CellSize);
                Canvas.SetTop(rect, point.Y * gameSettings.CellSize);
                GameCanvas.Children.Add(rect);
            }

            var foodEllipse = new Ellipse
            {
                Width = gameSettings.CellSize,
                Height = gameSettings.CellSize,
                Fill = new SolidColorBrush(gameSettings.FoodColor)
            };
            Canvas.SetLeft(foodEllipse, engine.Food.X * gameSettings.CellSize);
            Canvas.SetTop(foodEllipse, engine.Food.Y * gameSettings.CellSize);
            GameCanvas.Children.Add(foodEllipse);
        }

        private void ApplyColors()
        {
            colorManager.ApplySelectedColors(
                SnakeHeadColorPicker,
                SnakeBodyColorPicker,
                BackgroundColorPicker,
                GameCanvas);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (engine == null) return;

            engine.CurrentDirection = e.Key switch
            {
                Key.W or Key.Up => Direction.Up,
                Key.S or Key.Down => Direction.Down,
                Key.A or Key.Left => Direction.Left,
                Key.D or Key.Right => Direction.Right,
                _ => engine.CurrentDirection
            };
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) => StartNewGame();

        private void RestartButton_Click(object sender, RoutedEventArgs e) => StartNewGame();

        private void ColorPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (engine != null)
                ApplyColors();
        }
    }
}
