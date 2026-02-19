using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using SnakeGameWPF.GameCore.Logic;

namespace SnakeGameWPF.Helpers
{
    public class ColorSettingsManager
    {
        private readonly ColorOptions _colorOptions;
        private readonly GameSettings _settings;

        public ColorSettingsManager(ColorOptions colorOptions, GameSettings settings)
        {
            _colorOptions = colorOptions;
            _settings = settings;
        }

        public void InitializeColorPickers(
            ComboBox snakeHeadPicker,
            ComboBox snakeBodyPicker,
            ComboBox backgroundPicker)
        {
            snakeHeadPicker.ItemsSource = _colorOptions.GetSnakeHeadColors();
            snakeBodyPicker.ItemsSource = _colorOptions.GetSnakeBodyColors();
            backgroundPicker.ItemsSource = _colorOptions.GetBackgroundColors();

            snakeHeadPicker.SelectedIndex = 0;
            snakeBodyPicker.SelectedIndex = 0;
            backgroundPicker.SelectedIndex = 0;
        }

        public void ApplySelectedColors(
            ComboBox snakeHeadPicker,
            ComboBox snakeBodyPicker,
            ComboBox backgroundPicker,
            Canvas gameCanvas)
        {
            if (snakeHeadPicker.SelectedItem is KeyValuePair<string, Color> headColor)
                _settings.SnakeHeadColor = headColor.Value;

            if (snakeBodyPicker.SelectedItem is KeyValuePair<string, Color> bodyColor)
                _settings.SnakeBodyColor = bodyColor.Value;

            if (backgroundPicker.SelectedItem is KeyValuePair<string, Color> backgroundColor)
            {
                _settings.BackgroundColor = backgroundColor.Value;
                gameCanvas.Background = new SolidColorBrush(_settings.BackgroundColor);
            }
        }
    }
}
