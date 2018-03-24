namespace EasySort.WinForms
{
    partial class HelpForm
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
            this.HelpMainLabel = new System.Windows.Forms.Label();
            this.HelpButton_GetStarted = new System.Windows.Forms.Button();
            this.HelpButton_HowToUse = new System.Windows.Forms.Button();
            this.HelpButton_SortingAlgorithms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HelpMainLabel
            // 
            this.HelpMainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpMainLabel.BackColor = System.Drawing.SystemColors.Info;
            this.HelpMainLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HelpMainLabel.Location = new System.Drawing.Point(12, 40);
            this.HelpMainLabel.Name = "HelpMainLabel";
            this.HelpMainLabel.Size = new System.Drawing.Size(440, 212);
            this.HelpMainLabel.TabIndex = 0;
            this.HelpMainLabel.Text = "some info is here";
            // 
            // HelpButton_GetStarted
            // 
            this.HelpButton_GetStarted.AutoSize = true;
            this.HelpButton_GetStarted.BackColor = System.Drawing.SystemColors.Control;
            this.HelpButton_GetStarted.Location = new System.Drawing.Point(12, 12);
            this.HelpButton_GetStarted.Name = "HelpButton_GetStarted";
            this.HelpButton_GetStarted.Size = new System.Drawing.Size(144, 25);
            this.HelpButton_GetStarted.TabIndex = 1;
            this.HelpButton_GetStarted.Text = "Get started";
            this.HelpButton_GetStarted.UseVisualStyleBackColor = true;
            this.HelpButton_GetStarted.Click += new System.EventHandler(this.HelpButton_GetStarted_Click);
            // 
            // HelpButton_HowToUse
            // 
            this.HelpButton_HowToUse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.HelpButton_HowToUse.AutoSize = true;
            this.HelpButton_HowToUse.Location = new System.Drawing.Point(160, 12);
            this.HelpButton_HowToUse.Name = "HelpButton_HowToUse";
            this.HelpButton_HowToUse.Size = new System.Drawing.Size(144, 25);
            this.HelpButton_HowToUse.TabIndex = 2;
            this.HelpButton_HowToUse.Text = "How to use";
            this.HelpButton_HowToUse.UseVisualStyleBackColor = true;
            this.HelpButton_HowToUse.Click += new System.EventHandler(this.HelpButton_HowToUse_Click);
            // 
            // HelpButton_SortingAlgorithms
            // 
            this.HelpButton_SortingAlgorithms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpButton_SortingAlgorithms.AutoSize = true;
            this.HelpButton_SortingAlgorithms.Location = new System.Drawing.Point(308, 12);
            this.HelpButton_SortingAlgorithms.Name = "HelpButton_SortingAlgorithms";
            this.HelpButton_SortingAlgorithms.Size = new System.Drawing.Size(144, 25);
            this.HelpButton_SortingAlgorithms.TabIndex = 3;
            this.HelpButton_SortingAlgorithms.Text = "Sorting algorithms";
            this.HelpButton_SortingAlgorithms.UseVisualStyleBackColor = true;
            this.HelpButton_SortingAlgorithms.Click += new System.EventHandler(this.HelpButton_SortingAlgorithms_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.HelpButton_SortingAlgorithms);
            this.Controls.Add(this.HelpButton_HowToUse);
            this.Controls.Add(this.HelpButton_GetStarted);
            this.Controls.Add(this.HelpMainLabel);
            this.MinimumSize = new System.Drawing.Size(480, 300);
            this.Name = "HelpForm";
            this.Text = "Help";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HelpMainLabel;
        private System.Windows.Forms.Button HelpButton_GetStarted;
        private System.Windows.Forms.Button HelpButton_HowToUse;
        private System.Windows.Forms.Button HelpButton_SortingAlgorithms;
    }
}