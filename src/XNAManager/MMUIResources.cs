using System.Collections.Generic;
using System.Drawing;

namespace ModsManager
{
    public class MMUIResources
    {
        //
        // Colors
        //
        public static Color Transparent = Color.Transparent;
        public static Color Secondary = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
        public static Color Tertiary = Color.Black;
        public static Color ClickPrimary = Color.Red; // default: Red
        public static Color ClickSecondary = Color.Blue; // default: Blue
        public static Color HoverPrimary = Color.FromArgb(50, 255, 0, 0); // default: Light Translucid Red
        public static Color HoverSecondary = Color.FromArgb(50, 50, 100, 200); // default: Light Translucid Blue
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
        // Banned Mods
        //
        public static IList<Mod> BannedMods;

    }
}