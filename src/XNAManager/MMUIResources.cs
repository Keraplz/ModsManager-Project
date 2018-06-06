using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ModsManager
{
    public class MMUIResources
    {
        //
        // Colors
        //
        public static Color Transparent = System.Drawing.Color.Transparent;
        public static Color Secondary = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        public static Color Tertiary = System.Drawing.Color.Black;
        //
        // Icons
        //
        public static Image IconMaximize = global::ModsManager.Properties.Resources.White_Fit_to_Width_100px;
        public static Image IconNormalize = global::ModsManager.Properties.Resources.White_Collapse_100px;
        //
        // Sizes
        //
        public static Size WindowSize = new Size(1020, 600);
        //
        // Mod List Index
        //
        public static int Index = -1;

    }
}