using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    public class Games
    {
        public static Game Unknown = new Game();
        public static Game SpeedRunners = new Game("SpeedRunners", "Content", "mods", new String[] { ".xnb", ".ogg", ".txt", ".ttf", ".otf" });
    }
    public class Game
    {
        //public static IList<String> AllGames = new List<String>();
        private static IList<Game> AllGames = new List<Game>();

        private String GameName = "";
        private String ContentFolder = "";
        private String ModsFolder = "";
        private IList<String> Extensions = new List<String>();
        //public string LoaderDownloadURL = "";
        //public string LoaderHashURL = "";
        //public byte[] LoaderFile = null;
        //public byte[] Hash = null;
        //public byte DirectXVersion = 0;
        //public bool HasCustomLoader = false;
        //public bool UseCPKREDIR = false;


        public Game()
        {
            GameName = "";
            ContentFolder = "";
            ModsFolder = "";
            Extensions.Clear();
        }

        public Game(String input_gameName, String input_contentFolder, String input_modsFolder, String[] input_extensions/*, byte directXVersion, string loaderDownloadURL, string loaderHashURL, byte[] loaderFile*/)
        {
            GameName = input_gameName;
            ContentFolder = input_contentFolder;
            ModsFolder = input_modsFolder;
            foreach (string ext in input_extensions)
                Extensions.Add(ext);

            GameSetup();
            //if (input_gameName != "")
            //    AllGames.Add(input_gameName);
        }
        public static void GameSetup()
        {
            AllGames.Clear();
            AllGames.Add(Games.Unknown);
            AllGames.Add(Games.SpeedRunners);
        }


        public static IList<Game> GetGames()
        {
            if (AllGames.Count == 0) GameSetup();

            return AllGames;
        }
        //public static string GetName_static() { return GameName; }
        //public static string GetFolderContent_static() { return ContentFolder; }
        //public static string GetFolderMods_static() { return ModsFolder; }
        //public static IList<String> GetExtensions_static() { return Extensions; }
        public string GetName() { return GameName; }
        public string GetFolderContent() { return ContentFolder; }
        public string GetFolderMods() { return ModsFolder; }
        public IList<String> GetExtensions() { return Extensions; }
    }
}
