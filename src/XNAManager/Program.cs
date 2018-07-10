using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

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
            LogFile.Initialize(false);

            if (false)
            {
                // sample code to download mods
                Profiles.Default = new Profile(Profiles.Blank.GetProgramName(), Games.SpeedRunners);
                ModsXml modXML = ModsXml.Parse(new Uri(Profiles.Default.GetXmlUrl()), Games.SpeedRunners.GetName(), "Matrix Moonraker");
                ModOnline MMoonraker = new ModOnline("Matrix Moonraker", modXML.Preview);
                MMoonraker.Download();
            }
            else if (false)
            {
                // sample code to extract .zip file
                using (Stream s = File.Open("testing.zip", FileMode.OpenOrCreate))
                    CompressedFileHandle.ExtractZip(s, "cache\\testing");
            }
            else if (false)
            {
                // sample code to grab mod information from database.xml online
                Profiles.Default = new Profile(Profiles.Blank.GetProgramName(), Games.SpeedRunners);
                IList<ModsXml> XmlList = ModsXml.Parse(new Uri(Profiles.Default.GetXmlUrl()), Games.SpeedRunners.GetName());

                int n = 0;
                foreach (ModsXml modXml in XmlList)
                {
                    LogFile.WriteLine();
                    LogFile.WriteLine("XmlList[" + n + "] -> modXml.Name = " + modXml.Name);
                    LogFile.WriteLine("XmlList[" + n + "] -> modXml.Version = " + modXml.Version);
                    LogFile.WriteLine("XmlList[" + n + "] -> modXml.Uri = " + modXml.Uri);
                    LogFile.WriteLine("XmlList[" + n + "] -> modXml.Preview = " + modXml.Preview);
                    LogFile.WriteLine("XmlList[" + n + "] -> modXml.Description = " + modXml.Description);
                    n++;
                }

                LogFile.WriteLine();
            }

            //Environment.Exit(Environment.ExitCode);

            bool DevPass = false;
            /*
            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            // ----
            
            LogFile.Initialize(false);
            Profiles.Default = new Profile(Profiles.Blank.GetProgramName(), Games.SpeedRunners);
            //Profiles.CurrentProfile = Profiles.Default;

            // ----

            timeRecord.Stop();
            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
            */
            if (args.Length > 0)
            {
                Profiles.Default = new Profile(Profiles.Blank.GetProgramName(), Games.SpeedRunners);
                if (args[0] == "-dev")
                {
                    if (args[1] == "devPass")
                    {
                        DevPass = true;
                    }
                    else if (args[1] == "updateProcess")
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
                                ModsManager.Uninstall(modInfo);
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
                                ModsManager.Install(modInfo);
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

            //Convert.PNG_XNB("Logo_100x50.png", "Logo_100x50.xnb", false);
            //Extract("ModsManager", "Resources", "Logo_100x50.png");//, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExtractTest"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MMUILoadAction("OPEN", Profiles.Default.GetGame().GetFolderMods()));
            Application.Run(new MainWindow(DevPass));
            //Application.Run(new BetaMMUI());
            //Application.Run(new MMUIConverter());

            
        }

        
    }
}