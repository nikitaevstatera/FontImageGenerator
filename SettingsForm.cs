using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace FontImageGenerator
{
    public partial class SettingsForm : Form
    {
        private Settings _settings;

        public SettingsForm()
        {
            InitializeComponent();

            // Initialize settings
            _settings = new Settings();
            _settings.Characters = "0123456789".ToCharArray();
            _settings.ImageWidth = 1280;
            _settings.ImageHeight = 1280;
            _settings.FontSizes = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72, 108, 162, 243, 365 };
            _settings.FontColors = new Color[] { Color.FromArgb(40, 40, 40), Color.FromArgb(120, 120, 120), Color.FromArgb(180, 180, 180), Color.FromArgb(230, 230, 230) };
            _settings.BgColors = new Color[] { Color.FromArgb(40, 40, 40), Color.FromArgb(120, 120, 120), Color.FromArgb(180, 180, 180), Color.FromArgb(230, 230, 230) };

            // Populate controls
            textBoxCharacters.Text = new string(_settings.Characters);
            numericUpDownImageWidth.Value = _settings.ImageWidth;
            numericUpDownImageHeight.Value = _settings.ImageHeight;

            // Populate the ListBox with FontSizes
            foreach (int fontSize in _settings.FontSizes)
            {
                listBoxFontSizes.Items.Add(fontSize); // Add as object
                listBoxFontSizes.SelectedItems.Add(fontSize); // Add as object
            }

            // Populate the ListBox with FontColors
            foreach (Color fontColor in _settings.FontColors)
            {
                listBoxFontColors.Items.Add(fontColor); // Add as object
                listBoxFontColors.SelectedItems.Add(fontColor); // Add as object
            }

            // Populate the ListBox with BgColors
            foreach (Color bgColor in _settings.BgColors)
            {
                listBoxBgColors.Items.Add(bgColor); // Add as object
                listBoxBgColors.SelectedItems.Add(bgColor); // Add as object
            }

            // Add event handlers
            textBoxCharacters.TextChanged += (sender, e) => _settings.Characters = textBoxCharacters.Text.ToCharArray();
            numericUpDownImageWidth.ValueChanged += (sender, e) => _settings.ImageWidth = (int)numericUpDownImageWidth.Value;
            numericUpDownImageHeight.ValueChanged += (sender, e) => _settings.ImageHeight = (int)numericUpDownImageHeight.Value;

            listBoxFontSizes.SelectedIndexChanged += (sender, e) => _settings.FontSizes = listBoxFontSizes.SelectedItems.Cast<int>().ToArray();
            listBoxFontColors.SelectedIndexChanged += (sender, e) => _settings.FontColors = listBoxFontColors.SelectedItems.Cast<Color>().ToArray();
            listBoxBgColors.SelectedIndexChanged += (sender, e) => _settings.BgColors = listBoxBgColors.SelectedItems.Cast<Color>().ToArray();
        }

        public Settings GetSettings()
        {
            return _settings;
        }
    }

    public class Settings
    {
        public char[] Characters { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public int[] FontSizes { get; set; }
        public Color[] FontColors { get; set; }
        public Color[] BgColors { get; set; }
    }
}