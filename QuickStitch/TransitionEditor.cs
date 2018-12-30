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

namespace QuickStitch
{
    public partial class TransitionEditor : Form
    {
        public TransitionEditor()
        {
            InitializeComponent();
        }

        public Editor parent;

        private void TransitionEditor_Load(object sender, EventArgs e)
        {
            foreach(string path in parent.videoPaths)
            {
                firstSelect.Items.Add(parent.getCleanPath(path));
                secondSelect.Items.Add(parent.getCleanPath(path));
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            if(Directory.Exists((string)firstSelect.SelectedItem) && Directory.Exists((string)secondSelect.SelectedItem))
            {
                if (firstSelect.SelectedIndex > 0 && firstSelect.SelectedIndex < firstSelect.Items.Count && secondSelect.SelectedIndex > 0 && secondSelect.SelectedIndex < secondSelect.Items.Count)
                {
                    string firstPath = ((string)firstSelect.SelectedItem).Split('.')[0];
                    string secondPath = ((string)secondSelect.SelectedItem).Split('.')[0];

                    string firstFull = parent.videoPaths[firstSelect.SelectedIndex];
                    string secondFull = parent.videoPaths[secondSelect.SelectedIndex];

                    Metadata firstData = new Metadata(firstPath);
                    Metadata secondData = new Metadata(secondPath);

                }
                else
                    MessageBox.Show("Please choose valid selections.", "Selection Error");
            }
            else
                MessageBox.Show("Cannot generate preview, there are no cached frames.", "Preview Error");
        }
    }
}
