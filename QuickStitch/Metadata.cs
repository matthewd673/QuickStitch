using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace QuickStitch
{
    public class Metadata
    {

        static Color[] colorList = new Color[] { Color.PaleGreen, Color.LightBlue, Color.Pink, Color.PaleVioletRed, Color.Orange, Color.Yellow, Color.SlateBlue, Color.Violet, Color.Pink, Color.LightBlue, Color.LightGreen, Color.Maroon };

        public string path;
        public Color color;
        public int frames;
        public Bitmap thumbnail;

        Random rng;

        public Metadata(string path)
        {
            this.path = path;

            rng = new Random();
        }

        public void generateColor(int id)
        {
            color = colorList[id];
        }

    }
}
