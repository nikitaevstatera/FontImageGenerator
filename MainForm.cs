using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FontImageGenerator
{
    public partial class MainForm : Form
    {
        private SettingsForm _settingsForm;

        public MainForm()
        {
            InitializeComponent();
            LoadFonts();

            // Create settings form
            _settingsForm = new SettingsForm();
        }

        private void LoadFonts()
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                checkedListBoxFonts.Items.Add(font.Name);
            }
        }

        private void checkedListBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFont = checkedListBoxFonts.SelectedItem.ToString();
            UpdatePreview(selectedFont);
        }

        private void UpdatePreview(string fontName)
        {
            if (string.IsNullOrEmpty(fontName))
                return;

            Bitmap bitmap = new Bitmap(pictureBoxPreview.Width, pictureBoxPreview.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                using (System.Drawing.Font font = new System.Drawing.Font(fontName, 24))
                {
                    g.DrawString("0123456789", font, Brushes.Black, new PointF(10, 10));
                }
            }
            pictureBoxPreview.Image = bitmap;
        }

        private void btnGenerateImages_Click(object sender, EventArgs e)
        {
            if (checkedListBoxFonts.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one font from the list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = dialog.SelectedPath;

                    // Get settings
                    var settings = _settingsForm.GetSettings();

                    // Create YOLO annotation
                    var yoloAnnotation = new YoloAnnotation();

                    foreach (var selectedFont in checkedListBoxFonts.CheckedItems)
                    {
                        GenerateImages(yoloAnnotation, selectedFont.ToString(), folderPath, settings, false);
                    }
                    // Save YOLO annotation
                    yoloAnnotation.SaveToPath(folderPath);

                    MessageBox.Show("Images generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GenerateImages(YoloAnnotation yoloAnnotation, string fontName, string folderPath, Settings settings, bool DrawRectangles = false)
        {
            System.Drawing.Brush transparentBrush = new SolidBrush(Color.FromArgb(0, 0, 0, 0));
            // Создаем красный Pen
            System.Drawing.Pen redPen = new Pen(Color.Red, 2);

            string PrintedString = new string(settings.Characters);

            foreach (var fontColor in settings.FontColors)
            {
                foreach (var bgColor in settings.BgColors)
                {
                    if (fontColor != bgColor)
                    {
                        Bitmap bitmap = new Bitmap(settings.ImageWidth, settings.ImageHeight);
                        List<AnnotatedObject> annotatedObjects = new List<AnnotatedObject>();
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.Clear(bgColor);

                            // Draw characters
                            float xPosition = 2;
                            float yPosition = 10;
                            foreach (var fontSize in settings.FontSizes)
                            {
                                System.Drawing.Font font = new System.Drawing.Font(fontName, fontSize);
                                SizeF FullTextSize = g.MeasureString(PrintedString, font);
                                foreach (var character in settings.Characters)
                                {
                                    SizeF textSize = g.MeasureString(character.ToString(), font);
                                    if (xPosition + textSize.Width > bitmap.Width - 2)
                                    {
                                        xPosition = 2;
                                        yPosition += FullTextSize.Height + 5; // Расстояние между строками
                                    }
                                    if (yPosition + textSize.Height > bitmap.Height - 2)
                                        break;

                                    g.DrawString(character.ToString(), font, new SolidBrush(fontColor), new PointF(xPosition, yPosition));
                                    if (DrawRectangles)
                                        g.DrawRectangle(redPen, new RectangleF(xPosition, yPosition, textSize.Width, textSize.Height));
                                    // Add annotation
                                    var annotatedObject = new AnnotatedObject
                                    {
                                        Class = Array.IndexOf(settings.Characters, character),
                                        XCenter = xPosition + textSize.Width / 2,
                                        YCenter = yPosition + textSize.Height / 2,
                                        Width = textSize.Width,
                                        Height = textSize.Height
                                    };
                                    annotatedObjects.Add(annotatedObject);                                    

                                    xPosition += textSize.Width + 5; // Расстояние между символами
                                }
                                font.Dispose();
                            }

                            string filePath = System.IO.Path.Combine(folderPath, $"{fontName}_{fontColor.R}_{fontColor.G}_{fontColor.B}_{bgColor.R}_{bgColor.G}_{bgColor.B}.png");
                            bitmap.Save(filePath, ImageFormat.Png);
                        }
                        yoloAnnotation.AddNewAnnotatedImage(bitmap, annotatedObjects);
                    }
                }
            }

            transparentBrush.Dispose();
            redPen.Dispose();

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }
    }
}