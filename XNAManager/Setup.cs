using Keraplz.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    class InfoHolder
    {
        public static String GameName = Definitions.GameName;
        public static String ContentFolder = Definitions.ContentFolder;
        public static String ModsFolder = Definitions.ModsFolder;
    }
    public class Setup
    {
        // public static void MainSetup(string content, string modsFolder, string backupFolder, string tempFolder)
        public static void MainSetup(/*String content, String modsFolder, Boolean CreatePaths, Boolean ResetLogs, String readJSON*/)
        {
            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            // ----

            Setup.Maintenance_(true, true, true);
            Setup.SearchXNB_(GetFolderContent(), true);
            Setup.WriteJSON_(false, true);
            Setup.LogOutputs_();

            // ----

            timeRecord.Stop();

            // ----

            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);

            Definitions.toLabel_baseinfo_SetupTime = time.ToString(@"ss\:fff");
            Definitions.toLabel_baseinfo_InstalledMods = Keraplz.JSON.Read.mods_GetNInstalled();
            Definitions.toLabel_baseinfo_CurrentBuild = Check.GetCurrentBuild().ToString("000");

            Definitions.toLabel_baseinfo = "Game: " + GetGameName() + ", Build: " + Definitions.toLabel_baseinfo_CurrentBuild + ", SetupTime: " + Definitions.toLabel_baseinfo_SetupTime + ", Installed Mods: " + Definitions.toLabel_baseinfo_InstalledMods.ToString("00");
        }

        public static void InstallMod_(string input_modName)
        {
            ModsManager.installMod(input_modName);
            Keraplz.JSON.Write.ModDefinion_edit_installed(input_modName, true);
        }
        public static void UninstallMod_(string input_modName)
        {
            ModsManager.uninstallMod(input_modName);
            Keraplz.JSON.Write.ModDefinion_edit_installed(input_modName, false);
        }

        public static void Maintenance_(Boolean CreatePaths, Boolean ResetLogs, Boolean WriteModDefinitions)
        {
            Maintenance.CreatePaths(CreatePaths);
            Maintenance.ResetLogs(ResetLogs);
            Maintenance.WriteModDefinitions(WriteModDefinitions);
        }
        public static void WriteJSON_(Boolean firsttimesetup, Boolean config)
        {
            if (config)
            {
                Keraplz.JSON.Write.Configuration(firsttimesetup, Definitions.configFile);
            }
            else if (!config)
            {

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
            Log.Write(Definitions.logFiles);
        }

        //public static void NewGame() {  }
        //public static void SetGame(Game input_game)
        //{
        //    Game.CurrentGame = input_game;
        //    Game.GameName = Games.Unknown.GetName();
        //    Game.GameName = Games.SpeedRunners.GetName();
        //}
        //public Game GetGame() { return Game.CurrentGame; }

        public static void SetGameName(String input_name)
        {
            Definitions.GameName = input_name;
            InfoHolder.GameName = Definitions.GameName;
        }
        public static string GetGameName()
        {
            return InfoHolder.GameName;
        }

        public static void SetFolderMods(String input_folder)
        {
            Definitions.ModsFolder = input_folder;
            InfoHolder.ModsFolder = Definitions.ModsFolder;
        }
        public static string GetFolderMods()
        {
            return InfoHolder.ModsFolder;
        }

        public static void SetFolderContent(String input_folder)
        {
            Definitions.ContentFolder = input_folder;
            InfoHolder.ContentFolder = Definitions.ContentFolder;
        }
        public static string GetFolderContent()
        {
            return InfoHolder.ContentFolder;
        }



        private static void Setup_(String content, String modsFolder, Boolean CreatePaths, Boolean ResetLogs, String readJSON)
        {
            //Console.Write("Maintenance: ");

            // Clean .txt log files
            Maintenance.CreatePaths(CreatePaths);
            Maintenance.ResetLogs(ResetLogs);

            //Console.WriteLine("Done.");

            Keraplz.JSON.Write.Configuration(true, Definitions.configFile);

            //Console.Write("SearchXNB: ");

            // Start XNB search loop and Write JSON files based on XNB files
            //Search.SearchXNB(content, false);

            //Console.WriteLine("Done.");

            // Convert .xnb to .png
            //

            //Console.Write("WriteJSON: ");

            // Start XNB search loop and Write JSON files based on XNB files
            Search.SearchXNB(content, true);

            //Console.WriteLine("Done.");

            //Console.Write("ReadJSON: ");

            // Read JSON files recursively and duped
            Keraplz.JSON.Read.ReadJSON(readJSON);

            //Console.WriteLine("Done.");
            //Console.WriteLine("Installing mods: ");
            //Console.WriteLine();

            // Install all mods from folder
            ModsManager.installMods();

            //Console.WriteLine();
            //Console.WriteLine("Done.");
            //Console.Write("Write Log files: ");

            // Log the Writer output
            Log.Write(Definitions.logFiles);

            //Console.WriteLine("Done.");

            //Console.WriteLine();
            //Console.WriteLine();

            //Console.WriteLine(Check.jsonIgnored());
        }
    }
    class ModsManager
    {
        public static void uninstallMods()
        {
            try
            {
                int n = 0;

                string bPath = "ModsManager/_backup/" + Definitions.ContentFolder + " - ";
                string cPath = Definitions.ContentFolder + "/";
                string sPath = "";

                if (Directory.GetFiles(Definitions.ModsFolder, "*.json") != null)
                {
                    foreach (string s in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                    {
                        sPath = bPath + Path.GetFileNameWithoutExtension(s) + "/";

                        if (Directory.Exists(sPath) && Directory.Exists(cPath))
                        {
                            //Console.Write("Uninstalling mod: " + Path.GetFileNameWithoutExtension(s) + " ... ");

                            foreach (string extension in Definitions.fileExtensions)
                            {
                                foreach (string uninstallFile in Directory.GetFiles(sPath, "*" + extension, SearchOption.AllDirectories))
                                {
                                    cPath = cPath + uninstallFile.Remove(0, bPath.Length + Path.GetFileNameWithoutExtension(s).Length + 1);

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
                                    using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/uninstall.txt"))
                                    {
                                        Definitions.SWriterError.WriteLine(n.ToString("0000") + @" - """ + uninstallFile);
                                    }

                                    cPath = Definitions.ContentFolder + "/";
                                }
                            }

                            //Console.WriteLine("Done!");
                        }
                        //else Console.WriteLine(@"(uninstallMods)Error: Directory """ + sPath + @""" or directory ""Content/"" doesn't exists!");

                        dupeDirectories(Path.GetDirectoryName(sPath));
                    }
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.ModsManager.uninstallMods(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e);
                }
            }
        }
        public static void installMods()
        {
            int n = 0;
            try
            {
                if (!Directory.Exists(Definitions.ModsFolder))
                    Maintenance.CreatePaths(true);

                uninstallMods();

                Check.ManageMods(Definitions.ModsFolder);

                foreach (string s in Definitions.modsList)
                {
                    ////Console.WriteLine("s => " + s);
                    ////Console.WriteLine("Definitions.modsList[" + n + "] => " + Definitions.modsList[n]);

                    string sPath = Definitions.ModsFolder + "/" + s;
                    if (Check.IsDirectoryEmpty(sPath))
                    {
                        Definitions.remove_modsList.Add(Definitions.modsList[n]);
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

                foreach (string s in Definitions.remove_modsList)
                {
                    Definitions.modsList.Remove(s);
                }

                foreach (string s in Definitions.modsList)
                {
                    Definitions.modInstalling = s;
                    //Console.Write("Installing mod: " + s + " ... ");

                    foreach (string d in Directory.GetDirectories(Definitions.ModsFolder + "/" + s + "/"))
                    {
                        foreach (string a in Definitions.fileExtensions)
                        {
                            foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
                            {
                                Definitions.modFiles.Add(f);
                                Definitions.reformed_modFiles.Add(f.Remove(0, (Definitions.ModsFolder + "/" + s).Length + 1));
                                Definitions.reformed_modFiles_backup.Add(f.Remove(0, (Definitions.ModsFolder + "/" + s).Length + 1));
                                ////Console.WriteLine(" f => " + f);
                                ////Console.WriteLine();
                            }
                        }
                    }
                    ////Console.WriteLine(" Check.IsRepeated() => " + Check.IsRepeated());

                    if (Check.IsRepeated())
                    {
                        //Console.Write("Error: unable to install mods, ");

                        if (Definitions.IsRepeated_Error)
                        {
                            //Console.WriteLine(@"check ""logs/errorlog.txt"" for possible error in ""XNAManager.Check.IsRepeated(Boolean continueAnyway)""");
                        }
                        //else Console.WriteLine("a mod may be overlaping files with other mod.");

                        Definitions.IsRepeated_Error = false;
                    }
                    else
                    {
                        // edit this to only make backup of "files to replace"
                        // not anymore: check if onetimeBackup is true, if true: start original game files backup
                        Check.fileBackup(Definitions.modInstalling);

                        // now call method to override game files with mod files
                        foreach (string d in Definitions.modFiles)
                        {
                            ////Console.WriteLine(" d => " + d);
                            ////Console.WriteLine(" Path.GetDirectoryName(d) => " + Path.GetDirectoryName(d));

                            foreach (string w in Definitions.reformed_modFiles)
                            {
                                ////Console.WriteLine(" - Path.GetDirectoryName(w) => " + Path.GetDirectoryName(w));
                                if (Path.GetDirectoryName(w).ToLower().StartsWith(Definitions.ContentFolder.ToLower()))
                                {
                                    if (d.Remove(0, (Definitions.ModsFolder + "/" + s).Length + 1) == w || d.Remove(0, (Definitions.ModsFolder + "/" + s).Length + 1) == Definitions.ContentFolder + "/" + w)
                                    {
                                        File.Copy(d, w, true);
                                        Definitions.install.Add("Installing mod: " + s + " :");
                                        Definitions.install.Add("    " + d + " => " + w);
                                    }
                                }
                                else
                                {
                                    if (d.Remove(0, (Definitions.ModsFolder + "/" + s).Length + 1) == w || d.Remove(0, (Definitions.ModsFolder + "/" + s).Length + 1) == Definitions.ContentFolder + "/" + w)
                                    {
                                        File.Copy(d, "Content/" + w, true);
                                        Definitions.install.Add("Installing mod: " + s + " :");
                                        Definitions.install.Add("    " + d + " => " + Definitions.ContentFolder + "/" + w);
                                    }
                                }

                            }
                        }
                    }
                    //Console.WriteLine("Done!");
                    Definitions.install.Add("Done installing mod: " + s + " !");
                    ////Console.WriteLine("Done installing mod: " + s + " __ ");

                    Keraplz.JSON.Write.ModDefinion(s, Definitions.modFiles);
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.ModsManager.installMods(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }
        }

        public static void uninstallMod(string input_modName)
        {
            try
            {
                int n = 0;

                string bPath = "ModsManager/_backup/" + Definitions.ContentFolder + " - ";
                string cPath = Definitions.ContentFolder + "/";
                string sPath = bPath + Path.GetFileNameWithoutExtension(input_modName) + "/";

                if (Directory.Exists(sPath) && Directory.Exists(cPath))
                {
                    using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/uninstall.txt"))
                    {
                        Definitions.SWriterError.WriteLine("Uninstalling mod: " + Path.GetFileNameWithoutExtension(input_modName) + " ... ");
                    }

                    foreach (string extension in Definitions.fileExtensions)
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
                                //Console.WriteLine(@"ERROR TO UNINSTALL MOD """ + Path.GetFileNameWithoutExtension(s) + @""" REASON: File to uninstall doesn't match with installed file name(" + pTest_05 + " => " + pTest_06 + ")");
                            }

                            n = n + 1;
                            using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/uninstall.txt"))
                            {
                                Definitions.SWriterError.WriteLine(n.ToString("0000") + @" - """ + uninstallFile);
                            }

                            cPath = Definitions.ContentFolder + "/";
                        }
                    }

                    using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/uninstall.txt"))
                    {
                        Definitions.SWriterError.WriteLine("Done!");
                    }
                }
                //else Console.WriteLine(@"(uninstallMods)Error: Directory """ + sPath + @""" or directory ""Content/"" doesn't exists!");

                dupeDirectories(Path.GetDirectoryName(Path.GetDirectoryName(sPath)));
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.ModsManager.uninstallMod(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e);
                }
            }
        }
        public static void installMod(string input_modName)
        {
            try
            {
                if (!Directory.Exists(Definitions.ModsFolder))
                    Maintenance.CreatePaths(true);


                Definitions.modInstalling = input_modName;

                foreach (string d in Directory.GetDirectories(Definitions.ModsFolder + "/" + Definitions.modInstalling + "/"))
                {
                    foreach (string a in Definitions.fileExtensions)
                    {
                        foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
                        {
                            Definitions.modFiles.Add(f);
                            Definitions.reformed_modFiles.Add(f.Remove(0, (Definitions.ModsFolder + "/" + Definitions.modInstalling).Length + 1));
                            Definitions.reformed_modFiles_backup.Add(f.Remove(0, (Definitions.ModsFolder + "/" + Definitions.modInstalling).Length + 1));
                        }
                    }
                }

                if (Check.IsRepeated())
                {
                    if (Definitions.IsRepeated_Error)
                    {
                    }

                    Definitions.IsRepeated_Error = false;
                }
                else
                {
                    // edit this to only make backup of "files to replace"
                    // not anymore: check if onetimeBackup is true, if true: start original game files backup
                    Check.fileBackup(Definitions.modInstalling);

                    // now call method to override game files with mod files
                    foreach (string d in Definitions.modFiles)
                    {
                        foreach (string w in Definitions.reformed_modFiles)
                        {
                            if (Path.GetDirectoryName(w).ToLower().StartsWith(Definitions.ContentFolder.ToLower()))
                            {
                                if (d.Remove(0, (Definitions.ModsFolder + "/" + Definitions.modInstalling).Length + 1) == w || d.Remove(0, (Definitions.ModsFolder + "/" + Definitions.modInstalling).Length + 1) == Definitions.ContentFolder + "/" + w)
                                {
                                    File.Copy(d, w, true);
                                    Definitions.install.Add("Installing mod: " + Definitions.modInstalling + " :");
                                    Definitions.install.Add("    " + d + " => " + w);
                                }
                            }
                            else
                            {
                                if (d.Remove(0, (Definitions.ModsFolder + "/" + Definitions.modInstalling).Length + 1) == w || d.Remove(0, (Definitions.ModsFolder + "/" + Definitions.modInstalling).Length + 1) == Definitions.ContentFolder + "/" + w)
                                {
                                    File.Copy(d, "Content/" + w, true);
                                    Definitions.install.Add("Installing mod: " + Definitions.modInstalling + " :");
                                    Definitions.install.Add("    " + d + " => " + Definitions.ContentFolder + "/" + w);
                                }
                            }

                        }
                    }
                }

                Definitions.install.Add("Done installing mod: " + Definitions.modInstalling + " !");
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.ModsManager.installMod(" + input_modName + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
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
                    else { Definitions.modsList.Add(ss); }
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.ModsManager.setMods(" + modsFolder + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }
        }
    }
    class Check
    {

        public static int GetCurrentBuild()
        {
            int CurrentBuild = 0;
            int Build_ = 0;

            try
            {
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt";

                Build_ = Int32.Parse(File.ReadLines(filePath).First().Split('(', ')')[1]); //File.ReadLines(filePath).First().Remove(0, 26).Remove(3, 21);


                CurrentBuild = Build_;

                return CurrentBuild;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.Check.GetCurrentBuild(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }

                return Int32.Parse(Keraplz.JSON.Read.GetCurrentBuild(Definitions.configFile));
            }
        }
        public static void fileBackup(string input_modname)
        {
            try
            {
                string sPath = Definitions.ContentFolder + "/";
                string dPath = "ModsManager/_backup/" + Definitions.ContentFolder + " - " + input_modname; //dt.DayOfYear + "-" + dt.Year + "/";

                foreach (string s in Definitions.reformed_modFiles_backup)
                {
                    sPath = Definitions.ContentFolder + "/";
                    if (s.ToLower().StartsWith(Definitions.ContentFolder.ToLower()))
                        sPath = s;
                    else sPath = sPath + s;

                    string cDir = dPath + "/" + Path.GetDirectoryName(sPath).Remove(0, 8);

                    Directory.CreateDirectory(cDir);
                    File.Copy(sPath, cDir + "/" + Path.GetFileName(s), true);
                }

                Definitions.reformed_modFiles_backup.Clear();
                Definitions.onetimeBackup = false;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.Check.fileBackup(" + input_modname + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }

                Definitions.IsRepeated_Error = true;
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
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.Check.IsRepeated(" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
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
            if (a.Contains("Audio"))
            {
                return true;
            }
            else if (a.Contains("Backgrounds"))
            {
                return true;
            }
            else if (a.Contains("CEngine"))
            {
                return true;
            }
            else if (a.Contains("Characters"))
            {
                return true;
            }
            else if (a.Contains("Comics"))
            {
                return true;
            }
            else if (a.Contains("Levels"))
            {
                return true;
            }
            else if (a.Contains("Localisation"))
            {
                return true;
            }
            else if (a.Contains("Shaders"))
            {
                return true;
            }
            else if (a.Contains("Sprites"))
            {
                return true;
            }
            else if (a.Contains("Tiles"))
            {
                return true;
            }
            else if (a.Contains("UI"))
            {
                return true;
            }
            else
            {
                ////Console.WriteLine("unknown file type detected in mod: " + s);
                ////Console.WriteLine(a);
                return false;
            }
        }
        public static void ManageMods(string modsFolder)
        {
            int n = 0;
            try
            {
                Definitions.modContains.Clear();
                ModsManager.setMods(modsFolder);

                foreach (string s in Definitions.modsList)
                {
                    string sPath = modsFolder + "/" + s;
                    //var oneCount = Directory.EnumerateFiles(sPath).Count() + 1;
                    if (s.Contains("_backup") || s.Contains("_temp")) { }
                    else if (Check.IsDirectoryEmpty(sPath))
                    {
                        Definitions.remove_modsList.Add(s);
                        
                        //Console.WriteLine("Empty mods folder removed from IList: " + s);
                        //Console.WriteLine();
                    }
                    else
                    {
                        IList<string> sDir = Directory.GetDirectories(sPath);
                        foreach (string w in sDir)
                        {
                            if (w.Contains("Content"))
                            {
                                //var twoCount = 1; //Directory.EnumerateFiles(s).Count() + 1;
                                if (Check.IsDirectoryEmpty(sPath)) { }
                                else
                                {
                                    IList<string> wDir = Directory.GetDirectories(w);
                                    foreach (string a in wDir)
                                    {
                                        if (a.Contains("Audio"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Audio");
                                        }
                                        else if (a.Contains("Backgrounds"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Backgrounds");
                                        }
                                        else if (a.Contains("CEngine"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/CEngine");
                                        }
                                        else if (a.Contains("Characters"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Characters");
                                        }
                                        else if (a.Contains("Comics"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Comics");
                                        }
                                        else if (a.Contains("Levels"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Levels");
                                        }
                                        else if (a.Contains("Localisation"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Localisation");
                                        }
                                        else if (a.Contains("Shaders"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Shaders");
                                        }
                                        else if (a.Contains("Sprites"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Sprites");
                                        }
                                        else if (a.Contains("Tiles"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/Tiles");
                                        }
                                        else if (a.Contains("UI"))
                                        {
                                            n = n + 1;
                                            Definitions.modContains.Add("Content/UI");
                                        }
                                        else
                                        {
                                            //Console.WriteLine("unknown file type detected in mod: " + s);
                                            //Console.WriteLine(a);
                                        }
                                    }
                                }
                            }
                            else if (w.Contains("Audio"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Audio");
                            }
                            else if (w.Contains("Backgrounds"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Backgrounds");
                            }
                            else if (w.Contains("CEngine"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("CEngine");
                            }
                            else if (w.Contains("Characters"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Characters");
                            }
                            else if (w.Contains("Comics"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Comics");
                            }
                            else if (w.Contains("Levels"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Levels");
                            }
                            else if (w.Contains("Localisation"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Localisation");
                            }
                            else if (w.Contains("Shaders"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Shaders");
                            }
                            else if (w.Contains("Sprites"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Sprites");
                            }
                            else if (w.Contains("Tiles"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("Tiles");
                            }
                            else if (w.Contains("UI"))
                            {
                                n = n + 1;
                                Definitions.modContains.Add("UI");
                            }
                            else
                            {
                                //Console.WriteLine("unknown file type detected in mod: " + s);
                                //Console.WriteLine(w);
                            }
                        }
                    }
                }

                foreach (string s in Definitions.remove_modsList)
                {
                    Definitions.modsList.Remove(s);
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.Check.ManageMods()");
                    Definitions.SWriterError.WriteLine(e);
                }
            }

            ////Console.WriteLine();
            ////Console.WriteLine("n => " + n.ToString("0000") + " => " + (Definitions.modContains.Count() + 1).ToString("0000"));
        }
        public static string jsonIgnored()
        {
            return "json files :: " + Keraplz.JSON.Write.n.ToString("0000") + " => " + (Directory.EnumerateFiles("ModsManager/_content/", "*.json", SearchOption.AllDirectories).Count() + 1).ToString("0000");
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
        public static void WriteModDefinitions(Boolean skip)
        {
            if (!skip) { return; }
            else
            {
                foreach (string s in Directory.GetDirectories(Definitions.ModsFolder + "/"))
                {
                    string modName = Path.GetFileName(s);
                    if (!File.Exists(Definitions.ModsFolder + "/" + modName + ".json"))
                    {
                        foreach (string d in Directory.GetDirectories(Definitions.ModsFolder + "/" + modName + "/"))
                        {
                            foreach (string a in Definitions.fileExtensions)
                            {
                                foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
                                {
                                    Definitions.modFiles.Add(f);
                                }
                            }
                        }

                        Keraplz.JSON.Write.ModDefinion(modName, Definitions.modFiles);
                    }
                }
            }
        }
        public static void ResetLogs(Boolean skip)
        {
            if (!skip) { return; }
            else
            {
                foreach (string file in Definitions.logs_fileMaintenance)
                {
                    if (File.Exists("ModsManager/_logs/" + file))
                        File.Delete("ModsManager/_logs/" + file);

                    File.Create("ModsManager/_logs/" + file).Close();
                }
            }
        }
        public static void CreatePaths(Boolean skip)
        {
            if (!skip) { return; }
            else
            {
                foreach (string path in Definitions.logs_pathMaintenance)
                {
                    if (!Directory.Exists("ModsManager/" + path))
                        Directory.CreateDirectory("ModsManager/" + path);
                }

                Directory.CreateDirectory(Definitions.ModsFolder);
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
                    Definitions.toLog_unic = Definitions.ignoredList.Distinct();
                else if (file == "xnbpath.txt")
                    Definitions.toLog_unic = Definitions.xnbPath.Distinct();

                toLog = Definitions.toLog_unic;

                foreach (string line in toLog)
                {
                    n = n + 1;

                    using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/" + file))
                    {
                        Definitions.SWriterError.WriteLine((n).ToString("0000") + " - " + line);
                    }
                }

                n = 0;
                toLog = null;
            }
        }
    }
}