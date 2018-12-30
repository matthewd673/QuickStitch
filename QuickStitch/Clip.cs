using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickStitch
{
    public partial class Clip : UserControl
    {
        public Clip()
        {
            InitializeComponent();
        }

        public Editor parent; //set this pls

        public string fullPath;
        string clipName;
        public string clip
        {
            get
            {
                return clipName;
            }
            set
            {
                clipName = value;
                title.Text = value;
            }
        }
        
        public bool selected = false;

        private void Clip_Load(object sender, EventArgs e)
        {

        }

        public void setColor(Color color)
        {
            colorPanel.BackColor = color;
        }

        public void setThumbnail(Bitmap thumb)
        {
            thumbnail.BackgroundImage = thumb;
        }

        public void stopLoading()
        {
            progress.Visible = false;
        }

        private void Clip_Click(object sender, EventArgs e)
        {
            select();
        }

        public void select()
        {
            selected = !selected;
            if (selected)
            {
                title.ForeColor = SystemColors.Highlight;
                foreach(Clip c in parent.clips)
                {
                    if (c.fullPath != fullPath)
                    {
                        c.selected = false;
                        c.checkSelected();
                    }
                }
            }
            else
                title.ForeColor = Color.Black;
        }

        public void checkSelected()
        {
            if (selected)
                title.ForeColor = SystemColors.Highlight;
            else
                title.ForeColor = Color.Black;
        }

        private void Clip_DoubleClick(object sender, EventArgs e)
        {
            parent.jumpToClip(fullPath);
        }
    }
}
