namespace QuickStitch
{
    partial class Editor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.openButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.stitchButton = new System.Windows.Forms.Button();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.timeline = new System.Windows.Forms.Panel();
            this.timestampInput = new System.Windows.Forms.NumericUpDown();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.loadingIcons = new System.Windows.Forms.ImageList(this.components);
            this.playCheck = new System.Windows.Forms.CheckBox();
            this.fpsInput = new System.Windows.Forms.NumericUpDown();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.clipsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.addAudioButton = new System.Windows.Forms.Button();
            this.organizeLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.projectNameInput = new System.Windows.Forms.TextBox();
            this.loadProjectButton = new System.Windows.Forms.Button();
            this.transitionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.timestampInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsInput)).BeginInit();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(100, 39);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(93, 24);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Append Video";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(210, 543);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(48, 24);
            this.upButton.TabIndex = 2;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(264, 543);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(48, 24);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(318, 543);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(72, 24);
            this.removeButton.TabIndex = 4;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // stitchButton
            // 
            this.stitchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stitchButton.Location = new System.Drawing.Point(331, 67);
            this.stitchButton.Name = "stitchButton";
            this.stitchButton.Size = new System.Drawing.Size(59, 23);
            this.stitchButton.TabIndex = 6;
            this.stitchButton.Text = "Render";
            this.stitchButton.UseVisualStyleBackColor = true;
            this.stitchButton.Click += new System.EventHandler(this.stitchButton_Click);
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(12, 69);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(313, 20);
            this.nameInput.TabIndex = 7;
            this.nameInput.Text = "output.mp4";
            // 
            // timeline
            // 
            this.timeline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timeline.Location = new System.Drawing.Point(396, 498);
            this.timeline.Name = "timeline";
            this.timeline.Size = new System.Drawing.Size(567, 43);
            this.timeline.TabIndex = 8;
            this.timeline.Paint += new System.Windows.Forms.PaintEventHandler(this.timeline_Paint);
            this.timeline.MouseMove += new System.Windows.Forms.MouseEventHandler(this.timeline_MouseMove);
            // 
            // timestampInput
            // 
            this.timestampInput.Location = new System.Drawing.Point(969, 498);
            this.timestampInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.timestampInput.Name = "timestampInput";
            this.timestampInput.Size = new System.Drawing.Size(79, 20);
            this.timestampInput.TabIndex = 9;
            this.timestampInput.ValueChanged += new System.EventHandler(this.timestampInput_ValueChanged);
            // 
            // previewBox
            // 
            this.previewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.previewBox.Location = new System.Drawing.Point(396, 12);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(640, 480);
            this.previewBox.TabIndex = 10;
            this.previewBox.TabStop = false;
            // 
            // loadingIcons
            // 
            this.loadingIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("loadingIcons.ImageStream")));
            this.loadingIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.loadingIcons.Images.SetKeyName(0, "1");
            this.loadingIcons.Images.SetKeyName(1, "2");
            this.loadingIcons.Images.SetKeyName(2, "3");
            this.loadingIcons.Images.SetKeyName(3, "4");
            // 
            // playCheck
            // 
            this.playCheck.AutoSize = true;
            this.playCheck.Location = new System.Drawing.Point(1001, 524);
            this.playCheck.Name = "playCheck";
            this.playCheck.Size = new System.Drawing.Size(46, 17);
            this.playCheck.TabIndex = 12;
            this.playCheck.Text = "Play";
            this.playCheck.UseVisualStyleBackColor = true;
            this.playCheck.CheckedChanged += new System.EventHandler(this.playCheck_CheckedChanged);
            // 
            // fpsInput
            // 
            this.fpsInput.InterceptArrowKeys = false;
            this.fpsInput.Location = new System.Drawing.Point(1005, 547);
            this.fpsInput.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.fpsInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fpsInput.Name = "fpsInput";
            this.fpsInput.Size = new System.Drawing.Size(43, 20);
            this.fpsInput.TabIndex = 14;
            this.fpsInput.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(969, 549);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(30, 13);
            this.fpsLabel.TabIndex = 15;
            this.fpsLabel.Text = "FPS:";
            // 
            // clipsContainer
            // 
            this.clipsContainer.AutoScroll = true;
            this.clipsContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.clipsContainer.Location = new System.Drawing.Point(12, 96);
            this.clipsContainer.Name = "clipsContainer";
            this.clipsContainer.Size = new System.Drawing.Size(378, 445);
            this.clipsContainer.TabIndex = 16;
            this.clipsContainer.WrapContents = false;
            // 
            // addAudioButton
            // 
            this.addAudioButton.Location = new System.Drawing.Point(199, 39);
            this.addAudioButton.Name = "addAudioButton";
            this.addAudioButton.Size = new System.Drawing.Size(93, 24);
            this.addAudioButton.TabIndex = 17;
            this.addAudioButton.Text = "Import Audio";
            this.addAudioButton.UseVisualStyleBackColor = true;
            // 
            // organizeLabel
            // 
            this.organizeLabel.AutoSize = true;
            this.organizeLabel.Location = new System.Drawing.Point(127, 549);
            this.organizeLabel.Name = "organizeLabel";
            this.organizeLabel.Size = new System.Drawing.Size(77, 13);
            this.organizeLabel.TabIndex = 18;
            this.organizeLabel.Text = "Organize Clips:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(331, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(59, 21);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // projectNameInput
            // 
            this.projectNameInput.Location = new System.Drawing.Point(12, 13);
            this.projectNameInput.Name = "projectNameInput";
            this.projectNameInput.Size = new System.Drawing.Size(313, 20);
            this.projectNameInput.TabIndex = 20;
            this.projectNameInput.Text = "workspace/project1";
            // 
            // loadProjectButton
            // 
            this.loadProjectButton.Location = new System.Drawing.Point(12, 39);
            this.loadProjectButton.Name = "loadProjectButton";
            this.loadProjectButton.Size = new System.Drawing.Size(82, 24);
            this.loadProjectButton.TabIndex = 21;
            this.loadProjectButton.Text = "Load Existing";
            this.loadProjectButton.UseVisualStyleBackColor = true;
            // 
            // transitionButton
            // 
            this.transitionButton.Location = new System.Drawing.Point(298, 39);
            this.transitionButton.Name = "transitionButton";
            this.transitionButton.Size = new System.Drawing.Size(92, 24);
            this.transitionButton.TabIndex = 22;
            this.transitionButton.Text = "Add Transition";
            this.transitionButton.UseVisualStyleBackColor = true;
            this.transitionButton.Click += new System.EventHandler(this.transitionButton_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 573);
            this.Controls.Add(this.transitionButton);
            this.Controls.Add(this.loadProjectButton);
            this.Controls.Add(this.projectNameInput);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.organizeLabel);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.addAudioButton);
            this.Controls.Add(this.clipsContainer);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.fpsInput);
            this.Controls.Add(this.playCheck);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.timestampInput);
            this.Controls.Add(this.timeline);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.stitchButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Editor";
            this.Text = "QuickStitch";
            this.Load += new System.EventHandler(this.Editor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timestampInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button stitchButton;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Panel timeline;
        private System.Windows.Forms.NumericUpDown timestampInput;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.ImageList loadingIcons;
        private System.Windows.Forms.CheckBox playCheck;
        private System.Windows.Forms.NumericUpDown fpsInput;
        private System.Windows.Forms.Label fpsLabel;
        private System.Windows.Forms.FlowLayoutPanel clipsContainer;
        private System.Windows.Forms.Button addAudioButton;
        private System.Windows.Forms.Label organizeLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox projectNameInput;
        private System.Windows.Forms.Button loadProjectButton;
        private System.Windows.Forms.Button transitionButton;
    }
}

