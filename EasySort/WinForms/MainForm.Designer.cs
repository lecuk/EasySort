namespace EasySort.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DisplayBox = new System.Windows.Forms.PictureBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.SortCollectionListbox = new System.Windows.Forms.ListBox();
            this.GeneratorCollectionListbox = new System.Windows.Forms.ListBox();
            this.SortOptionsPanel = new System.Windows.Forms.Panel();
            this.SortNameLabel = new System.Windows.Forms.Label();
            this.SortDescriptionLabel = new System.Windows.Forms.Label();
            this.SortURLLabel = new System.Windows.Forms.LinkLabel();
            this.ArrayLengthLabel = new System.Windows.Forms.Label();
            this.SortDelayTrackbar = new System.Windows.Forms.TrackBar();
            this.SortDelayLabel = new System.Windows.Forms.Label();
            this.ArrayLengthNumeric = new System.Windows.Forms.NumericUpDown();
            this.GenerateOptionsPanel = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.SetDefaultStyleButton = new System.Windows.Forms.MenuItem();
            this.SetRainbowStyleButton = new System.Windows.Forms.MenuItem();
            this.SetDistanceBasedStyleButton = new System.Windows.Forms.MenuItem();
            this.SetMonochromeStyleButton = new System.Windows.Forms.MenuItem();
            this.SetCustomStyleButton = new System.Windows.Forms.MenuItem();
            this.SetCustomDefaultColorButton = new System.Windows.Forms.MenuItem();
            this.SetCustomComparedColorButton = new System.Windows.Forms.MenuItem();
            this.SetCustomSwappedColorButton = new System.Windows.Forms.MenuItem();
            this.SetCustomSpecialColorButton = new System.Windows.Forms.MenuItem();
            this.EditCustomStyleRoot = new System.Windows.Forms.MenuItem();
            this.ChangeStyleRoot = new System.Windows.Forms.MenuItem();
            this.MenuRoot = new System.Windows.Forms.MenuItem();
            this.HelpRoot = new System.Windows.Forms.MenuItem();
            this.HelpButton = new System.Windows.Forms.MenuItem();
            this.AppInfoButton = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.SortInfoPanel = new System.Windows.Forms.Panel();
            this.InfoUILabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).BeginInit();
            this.SortOptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SortDelayTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayLengthNumeric)).BeginInit();
            this.GenerateOptionsPanel.SuspendLayout();
            this.SortInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayBox
            // 
            this.DisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DisplayBox.Location = new System.Drawing.Point(0, 230);
            this.DisplayBox.Name = "DisplayBox";
            this.DisplayBox.Size = new System.Drawing.Size(794, 242);
            this.DisplayBox.TabIndex = 0;
            this.DisplayBox.TabStop = false;
            this.DisplayBox.Resize += new System.EventHandler(this.DisplayBox_SizeChanged);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenerateButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.GenerateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateButton.Location = new System.Drawing.Point(3, 139);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(139, 49);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate array";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // SortButton
            // 
            this.SortButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortButton.Location = new System.Drawing.Point(3, 117);
            this.SortButton.Name = "SortButton";
            this.SortButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SortButton.Size = new System.Drawing.Size(147, 41);
            this.SortButton.TabIndex = 3;
            this.SortButton.Text = "Sort!";
            this.SortButton.UseVisualStyleBackColor = true;
            this.SortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // SortCollectionListbox
            // 
            this.SortCollectionListbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SortCollectionListbox.FormattingEnabled = true;
            this.SortCollectionListbox.Location = new System.Drawing.Point(3, 3);
            this.SortCollectionListbox.Name = "SortCollectionListbox";
            this.SortCollectionListbox.ScrollAlwaysVisible = true;
            this.SortCollectionListbox.Size = new System.Drawing.Size(147, 108);
            this.SortCollectionListbox.TabIndex = 4;
            this.SortCollectionListbox.SelectedIndexChanged += new System.EventHandler(this.SortCollectionListbox_SelectedIndexChanged);
            // 
            // GeneratorCollectionListbox
            // 
            this.GeneratorCollectionListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneratorCollectionListbox.FormattingEnabled = true;
            this.GeneratorCollectionListbox.Location = new System.Drawing.Point(3, 3);
            this.GeneratorCollectionListbox.Name = "GeneratorCollectionListbox";
            this.GeneratorCollectionListbox.ScrollAlwaysVisible = true;
            this.GeneratorCollectionListbox.Size = new System.Drawing.Size(139, 108);
            this.GeneratorCollectionListbox.TabIndex = 5;
            this.GeneratorCollectionListbox.SelectedIndexChanged += new System.EventHandler(this.GeneratorCollectionListbox_SelectedIndexChanged);
            // 
            // SortOptionsPanel
            // 
            this.SortOptionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SortOptionsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SortOptionsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.SortOptionsPanel.Controls.Add(this.SortCollectionListbox);
            this.SortOptionsPanel.Controls.Add(this.SortButton);
            this.SortOptionsPanel.Enabled = false;
            this.SortOptionsPanel.Location = new System.Drawing.Point(629, 12);
            this.SortOptionsPanel.Name = "SortOptionsPanel";
            this.SortOptionsPanel.Size = new System.Drawing.Size(153, 161);
            this.SortOptionsPanel.TabIndex = 6;
            // 
            // SortNameLabel
            // 
            this.SortNameLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortNameLabel.Location = new System.Drawing.Point(3, 3);
            this.SortNameLabel.Name = "SortNameLabel";
            this.SortNameLabel.Size = new System.Drawing.Size(180, 19);
            this.SortNameLabel.TabIndex = 7;
            this.SortNameLabel.Text = "Sort name";
            // 
            // SortDescriptionLabel
            // 
            this.SortDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SortDescriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SortDescriptionLabel.Location = new System.Drawing.Point(3, 22);
            this.SortDescriptionLabel.Name = "SortDescriptionLabel";
            this.SortDescriptionLabel.Size = new System.Drawing.Size(449, 119);
            this.SortDescriptionLabel.TabIndex = 9;
            this.SortDescriptionLabel.Text = "Sort description: bla bla bla bla bla bla bla bla";
            // 
            // SortURLLabel
            // 
            this.SortURLLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SortURLLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.SortURLLabel.Location = new System.Drawing.Point(189, 3);
            this.SortURLLabel.Name = "SortURLLabel";
            this.SortURLLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SortURLLabel.Size = new System.Drawing.Size(263, 19);
            this.SortURLLabel.TabIndex = 8;
            this.SortURLLabel.TabStop = true;
            this.SortURLLabel.Text = "https://en.wikipedia.org/wiki/Sort_name";
            this.SortURLLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.SortURLLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortURLLabel_LinkClicked);
            // 
            // ArrayLengthLabel
            // 
            this.ArrayLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ArrayLengthLabel.AutoSize = true;
            this.ArrayLengthLabel.Location = new System.Drawing.Point(7, 117);
            this.ArrayLengthLabel.Name = "ArrayLengthLabel";
            this.ArrayLengthLabel.Size = new System.Drawing.Size(66, 13);
            this.ArrayLengthLabel.TabIndex = 10;
            this.ArrayLengthLabel.Text = "Array length:";
            // 
            // SortDelayTrackbar
            // 
            this.SortDelayTrackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SortDelayTrackbar.BackColor = System.Drawing.SystemColors.Control;
            this.SortDelayTrackbar.LargeChange = 1;
            this.SortDelayTrackbar.Location = new System.Drawing.Point(163, 161);
            this.SortDelayTrackbar.Maximum = 25;
            this.SortDelayTrackbar.Name = "SortDelayTrackbar";
            this.SortDelayTrackbar.Size = new System.Drawing.Size(460, 45);
            this.SortDelayTrackbar.TabIndex = 11;
            this.SortDelayTrackbar.Value = 15;
            this.SortDelayTrackbar.Scroll += new System.EventHandler(this.SortDelayTrackbar_Scroll);
            // 
            // SortDelayLabel
            // 
            this.SortDelayLabel.AutoSize = true;
            this.SortDelayLabel.Location = new System.Drawing.Point(160, 193);
            this.SortDelayLabel.Name = "SortDelayLabel";
            this.SortDelayLabel.Size = new System.Drawing.Size(147, 13);
            this.SortDelayLabel.TabIndex = 13;
            this.SortDelayLabel.Text = "Delay between updates: 1 ms";
            // 
            // ArrayLengthNumeric
            // 
            this.ArrayLengthNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArrayLengthNumeric.Location = new System.Drawing.Point(75, 115);
            this.ArrayLengthNumeric.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.ArrayLengthNumeric.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ArrayLengthNumeric.Name = "ArrayLengthNumeric";
            this.ArrayLengthNumeric.Size = new System.Drawing.Size(67, 20);
            this.ArrayLengthNumeric.TabIndex = 14;
            this.ArrayLengthNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // GenerateOptionsPanel
            // 
            this.GenerateOptionsPanel.BackColor = System.Drawing.SystemColors.Window;
            this.GenerateOptionsPanel.Controls.Add(this.GeneratorCollectionListbox);
            this.GenerateOptionsPanel.Controls.Add(this.ArrayLengthNumeric);
            this.GenerateOptionsPanel.Controls.Add(this.ArrayLengthLabel);
            this.GenerateOptionsPanel.Controls.Add(this.GenerateButton);
            this.GenerateOptionsPanel.Location = new System.Drawing.Point(12, 15);
            this.GenerateOptionsPanel.Name = "GenerateOptionsPanel";
            this.GenerateOptionsPanel.Size = new System.Drawing.Size(145, 191);
            this.GenerateOptionsPanel.TabIndex = 15;
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(632, 179);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(147, 27);
            this.StopButton.TabIndex = 16;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // SetDefaultStyleButton
            // 
            this.SetDefaultStyleButton.Index = 0;
            this.SetDefaultStyleButton.Shortcut = System.Windows.Forms.Shortcut.Alt1;
            this.SetDefaultStyleButton.Text = "Default";
            this.SetDefaultStyleButton.Click += new System.EventHandler(this.SetDefaultStyleButton_Click);
            // 
            // SetRainbowStyleButton
            // 
            this.SetRainbowStyleButton.Index = 1;
            this.SetRainbowStyleButton.Shortcut = System.Windows.Forms.Shortcut.Alt2;
            this.SetRainbowStyleButton.Text = "Rainbow";
            this.SetRainbowStyleButton.Click += new System.EventHandler(this.SetRainbowStyleButton_Click);
            // 
            // SetDistanceBasedStyleButton
            // 
            this.SetDistanceBasedStyleButton.Index = 2;
            this.SetDistanceBasedStyleButton.Shortcut = System.Windows.Forms.Shortcut.Alt3;
            this.SetDistanceBasedStyleButton.Text = "Distance-based";
            this.SetDistanceBasedStyleButton.Click += new System.EventHandler(this.SetDistanceBasedStyleButton_Click);
            // 
            // SetMonochromeStyleButton
            // 
            this.SetMonochromeStyleButton.Index = 3;
            this.SetMonochromeStyleButton.Shortcut = System.Windows.Forms.Shortcut.Alt4;
            this.SetMonochromeStyleButton.Text = "Monochrome";
            this.SetMonochromeStyleButton.Click += new System.EventHandler(this.SetMonochromeStyleButton_Click);
            // 
            // SetCustomStyleButton
            // 
            this.SetCustomStyleButton.Index = 4;
            this.SetCustomStyleButton.Shortcut = System.Windows.Forms.Shortcut.Alt5;
            this.SetCustomStyleButton.Text = "Custom";
            this.SetCustomStyleButton.Click += new System.EventHandler(this.SetCustomStyleButton_Click);
            // 
            // SetCustomDefaultColorButton
            // 
            this.SetCustomDefaultColorButton.Index = 0;
            this.SetCustomDefaultColorButton.Text = "Default color";
            this.SetCustomDefaultColorButton.Click += new System.EventHandler(this.SetCustomDefaultColorButton_Click);
            // 
            // SetCustomComparedColorButton
            // 
            this.SetCustomComparedColorButton.Index = 1;
            this.SetCustomComparedColorButton.Text = "Compared";
            this.SetCustomComparedColorButton.Click += new System.EventHandler(this.SetCustomComparedColorButton_Click);
            // 
            // SetCustomSwappedColorButton
            // 
            this.SetCustomSwappedColorButton.Index = 2;
            this.SetCustomSwappedColorButton.Text = "Swapped";
            this.SetCustomSwappedColorButton.Click += new System.EventHandler(this.SetCustomSwappedColorButton_Click);
            // 
            // SetCustomSpecialColorButton
            // 
            this.SetCustomSpecialColorButton.Index = 3;
            this.SetCustomSpecialColorButton.Text = "Special";
            this.SetCustomSpecialColorButton.Click += new System.EventHandler(this.SetCustomSpecialColorButton_Click);
            // 
            // EditCustomStyleRoot
            // 
            this.EditCustomStyleRoot.Index = 5;
            this.EditCustomStyleRoot.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SetCustomDefaultColorButton,
            this.SetCustomComparedColorButton,
            this.SetCustomSwappedColorButton,
            this.SetCustomSpecialColorButton});
            this.EditCustomStyleRoot.Text = "Edit custom style...";
            // 
            // ChangeStyleRoot
            // 
            this.ChangeStyleRoot.Index = 0;
            this.ChangeStyleRoot.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SetDefaultStyleButton,
            this.SetRainbowStyleButton,
            this.SetDistanceBasedStyleButton,
            this.SetMonochromeStyleButton,
            this.SetCustomStyleButton,
            this.EditCustomStyleRoot});
            this.ChangeStyleRoot.Text = "Change style";
            // 
            // MenuRoot
            // 
            this.MenuRoot.Index = 0;
            this.MenuRoot.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ChangeStyleRoot});
            this.MenuRoot.Text = "Menu";
            // 
            // HelpRoot
            // 
            this.HelpRoot.Index = 1;
            this.HelpRoot.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.HelpButton,
            this.AppInfoButton});
            this.HelpRoot.Text = "Help";
            // 
            // HelpButton
            // 
            this.HelpButton.Index = 0;
            this.HelpButton.Text = "How to use";
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // AppInfoButton
            // 
            this.AppInfoButton.Index = 1;
            this.AppInfoButton.Text = "About...";
            this.AppInfoButton.Click += new System.EventHandler(this.AppInfoButton_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuRoot,
            this.HelpRoot});
            // 
            // SortInfoPanel
            // 
            this.SortInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SortInfoPanel.Controls.Add(this.SortNameLabel);
            this.SortInfoPanel.Controls.Add(this.SortDescriptionLabel);
            this.SortInfoPanel.Controls.Add(this.SortURLLabel);
            this.SortInfoPanel.Location = new System.Drawing.Point(163, 9);
            this.SortInfoPanel.Name = "SortInfoPanel";
            this.SortInfoPanel.Size = new System.Drawing.Size(460, 146);
            this.SortInfoPanel.TabIndex = 17;
            // 
            // InfoUILabel
            // 
            this.InfoUILabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoUILabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.InfoUILabel.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoUILabel.ForeColor = System.Drawing.Color.White;
            this.InfoUILabel.Location = new System.Drawing.Point(0, 212);
            this.InfoUILabel.Name = "InfoUILabel";
            this.InfoUILabel.Size = new System.Drawing.Size(794, 18);
            this.InfoUILabel.TabIndex = 18;
            this.InfoUILabel.Text = "Array length: 100   Generator: Default   Sorting algorithm: Bubble sort   Compari" +
    "sions: 100; Swaps: 100; Modifies: 0   Style: Default.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.InfoUILabel);
            this.Controls.Add(this.SortInfoPanel);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.GenerateOptionsPanel);
            this.Controls.Add(this.SortDelayLabel);
            this.Controls.Add(this.SortDelayTrackbar);
            this.Controls.Add(this.SortOptionsPanel);
            this.Controls.Add(this.DisplayBox);
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(810, 400);
            this.Name = "MainForm";
            this.Text = "EasySort";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayBox)).EndInit();
            this.SortOptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SortDelayTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrayLengthNumeric)).EndInit();
            this.GenerateOptionsPanel.ResumeLayout(false);
            this.GenerateOptionsPanel.PerformLayout();
            this.SortInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DisplayBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.ListBox SortCollectionListbox;
        private System.Windows.Forms.ListBox GeneratorCollectionListbox;
        private System.Windows.Forms.Panel SortOptionsPanel;
        private System.Windows.Forms.Label SortNameLabel;
        private System.Windows.Forms.Label ArrayLengthLabel;
        private System.Windows.Forms.TrackBar SortDelayTrackbar;
        private System.Windows.Forms.Label SortDescriptionLabel;
        private System.Windows.Forms.Label SortDelayLabel;
        private System.Windows.Forms.NumericUpDown ArrayLengthNumeric;
        private System.Windows.Forms.Panel GenerateOptionsPanel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.MenuItem SetDefaultStyleButton;
        private System.Windows.Forms.MenuItem SetRainbowStyleButton;
        private System.Windows.Forms.MenuItem SetDistanceBasedStyleButton;
        private System.Windows.Forms.MenuItem SetMonochromeStyleButton;
        private System.Windows.Forms.MenuItem SetCustomStyleButton;
        private System.Windows.Forms.MenuItem SetCustomDefaultColorButton;
        private System.Windows.Forms.MenuItem SetCustomComparedColorButton;
        private System.Windows.Forms.MenuItem SetCustomSwappedColorButton;
        private System.Windows.Forms.MenuItem SetCustomSpecialColorButton;
        private System.Windows.Forms.MenuItem EditCustomStyleRoot;
        private System.Windows.Forms.MenuItem ChangeStyleRoot;
        private System.Windows.Forms.MenuItem MenuRoot;
        private System.Windows.Forms.MenuItem HelpRoot;
        private System.Windows.Forms.MainMenu mainMenu1;
        private new System.Windows.Forms.MenuItem HelpButton;
        private System.Windows.Forms.Panel SortInfoPanel;
        private System.Windows.Forms.Label InfoUILabel;
        private System.Windows.Forms.LinkLabel SortURLLabel;
        private System.Windows.Forms.MenuItem AppInfoButton;
    }
}

