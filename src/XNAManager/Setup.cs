using Keraplz.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModsManager
{
    public class Setup
    {
        public static void MainSetup()
        {
            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            // ----

            //if (File.Exists("Keraplz.AutoUpdate.dll")) File.Delete("Keraplz.AutoUpdate.dll");
            //if (File.Exists("Keraplz.JSON.dll")) File.Delete("Keraplz.JSON.dll");
            //if (File.Exists("Keraplz.Resources.dll")) File.Delete("Keraplz.Resources.dll");
            //if (Directory.Exists("SRModManager")) Directory.Delete("SRModManager", true);

            //if (Directory.Exists(Profiles.Default.GetProgramName() + "/_content/"))
            //{
            //    DirectoryInfo info = new DirectoryInfo(Profiles.Default.GetProgramName() + "/_content/");
            //    foreach (FileInfo file in info.GetFiles())
            //        if (file.Exists)
            //            file.Delete();
            //    foreach (DirectoryInfo dir in info.GetDirectories())
            //        if (dir.Exists)
            //            dir.Delete(true);
            //}

            Maintenance_(Profiles.Default.GetProgramName(), Profiles.Default.GetGame(), Profiles.Default.GetMaintenancePaths(), Profiles.Default.GetMaintenanceFiles());
            //Maintenance_(Profiles.Default, true, true, true);
            SearchXNB_(Profiles.Default.GetGame().GetFolderContent(), true);
            WriteJSON_(true);
            LogOutputs_();

            // ----

            //Definitions.BannedMods = Check.GetModsToBan();

            // ----

            timeRecord.Stop();

            // ----

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
        }

        public static void InstallMod_(Mod mod_info)
        {
            ModsManager.installMod(mod_info);
            Keraplz.JSON.Write.ModDefinion.Edit.Installed(mod_info, true);
        }
        public static void InstallMod_(string input_modName)
        {
            ModsManager.installMod(input_modName);
            Keraplz.JSON.Write.ModDefinion.Edit.Installed(Keraplz.JSON.Read.Mods.GetModByName(input_modName), true);
        }
        public static void UninstallMod_(Mod mod_info)
        {
            ModsManager.uninstallMod(mod_info);
            Keraplz.JSON.Write.ModDefinion.Edit.Installed(mod_info, false);
        }
        public static void UninstallMod_(string input_modName)
        {
            ModsManager.uninstallMod(input_modName);
            Keraplz.JSON.Write.ModDefinion.Edit.Installed(Keraplz.JSON.Read.Mods.GetModByName(input_modName), false);
        }

        public static IList<Mod> Maintenance_(String ProgramName, Game Game, String[] PathArray, String[] FileArray)
        {
            Maintenance.CreatePaths(ProgramName, Game, PathArray);
            Maintenance.ResetLogs(ProgramName, FileArray);
            return Maintenance.WriteModDefinitions(Game);
        }
        public static void Maintenance_(String ProgramName, Game Game, String[] PathArray, String[] FileArray, Boolean shouldWMD = true)
        {
            Maintenance.CreatePaths(ProgramName, Game, PathArray);
            Maintenance.ResetLogs(ProgramName, FileArray);
            if (shouldWMD) Maintenance.WriteModDefinitions(Game);
        }
        public static void Maintenance_(Profile profile, Boolean CreatePaths, String[] PathArray, String[] FileArray, Boolean ResetLogs, Boolean WriteModDefinitions)
        {
            Maintenance.CreatePaths(profile, PathArray, CreatePaths);
            Maintenance.ResetLogs(profile, FileArray, ResetLogs);
            Maintenance.WriteModDefinitions(profile, WriteModDefinitions);
        }
        public static void Maintenance_(String[] PathArray, String[] FileArray, Boolean CreatePaths, Boolean ResetLogs, Boolean WriteModDefinitions)
        {
            Maintenance.CreatePaths(PathArray, CreatePaths);
            Maintenance.ResetLogs(FileArray, ResetLogs);
            Maintenance.WriteModDefinitions(WriteModDefinitions);
        }
        public static void WriteJSON_(Boolean config)
        {
            try
            {
                if (config)
                {
                    Keraplz.JSON.Write.Configuration(Profiles.Default);
                }
                else if (!config)
                {

                }
            }
            catch (Exception e)
            {
                
                {
                    LogFile.WriteLine("Error found in ModsManager.Setup.WriteJSON_(" + config.ToString() + ")");
                    LogFile.WriteLine(e.Message);
                }
            }
        }
        public static void SearchXNB_(String content, Boolean shouldWrite)
        {
            Search.SearchXNB(content, shouldWrite);
        }
        public static void ReadJSON_(String path)
        {
            Keraplz.JSON.Read.ReadJSON(path);
        }
        public static void LogOutputs_()
        {
            Log.Write(new String[] { "ignoredList.txt", "install.txt" });
        }
    }
    class ModsManager
    {
        public static IList<String> modsList = new List<String>();

        public static void uninstallMods()
        {
            try
            {
                int n = 0;

                string bPath = Profiles.Default.GetProgramName() + "/_backup/" + Profiles.Default.GetGame().GetFolderContent() + " - ";
                string cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                string sPath = "";

                if (Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json") != null)
                {
                    foreach (string s in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                    {
                        string modName = Path.GetFileNameWithoutExtension(s);
                        sPath = bPath + modName + "/";

                        if (Directory.Exists(sPath) && Directory.Exists(cPath))
                        {
                            using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                                sw.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(modName) + " ... ");
                            LogFile.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(modName) + " ... ");
                            var timeRecord = System.Diagnostics.Stopwatch.StartNew();
                            //Console.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(s) + " ... ");

                            foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
                            {
                                foreach (string uninstallFile in Directory.GetFiles(sPath, "*" + extension, SearchOption.AllDirectories))
                                {
                                    cPath = cPath + uninstallFile.Remove(0, bPath.Length + modName.Length + 1);

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
                                    else
                                    {
                                        //Console.WriteLine(@"ERROR TO UNINSTALL MOD """ + Path.GetFileNameWithoutExtension(s) + @""" REASON: File to uninstall doesn't match with installed file name(" + pTest_05 + " => " + pTest_06 + ")");
                                    }

                                    n = n + 1;
                                    //using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                                    //{
                                        //LogFile.WriteLine(n.ToString("0000") + @" - """ + uninstallFile);
                                    //}

                                    cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                                }
                            }

                            timeRecord.Stop();
                            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                            LogFile.WriteEnd("Done " + time.ToString(@"ss\:fff"));
                            using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                                sw.WriteLine("Done " + time.ToString(@"ss\:fff"));
                            //Console.WriteLine("Done!");
                        }
                        //else Console.WriteLine(@"(uninstallMods)Error: Directory """ + sPath + @""" or directory ""Content/"" doesn't exists!");

                        dupeDirectories(Path.GetDirectoryName(sPath));
                    }
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.uninstallMods(" + "" + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void installMods()
        {
            IList<String> RemoveMods = new List<String>();
            int n = 0;

            try
            {
                if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                    Maintenance.CreatePaths(Profiles.Default.GetMaintenancePaths(), true);

                uninstallMods();

                Check.ManageMods(Profiles.Default.GetGame().GetFolderMods());

                foreach (string s in modsList)
                {
                    ////Console.WriteLine("s => " + s);
                    ////Console.WriteLine("Definitions.modsList[" + n + "] => " + Definitions.modsList[n]);

                    string sPath = Profiles.Default.GetGame().GetFolderMods() + "/" + s;
                    if (Check.IsDirectoryEmpty(sPath))
                    {
                        RemoveMods.Add(modsList[n]);
                        //Console.WriteLine("Empty mods folder removed from IList: " + s);
                        //Console.WriteLine();
                    }
                    else
                    {
                        IList<string> sDir = Directory.GetDirectories(sPath);
                        foreach (string w in sDir)
                        {
                            if (Check.dupe_subFolders(w, s))
                            {
                                ////Console.WriteLine("w => " + w);
                            }
                        }
                        ////Console.WriteLine("sPath => " + sPath);
                    }

                    n = n + 1;
                }

                foreach (string s in RemoveMods)
                {
                    modsList.Remove(s);
                }

                foreach (string modName in modsList)
                {
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.Write("Installing mod: " + Path.GetFileNameWithoutExtension(modName) + " ... ");
                    LogFile.Write("Installing mod: " + Path.GetFileNameWithoutExtension(modName) + " ... ");
                    var timeRecord = System.Diagnostics.Stopwatch.StartNew();
                    //Console.Write("Installing mod: " + s + " ... ");

                    foreach (string d in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderMods() + "/" + modName + "/"))
                    {
                        foreach (string a in Profiles.Default.GetGame().GetExtensions().ToArray())
                        {
                            foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
                            {
                                Definitions.modFiles.Add(f);
                                Definitions.reformed_modFiles.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + modName).Length + 1));
                                Definitions.reformed_modFiles_backup.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + modName).Length + 1));
                                ////Console.WriteLine(" f => " + f);
                                ////Console.WriteLine();
                            }
                        }
                    }
                    ////Console.WriteLine(" Check.IsRepeated() => " + Check.IsRepeated());

                    if (!Check.IsRepeated())
                    {
                        // edit this to only make backup of "files to replace"
                        // not anymore: check if onetimeBackup is true, if true: start original game files backup
                        Check.fileBackup(modName);

                        // now call method to override game files with mod files
                        foreach (string modPath in Definitions.modFiles)
                        {
                            ////Console.WriteLine(" d => " + d);
                            ////Console.WriteLine(" Path.GetDirectoryName(d) => " + Path.GetDirectoryName(d));

                            foreach (string modFile in Definitions.reformed_modFiles)
                            {
                                ////Console.WriteLine(" - Path.GetDirectoryName(w) => " + Path.GetDirectoryName(w));
                                if (Path.GetDirectoryName(modFile).ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                                {
                                    if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + modName).Length + 1) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + modName).Length + 1) == Profiles.Default.GetGame().GetFolderContent() + "/" + modFile)
                                    {
                                        File.Copy(modPath, modFile, true);
                                        //Definitions.install.Add("Installing mod: " + modName + " :");
                                        //Definitions.install.Add("    " + modPath + " => " + modFile);
                                    }
                                }
                                else
                                {
                                    if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + modName).Length + 1) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + modName).Length + 1) == Profiles.Default.GetGame().GetFolderContent() + "/" + modFile)
                                    {
                                        File.Copy(modPath, Profiles.Default.GetGame().GetFolderContent() + "/" + modFile, true);
                                        //Definitions.install.Add("Installing mod: " + modName + " :");
                                        //Definitions.install.Add("    " + modPath + " => " + Profiles.Default.GetGame().GetFolderContent() + "/" + modFile);
                                    }
                                }

                            }
                        }
                    }

                    timeRecord.Stop();
                    TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteEnd("Done " + time.ToString(@"ss\:fff"));
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.WriteLine("Done " + time.ToString(@"ss\:fff"));

                    //Console.WriteLine("Done!");
                    //Definitions.install.Add("Done installing mod: " + modName + " !");

                    //Keraplz.JSON.Write.ModDefinion.ModConfig(s, Definitions.modFiles);
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.installMods(" + "" + ")");
                LogFile.WriteLine(e.Message);
            }
        }

        public static void uninstallMod(string input_modName)
        {
            try
            {
                //int n = 0;

                string bPath = Profiles.Default.GetProgramName() + "/_backup/" + Profiles.Default.GetGame().GetFolderContent() + " - ";
                string cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                string sPath = bPath + Path.GetFileNameWithoutExtension(input_modName) + "/";

                if (Directory.Exists(sPath) && Directory.Exists(cPath))
                {
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                        sw.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(input_modName) + " ... ");
                    LogFile.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(input_modName) + " ... ");
                    var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                    foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
                    {
                        foreach (string uninstallFile in Directory.GetFiles(sPath, "*" + extension, SearchOption.AllDirectories))
                        {
                            cPath = cPath + uninstallFile.Remove(0, bPath.Length + Path.GetFileNameWithoutExtension(input_modName).Length + 1);

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
                            else
                            {
                                //using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                                    //sw.WriteLine(@"ERROR TO UNINSTALL MOD """ + Path.GetFileNameWithoutExtension(input_modName) + @""" REASON: File to uninstall doesn't match with installed file name(" + pTest_05 + " => " + pTest_06 + ")");
                                //Console.WriteLine(@"ERROR TO UNINSTALL MOD """ + Path.GetFileNameWithoutExtension(input_modName) + @""" REASON: File to uninstall doesn't match with installed file name(" + pTest_05 + " => " + pTest_06 + ")");
                            }

                            //n = n + 1;
                            //using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                                //sw.WriteLine(n.ToString("0000") + @" - """ + uninstallFile);

                            cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                        }
                    }

                    timeRecord.Stop();
                    TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteEnd("Done " + time.ToString(@"ss\:fff"));
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                        sw.WriteLine("Done " + time.ToString(@"ss\:fff"));
                }
                //else Console.WriteLine(@"(uninstallMods)Error: Directory """ + sPath + @""" or directory ""Content/"" doesn't exists!");

                string toDupe = Path.GetDirectoryName(Path.GetDirectoryName(sPath));
                dupeDirectories(toDupe);
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.uninstallMod(" + input_modName + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void installMod(string input_modName)
        {
            try
            {
                if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                    Maintenance.CreatePaths(Profiles.Default.GetMaintenancePaths(), true);

                foreach (string d in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modName + "/"))
                {
                    foreach (string a in Profiles.Default.GetGame().GetExtensions().ToArray())
                    {
                        foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
                        {
                            Definitions.modFiles.Add(f);
                            Definitions.reformed_modFiles.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + input_modName).Length + 1));
                            Definitions.reformed_modFiles_backup.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + input_modName).Length + 1));
                        }
                    }
                }

                if (!Check.IsRepeated())
                {
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.Write("Installing mod: " + Path.GetFileNameWithoutExtension(input_modName) + " ... ");
                    LogFile.Write("Installing mod: " + Path.GetFileNameWithoutExtension(input_modName) + " ... ");
                    var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                    // start original game files backup
                    Check.fileBackup(input_modName);

                    // now call method to override game files with mod files
                    foreach (string modPath in Definitions.modFiles)
                    {
                        foreach (string modFile in Definitions.reformed_modFiles)
                        {
                            if (Path.GetDirectoryName(modFile).ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                            {
                                if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + input_modName).Length + 1) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + input_modName).Length + 1) == Profiles.Default.GetGame().GetFolderContent() + "/" + modFile)
                                {
                                    File.Copy(modPath, modFile, true);
                                    //Definitions.install.Add("Installing mod: " + Definitions.modInstalling + " :");
                                    //Definitions.install.Add("    " + d + " => " + w);
                                }
                            }
                            else
                            {
                                if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + input_modName).Length + 1) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + input_modName).Length + 1) == Profiles.Default.GetGame().GetFolderContent() + "/" + modFile)
                                {
                                    File.Copy(modPath, Profiles.Default.GetGame().GetFolderContent() + "/" + modFile, true);
                                    //Definitions.install.Add("Installing mod: " + Definitions.modInstalling + " :");
                                    //Definitions.install.Add("    " + d + " => " + Profiles.Default.GetGame().GetFolderContent() + "/" + w);
                                }
                            }

                        }
                    }

                    timeRecord.Stop();
                    TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteEnd("Done " + time.ToString(@"ss\:fff"));
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.WriteLine("Done " + time.ToString(@"ss\:fff"));
                }

                //Definitions.install.Add("Done installing mod: " + Definitions.modInstalling + " !");
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.installMod(" + input_modName + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void uninstallMod(Mod mod_info)
        {
            try
            {
                string bPath = Profiles.Default.GetProgramName() + "/_backup/" + Profiles.Default.GetGame().GetFolderContent() + " - ";
                string cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                string sPath = bPath + Path.GetFileNameWithoutExtension(mod_info.GetName()) + "/";

                if (Directory.Exists(sPath) && Directory.Exists(cPath))
                {
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                        sw.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(mod_info.GetName()) + " ... ");
                    LogFile.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(mod_info.GetName()) + " ... ");
                    var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                    foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
                    {
                        foreach (string uninstallFile in Directory.GetFiles(sPath, "*" + extension, SearchOption.AllDirectories))
                        {
                            cPath = cPath + uninstallFile.Remove(0, bPath.Length + Path.GetFileNameWithoutExtension(mod_info.GetName()).Length + 1);

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

                    timeRecord.Stop();
                    TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteEnd("Done " + time.ToString(@"ss\:fff"));
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
                        sw.WriteLine("Done " + time.ToString(@"ss\:fff"));
                }

                string toDupe = Path.GetDirectoryName(Path.GetDirectoryName(sPath));
                dupeDirectories(toDupe);
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.uninstallMod(Mod " + mod_info.GetName() + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void installMod(Mod mod_info)
        {
            try
            {
                if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                    Maintenance.CreatePaths(Profiles.Default.GetMaintenancePaths(), true);

                foreach (string d in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName() + "/"))
                {
                    foreach (string a in Profiles.Default.GetGame().GetExtensions().ToArray())
                    {
                        foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
                        {
                            Definitions.modFiles.Add(f);
                            Definitions.reformed_modFiles.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName()).Length + 1));
                            Definitions.reformed_modFiles_backup.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName()).Length + 1));
                        }
                    }
                }

                if (!Check.IsRepeated())
                {
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.Write("Installing mod: " + Path.GetFileNameWithoutExtension(mod_info.GetName()) + " ... ");
                    LogFile.Write("Installing mod: " + Path.GetFileNameWithoutExtension(mod_info.GetName()) + " ... ");
                    var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                    // start original game files backup
                    Check.fileBackup(mod_info.GetName());

                    // now call method to override game files with mod files
                    foreach (string modPath in Definitions.modFiles)
                    {
                        foreach (string modFile in Definitions.reformed_modFiles)
                        {
                            if (Path.GetDirectoryName(modFile).ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                            {
                                if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName()).Length + 1) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName()).Length + 1) == Profiles.Default.GetGame().GetFolderContent() + "/" + modFile)
                                {
                                    File.Copy(modPath, modFile, true);
                                }
                            }
                            else
                            {
                                if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName()).Length + 1) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName()).Length + 1) == Profiles.Default.GetGame().GetFolderContent() + "/" + modFile)
                                {
                                    File.Copy(modPath, Profiles.Default.GetGame().GetFolderContent() + "/" + modFile, true);
                                }
                            }

                        }
                    }

                    timeRecord.Stop();
                    TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteEnd("Done " + time.ToString(@"ss\:fff"));
                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
                        sw.WriteLine("Done " + time.ToString(@"ss\:fff"));
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.ModsManager.installMod(Mod " + mod_info.GetName() + ")");
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

        public static void setMods(string modsFolder)
        {
            try
            {
                foreach (string s in Directory.GetDirectories(modsFolder))
                {
                    string ss = s.Remove(0, modsFolder.Length + 1);

                    if (ss.ToLower().Contains("_backup") || ss.ToLower().Contains("_temp")) { }
                    else { modsList.Add(ss); }
                }
            }
            catch (Exception e)
            {
                
                {
                    LogFile.WriteLine("Error found in ModsManager.ModsManager.setMods(" + modsFolder + ")");
                    LogFile.WriteLine(e.Message);
                }
            }
        }
    }
    class Check
    {
        private static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
        public static IList<IList<Mod>> GetBannedMods(Game game_info)
        {
            IList<IList<Mod>> BannedMods = new List<IList<Mod>>();

            //try
            //{
                foreach (string nameer in Directory.GetFiles(game_info.GetFolderMods(), "*.json"))
                {
                    IList<String> CurrentModContent = new List<String>();
                    string modName = Path.GetFileNameWithoutExtension(nameer);

                    foreach (string ModContent in Read.Mods.GetContent(modName, game_info.GetFolderMods()))
                            BannedMods.Add(new List<Mod>(Read.Mods.GetContainsMod(ModContent.Remove(0, game_info.GetFolderMods().Length + 2 + modName.Length + 2), game_info.GetFolderMods())));
                }

                BannedMods = BannedMods.Distinct().ToList();

                if (BannedMods.Count > 0) return BannedMods;
                else return null;
            //}
            //catch (Exception e)
            //{
                //LogFile.WriteLine("Error found in ModsManager.Check.GetBannedMods(Game " + game_info.GetName() + ")");
                //LogFile.WriteLine(e.Message);

                //return null;
            //}
        }
        public static IList<Mod> GetBannedModsOld(Game game_info)
        {
            IDictionary<String, Int32> modsContainsDict = new Dictionary<String, Int32>();
            IDictionary<String, Int32> dictionary = new Dictionary<String, Int32>();
            IList<Int32> TimesRepeated = new List<Int32>();
            IList<String> ContentChecked = new List<String>();

            IList<Mod> BannedMods = new List<Mod>();

            try
            {
                foreach (string nameer in Directory.GetFiles(game_info.GetFolderMods(), "*.json"))
                {
                    IList<String> CurrentModContent = new List<String>();
                    string ModName = Path.GetFileNameWithoutExtension(nameer);

                    foreach (string ModContent in Read.Mods.GetContent(ModName, game_info.GetFolderMods()))
                        CurrentModContent.Add(ModContent.Remove(0, game_info.GetFolderMods().Length + 2 + ModName.Length + 2));

                    if (CurrentModContent != null)
                    {
                        foreach (string content_ in CurrentModContent)
                        {
                            string content_base = content_.ToLower();

                            if (dictionary.ContainsKey(content_base))
                                dictionary[content_base] += 1;
                            else dictionary.Add(content_base, 1);
                        }

                        CurrentModContent.Clear();
                    }
                }

                foreach (string nameer in Directory.GetFiles(game_info.GetFolderMods(), "*.json"))
                {
                    int n = 0;
                    IList<String> CurrentModContent = new List<String>();
                    string ModName = Path.GetFileNameWithoutExtension(nameer);

                    foreach (string ModContent in Read.Mods.GetContent(ModName, game_info.GetFolderMods()))
                    {
                        CurrentModContent.Add(ModContent.Remove(0, game_info.GetFolderMods().Length + 2 + ModName.Length + 2));
                    }

                    foreach (string content_ in CurrentModContent)
                    {
                        string content_base = content_.ToLower();

                        foreach (KeyValuePair<String, Int32> contentDict in Keraplz.JSON.Read.Mods.GetContainsDict(content_base, game_info.GetFolderMods()))
                        {
                            if (!modsContainsDict.ContainsKey(contentDict.Key))
                                modsContainsDict.Add(contentDict);
                        }

                        if (ContentChecked.Contains(content_base)) { }
                        else
                        {
                            n = dictionary[content_base];
                            TimesRepeated.Add(dictionary[content_base]);

                            ContentChecked.Add(content_base);
                        }

                        if (Keraplz.JSON.Read.Mods.Contains(content_base, game_info.GetFolderMods()))
                        {
                            IList<String> modsContains = Keraplz.JSON.Read.Mods.GetContains(content_base, game_info.GetFolderMods());

                            var modsCList = modsContainsDict.ToList();
                            modsCList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                            int n_ = 0;
                            if (n_ < n - 1)
                                while (n_ < n - 1)
                                {
                                    foreach (KeyValuePair<String, Int32> mod in modsCList)
                                    {
                                        if (n_ == n - 1) { goto BREAK; }
                                        else
                                        {
                                            if (!BannedMods.Contains(Read.Mods.GetModByName(mod.Key, game_info.GetFolderMods())))
                                                BannedMods.Add(Read.Mods.GetModByName(mod.Key, game_info.GetFolderMods()));

                                            n_ = n_ + 1;
                                        }
                                    }

                                BREAK: ;
                                }
                        }
                    }

                    CurrentModContent.Clear();
                    modsContainsDict.Clear();
                }

                if (BannedMods.Count > 0) return BannedMods;
                else return null;
            }
            catch (Exception e)
            {
                if (!Directory.Exists(Profiles.Blank.GetProgramName() + "/_logs/")) Directory.CreateDirectory(Profiles.Blank.GetProgramName() + "/_logs/");
                
                {
                    LogFile.WriteLine("Error found in ModsManager.Check.GetBannedMods(" + game_info.GetName() + ")");
                    LogFile.WriteLine(e.Message);
                }

                return null;
            }
        }
        public static IList<String> GetBannedMods()
        {
            IDictionary<String, Int32> modsContainsDict = new Dictionary<String, Int32>();
            IDictionary<String, Int32> dictionary = new Dictionary<String, Int32>();
            IList<Int32> TimesRepeated = new List<Int32>();
            IList<String> ContentChecked = new List<String>();

            IList<String> BannedMods = new List<String>();

            try
            {
                foreach (string nameer in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    IList<String> CurrentModContent = new List<String>();
                    string ModName = Path.GetFileNameWithoutExtension(nameer);

                    foreach (string ModContent in Read.Mods.GetContent(ModName))
                    {
                        CurrentModContent.Add(ModContent.Remove(0, Profiles.Default.GetGame().GetFolderMods().Length + 2 + ModName.Length + 2));
                    }

                    if (CurrentModContent != null)
                    {
                        
                        foreach (string content_ in CurrentModContent)
                        {
                            string content_base = content_.ToLower();

                            if (dictionary.ContainsKey(content_base))
                            {
                                dictionary[content_base] += 1;
                            }
                            else
                            {
                                dictionary.Add(content_base, 1);
                            }
                        }

                        CurrentModContent.Clear();
                    }
                }

                foreach (string nameer in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    int n = 0;
                    IList<String> CurrentModContent = new List<String>();
                    string ModName = Path.GetFileNameWithoutExtension(nameer);

                    foreach (string ModContent in Read.Mods.GetContent(ModName))
                    {
                        CurrentModContent.Add(ModContent.Remove(0, Profiles.Default.GetGame().GetFolderMods().Length + 2 + ModName.Length + 2));
                    }

                    foreach (string content_ in CurrentModContent)
                    {
                        string content_base = content_.ToLower();

                        foreach (KeyValuePair<String, Int32> contentDict in Keraplz.JSON.Read.Mods.GetContainsDict(content_base))
                        {
                            if (!modsContainsDict.ContainsKey(contentDict.Key))
                                modsContainsDict.Add(contentDict);
                        }

                        if (ContentChecked.Contains(content_base)) { }
                        else
                        {
                            n = dictionary[content_base];
                            TimesRepeated.Add(dictionary[content_base]);

                            ContentChecked.Add(content_base);
                        }

                        if (Keraplz.JSON.Read.Mods.Contains(content_base))
                        {
                            IList<String> modsContains = Keraplz.JSON.Read.Mods.GetContains(content_base);

                            var modsCList = modsContainsDict.ToList();
                            modsCList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

                            int n_ = 0;
                            if (n_ < n - 1)
                                while (n_ < n - 1)
                                {
                                    foreach (KeyValuePair<String, Int32> mod in modsCList)
                                    {
                                        if (n_ == n - 1) { goto BREAK; }
                                        else
                                        {
                                            if (BannedMods.Contains(mod.Key)) { }
                                            else BannedMods.Add(mod.Key);

                                            n_ = n_ + 1;
                                        }
                                    }

                                    BREAK:;
                                }
                        }
                    }

                    CurrentModContent.Clear();
                    modsContainsDict.Clear();
                }

                BannedMods = BannedMods.Distinct().ToList();

                if (BannedMods.Count > 0)
                    return BannedMods;
                else return null;
            }
            catch (Exception e)
            {
                if (!Directory.Exists(Profiles.Default.GetProgramName() + "/_logs/")) Directory.CreateDirectory(Profiles.Default.GetProgramName() + "/_logs/");
                
                {
                    LogFile.WriteLine("Error found in ModsManager.Check.GetBannedMods(" + "" + ")");
                    LogFile.WriteLine(e.Message);
                }

                return null;
            }
        }

        public static string GetCurrentVersion()
        {
            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt";

                if (File.Exists(filePath))
                    return "r" + File.ReadLines(filePath).First().Split('r', ')')[1] + ")";
                else return string.Empty;
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Check.GetCurrentVersion(" + "" + ")");
                LogFile.WriteLine(e.Message);

                return string.Empty;
            }
        }
        public static int GetCurrentBuild()
        {
            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt";

                if (File.Exists(filePath))
                    return Int32.Parse(File.ReadLines(filePath).First().Split('(', ')')[1]); //File.ReadLines(filePath).First().Remove(0, 26).Remove(3, 21);
                else return 0;
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Check.GetCurrentBuild(" + "" + ")");
                LogFile.WriteLine(e.Message);

                return 0;
            }
        }
        public static IList<String> GetTypes(Game Game, String modName)
        {
            IList<String> towrite_types = new List<String>();

            foreach (string type in Directory.GetDirectories(Game.GetFolderMods() + "/" + modName + "/" + Game.GetFolderContent() + "/"))
            {
                towrite_types.Add(type.Split('/').Last());
            }

            towrite_types = towrite_types.Distinct().ToList();
            return towrite_types;
        }
        public static IList<String> GetTypes(Profile profile, String modName)
        {
            IList<String> towrite_types = new List<String>();

            foreach (string type in Directory.GetDirectories(profile.GetGame().GetFolderMods() + "/" + modName + "/" + profile.GetGame().GetFolderContent() + "/"))
            {
                towrite_types.Add(type.Split('/').Last());
            }

            towrite_types = towrite_types.Distinct().ToList();
            return towrite_types;
        }
        public static IList<String> GetTypes(String modName)
        {
            IList<String> towrite_types = new List<String>();

            foreach (string type in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderMods() + "/" + modName + "/" + Profiles.Default.GetGame().GetFolderContent() + "/"))
            {
                towrite_types.Add(type.Split('/').Last());
            }

            towrite_types = towrite_types.Distinct().ToList();
            return towrite_types;
        }
        public static IList<String> GetContent(Game Game, String modName)
        {
            IList<String> towrite_pathfiles = new List<String>();

            foreach (string type in Directory.GetDirectories(Game.GetFolderMods() + "/" + modName + "/" + Game.GetFolderContent() + "/"))
            {
                foreach (string extension in Game.GetExtensions().ToArray())
                {
                    foreach (string filepath in Directory.GetFiles(type, "*" + extension, SearchOption.AllDirectories))
                    {
                        towrite_pathfiles.Add(filepath.Replace("/", "\\"));
                    }
                }
            }

            towrite_pathfiles = towrite_pathfiles.Distinct().ToList();
            return towrite_pathfiles;
        }
        public static IList<String> GetContent(Profile profile, String modName)
        {
            IList<String> towrite_pathfiles = new List<String>();

            foreach (string type in Directory.GetDirectories(profile.GetGame().GetFolderMods() + "/" + modName + "/" + profile.GetGame().GetFolderContent() + "/"))
            {
                foreach (string extension in profile.GetGame().GetExtensions().ToArray())
                {
                    foreach (string filepath in Directory.GetFiles(type, "*" + extension, SearchOption.AllDirectories))
                    {
                        towrite_pathfiles.Add(filepath.Replace("/", "\\"));
                    }
                }
            }

            towrite_pathfiles = towrite_pathfiles.Distinct().ToList();
            return towrite_pathfiles;
        }
        public static IList<String> GetContent(String modName)
        {
            IList<String> towrite_pathfiles = new List<String>();

            foreach (string type in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderMods() + "/" + modName + "/" + Profiles.Default.GetGame().GetFolderContent() + "/"))
            {
                foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
                {
                    foreach (string filepath in Directory.GetFiles(type, "*" + extension, SearchOption.AllDirectories))
                    {
                        towrite_pathfiles.Add(filepath.Replace("/", "\\"));
                    }
                }
            }

            towrite_pathfiles = towrite_pathfiles.Distinct().ToList();
            return towrite_pathfiles;
        }

        public static void fileBackup(string input_modname)
        {
            try
            {
                string sPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                string dPath = Profiles.Default.GetProgramName() + "/_backup/" + Profiles.Default.GetGame().GetFolderContent() + " - " + input_modname;

                foreach (string s in Definitions.reformed_modFiles_backup)
                {
                    sPath = Profiles.Default.GetGame().GetFolderContent() + "/";
                    if (s.ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                        sPath = s;
                    else sPath = sPath + s;

                    string cDir = dPath + "/" + Path.GetDirectoryName(sPath).Remove(0, 8);

                    Directory.CreateDirectory(cDir);
                    File.Copy(sPath, cDir + "/" + Path.GetFileName(s), true);
                }

                Definitions.reformed_modFiles_backup.Clear();
            }
            catch (Exception e)
            {
                
                {
                    LogFile.WriteLine("Error found in ModsManager.Check.fileBackup(" + input_modname + ")");
                    LogFile.WriteLine(e.Message);
                }
            }
        }
        public static Boolean IsRepeated()
        {
            try
            {
                int count_modFiles = Definitions.reformed_modFiles.Count();
                Definitions.reformed_modFiles_unic = Definitions.reformed_modFiles.Distinct();

                // mod files => dupped mod files
                ////Console.WriteLine(count_modFiles.ToString("0000") + " => " + (Definitions.reformed_modFiles_unic.Count()).ToString("0000"));

                //Definitions.reformed_modFiles = Definitions.modFiles;
                if (count_modFiles != Definitions.reformed_modFiles_unic.Count()) return true;
                return false;
            }
            catch (Exception e)
            {
                
                {
                    LogFile.WriteLine("Error found in ModsManager.Check.IsRepeated(" + ")");
                    LogFile.WriteLine(e.Message);
                }

                return true;
            }
        }
        public static Boolean IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        public static Boolean dupe_subFolders(string a, string s)
        {
            if (Directory.Exists(Profiles.Default.GetProgramName() + "/_content/"))
            foreach (String Type in Directory.GetDirectories(Profiles.Default.GetProgramName() + "/_content/", "*"))
            {
                if (a.ToLower().Contains(Type.ToLower())) return true;
                else return false;
            }
            return false;
        }

        public static void ManageMods(string modsFolder)
        {
            int n = 0;
            IList<String> RemoveMods = new List<String>();

            try
            {
                //Definitions.modContains.Clear();
                ModsManager.setMods(modsFolder);

                foreach (string s in ModsManager.modsList)
                {
                    string sPath = modsFolder + "/" + s;
                    //var oneCount = Directory.EnumerateFiles(sPath).Count() + 1;
                    if (s.Contains("_backup") || s.Contains("_temp")) { }
                    else if (Check.IsDirectoryEmpty(sPath))
                    {
                        RemoveMods.Add(s);
                        
                        //Console.WriteLine("Empty mods folder removed from IList: " + s);
                        //Console.WriteLine();
                    }
                    else
                    {
                        IList<string> sDir = Directory.GetDirectories(sPath);
                        if (Directory.Exists(Profiles.Default.GetProgramName() + "/_content/"))
                        foreach (string w in sDir)
                        {
                            if (w.Contains(Profiles.Default.GetGame().GetFolderContent()))
                            {
                                //var twoCount = 1; //Directory.EnumerateFiles(s).Count() + 1;
                                if (Check.IsDirectoryEmpty(sPath)) { }
                                else
                                {
                                    IList<string> wDir = Directory.GetDirectories(w);
                                    foreach (string a in wDir)
                                    {
                                        foreach (String Type in Directory.GetDirectories(Profiles.Default.GetProgramName() + "/_content/", "*"))
                                        {
                                            if (a.ToLower().Contains(Type.ToLower()))
                                            {
                                                n = n + 1;
                                                //modContains.Add(Profiles.Default.GetGame().GetFolderContent() + "/" + Type);
                                            }
                                        }
                                    }
                                }
                            }

                            foreach (String Type in Directory.GetDirectories(Profiles.Default.GetProgramName() + "/_content/", "*"))
                            {
                                if (w.ToLower().Contains(Type.ToLower()))
                                {
                                    n = n + 1;
                                    //Definitions.modContains.Add(Type);
                                }
                            }
                        }
                    }
                }

                foreach (string s in RemoveMods)
                {
                    ModsManager.modsList.Remove(s);
                }
            }
            catch (Exception e)
            {
                
                {
                    LogFile.WriteLine("Error found in ModsManager.Check.ManageMods(" + modsFolder  + ")");
                    LogFile.WriteLine(e.Message);
                }
            }

            ////Console.WriteLine();
            ////Console.WriteLine("n => " + n.ToString("0000") + " => " + (Definitions.modContains.Count() + 1).ToString("0000"));
        }
        public static string jsonIgnored()
        {
            return "json files :: " + Keraplz.JSON.Write.n.ToString("0000") + " => " + (Directory.EnumerateFiles(Profiles.Default.GetProgramName() + "/_content/", "*.json", SearchOption.AllDirectories).Count()).ToString("0000");
        }

        #region "IgnoredXNB"
        public static Boolean Ignored(String filename, String directory)
        {
            if (ContainsSFX(filename, directory) || ContainsATLAS(filename))
            {
                return true;
            }
            else return false;
        }

        private static Boolean ContainsSFX(String filename, String directory)
        {
            String[] directories = directory.Split(Path.DirectorySeparatorChar);

            Definitions.ignoredType = "SFX";
            Definitions.ignoredFile = "   :: " + filename;

            if (directories.ToLookup(i => i.ToLower()).Contains("sfx"))
                return true;
            else return false;
        }
        private static Boolean ContainsATLAS(String filename)
        {
            Definitions.ignoredType = "ATLAS";
            Definitions.ignoredFile = " :: " + filename;

            if (filename.ToLower().Contains("atlas"))
                return true;
            else return false;
        }
        #endregion

    }
    class Maintenance
    {
        public static IList<Mod> WriteModDefinitions(Game Game)
        {
            IList<Mod> Mods = new List<Mod>();

            try
            {
                foreach (string modPath in Directory.GetDirectories(Game.GetFolderMods() + "/"))
                {
                    string modName = Path.GetFileName(modPath);

                    if (!File.Exists(Game.GetFolderMods() + "/" + modName + ".json"))
                    {
                        Mod mod_info = new Mod(modName, false, Check.GetTypes(Game, modName), Check.GetContent(Game, modName));
                        Keraplz.JSON.Write.ModDefinion.ModConfig(mod_info, Game);
                        Mods.Add(mod_info);
                    }
                    else
                    {
                        Mod mod_info = new Mod(modName, Read.Mods.IsInstalled(modName, Game.GetFolderMods()), Read.Mods.GetType(modName, Game.GetFolderMods()), Read.Mods.GetContent(modName, Game.GetFolderMods()));
                        Mods.Add(mod_info);
                    }
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Maintenance.WriteModDefinitions(Game " + Game.GetName() + ")");
                LogFile.WriteLine(e.Message);
            }

            return Mods;
        }
        public static void WriteModDefinitions(Profile profile, Boolean skip)
        {
            try
            {
                if (!skip) { return; }
                else
                {
                    foreach (string modPath in Directory.GetDirectories(profile.GetGame().GetFolderMods() + "/"))
                    {
                        string modName = Path.GetFileName(modPath);

                        foreach (string _modPath in Directory.GetDirectories(profile.GetGame().GetFolderMods() + "/"))
                        {
                            string _modName = Path.GetFileName(modPath);

                            if (!File.Exists(profile.GetGame().GetFolderMods() + "/" + modName + ".json"))
                            {
                                Mod mod_info = new Mod(modName, false, Check.GetTypes(profile, modName), Check.GetContent(profile, modName));
                                Keraplz.JSON.Write.ModDefinion.ModConfig(mod_info, profile.GetGame());
                                if (!profile.Contains(mod_info))
                                    profile.AddMod(mod_info);
                            }
                            else
                            {
                                Mod mod_info = new Mod(modName, Read.Mods.IsInstalled(modName), Read.Mods.GetType(modName), Read.Mods.GetContent(modName));
                                if (!profile.Contains(mod_info))
                                    profile.AddMod(mod_info);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Maintenance.WriteModDefinitions(Profile, Boolean " + skip.ToString() + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void WriteModDefinitions(Boolean skip)
        {
            Profile profile = Profiles.Default;

            try
            {
                if (!skip) { return; }
                else
                {
                    foreach (string modPath in Directory.GetDirectories(profile.GetGame().GetFolderMods() + "/"))
                    {
                        string modName = Path.GetFileName(modPath);

                        if (!File.Exists(profile.GetGame().GetFolderMods() + "/" + modName + ".json"))
                        {
                            Mod mod_info = new Mod(modName, false, Check.GetTypes(modName), Check.GetContent(modName));
                            Keraplz.JSON.Write.ModDefinion.ModConfig(mod_info, profile.GetGame());
                            if (!profile.Contains(mod_info))
                                profile.AddMod(mod_info);
                        }
                        else
                        {
                            Mod mod_info = new Mod(modName, Read.Mods.IsInstalled(modName), Read.Mods.GetType(modName), Read.Mods.GetContent(modName));
                            if (!profile.Contains(mod_info))
                                profile.AddMod(mod_info);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Maintenance.WriteModDefinitions(Boolean " + skip.ToString() + ")");
                LogFile.WriteLine(e.Message);
            }
        }
        public static void ResetLogs(String ProgramName, String[] FileArray)
        {
            foreach (string file in FileArray)
            {
                if (File.Exists(ProgramName + "/_logs/" + file))
                    File.Delete(ProgramName + "/_logs/" + file);

                File.Create(ProgramName + "/_logs/" + file).Close();
            }
        }
        public static void ResetLogs(Profile profile, String[] FileArray, Boolean skip)
        {
            if (!skip) { return; }
            else
            {
                foreach (string file in FileArray)
                {
                    if (File.Exists(profile.GetProgramName() + "/_logs/" + file))
                        File.Delete(profile.GetProgramName() + "/_logs/" + file);

                    File.Create(profile.GetProgramName() + "/_logs/" + file).Close();
                }
            }
        }
        public static void ResetLogs(String[] FileArray, Boolean skip)
        {
            if (!skip) { return; }
            else
            {
                foreach (string file in FileArray)
                {
                    if (File.Exists(Profiles.Default.GetProgramName() + "/_logs/" + file))
                        File.Delete(Profiles.Default.GetProgramName() + "/_logs/" + file);

                    File.Create(Profiles.Default.GetProgramName() + "/_logs/" + file).Close();
                }
            }
        }
        public static void CreatePaths(String ProgramName, Game Game, String[] PathArray)
        {
            foreach (string path in PathArray)
            {
                if (!Directory.Exists(ProgramName + "/" + path))
                    Directory.CreateDirectory(ProgramName + "/" + path);
            }

            if (!Directory.Exists(Game.GetFolderMods()))
                Directory.CreateDirectory(Game.GetFolderMods());
        }
        public static void CreatePaths(Profile profile, String[] PathArray, Boolean skip)
        {
            if (!skip) { return; }
            else
            {
                foreach (string path in PathArray)
                {
                    if (!Directory.Exists(profile.GetProgramName() + "/" + path))
                        Directory.CreateDirectory(profile.GetProgramName() + "/" + path);
                }

                if (!Directory.Exists(profile.GetGame().GetFolderMods()))
                    Directory.CreateDirectory(profile.GetGame().GetFolderMods());
            }
        }
        public static void CreatePaths(String[] PathArray, Boolean skip)
        {
            if (!skip) { return; }
            else
            {
                foreach (string path in PathArray)
                {
                    if (!Directory.Exists(Profiles.Default.GetProgramName() + "/" + path))
                        Directory.CreateDirectory(Profiles.Default.GetProgramName() + "/" + path);
                }

                if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                    Directory.CreateDirectory(Profiles.Default.GetGame().GetFolderMods());
            }
        }
    }
    class Log
    {
        public static void Write(string[] input_logFiles)
        {
            int n = 0;
            IEnumerable<String> toLog = new List<String>();

            foreach (string file in input_logFiles)
            {
                if (file == "install.txt")
                    Definitions.toLog_unic = Definitions.install.Distinct();
                else if (file == "output.txt")
                    Definitions.toLog_unic = Definitions.outputName.Distinct();
                else if (file == "ignoredList.txt")
                    Definitions.toLog_unic = Definitions.ignoredList;
                else if (file == "xnbpath.txt")
                    Definitions.toLog_unic = Definitions.xnbPath.Distinct();

                toLog = Definitions.toLog_unic;

                foreach (string line in toLog)
                {
                    n = n + 1;

                    using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/" + file))
                    {
                        sw.WriteLine((n).ToString("0000") + " - " + line);
                    }
                }

                n = 0;
                toLog = null;
            }
        }
    }
}