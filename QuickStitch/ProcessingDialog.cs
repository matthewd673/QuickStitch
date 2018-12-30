using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickStitch
{
    public partial class ProcessingDialog : Form
    {
        public ProcessingDialog()
        {
            InitializeComponent();
        }

        public string fullPath;
        public string clipName = "a clip";

        private void ProcessingDialog_Load(object sender, EventArgs e)
        {
            description.Text = description.Text.Replace("a clip", clipName); //super lazy but thats okay
        }

        public void updateStatus(string status)
        {
            statusLabel.Text = status + "...";
        }
    }
}
