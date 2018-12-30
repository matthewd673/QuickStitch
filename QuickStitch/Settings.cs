using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuickStitch
{
    public class Settings
    {

        //render settings
        public static bool resizeRender;
        public static int renderWidth;
        public static int renderHeight;

        //cache settings
        public static bool generatePreviews;
        public static int previewWidth;
        public static int previewHeight;
        public static string previewExtension;

        public static void loadSettings()
        {
            if(File.Exists("settings.txt"))
            {
                string[] lines = File.ReadAllLines("settings.txt");
                foreach(string l in lines)
                {
                    if(l.Contains(":")) //this should always happen if the user isnt stupid, but may as well prevent a crash
                    {
                        string prop = l.Split(':')[0];
                        string val = l.Split(':')[1];

                        switch(prop)
                        {
                            case "renderResize":
                                if (val == "true")
                                    resizeRender = true;
                                else
                                    resizeRender = false;
                                break;
                            case "renderW":
                                renderWidth = Convert.ToInt32(val);
                                break;
                            case "renderH":
                                renderHeight = Convert.ToInt32(val);
                                break;
                            case "cacheGen":
                                if (val == "true")
                                    generatePreviews = true;
                                else
                                    generatePreviews = false;
                                break;
                            case "cacheW":
                                previewWidth = Convert.ToInt32(val);
                                break;
                            case "cacheH":
                                previewHeight = Convert.ToInt32(val);
                                break;
                            case "cacheExt":
                                previewExtension = val; //you better not mess this one up
                                break;
                        }
                    }
                }
            }
            else
            {
                //random defaults

                resizeRender = false;

                generatePreviews = true;
                previewWidth = 640;
                previewHeight = 480;
                previewExtension = ".jpg";
            }
        }

    }
}
