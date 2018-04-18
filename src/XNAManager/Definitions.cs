using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public class Definitions
    {
        public static String toLabel_modName = "no_name_found";
        public static String toLabel_modType = "no_type_found";
        public static String toLabel_modAuthor = "no_author_found";
        public static String toLabel_modDescription = "no_description_found";

        public static String toLabel_baseinfo_CurrentGame = "no_game_found";
        public static String toLabel_baseinfo_CurrentBuild = "000";
        public static String toLabel_baseinfo_SetupTime = "00:000";
        public static Int32 toLabel_baseinfo_InstalledMods = 0;
        public static String toLabel_baseinfo = string.Format("Game: {0}, Build: {1}, SetupTime: {2}, Installed Mods: {3}",
                toLabel_baseinfo_CurrentGame,
                toLabel_baseinfo_CurrentBuild,
                toLabel_baseinfo_SetupTime,
                toLabel_baseinfo_InstalledMods.ToString("00"));

        public static String ignoredType = "";
        public static String ignoredFile = "";

        public static IEnumerable<String> toLog_unic = new List<String>();

        public static IList<String> install = new List<String>();
        public static IEnumerable<String> install_unic = new List<String>();

        public static IList<String> outputName = new List<String>();
        public static IEnumerable<String> outputName_unic = new List<String>();

        public static IList<String> ignoredList = new List<String>();
        public static IEnumerable<String> ignoredList_unic = new List<String>();

        public static IList<String> xnbPath = new List<String>();
        public static IEnumerable<String> xnbPath_unic = new List<String>();

        public static IList<String> installList = new List<String>();

        public static IList<String> modFiles = new List<String>();
        public static IList<String> reformed_modFiles = new List<String>();
        public static IList<String> reformed_modFiles_backup = new List<String>();
        public static IEnumerable<String> reformed_modFiles_unic = new List<String>();
    }
}