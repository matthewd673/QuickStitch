using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace QuickStitch
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }
        
        public List<string> videoPaths = new List<string>();
        public Dictionary<string, Metadata> videoData = new Dictionary<string, Metadata>();

        Graphics g;

        int timestamp = 0;
        int totalFrames = 0;
        decimal scale = 1;
        string highlighted = "";

        System.Windows.Forms.Timer playTimer = new System.Windows.Forms.Timer();

        public List<Clip> clips = new List<Clip>();

        List<ProcessingDialog> processingWindows = new List<ProcessingDialog>();

        private void Editor_Load(object sender, EventArgs e)
        {

            if(!File.Exists("ffmpeg.exe") || !File.Exists("ffprobe.exe"))
            {
                if(MessageBox.Show("FFMPEG or FFProbe is not present in your working directory. QuickStitch requires these tools to load and manipulate videos. Would you like to download them now?", "FFMPEG Missing", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process downloadProcess = new Process();
                    downloadProcess.StartInfo = new ProcessStartInfo("https://ffmpeg.zeranoe.com/builds/");
                    downloadProcess.Start();
                }
                else
                {
                    MessageBox.Show("Until FFMPEG and FFProbe are available you will encounter errors.", "Warning");
                }
                
            }

            g = timeline.CreateGraphics();

            playTimer.Tick += playTimer_Tick;

            Settings.loadSettings();
        }

        Stopwatch metadataWatch = new Stopwatch();

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Append a video file";
            openDialog.CheckFileExists = true;
            openDialog.Multiselect = true;
            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string path in openDialog.FileNames)
                {
                    videoPaths.Add(path);
                    //videoList.Items.Add(getCleanPath(path));

                    Clip clip = new Clip();
                    clip.parent = this;
                    clip.fullPath = path;
                    clip.clip = getCleanPath(path);
                    clipsContainer.Controls.Add(clip);
                    clips.Add(clip);
                    
                    metadataWatch.Start();

                    //generate processing dialog
                    ProcessingDialog processingDialog = new ProcessingDialog();
                    processingDialog.fullPath = path;
                    processingDialog.clipName = getCleanPath(path);
                    processingDialog.Show();
                    processingWindows.Add(processingDialog);

                    //lock off crashy ui
                    timeline.Enabled = false;
                    timestampInput.Enabled = false;
                    playCheck.Enabled = false;

                    Thread metadataThread = new Thread(() => findMetadata(path));
                    metadataThread.Start();

                }
            }
        }

        public string getCleanPath(string path)
        {
            return path.Split('\\')[path.Split('\\').Count() - 1];
        }

        void addMetadata(Metadata m)
        {
            videoData[m.path] = m;
            metadataWatch.Stop();

            totalFrames = 0;
            foreach (string path in videoPaths)
            {
                if (videoData.ContainsKey(path))
                {
                    totalFrames += videoData[path].frames;
                }
            }

            foreach (Clip c in clips)
            {
                if (c.fullPath == m.path)
                {
                    c.setColor(m.color);
                    c.setThumbnail(m.thumbnail);
                    c.stopLoading();
                }
            }

            timestampInput.Maximum = totalFrames;

            if (processingWindows.Count > 0)
            {
                foreach(ProcessingDialog dialog in processingWindows)
                {
                    if(dialog.fullPath == m.path)
                    {
                        dialog.Hide();
                        processingWindows.Remove(dialog);
                        break;
                    }
                }
            }
            
            if(processingWindows.Count == 0) //yes this has to be distinct, think about it
            {
                timeline.Enabled = true;
                timestampInput.Enabled = true;
                playCheck.Enabled = true;
                displayFrame(timestamp); //this doesn't work, why?
            }

            timeline.Invalidate();
        }

        void updateProcessing(string path, string status)
        {
            foreach (ProcessingDialog dialog in processingWindows)
            {
                if (dialog.fullPath == path)
                {
                    dialog.updateStatus(status);
                    break;
                }
            }
        }

        delegate void metadataDelegate(Metadata m);

        delegate void updateProcessingDelegate(string path, string status);

        void findMetadata(string path)
        {
            metadataDelegate setData = addMetadata;
            updateProcessingDelegate updateStatus = updateProcessing;

            Metadata m = new Metadata(path);

            Invoke(updateStatus, path, "Preparing FFProbe");

            string frameArgs = "-v error -count_frames -select_streams v:0 -show_entries stream=nb_frames -of default=nokey=1:noprint_wrappers=1 \"" + path + "\"";

            //count the frames
            Process ffprobe = new Process();
            ffprobe.StartInfo = new ProcessStartInfo("ffprobe.exe", frameArgs);
            ffprobe.StartInfo.UseShellExecute = false;
            ffprobe.StartInfo.CreateNoWindow = true;
            ffprobe.StartInfo.RedirectStandardOutput = true;

            Invoke(updateStatus, path, "Executing FFProbe");

            ffprobe.Start();

            string output = ffprobe.StandardOutput.ReadToEnd();

            ffprobe.WaitForExit();

            m.frames = Convert.ToInt32(output);

            //this should happen on another thread eventually

            string previewDirName = "previews\\" + getCleanPath(path).Split('.')[0];

            string previewExt = Settings.previewExtension;

            if (Settings.generatePreviews)
            {
                Invoke(updateStatus, path, "Preparing to generate previews");

                if (!Directory.Exists("previews"))
                {
                    Directory.CreateDirectory("previews");
                }

                if (!Directory.Exists(previewDirName))
                    Directory.CreateDirectory(previewDirName);

                string previewSize = Settings.previewWidth.ToString() + "x" + Settings.previewHeight.ToString();

                Invoke(updateStatus, path, "Preparing FFMPEG");

                string splitArgs = "-i \"" + path + "\" -s " + previewSize + " -f image2 \"" + previewDirName + "\\%d" + previewExt + "\"";
                Process ffmpeg = new Process();
                ffmpeg.StartInfo = new ProcessStartInfo("ffmpeg.exe", splitArgs);
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.CreateNoWindow = true;

                Invoke(updateStatus, path, "Executing FFMPEG");

                ffmpeg.Start();

                ffmpeg.WaitForExit();
            }
            Invoke(updateStatus, path, "Generating thumbnail");

            //grab a thumbnail from the first preview frame
            if (File.Exists(previewDirName + "\\1" + previewExt))
            {
                Bitmap firstFrame = new Bitmap(previewDirName + "\\1" + previewExt);
                Bitmap thumbnail = new Bitmap(32, 32);
                Graphics thumbG = Graphics.FromImage(thumbnail);
                thumbG.DrawImage(firstFrame, 0, 0, 32, 32);
                thumbnail.Save(previewDirName + "\\thumb" + previewExt);
                m.thumbnail = thumbnail;
            }
            else
            {
                m.thumbnail = new Bitmap(16, 16);
            }

            Invoke(updateStatus, path, "Finishing up");

            m.generateColor(videoData.Count);

            Invoke(setData, m);

        }

        public string getSelectedPath()
        {
            string selectedPath = "";
            foreach (Clip c in clips)
            {
                if(c.selected)
                {
                    selectedPath = c.fullPath;
                }
            }
            return selectedPath;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            string path = getSelectedPath();
            if (path != "")
            {
                videoPaths.Remove(path);
                foreach(Clip c in clips)
                {
                    if(c.fullPath == path)
                    {
                        clips.Remove(c);
                        refreshClips();
                        break;
                    }
                }

                totalFrames = 0;
                foreach (string videoPath in videoPaths)
                {
                    if(videoData.ContainsKey(videoPath))
                    {
                        totalFrames += videoData[path].frames;
                    }
                }

                timestampInput.Maximum = totalFrames;
                 
                //is this necessary?
                if (timestampInput.Value > timestampInput.Maximum)
                    timestampInput.Value = timestampInput.Maximum;

                timeline.Invalidate();
                displayFrame(timestamp);

            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            string path = getSelectedPath();
            int index = -1;
            for(int i = 0; i < videoPaths.Count; i++)
            {
                if (videoPaths[i] == path)
                {
                    index = i;
                    break;
                }
            }

            if(index > 0 && index < videoPaths.Count)
            {
                string above = videoPaths[index - 1];
                string current = path;

                videoPaths[index - 1] = current;
                videoPaths[index] = above;

                refreshClips();

                timeline.Invalidate();
                displayFrame(timestamp);
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            string path = getSelectedPath();
            int index = -1;
            for (int i = 0; i < videoPaths.Count; i++)
            {
                if (videoPaths[i] == path)
                {
                    index = i;
                    break;
                }
            }

            if (index >= 0 && index < videoPaths.Count - 1)
            {
                string below = videoPaths[index + 1];
                string current = path;

                videoPaths[index + 1] = current;
                videoPaths[index] = below;

                refreshClips();

                timeline.Invalidate();
                displayFrame(timestamp);
            }
            
        }

        public void refreshClips()
        {
            clipsContainer.Controls.Clear();
            foreach(string path in videoPaths)
            {
                foreach(Clip c in clips)
                {
                    if(c.fullPath == path)
                    {
                        clipsContainer.Controls.Add(c);
                    }
                }
            }
        }

        public void jumpToClip(string path)
        {
            int previousFrames = 0;
            foreach(string videoPath in videoPaths)
            {
                if (videoPath != path)
                {
                    if (videoData.ContainsKey(videoPath))
                    {
                        previousFrames += videoData[videoPath].frames;
                    }
                }
                else
                    break;
            }
            timestampInput.Value = previousFrames + 1;
        }

        private void stitchButton_Click(object sender, EventArgs e)
        {
            Stitcher stitcher = new Stitcher();
            stitcher.videos = videoPaths;
            stitcher.outputFile = nameInput.Text;
            stitcher.Show();
        }

        public void highlightClip(string path)
        {
            if (highlighted == path)
                highlighted = "";
            else
                highlighted = path;
            timeline.Invalidate();
        }

        private void timeline_Paint(object sender, PaintEventArgs e)
        {
            g.FillRectangle(Brushes.LightGray, 0, 0, timeline.Width, timeline.Height);
            
            if (totalFrames > 0)
                scale = Decimal.Divide(timeline.Width, totalFrames);

            int previousFrames = 0;

            foreach (string path in videoPaths)
            {
                if (videoData.ContainsKey(path))
                {
                    int boxX = (int)(previousFrames * scale);
                    int boxWidth = (int)(videoData[path].frames * scale);
                    g.FillRectangle(new SolidBrush(videoData[path].color), boxX, 0, boxWidth, timeline.Height);
                    
                    if(path == highlighted)
                    {
                        g.DrawRectangle(Pens.Black, boxX, 0, boxWidth - 2, timeline.Height - 3);
                    }

                    if(boxWidth >= 16)
                    {
                        g.DrawImage(videoData[path].thumbnail, boxX, (int)(Decimal.Divide(timeline.Height - 16, 2)), 16, 16);
                    }

                    previousFrames += videoData[path].frames;
                }
            }

            g.DrawLine(Pens.Black, (int)(timestamp * scale), 0, (int)(timestamp * scale), timeline.Height);
        }

        private void timeline_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                if(totalFrames > 0)
                    Decimal.Divide(timeline.Width, totalFrames);

                timestamp = (int)(e.X / scale);

                if (timestamp < 0)
                    timestamp = 0;
                if (timestamp > totalFrames)
                    timestamp = totalFrames;
                timestampInput.Value = timestamp;
            }
        }

        private void timestampInput_ValueChanged(object sender, EventArgs e)
        {
            timestamp = (int)timestampInput.Value;
            timeline.Invalidate();

            displayFrame((int)timestampInput.Value);

        }

        void displayFrame(int frame)
        {
            int previousFrames = 0;

            for (int i = 0; i < videoPaths.Count; i++)
            {
                string path = videoPaths[i];
                previousFrames += videoData[path].frames;
                if (previousFrames > timestamp)
                {
                    int offset = 0;
                    for (int k = 0; k < i; k++)
                    {
                        //remove all previous frame counts
                        offset += videoData[videoPaths[k]].frames;
                    }

                    int getFrame = timestamp - offset;

                    string previewDir = "previews\\" + getCleanPath(path).Split('.')[0];
                    string previewFile = previewDir + "\\" + getFrame.ToString() + Settings.previewExtension;

                    if (File.Exists(previewFile))
                    {
                        previewBox.BackgroundImage = Image.FromFile(previewFile);
                    }

                    break;
                }
            }
        }

        private void playCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (playCheck.Checked)
            {
                fpsInput.Enabled = false;
                playTimer.Interval = (1000 / (int)fpsInput.Value);
                playTimer.Start();
            }
            else
            {
                playTimer.Stop();
                fpsInput.Enabled = true;
            }
        }

        private void playTimer_Tick(object sender, EventArgs e)
        {
            if (timestampInput.Value < timestampInput.Maximum - 1)
                timestampInput.Value++;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(projectNameInput.Text))
            {
                Directory.CreateDirectory(projectNameInput.Text);
            }

            string projectFileOutput = "";

            foreach (Clip c in clips)
            {
                projectFileOutput += "V:" + c.fullPath;
                if (videoData.ContainsKey(c.fullPath))
                {
                    projectFileOutput += ":" + videoData[c.fullPath].frames.ToString();
                }
                else
                    projectFileOutput += ":0";
                projectFileOutput += "\n";

            }

        }

        private void transitionButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This feature is a work in progress. Would you like to contribute on Bitbucket?", "Coming Soon!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Process shill = new Process();
                shill.StartInfo = new ProcessStartInfo("https://bitbucket.org/matthewd673/QuickStitch");
                shill.Start();
            }
        }
    }
}
