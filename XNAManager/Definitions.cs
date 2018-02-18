using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    class Definitions
    {
        public static StreamWriter SWriterError;

        public static Boolean IsRepeated_Error = false;

        public static Boolean onetimeBackup = true;

        public static String modInstalling;

        public static String ignoredType;
        public static String ignoredFile;

        public static String input_type;
        public static String input_filepath;
        public static IList<String> input_files = new List<String>();

        public static IList<String> fileList = new List<String>();

        public static IEnumerable<String> toLog_unic = new List<String>();

        public static IList<String> install = new List<String>();
        public static IEnumerable<String> install_unic = new List<String>();

        public static IList<String> outputName = new List<String>();
        public static IEnumerable<String> outputName_unic = new List<String>();

        public static IList<String> ignoredList = new List<String>();
        public static IEnumerable<String> ignoredList_unic = new List<String>();

        public static IList<String> xnbPath = new List<String>();
        public static IEnumerable<String> xnbPath_unic = new List<String>();

        public static IList<String> modsList = new List<String>();
        public static IList<String> remove_modsList = new List<String>();

        public static IList<String> installList = new List<String>();

        public static IList<String> modFiles = new List<String>();
        public static IList<String> reformed_modFiles = new List<String>();
        public static IList<String> reformed_modFiles_backup = new List<String>();  
        public static IEnumerable<String> reformed_modFiles_unic = new List<String>();

        public static IList<String> modContains = new List<String>();

        public static String GameName = "SpeedRunners";
        public static String ContentFolder = "Content";
        public static String ModsFolder = "mods";
        public static String[] fileExtensions = { ".xnb", ".ogg", ".txt", ".ttf", ".otf" };

        //public static String GameName = Game.GetName_static();
        //public static String ContentFolder = Game.GetFolderContent_static();
        //public static String ModsFolder = Game.GetFolderMods_static();
        //public static String[] fileExtensions = Game.GetExtensions_static().ToArray();

        //public static String GameName = Games.SpeedRunners.GetName();
        //public static String ContentFolder = Games.SpeedRunners.GetFolderContent();
        //public static String ModsFolder = Games.SpeedRunners.GetFolderMods();
        //public static String[] fileExtensions = Games.SpeedRunners.GetExtensions().ToArray();

        public static String[] logs_pathMaintenance = { "_backup", "_content", "_logs" };
        public static String[] logs_fileMaintenance = { "install.txt", "uninstall.txt", "ignoredList.txt", "reader_test.txt", "writer.txt", "errorlog.txt" };

        public static String[] logFiles = { /*"xnbpath.txt",*/ "ignoredList.txt", /*"output.txt",*/ "install.txt" };
        public static String configFile = "ModsManager/Configuration.json";

        public static String[] previewExtensions = { ".jpg", ".jpeg", ".png" };

        public static String toLabel_modName = "no_name_found";
        public static String toLabel_modType = "no_type_found";
        public static String toLabel_modAuthor = "no_author_found";
        public static String toLabel_modDescription = "no_description_found";

        public static String toLabel_baseinfo_CurrentGame = "no_game_found";
        public static String toLabel_baseinfo_CurrentBuild = "000";
        public static String toLabel_baseinfo_SetupTime = "00:000";
        public static Int32 toLabel_baseinfo_InstalledMods = 0;
        public static String toLabel_baseinfo = "Game: " + toLabel_baseinfo_CurrentGame + ", Build: " + toLabel_baseinfo_CurrentBuild + ", SetupTime: " + toLabel_baseinfo_SetupTime + ", Installed Mods: " + toLabel_baseinfo_InstalledMods.ToString("00");
    }
}