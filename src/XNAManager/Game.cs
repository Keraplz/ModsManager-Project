using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    public class Games
    {
        //public static Game Unknown = new Game();
        public static Game SpeedRunners = new Game("SpeedRunners", "Content", "mods", new String[] { ".xnb", ".ogg", ".txt", ".ttf", ".otf" });
    }

    public class Game
    {
        //private static IList<Game> AllGames = new List<Game>();

        [Newtonsoft.Json.JsonProperty("gameName")]
        private String m_gameName = "";

        [Newtonsoft.Json.JsonProperty("contentFolder")]
        private String m_contentFolder = "";

        [Newtonsoft.Json.JsonProperty("modsFolder")]
        private String m_modsFolder = "";

        [Newtonsoft.Json.JsonProperty("extensions")]
        private IList<String> m_extensions = new List<String>();


        //public Game()
        //{
        //}

        [Newtonsoft.Json.JsonConstructor]
        public Game(String input_gameName, String input_contentFolder, String input_modsFolder, String[] input_extensions)
        {
            m_gameName = input_gameName;
            m_contentFolder = input_contentFolder;
            m_modsFolder = input_modsFolder;
            m_extensions = input_extensions;

            //GameSetup();
        }
        //public static void GameSetup()
        //{
        //    AllGames.Clear();
        //    AllGames.Add(Games.Unknown);
        //    AllGames.Add(Games.SpeedRunners);
        //}
        

        //public static IList<Game> GetGames()
        //{
        //    if (AllGames.Count == 0) GameSetup();
        //
        //    return AllGames;
        //}

        public void SetName(String input_gamename) {
            m_gameName = input_gamename;
        }
        public void SetFolderContent(String input_foldercontent) {
            m_contentFolder = input_foldercontent;
        }
        public void SetFolderMods(String input_foldermods) {
            m_modsFolder = input_foldermods;
        }
        public void SetExtensions(IList<String> input_extensions) {
            m_extensions = input_extensions;
        }
        public string GetName() { return m_gameName; }
        public string GetFolderContent() { return m_contentFolder; }
        public string GetFolderMods() { return m_modsFolder; }
        public IList<String> GetExtensions() { return m_extensions; }
    }
}
