namespace QuickStitch
{
    partial class ProcessingDialog
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
            this.description = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(9, 9);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(176, 13);
            this.description.TabIndex = 0;
            this.description.Text = "Please wait while a clip processes...";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 38);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(336, 23);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progress.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(9, 22);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(52, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Waiting...";
            // 
            // ProcessingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 71);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.description);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProcessingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Processing";
            this.Load += new System.EventHandler(this.ProcessingDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label description;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label statusLabel;
    }
}