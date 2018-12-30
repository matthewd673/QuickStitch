namespace QuickStitch
{
    partial class Clip
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.thumbnail = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbnail
            // 
            this.thumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.thumbnail.Location = new System.Drawing.Point(3, 3);
            this.thumbnail.Name = "thumbnail";
            this.thumbnail.Size = new System.Drawing.Size(32, 32);
            this.thumbnail.TabIndex = 0;
            this.thumbnail.TabStop = false;
            this.thumbnail.Click += new System.EventHandler(this.Clip_Click);
            this.thumbnail.DoubleClick += new System.EventHandler(this.Clip_DoubleClick);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(38, 3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(39, 20);
            this.title.TabIndex = 1;
            this.title.Text = "Clip";
            this.title.Click += new System.EventHandler(this.Clip_Click);
            this.title.DoubleClick += new System.EventHandler(this.Clip_DoubleClick);
            // 
            // colorPanel
            // 
            this.colorPanel.Location = new System.Drawing.Point(41, 25);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(200, 10);
            this.colorPanel.TabIndex = 2;
            this.colorPanel.Click += new System.EventHandler(this.Clip_Click);
            this.colorPanel.DoubleClick += new System.EventHandler(this.Clip_DoubleClick);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(3, 3);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(32, 32);
            this.progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progress.TabIndex = 3;
            // 
            // Clip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.progress);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.thumbnail);
            this.Name = "Clip";
            this.Size = new System.Drawing.Size(320, 40);
            this.Load += new System.EventHandler(this.Clip_Load);
            this.Click += new System.EventHandler(this.Clip_Click);
            this.DoubleClick += new System.EventHandler(this.Clip_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbnail;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.ProgressBar progress;
    }
}
