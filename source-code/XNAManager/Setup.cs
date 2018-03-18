using Keraplz.JSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModsManager
{
    class InfoHolder
    {
        public static String GameName = Definitions.GameName;
        public static String ContentFolder = Definitions.ContentFolder;
        public static String ModsFolder = Definitions.ModsFolder;

        public void SetGameName(string input_GameName)
        {
            GameName = input_GameName;
        }
        public void SetContentFolder(string input_ContentFolder)
        {
            ContentFolder = input_ContentFolder;
        }
        public void SetModsFolder(string input_ModsFolder)
        {
            ModsFolder = input_ModsFolder;
        }
    }
    public class Setup
    {
        // public static void MainSetup(string content, string modsFolder, string backupFolder, string tempFolder)
        public static void MainSetup(/*String content, String modsFolder, Boolean CreatePaths, Boolean ResetLogs, String readJSON*/)
        {
            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            // ----

            //if (File.Exists("Keraplz.AutoUpdate.dll")) File.Delete("Keraplz.AutoUpdate.dll");
            //if (File.Exists("Keraplz.JSON.dll")) File.Delete("Keraplz.JSON.dll");
            //if (File.Exists("Keraplz.Resources.dll")) File.Delete("Keraplz.Resources.dll");
            //if (Directory.Exists("SRModManager")) Directory.Delete("SRModManager", true);

            //if (Directory.Exists(Definitions.ProgramName + "/_content/"))
            //{
            //    DirectoryInfo info = new DirectoryInfo(Definitions.ProgramName + "/_content/");
            //    foreach (FileInfo file in info.GetFiles())
            //        if (file.Exists)
            //            file.Delete();
            //    foreach (DirectoryInfo dir in info.GetDirectories())
            //        if (dir.Exists)
            //            dir.Delete(true);
            //}

            Maintenance_(true, true, true);
            SearchXNB_(GetFolderContent(), true);
            WriteJSON_(true);
            LogOutputs_();

            // ----

            Definitions.BannedMods = Check.GetModsToBan();

            // ----

            timeRecord.Stop();

            // ----

            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);

            Definitions.toLabel_baseinfo_SetupTime = time.ToString(@"ss\:fff");
            Definitions.toLabel_baseinfo_InstalledMods = Keraplz.JSON.Read.Mods.GetNInstalled();
            Definitions.toLabel_baseinfo_CurrentBuild = Check.GetCurrentBuild().ToString("000");

            Definitions.toLabel_baseinfo = string.Format(
                "Game: {0}, Build: {1}, SetupTime: {2}, Installed Mods: {3}",
                GetGameName(),
                Definitions.toLabel_baseinfo_CurrentBuild,
                Definitions.toLabel_baseinfo_SetupTime,
                Definitions.toLabel_baseinfo_InstalledMods.ToString("00"));
        }

        public static void InstallMod_(string input_modName)
        {
            ModsManager.installMod(input_modName);
            Keraplz.JSON.Write.ModDefinion.Edit.Installed(input_modName, true);
        }
        public static void UninstallMod_(string input_modName)
        {
            ModsManager.uninstallMod(input_modName);
            Keraplz.JSON.Write.ModDefinion.Edit.Installed(input_modName, false);
        }

        public static void Maintenance_(Boolean CreatePaths, Boolean ResetLogs, Boolean WriteModDefinitions)
        {
            Maintenance.CreatePaths(CreatePaths);
            Maintenance.ResetLogs(ResetLogs);
            Maintenance.WriteModDefinitions(WriteModDefinitions);
        }
        public static void WriteJSON_(Boolean config)
        {
            try
            {
                if (config)
                {
                    Keraplz.JSON.Write.Configuration(Definitions.configFile);
                }
                else if (!config)
                {

                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Setup.WriteJSON_(" + config.ToString() + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
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
            Log.Write(Definitions.logFiles);
        }

        //public static void NewGame() {  }
        //public static void SetGame(Game input_game)
        //{
        //    Game.SetCurrentGame(input_game);
        //    //Game.GameName = Games.Unknown.GetName();
        //    //Game.GameName = Games.SpeedRunners.GetName();
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

            Keraplz.JSON.Write.Configuration(Definitions.configFile);

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
        private static Boolean Successful = false;
        public static Boolean IsSuccessful()
        {
            if (!Successful) return false;
            else if (Successful)
            {
                Successful = false;
                return true;
            }
            return false; 
        }
        public static void uninstallMods()
        {
            try
            {
                int n = 0;

                string bPath = Definitions.ProgramName + "/_backup/" + Definitions.ContentFolder + " - ";
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
                                    using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/uninstall.txt"))
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

                Successful = true;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.ModsManager.uninstallMods(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
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

                    Keraplz.JSON.Write.ModDefinion.ModConfig(s, Definitions.modFiles);
                }

                Successful = true;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.ModsManager.installMods(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }
        }

        public static void uninstallMod(string input_modName)
        {
            try
            {
                int n = 0;

                string bPath = Definitions.ProgramName + "/_backup/" + Definitions.ContentFolder + " - ";
                string cPath = Definitions.ContentFolder + "/";
                string sPath = bPath + Path.GetFileNameWithoutExtension(input_modName) + "/";

                if (Directory.Exists(sPath) && Directory.Exists(cPath))
                {
                    using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/uninstall.txt"))
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
                                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/uninstall.txt"))
                                {
                                    Definitions.SWriterError.WriteLine(@"ERROR TO UNINSTALL MOD """ + Path.GetFileNameWithoutExtension(input_modName) + @""" REASON: File to uninstall doesn't match with installed file name(" + pTest_05 + " => " + pTest_06 + ")");
                                }
                                //Console.WriteLine(@"ERROR TO UNINSTALL MOD """ + Path.GetFileNameWithoutExtension(input_modName) + @""" REASON: File to uninstall doesn't match with installed file name(" + pTest_05 + " => " + pTest_06 + ")");
                            }

                            n = n + 1;
                            using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/uninstall.txt"))
                            {
                                Definitions.SWriterError.WriteLine(n.ToString("0000") + @" - """ + uninstallFile);
                            }

                            cPath = Definitions.ContentFolder + "/";
                        }
                    }

                    using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/uninstall.txt"))
                    {
                        Definitions.SWriterError.WriteLine("Done!");
                    }
                }
                //else Console.WriteLine(@"(uninstallMods)Error: Directory """ + sPath + @""" or directory ""Content/"" doesn't exists!");

                string toDupe = Path.GetDirectoryName(Path.GetDirectoryName(sPath));
                dupeDirectories(toDupe);

                Successful = true;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.ModsManager.uninstallMod(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
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
                Successful = true;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.ModsManager.installMod(" + input_modName + ")");
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
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.ModsManager.setMods(" + modsFolder + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
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
        public static IList<String> GetModsToBan()
        {
            IDictionary<String, Int32> modsContainsDict = new Dictionary<String, Int32>();
            IDictionary<String, Int32> dictionary = new Dictionary<String, Int32>();
            IList<Int32> TimesRepeated = new List<Int32>();
            IList<String> ContentChecked = new List<String>();

            IList<String> BannedMods = new List<String>();

            try
            {
                foreach (string nameer in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    IList<String> CurrentModContent = new List<String>();
                    string ModName = Path.GetFileNameWithoutExtension(nameer);

                    foreach (string ModContent in Read.Mods.GetContent(ModName))
                    {
                        CurrentModContent.Add(ModContent.Remove(0, Definitions.ModsFolder.Length + 1 + ModName.Length + 1));
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

                foreach (string nameer in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    int n = 0;
                    IList<String> CurrentModContent = new List<String>();
                    string ModName = Path.GetFileNameWithoutExtension(nameer);

                    foreach (string ModContent in Read.Mods.GetContent(ModName))
                    {
                        CurrentModContent.Add(ModContent.Remove(0, Definitions.ModsFolder.Length + 1 + ModName.Length + 1));
                    }

                    foreach (string content_ in CurrentModContent)
                    {
                        string content_base = content_.ToLower();

                        foreach (KeyValuePair<String, Int32> contentDict in Keraplz.JSON.Read.Mods.GetContainsDict(content_base))
                        {
                            //modsContainsDict.Add(ModName, contentDict[ModName]);
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
                                    //foreach (string mod in modsContains)
                                    //{
                                    //    if (n_ == n - 1) { goto BREAK; }
                                    //    else {
                                    //        if (BannedMods.Contains(mod)) { }
                                    //        else BannedMods.Add(mod);
                                    //
                                    //        n_ = n_ + 1;
                                    //    }
                                    //}

                                    BREAK:;
                                }
                        }
                    }

                    CurrentModContent.Clear();
                    modsContainsDict.Clear();
                }
                //AllMods = AllMods.Distinct().ToArray();
                //var BannedContent = AllContent.GroupBy(e => e).Where(e => e.Count() >= 2).Select(e => e.First());

                BannedMods = BannedMods.Distinct().ToList();

                if (BannedMods.Count > 0)
                    return BannedMods;
                else return null;
            }
            catch (Exception e)
            {
                if (!Directory.Exists(Definitions.ProgramName + "/_logs/")) Directory.CreateDirectory(Definitions.ProgramName + "/_logs/");
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Check.GetModsToBan(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }

                return null;
            }
        }

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
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Check.GetCurrentBuild(" + "" + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }

                return Keraplz.JSON.Read.GetCurrentBuild(Definitions.configFile);
            }
        }
        public static void fileBackup(string input_modname)
        {
            try
            {
                string sPath = Definitions.ContentFolder + "/";
                string dPath = Definitions.ProgramName + "/_backup/" + Definitions.ContentFolder + " - " + input_modname;

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
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Check.fileBackup(" + input_modname + ")");
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
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Check.IsRepeated(" + ")");
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
            foreach (String Type in Directory.GetDirectories(Definitions.ProgramName + "/_content/", "*"))
            {
                if (a.ToLower().Contains(Type.ToLower())) return true;
                else return false;
            }
            return false;
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
                            if (w.Contains(Definitions.ContentFolder))
                            {
                                //var twoCount = 1; //Directory.EnumerateFiles(s).Count() + 1;
                                if (Check.IsDirectoryEmpty(sPath)) { }
                                else
                                {
                                    IList<string> wDir = Directory.GetDirectories(w);
                                    foreach (string a in wDir)
                                    {
                                        foreach (String Type in Directory.GetDirectories(Definitions.ProgramName + "/_content/", "*"))
                                        {
                                            if (a.ToLower().Contains(Type.ToLower()))
                                            {
                                                n = n + 1;
                                                Definitions.modContains.Add(Definitions.ContentFolder + "/" + Type);
                                            }
                                        }
                                    }
                                }
                            }

                            foreach (String Type in Directory.GetDirectories(Definitions.ProgramName + "/_content/", "*"))
                            {
                                if (w.ToLower().Contains(Type.ToLower()))
                                {
                                    n = n + 1;
                                    Definitions.modContains.Add(Type);
                                }
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
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Check.ManageMods(" + modsFolder  + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }

            ////Console.WriteLine();
            ////Console.WriteLine("n => " + n.ToString("0000") + " => " + (Definitions.modContains.Count() + 1).ToString("0000"));
        }
        public static string jsonIgnored()
        {
            return "json files :: " + Keraplz.JSON.Write.n.ToString("0000") + " => " + (Directory.EnumerateFiles(Definitions.ProgramName + "/_content/", "*.json", SearchOption.AllDirectories).Count()).ToString("0000");
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
            IList<String> ModFiles = new List<String>();

            try
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
                                        ModFiles.Add(f);
                                    }
                                }
                            }

                            Keraplz.JSON.Write.ModDefinion.ModConfig(modName, ModFiles);
                        }

                        ModFiles.Clear();
                    }
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Maintenance.WriteModDefinitions(" + skip.ToString() + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
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
                    if (File.Exists(Definitions.ProgramName + "/_logs/" + file))
                        File.Delete(Definitions.ProgramName + "/_logs/" + file);

                    File.Create(Definitions.ProgramName + "/_logs/" + file).Close();
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
                    if (!Directory.Exists(Definitions.ProgramName + "/" + path))
                        Directory.CreateDirectory(Definitions.ProgramName + "/" + path);
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
                    Definitions.toLog_unic = Definitions.ignoredList;
                else if (file == "xnbpath.txt")
                    Definitions.toLog_unic = Definitions.xnbPath.Distinct();

                toLog = Definitions.toLog_unic;

                foreach (string line in toLog)
                {
                    n = n + 1;

                    using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/" + file))
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