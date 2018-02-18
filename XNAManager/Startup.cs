using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class Startup : Form
    {
        private string GameName = Definitions.GameName;
        private string ContentFolder = Definitions.ContentFolder;
        private string ModsFolder = Definitions.ModsFolder;
        private Game CurrentGame = Games.SpeedRunners;

        public Startup(Game input_game)
        {
            InitializeComponent();

            // ----

            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            // ----

            if (false)
            foreach (Game Game_ in Game.AllGames)
            {
                // set current game here
                if (Game_ == CurrentGame)
                {
                    GameName = Game_.GetName();
                    ModsFolder = Game_.GetFolderMods();
                    ContentFolder = Game_.GetFolderContent();


                    CurrentGame = Game_;
                }
            }

            if (input_game.GetName() != "")
                GameName = input_game.GetName();
            if (input_game.GetFolderContent() != "")
                ContentFolder = input_game.GetFolderContent();
            if (input_game.GetFolderMods() != "")
                ModsFolder = input_game.GetFolderMods();

            if (Definitions.GameName != GameName)
                if (GameName != "")
                    Setup.SetGameName(GameName);
            if (Definitions.ModsFolder != ModsFolder)
                if (ModsFolder != "")
                    Setup.SetFolderMods(ModsFolder);
            if (Definitions.ContentFolder != ContentFolder)
                if (ContentFolder != "")
                    Setup.SetFolderContent(ContentFolder);


            Setup.Maintenance_(true, true, true);
            Setup.SearchXNB_(ContentFolder, true);
            Setup.WriteJSON_(false, true);
            Setup.LogOutputs_();

            // ----

            timeRecord.Stop();

            // ----

            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);

            Definitions.toLabel_baseinfo_SetupTime = time.ToString(@"ss\:fff");
            Definitions.toLabel_baseinfo_InstalledMods = Keraplz.JSON.Read.mods_GetNInstalled();
            Definitions.toLabel_baseinfo_CurrentBuild = Check.GetCurrentBuild().ToString("000");

            Definitions.toLabel_baseinfo = "Game: " + GameName + ", Build: " + Definitions.toLabel_baseinfo_CurrentBuild + ", SetupTime: " + Definitions.toLabel_baseinfo_SetupTime + ", Installed Mods: " + Definitions.toLabel_baseinfo_InstalledMods.ToString("00");
            
            
            //MainWindow MainWindow_ = new MainWindow();
            //MainWindow_.Show();
        }
    }
}