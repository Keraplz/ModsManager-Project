using Keraplz.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    class ModsManager
    {
        public static void uninstallMods()
        {
            try
            {
                foreach (Mod modInfo in Profiles.Default.GetMods())
                    uninstallMod(modInfo);
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.uninstallMods(" + "" + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void installMods()
        {
            try
            {
                foreach (Mod modInfo in Profiles.Default.GetMods())
                    installMod(modInfo);
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.installMods(" + "" + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void uninstallMod(Mod modInfo)
        {
            try
            {
                if (!modInfo.isInstalled()) { return; }

                string bPath = Profiles.Default.GetProgramName() + "/_backup/" + Profiles.Default.GetGame().GetFolderContent() + " - ";
                string cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                string sPath = bPath + modInfo.GetName() + "/";

                if (Directory.Exists(sPath) && Directory.Exists(cPath))
                {
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                        sw.Write("Uninstalling mod: " + modInfo.GetName() + " . . .  ");
                    LogFile.Write("Uninstalling mod: " + modInfo.GetName() + " . . .  ");
                    var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                    foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
                    {
                        foreach (string uninstallFile in Directory.GetFiles(sPath, "*" + extension, SearchOption.AllDirectories))
                        {
                            cPath = cPath + uninstallFile.Remove(0, bPath.Length + modInfo.GetName().Length + 1);

                            string pTest_01 = Path.GetFileName(Path.GetDirectoryName(uninstallFile));
                            string pTest_02 = Path.GetFileName(uninstallFile);
                            string pTest_03 = Path.GetFileName(Path.GetDirectoryName(cPath));
                            string pTest_04 = Path.GetFileName(cPath);
                            string pTest_05 = pTest_01 + "/" + pTest_02;
                            string pTest_06 = pTest_03 + "/" + pTest_04;

                            if (pTest_05 == pTest_06)
                            {
                                File.Copy(uninstallFile, cPath, true);
                                File.Delete(uninstallFile);
                            }

                            cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                        }
                    }

                    Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, false);

                    timeRecord.Stop();
                    TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"), true);
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                        sw.WriteLine("Done " + time.ToString(@"ss\:fff"));
                }

                string toDupe = Path.GetDirectoryName(Path.GetDirectoryName(sPath));
                dupeDirectories(toDupe);
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.uninstallMod(Mod " + modInfo.GetName() + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void installMod(Mod modInfo)
        {
            IList<String> modFiles = new List<String>();
            IList<String> Pass_modFiles = new List<String>();

            try
            {
                if (modInfo.isInstalled()) { return; }

                if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                    Maintenance.CreatePaths(Profiles.Default.GetMaintenancePaths(), true);

                foreach (string d in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\"))
                {
                    foreach (string a in Profiles.Default.GetGame().GetExtensions().ToArray())
                    {
                        foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
                        {
                            modFiles.Add(f);
                            Pass_modFiles.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length));
                            //Definitions.reformed_modFiles_backup.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length));
                        }
                    }
                }

                if (!IsRepeated(Pass_modFiles))
                {
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.Write("Installing mod: " + modInfo.GetName() + " . . .  ");
                    LogFile.Write("Installing mod: " + modInfo.GetName() + " . . .  ");
                    var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                    // start original game files backup
                    FileBackup(modInfo.GetName(), Pass_modFiles);

                    // now call method to override game files with mod files
                    foreach (string modPath in modFiles)
                    {
                        foreach (string modFile in Pass_modFiles)
                        {
                            if (Path.GetDirectoryName(modFile).ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                            {
                                if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == Profiles.Default.GetGame().GetFolderContent() + "\\" + modFile)
                                {
                                    File.Copy(modPath, modFile, true);
                                }
                            }
                            else
                            {
                                if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == Profiles.Default.GetGame().GetFolderContent() + "\\" + modFile)
                                {
                                    File.Copy(modPath, Profiles.Default.GetGame().GetFolderContent() + "\\" + modFile, true);
                                }
                            }
                        }
                    }

                    Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, true);

                    timeRecord.Stop();
                    TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"), true);
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.WriteLine("Done " + time.ToString(@"ss\:fff"));
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.installMod(Mod " + modInfo.GetName() + ")");
                LogFile.WriteLine(e.Message);
            }
        }

        public static IList<IList<Mod>> GetBannedMods(Game game_info)
        {
            IList<IList<Mod>> BannedMods = new List<IList<Mod>>();

            foreach (string nameer in Directory.GetFiles(game_info.GetFolderMods(), "*.json"))
            {
                IList<String> CurrentModContent = new List<String>();
                string modName = Path.GetFileNameWithoutExtension(nameer);

                foreach (string ModContent in Read.Mods.GetContent(modName, game_info.GetFolderMods()))
                    BannedMods.Add(new List<Mod>(Read.Mods.GetContainsMod(ModContent.Remove(0, game_info.GetFolderMods().Length + 2 + modName.Length + 2), game_info.GetFolderMods())));
            }

            if (BannedMods.Count > 0) return BannedMods;
            else return null;
        }

        private static Boolean IsRepeated(IList<String> modFiles)
        {
            try
            {
                IList<String> unicList = new List<String>();
                unicList = modFiles.Distinct().ToList();

                if (modFiles.Count() != unicList.Count()) return true;
                return false;
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Check.IsRepeated(IList<String> " + ")");
                LogFile.WriteLine(e.Message);

                return true;
            }
        }
        private static void FileBackup(String modName, IList<String> modFiles)
        {
            try
            {
                string sPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                string dPath = Profiles.Default.GetProgramName() + "/_backup/" + Profiles.Default.GetGame().GetFolderContent() + " - " + modName;

                foreach (string s in modFiles)
                {
                    sPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                    if (s.ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                        sPath = s;
                    else sPath = sPath + s;

                    string cDir = dPath + "/" + Path.GetDirectoryName(sPath).Remove(0, 8);

                    Directory.CreateDirectory(cDir);
                    File.Copy(sPath, cDir + "/" + Path.GetFileName(s), true);
                }

                modFiles.Clear();
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Check.fileBackup(String " + modName + ", IList<String> )");
                LogFile.WriteLine(e.Message);
            }
        }
        private static void dupeDirectories(string startLocation)
        {
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                dupeDirectories(directory);
                if (Directory.GetFiles(directory).Length == 0 &&
                    Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }

    }
}