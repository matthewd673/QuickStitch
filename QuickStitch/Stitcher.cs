using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace QuickStitch
{
    public partial class Stitcher : Form
    {
        public Stitcher()
        {
            InitializeComponent();
        }

        public List<string> videos = new List<string>();
        public string outputFile;

        Thread renderThread;

        private void Stitcher_Load(object sender, EventArgs e)
        {
            bool ready = true;
            if (videos.Count <= 1)
            {
                MessageBox.Show("Too few videos were listed. Check that there are at least two videos to stitch.", "No Videos Provided");
                ready = false;
                Hide();
            }
            if (!File.Exists("ffmpeg.exe"))
            {
                MessageBox.Show("No FFMPEG binary was found in the working directory. FFMPEG must be downloaded from an official source and named \"ffmpeg.exe\".", "FFMPEG Missing");
                ready = false;
                Hide();
            }
            if (File.Exists(outputFile))
            {
                if (MessageBox.Show("The file " + outputFile + " already exists and will be replaced. Are you sure you want to continue?", "Overwrite Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    ready = false;
                    Hide();
                }
                else
                {
                    File.Delete(outputFile);
                }
            }

            if (!ready)
            {
                progress.MarqueeAnimationSpeed = 0;
                stepLabel.Text = "Please fix any issues and try again.";
            }
            if (ready)
            {
                renderThread = new Thread(render);
                renderThread.Start();
            }

        }

        void changeLabel(string text)
        {
            stepLabel.Text = text;
        }

        void changeBarAnimation(bool animate)
        {
            if (animate)
                progress.MarqueeAnimationSpeed = 100;
            else
                progress.MarqueeAnimationSpeed = 0;
        }

        delegate void labelDelegate(string text);
        delegate void animateBarDelegate(bool animate);

        void render()
        {

            Stopwatch watch = Stopwatch.StartNew();

            labelDelegate labelText = changeLabel;
            animateBarDelegate animateBar = changeBarAnimation;

            Invoke(labelText, "Creating input file");

            string inputString = "";
            foreach (string path in videos)
            {
                inputString += "file '" + path + "'" + Environment.NewLine;
            }
            File.WriteAllText("input.txt", inputString);

            Invoke(labelText, "Executing FFMPEG");

            string scaleArgs = "";

            if(Settings.resizeRender)
            {
                scaleArgs = " scale=" + Settings.renderWidth.ToString() + ":" + Settings.renderHeight.ToString();
            }

            string arguments = "-f concat -safe 0 -i input.txt" + scaleArgs + " -codec copy \"" + outputFile + "\"";

            Process ffmpeg = new Process();
            ffmpeg.StartInfo = new ProcessStartInfo("ffmpeg.exe", arguments);
            ffmpeg.StartInfo.UseShellExecute = false;
            ffmpeg.StartInfo.CreateNoWindow = true;
            ffmpeg.Start();

            ffmpeg.WaitForExit();

            int executeTime = (int)(watch.ElapsedMilliseconds / 1000);
            if(executeTime > 0)
                Invoke(labelText, "Complete (" + executeTime.ToString() + "s elapsed)");
            else
                Invoke(labelText, "Complete (<1s elapsed)");


            Invoke(animateBar, false);

            watch.Stop();

            MessageBox.Show("Render complete", "Done");
        }
    }
}
