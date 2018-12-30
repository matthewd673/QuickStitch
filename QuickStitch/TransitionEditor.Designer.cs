namespace QuickStitch
{
    partial class TransitionEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransitionEditor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.firstSelect = new System.Windows.Forms.ListBox();
            this.secondSelect = new System.Windows.Forms.ListBox();
            this.styleSelect = new System.Windows.Forms.ComboBox();
            this.durationInput = new System.Windows.Forms.NumericUpDown();
            this.previewButton = new System.Windows.Forms.Button();
            this.playBar = new System.Windows.Forms.TrackBar();
            this.frameInput = new System.Windows.Forms.NumericUpDown();
            this.playCheck = new System.Windows.Forms.CheckBox();
            this.generateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(456, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // firstSelect
            // 
            this.firstSelect.FormattingEnabled = true;
            this.firstSelect.Location = new System.Drawing.Point(12, 12);
            this.firstSelect.Name = "firstSelect";
            this.firstSelect.Size = new System.Drawing.Size(216, 329);
            this.firstSelect.TabIndex = 1;
            // 
            // secondSelect
            // 
            this.secondSelect.FormattingEnabled = true;
            this.secondSelect.Location = new System.Drawing.Point(234, 12);
            this.secondSelect.Name = "secondSelect";
            this.secondSelect.Size = new System.Drawing.Size(216, 329);
            this.secondSelect.TabIndex = 2;
            // 
            // styleSelect
            // 
            this.styleSelect.FormattingEnabled = true;
            this.styleSelect.Items.AddRange(new object[] {
            "Crossfade",
            "Slide Right",
            "Slide Left",
            "Slide Up",
            "Slide Down",
            "Shrink",
            "Grow"});
            this.styleSelect.Location = new System.Drawing.Point(456, 12);
            this.styleSelect.Name = "styleSelect";
            this.styleSelect.Size = new System.Drawing.Size(189, 21);
            this.styleSelect.TabIndex = 3;
            // 
            // durationInput
            // 
            this.durationInput.Location = new System.Drawing.Point(651, 13);
            this.durationInput.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.durationInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.durationInput.Name = "durationInput";
            this.durationInput.Size = new System.Drawing.Size(57, 20);
            this.durationInput.TabIndex = 4;
            this.durationInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(714, 8);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(62, 27);
            this.previewButton.TabIndex = 5;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // playBar
            // 
            this.playBar.Location = new System.Drawing.Point(456, 287);
            this.playBar.Name = "playBar";
            this.playBar.Size = new System.Drawing.Size(257, 45);
            this.playBar.TabIndex = 6;
            // 
            // frameInput
            // 
            this.frameInput.Location = new System.Drawing.Point(719, 287);
            this.frameInput.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.frameInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameInput.Name = "frameInput";
            this.frameInput.Size = new System.Drawing.Size(57, 20);
            this.frameInput.TabIndex = 7;
            this.frameInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // playCheck
            // 
            this.playCheck.AutoSize = true;
            this.playCheck.Location = new System.Drawing.Point(719, 313);
            this.playCheck.Name = "playCheck";
            this.playCheck.Size = new System.Drawing.Size(46, 17);
            this.playCheck.TabIndex = 8;
            this.playCheck.Text = "Play";
            this.playCheck.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(702, 336);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 9;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // TransitionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 367);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.playCheck);
            this.Controls.Add(this.frameInput);
            this.Controls.Add(this.playBar);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.durationInput);
            this.Controls.Add(this.styleSelect);
            this.Controls.Add(this.secondSelect);
            this.Controls.Add(this.firstSelect);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransitionEditor";
            this.Text = "Transition Editor";
            this.Load += new System.EventHandler(this.TransitionEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.durationInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frameInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox firstSelect;
        private System.Windows.Forms.ListBox secondSelect;
        private System.Windows.Forms.ComboBox styleSelect;
        private System.Windows.Forms.NumericUpDown durationInput;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.TrackBar playBar;
        private System.Windows.Forms.NumericUpDown frameInput;
        private System.Windows.Forms.CheckBox playCheck;
        private System.Windows.Forms.Button generateButton;
    }
}