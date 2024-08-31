namespace FontImageGenerator
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxCharacters;
        private System.Windows.Forms.NumericUpDown numericUpDownImageWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownImageHeight;
        private System.Windows.Forms.ListBox listBoxFontSizes;
        private System.Windows.Forms.ListBox listBoxFontColors;
        private System.Windows.Forms.ListBox listBoxBgColors;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxCharacters = new TextBox();
            numericUpDownImageWidth = new NumericUpDown();
            numericUpDownImageHeight = new NumericUpDown();
            listBoxFontSizes = new ListBox();
            listBoxFontColors = new ListBox();
            listBoxBgColors = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownImageWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownImageHeight).BeginInit();
            SuspendLayout();
            // 
            // textBoxCharacters
            // 
            textBoxCharacters.Location = new Point(14, 14);
            textBoxCharacters.Margin = new Padding(4, 3, 4, 3);
            textBoxCharacters.Name = "textBoxCharacters";
            textBoxCharacters.Size = new Size(233, 23);
            textBoxCharacters.TabIndex = 0;
            // 
            // numericUpDownImageWidth
            // 
            numericUpDownImageWidth.Location = new Point(254, 14);
            numericUpDownImageWidth.Margin = new Padding(4, 3, 4, 3);
            numericUpDownImageWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownImageWidth.Name = "numericUpDownImageWidth";
            numericUpDownImageWidth.Size = new Size(117, 23);
            numericUpDownImageWidth.TabIndex = 1;
            // 
            // numericUpDownImageHeight
            // 
            numericUpDownImageHeight.Location = new Point(378, 14);
            numericUpDownImageHeight.Margin = new Padding(4, 3, 4, 3);
            numericUpDownImageHeight.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownImageHeight.Name = "numericUpDownImageHeight";
            numericUpDownImageHeight.Size = new Size(117, 23);
            numericUpDownImageHeight.TabIndex = 2;
            // 
            // listBoxFontSizes
            // 
            listBoxFontSizes.FormattingEnabled = true;
            listBoxFontSizes.ItemHeight = 15;
            listBoxFontSizes.Location = new Point(14, 44);
            listBoxFontSizes.Margin = new Padding(4, 3, 4, 3);
            listBoxFontSizes.Name = "listBoxFontSizes";
            listBoxFontSizes.SelectionMode = SelectionMode.MultiSimple;
            listBoxFontSizes.Size = new Size(116, 184);
            listBoxFontSizes.TabIndex = 3;
            // 
            // listBoxFontColors
            // 
            listBoxFontColors.FormattingEnabled = true;
            listBoxFontColors.ItemHeight = 15;
            listBoxFontColors.Location = new Point(138, 44);
            listBoxFontColors.Margin = new Padding(4, 3, 4, 3);
            listBoxFontColors.Name = "listBoxFontColors";
            listBoxFontColors.SelectionMode = SelectionMode.MultiSimple;
            listBoxFontColors.Size = new Size(116, 184);
            listBoxFontColors.TabIndex = 4;
            // 
            // listBoxBgColors
            // 
            listBoxBgColors.FormattingEnabled = true;
            listBoxBgColors.ItemHeight = 15;
            listBoxBgColors.Location = new Point(261, 44);
            listBoxBgColors.Margin = new Padding(4, 3, 4, 3);
            listBoxBgColors.Name = "listBoxBgColors";
            listBoxBgColors.SelectionMode = SelectionMode.MultiSimple;
            listBoxBgColors.Size = new Size(116, 184);
            listBoxBgColors.TabIndex = 5;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 242);
            Controls.Add(listBoxBgColors);
            Controls.Add(listBoxFontColors);
            Controls.Add(listBoxFontSizes);
            Controls.Add(numericUpDownImageHeight);
            Controls.Add(numericUpDownImageWidth);
            Controls.Add(textBoxCharacters);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SettingsForm";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)numericUpDownImageWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownImageHeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}