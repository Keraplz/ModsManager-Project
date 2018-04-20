using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


// TODO: 
//       rewrite toLabel member from Definitions.cs directly on the MainWindow if possible

namespace ModsManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            // ----

            LogFile.Initialize(false);
            Profiles.Default = new Profile(Keraplz.JSON.Read.Configuration.GetProgramName(), Games.SpeedRunners);

            // ----

            timeRecord.Stop();
            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);

            Definitions.toLabel_baseinfo_SetupTime = time.ToString(@"ss\:fff");
            Definitions.toLabel_baseinfo_InstalledMods = Keraplz.JSON.Read.Mods.GetNInstalled();
            Definitions.toLabel_baseinfo_CurrentBuild = Check.GetCurrentBuild().ToString("000");
            Definitions.toLabel_baseinfo = string.Format(
                "Game: {0}, Build: {1}, SetupTime: {2}, Installed Mods: {3}",
                Profiles.Default.GetGame().GetName(),
                Definitions.toLabel_baseinfo_CurrentBuild,
                Definitions.toLabel_baseinfo_SetupTime,
                Definitions.toLabel_baseinfo_InstalledMods.ToString("00"));

            if (args.Length > 0)
            {
                if (args[0] == "-dev")
                {
                    if (args[1] == "updateProcess")
                    {
                        LogFile.WriteLine("Refreshing Mods . . .  ");
                        var timeRecord_ = System.Diagnostics.Stopwatch.StartNew();

                        // ----
                        // Get installed mods
                        IList<Mod> modsInstalled = Keraplz.JSON.Read.Mods.GetInstalled();

                        if (modsInstalled.Count > 0)
                        {
                            // Uninstall all installed mods
                            foreach (Mod modInfo in modsInstalled)
                                ModsManager.uninstallMod(modInfo);
                        }

                        // Clear mods/*.json files
                        foreach (string modFile in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                            File.Delete(modFile);

                        // Rewrite mods/*.json files
                        Maintenance.WriteModDefinitions(Profiles.Default.GetGame());

                        if (modsInstalled.Count > 0)
                        {
                            // Refresh IList<Mod> modsInstalled
                            IList<Mod> modsInstalledOld = new List<Mod>();
                            foreach (Mod modInfo in modsInstalled)
                                modsInstalledOld.Add(modInfo);
                            modsInstalled.Clear();
                            foreach (Mod modInfo in modsInstalledOld)
                                modsInstalled.Add(new Mod(modInfo.GetName(), false, modInfo.GetTypes(), modInfo.GetContent()));

                            // Reinstall all previously installed mods
                            foreach (Mod modInfo in modsInstalled)
                                ModsManager.installMod(modInfo);
                        }

                        // Refresh Profile
                        Profiles.Default.Refresh();

                        // ----

                        timeRecord_.Stop();
                        TimeSpan time_ = TimeSpan.FromMilliseconds(timeRecord_.ElapsedMilliseconds);
                        LogFile.WriteLine("Done " + time_.ToString(@"ss\:fff"));
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(Profiles.Default));
        }
    }
}