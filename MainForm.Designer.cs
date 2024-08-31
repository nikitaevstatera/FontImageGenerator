namespace FontImageGenerator
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.CheckedListBox checkedListBoxFonts;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button btnGenerateImages;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

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
            checkedListBoxFonts = new CheckedListBox();
            pictureBoxPreview = new PictureBox();
            btnGenerateImages = new Button();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // checkedListBoxFonts
            // 
            checkedListBoxFonts.FormattingEnabled = true;
            checkedListBoxFonts.Location = new Point(13, 27);
            checkedListBoxFonts.Margin = new Padding(4, 3, 4, 3);
            checkedListBoxFonts.Name = "checkedListBoxFonts";
            checkedListBoxFonts.Size = new Size(233, 472);
            checkedListBoxFonts.TabIndex = 0;
            checkedListBoxFonts.SelectedIndexChanged += checkedListBoxFonts_SelectedIndexChanged;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPreview.Location = new Point(256, 30);
            pictureBoxPreview.Margin = new Padding(4, 3, 4, 3);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(746, 484);
            pictureBoxPreview.TabIndex = 1;
            pictureBoxPreview.TabStop = false;
            // 
            // btnGenerateImages
            // 
            btnGenerateImages.Location = new Point(253, 520);
            btnGenerateImages.Margin = new Padding(4, 3, 4, 3);
            btnGenerateImages.Name = "btnGenerateImages";
            btnGenerateImages.Size = new Size(747, 27);
            btnGenerateImages.TabIndex = 2;
            btnGenerateImages.Text = "—формировать...";
            btnGenerateImages.UseVisualStyleBackColor = true;
            btnGenerateImages.Click += btnGenerateImages_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1015, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 559);
            Controls.Add(menuStrip1);
            Controls.Add(btnGenerateImages);
            Controls.Add(pictureBoxPreview);
            Controls.Add(checkedListBoxFonts);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Font Image Generator";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}