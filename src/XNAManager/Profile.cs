using Keraplz.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    public class Profiles
    {
        public static Profile Blank = new Profile();
        public static Profile Default;// = new Profile(Keraplz.JSON.Read.Configuration.GetProgramName(), Keraplz.JSON.Read.Configuration.GetGame(), Keraplz.JSON.Read.Configuration.GetUIGraphics());
        //public static Profile Default = new Profile("ModsManager", Games.SpeedRunners, false);
        public static Profile CurrentProfile;
    }
    public class Profile
    {
        private IList<Mod> m_Mods;
        private Game m_Game;
        private IList<Mod> m_BannedMods;
        private String[] m_PreviewExt;
        private String[] m_MaintenancePaths;
        private String[] m_MaintenanceFiles;
        private String m_ProgramName = string.Empty;
        private String m_WindowName = string.Empty;
        private String m_XmlUrl = string.Empty;

        // ----------------

        public Profile()
        {
            m_Game = Games.SpeedRunners;
            m_ProgramName = "ModsManager";
            m_WindowName = m_Game.GetName() + " " + m_ProgramName;
            m_Mods = new List<Mod>();
            m_BannedMods = new List<Mod>();
            m_PreviewExt = new String[] { ".jpg", ".jpeg", ".png" };
            m_MaintenancePaths = new String[] { "_backup", "_content", "_logs" };
            m_MaintenanceFiles = new String[] { "install.txt", "uninstall.txt", "search.txt" };
            m_XmlUrl = "https://raw.githubusercontent.com/Keraplz/ModsManager-Project/master/update.xml";
        }

        public Profile(String input_programName, Game input_game)
        {
            LogFile.Write("Constructing Profile . . .  ");
            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            m_Mods = new List<Mod>();

            if (input_programName != null) m_ProgramName = input_programName;
            else m_ProgramName = Profiles.Blank.GetProgramName();

            //if (LogFile.isActive) LogFile.AddMessage("Program Name :: " + m_ProgramName);

            if (input_game != null) m_Game = input_game;
            else m_Game = Profiles.Blank.GetGame();

            //if (LogFile.isActive) LogFile.AddMessage("Game Name :: " + m_Game.GetName());

            m_PreviewExt = Profiles.Blank.GetPreviewExt();
            m_MaintenancePaths = Profiles.Blank.GetMaintenancePaths();
            m_MaintenanceFiles = Profiles.Blank.GetMaintenanceFiles();

            Setup.Maintenance_(input_programName, input_game, m_MaintenancePaths, m_MaintenanceFiles, true, true);

            foreach (string modPath in Directory.GetFiles(m_Game.GetFolderMods(), "*.json"))
            {
                string modName = Path.GetFileNameWithoutExtension(modPath);
                Mod modInfo = Read.Mods.GetModByName(modName, m_Game.GetFolderMods());
                if (modInfo.ShouldLoad()) m_Mods.Add(modInfo);

                //if (LogFile.isActive) LogFile.AddMessage("Mod Added :: " + modInfo.GetName());
            }

            m_WindowName = m_Game.GetName() + " " + m_ProgramName;
            m_XmlUrl = Profiles.Blank.GetXmlUrl();

            //if (LogFile.isActive) LogFile.AddMessage("AutoUpdater Uri :: " + m_XmlUrl);

            if (m_Mods.Count == 0 || m_Mods.Count != Directory.GetFiles(input_game.GetFolderMods(), "*.json").Count())
                if (m_Mods.Count > 0)
                {
                    IList<Mod> toAdd = new List<Mod>();
                    foreach (Mod modInfo in Keraplz.JSON.Write.Configuration(m_ProgramName, m_Game))
                    {
                        Boolean shouldAdd = false;

                        foreach (Mod mod in m_Mods)
                        {
                            for (int n = 0; n < m_Mods.Count; n++)
                            {
                                if (!m_Mods[n].Contains(modInfo.GetName())) shouldAdd = true;
                                else shouldAdd = false;

                                if (shouldAdd || m_Mods[n].GetName() == modInfo.GetName()) break;
                            }

                            if (shouldAdd && modInfo.ShouldLoad()) toAdd.Add(modInfo);
                            shouldAdd = false;
                        }
                    }

                    toAdd = toAdd.Distinct().ToList();
                    foreach (Mod modInfo in toAdd)
                    {
                        m_Mods.Add(modInfo);

                        //if (LogFile.isActive) LogFile.AddMessage("Mod Added :: " + mod_info.GetName());
                    }
                }
                else
                {
                    foreach (Mod modInfo in Keraplz.JSON.Write.Configuration(m_ProgramName, m_Game, m_MaintenancePaths, m_MaintenanceFiles))
                    {
                        if (!m_Mods.Contains(modInfo) && modInfo.ShouldLoad())
                            m_Mods.Add(modInfo);
                    }
                }

            //IEnumerable<String> subfolders = Directory.EnumerateDirectories(m_Game.GetFolderMods());
            //if (!Directory.Exists(m_Game.GetFolderMods()) || subfolders.ToList().Count < 1) m_BannedMods = new List<Mod>();
            //else m_BannedMods = Check.GetBannedMods(m_Game);

            Profiles.Blank.RefreshBannedMods(m_Game);
            m_BannedMods = Profiles.Blank.GetBannedMods();

            timeRecord.Stop();
            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
            LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"), true);
        }

        // ----------------

        public void SetGame(Game input_game) {
            m_Game = input_game;
        }
        public void SetProgramName(String input_ProgramName) {
            m_ProgramName = input_ProgramName;
        }
        public void SetWindowName(String input_WindowName) {
            m_WindowName = input_WindowName;
        }
        public void SetXmlUrl(String input_XmlUrl) {
            m_XmlUrl = input_XmlUrl;
        }

        // ----------------

        public Game GetGame() {
            if (m_Game != null) return m_Game;
            else return Profiles.Default.GetGame();
        }
        public String GetProgramName() {
            if (m_ProgramName != null) return m_ProgramName;
            else return Profiles.Default.GetProgramName();
        }
        public String GetWindowName() {
            if (m_WindowName != null) return m_WindowName;
            else if (m_Game.GetName() == null) return GetProgramName();
            else return m_Game.GetName() + " " + GetProgramName();
        }
        public String GetXmlUrl() {
            if (m_XmlUrl != null) return m_XmlUrl;
            else return Profiles.Default.GetXmlUrl();
        }
        public IList<Mod> GetMods() {
            return m_Mods;
        }
        public IList<Mod> GetBannedMods() {
            return m_BannedMods;
        }
        public String[] GetMaintenancePaths() {
            if (m_MaintenancePaths != null) return m_MaintenancePaths;
            else return Profiles.Default.GetMaintenancePaths();
        }
        public String[] GetMaintenanceFiles() {
            if (m_MaintenanceFiles != null) return m_MaintenanceFiles;
            else return Profiles.Default.GetMaintenanceFiles();
        }
        public String[] GetPreviewExt() {
            if (m_PreviewExt != null) return m_PreviewExt;
            else return Profiles.Default.GetPreviewExt();
        }

        // ----------------

        public void Refresh() {
            LogFile.Write("Refreshing Profile . . .  ");
            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            m_Mods.Clear();
            m_BannedMods.Clear();

            m_WindowName = m_Game.GetName() + " " + m_ProgramName;
            RefreshBannedMods(m_Game);

            foreach (string modPath in Directory.GetFiles(m_Game.GetFolderMods(), "*.json"))
            {
                string modName = Path.GetFileNameWithoutExtension(modPath);
                Mod modInfo = Read.Mods.GetModByName(modName, m_Game.GetFolderMods());
                Boolean IsBanned = false;

                if(modInfo.isBanned()) IsBanned = true;

                if (modInfo.ShouldLoad(IsBanned))
                    m_Mods.Add(modInfo);
                else m_Mods.Add(new Mod(modInfo.GetName(), Read.Mods.IsInstalled(modName, m_Game.GetFolderMods()), null, null));
            }

            timeRecord.Stop();
            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
            LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"), true);
        }
        public Boolean isLoaded(Mod modInfo)
        {
            return modInfo.ShouldLoad(/*isBanned(modInfo)*/);
        }
        public Boolean isBanned(Mod modInfo) {
            if (m_BannedMods.Any(x => x.GetName() == modInfo.GetName())) return true;
            else return false;
        }
        public void BanMod(Mod modInfo) {
            if (!m_BannedMods.Any(x => x.GetName() == modInfo.GetName())) m_BannedMods.Add(modInfo);
        }
        public void UnBanMod(Mod modInfo) {
            if (m_BannedMods.Any(x => x.GetName() == modInfo.GetName())) m_BannedMods.Remove(modInfo);
        }

        public void RefreshBannedMods()
        {
            Profiles.Blank.m_BannedMods.Clear();
            m_BannedMods.Clear();
            foreach (IList<Mod> modList in ModsManager.GetBannedMods(m_Game/*, m_Mods*/))
                if (modList.Count() > 1)
                    foreach (Mod modInstalled in Read.Mods.GetInstalled(m_Game.GetFolderMods()))
                        if (modList.Any(x => x.GetName() == modInstalled.GetName()) && modInstalled.ShouldLoad())
                            foreach (Mod modInfo in modList)
                                if (modInfo.GetName() != modInstalled.GetName() && modInfo.ShouldLoad())
                                    if (!m_BannedMods.Any(x => x.GetName() == modInfo.GetName()) || m_BannedMods.Count == 0)
                                        Profiles.Blank.m_BannedMods.Add(modInfo);
            m_BannedMods = Profiles.Blank.GetBannedMods();
        }
        public void RefreshBannedMods(Game Game) {
            Profiles.Blank.m_BannedMods.Clear();
            m_BannedMods.Clear();
            foreach (IList<Mod> modList in ModsManager.GetBannedMods(Game/*, m_Mods*/))
                if (modList.Count() > 1)
                    foreach (Mod modInstalled in Read.Mods.GetInstalled(m_Game.GetFolderMods()))
                        if (modList.Any(x => x.GetName() == modInstalled.GetName())/* && modInstalled.ShouldLoad()*/)
                            foreach (Mod modInfo in modList)
                                if (modInfo.GetName() != modInstalled.GetName() && !modInfo.ShouldLoad(true))
                                    if (!m_BannedMods.Any(x => x.GetName() == modInfo.GetName()) || m_BannedMods.Count == 0)
                                        Profiles.Blank.m_BannedMods.Add(modInfo);
            m_BannedMods = Profiles.Blank.GetBannedMods();
        }

        public void AddMod(Mod mod_info) {
            m_Mods.Add(mod_info);
        }

        public Boolean Contains(Mod mod_info) {
            if (m_Mods.Contains(mod_info))
                return true;
            else return false;
        }


        public bool Load(Mod modInfo)
        {
            bool result;
            if (modInfo.isLoaded()) return true;
            else result = Keraplz.JSON.Write.ModDefinion.Edit.Load(modInfo, true);
            Refresh();
            return result;
        }

        public bool Unload(Mod modInfo)
        {
            bool result;
            if (!modInfo.isLoaded()) return true;
            else result = Keraplz.JSON.Write.ModDefinion.Edit.Load(modInfo, false);
            Refresh();
            return result;
        }
    }
}