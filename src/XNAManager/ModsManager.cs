using Keraplz.JSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    class ModsManager
    {
        //public static async void UninstallMods()
        //{
        //    try
        //    {
        //        foreach (Mod modInfo in Profiles.Default.GetMods())
        //            await Uninstall(modInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        LogFile.WriteError(e);
        //    }
        //}
        //public static async void InstallMods()
        //{
        //    try
        //    {
        //        foreach (Mod modInfo in Profiles.Default.GetMods())
        //            await Install(modInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        LogFile.WriteError(e);
        //    }
        //}
        //public static async void UninstallMods(IList<Mod> modList)
        //{
        //    try
        //    {
        //        foreach (Mod modInfo in modList)
        //            await Uninstall(modInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        LogFile.WriteError(e);
        //    }
        //}
        //public static async void InstallMods(IList<Mod> modList)
        //{
        //    try
        //    {
        //        foreach (Mod modInfo in modList)
        //            await Install(modInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        LogFile.WriteError(e);
        //    }
        //}
        //public static void uninstallMod(Mod modInfo)
        //{
        //    try
        //    {
        //        if (!modInfo.isInstalled()) { return; }
        //
        //        string bPath = Profiles.Default.GetProgramName() + "/_backup/" + Profiles.Default.GetGame().GetFolderContent() + " - ";
        //        string cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
        //        string sPath = bPath + modInfo.GetName() + "/";
        //
        //        if (Directory.Exists(sPath) && Directory.Exists(cPath))
        //        {/*
        //            using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
        //                sw.Write("Uninstalling mod: " + modInfo.GetName() + " . . .  ");*/
        //            LogFile.Write("Uninstalling mod: " + modInfo.GetName() + " . . .  ");
        //            var timeRecord = System.Diagnostics.Stopwatch.StartNew();
        //
        //            foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
        //            {
        //                foreach (string uninstallFile in Directory.GetFiles(sPath, "*" + extension, SearchOption.AllDirectories))
        //                {
        //                    cPath = cPath + uninstallFile.Remove(0, bPath.Length + modInfo.GetName().Length + 1);
        //
        //                    string pTest_01 = Path.GetFileName(Path.GetDirectoryName(uninstallFile));
        //                    string pTest_02 = Path.GetFileName(uninstallFile);
        //                    string pTest_03 = Path.GetFileName(Path.GetDirectoryName(cPath));
        //                    string pTest_04 = Path.GetFileName(cPath);
        //                    string pTest_05 = pTest_01 + "/" + pTest_02;
        //                    string pTest_06 = pTest_03 + "/" + pTest_04;
        //
        //                    if (pTest_05 == pTest_06)
        //                    {
        //                        File.Copy(uninstallFile, cPath, true);
        //                        File.Delete(uninstallFile);
        //                    }
        //
        //                    cPath = Profiles.Default.GetGame().GetFolderContent() + "/";
        //                }
        //            }
        //
        //            Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, false);
        //
        //            timeRecord.Stop();
        //            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
        //            LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"));/*
        //            using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/uninstall.txt"))
        //                sw.WriteLine("Done " + time.ToString(@"ss\:fff"));*/
        //        }
        //
        //        string toDupe = Path.GetDirectoryName(Path.GetDirectoryName(sPath));
        //        dupeDirectories(toDupe);
        //    }
        //    catch (Exception e)
        //    {
        //        LogFile.WriteError(e); // ModsManager.ModsManager.uninstallMod(Mod " + modInfo.GetName() + ")");
        //        //LogFile.WriteLine(e.Message);
        //    }
        //}
        //public static void installMod(Mod modInfo)
        //{
        //    IList<String> modFiles = new List<String>();
        //    IList<String> Pass_modFiles = new List<String>();
        //
        //    try
        //    {
        //        if (modInfo.isInstalled()) { return; }
        //
        //        if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
        //            Maintenance.CreatePaths(Profiles.Default.GetMaintenancePaths(), true);
        //
        //        foreach (string d in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\"))
        //        {
        //            foreach (string a in Profiles.Default.GetGame().GetExtensions().ToArray())
        //            {
        //                foreach (string f in Directory.GetFiles(d, "*" + a, SearchOption.AllDirectories))
        //                {
        //                    modFiles.Add(f);
        //                    Pass_modFiles.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length));
        //                    //Definitions.reformed_modFiles_backup.Add(f.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length));
        //                }
        //            }
        //        }
        //
        //        if (!IsRepeated(Pass_modFiles))
        //        {/*
        //            using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
        //                sw.Write("Installing mod: " + modInfo.GetName() + " . . .  ");*/    
        //            LogFile.Write("Installing mod: " + modInfo.GetName() + " . . .  ");
        //            var timeRecord = System.Diagnostics.Stopwatch.StartNew();
        //
        //            // start original game files backup
        //            FileBackup(modInfo.GetName(), Pass_modFiles);
        //
        //            // now call method to override game files with mod files
        //            foreach (string modPath in modFiles)
        //            {
        //                foreach (string modFile in Pass_modFiles)
        //                {
        //                    if (Path.GetDirectoryName(modFile).ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
        //                    {
        //                        if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == Profiles.Default.GetGame().GetFolderContent() + "\\" + modFile)
        //                        {
        //                            File.Copy(modPath, modFile, true);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == modFile || modPath.Remove(0, (Profiles.Default.GetGame().GetFolderMods() + "\\" + modInfo.GetName() + "\\").Length) == Profiles.Default.GetGame().GetFolderContent() + "\\" + modFile)
        //                        {
        //                            File.Copy(modPath, Profiles.Default.GetGame().GetFolderContent() + "\\" + modFile, true);
        //                        }
        //                    }
        //                }
        //            }
        //
        //            Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, true);
        //
        //            timeRecord.Stop();
        //            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
        //            LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"));/*
        //            using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/install.txt"))
        //                sw.WriteLine("Done " + time.ToString(@"ss\:fff"));*/
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        LogFile.WriteError(e); // ModsManager.ModsManager.installMod(Mod " + modInfo.GetName() + ")");
        //        //LogFile.WriteLine(e.Message);
        //    }
        //}

        public static async Task<Boolean> UninstallAsync(Mod modInfo)
        {
            string originalPath = string.Empty;
            string srcPath = string.Empty;
            bool IsSuccess = false;
            int n = 0;

            try
            {
                if (!modInfo.isInstalled()) { return false; }

                LogFile.Write("Uninstalling mod: " + modInfo.GetName() + " . . .  ");
                var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                // Install Mod Content files one-by-one
                await Task.Run(() =>
                {
                    foreach (string modFile in modInfo.GetContent())
                    {
                        originalPath = /*GetOriginalPath();*/ modFile.Remove(0, Profiles.Default.GetGame().GetFolderMods().Length + "\\".Length + modInfo.GetName().Length + "\\".Length);
                        srcPath = originalPath.Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length);

                        srcPath = Path.Combine(Profiles.Default.GetProgramName(), "_backup", Profiles.Default.GetGame().GetFolderContent() + " - " + modInfo.GetName(), srcPath);
                        try
                        {
                            if (!File.Exists(srcPath)) IsSuccess = false;
                            else if (!File.Exists(originalPath)) IsSuccess = false;
                            else
                            {
                                File.Copy(srcPath, originalPath, true);
                                n = n + 1;
                            }
                        }
                        catch
                        {
                            IsSuccess = false;
                        }
                    }
                });

                // Check if method was successful, if not, return false
                int i = modInfo.GetContent().Count();
                if (i == n)
                    IsSuccess = true;
                else
                {
                    timeRecord.Stop();
                    TimeSpan timeFail = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteLine("Fail " + timeFail.ToString(@"ss\:fff"));

                    return false;
                }

                // Edit Mod .json file isInstalled property
                await Task.Run(() =>
                {
                    Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, false);
                });

                timeRecord.Stop();
                TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"));

                return IsSuccess;
            }
            catch (Exception e)
            {
                LogFile.WriteError(e);
                return false;
            }
        }
        public static async Task<Boolean> InstallAsync(Mod modInfo)
        {
            string originalPath = string.Empty;
            string srcPath = string.Empty;
            bool IsSuccess = false;
            int n = 0;

            try
            {
                if (modInfo.isInstalled()) { return false; }

                LogFile.Write("Installing mod: " + modInfo.GetName() + " . . .  ");
                var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                // Backup original files
                await Task.Run(() => FileBackupAsync(modInfo));

                // Install Mod Content files one-by-one
                await Task.Run(() =>
                {
                    foreach (string modFile in modInfo.GetContent())
                    {
                        srcPath = modFile;
                        originalPath = modFile.Remove(0, Profiles.Default.GetGame().GetFolderMods().Length + "\\".Length + modInfo.GetName().Length + "\\".Length);

                        File.Copy(srcPath, originalPath, true);
                        n = n + 1;
                    }
                });

                // Check if method was successful, if not, return false
                if (modInfo.GetContent().Count() == n)
                    IsSuccess = true;
                else
                {
                    timeRecord.Stop();
                    TimeSpan timeFail = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteLine("Fail " + timeFail.ToString(@"ss\:fff"));

                    return false;
                }

                // Edit Mod .json file isInstalled property
                await Task.Run(() =>
                {
                    Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, true);
                });

                timeRecord.Stop();
                TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"));

                return IsSuccess;
            }
            catch (Exception e)
            {
                LogFile.WriteError(e);
                return false;
            }
        }
        public static Boolean Uninstall(Mod modInfo)
        {
            string originalPath = string.Empty;
            string srcPath = string.Empty;
            bool IsSuccess = false;
            int n = 0;

            try
            {
                if (!modInfo.isInstalled()) { return false; }

                LogFile.Write("Uninstalling mod: " + modInfo.GetName() + " . . .  ");
                var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                // Install Mod Content files one-by-one
                foreach (string modFile in modInfo.GetContent())
                {
                    originalPath = /*GetOriginalPath();*/ modFile.Remove(0, Profiles.Default.GetGame().GetFolderMods().Length + "\\".Length + modInfo.GetName().Length + "\\".Length);
                    srcPath = originalPath.Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length);

                    srcPath = Path.Combine(Profiles.Default.GetProgramName(), "_backup", Profiles.Default.GetGame().GetFolderContent() + " - " + modInfo.GetName(), srcPath);
                    try
                    {
                        if (!File.Exists(srcPath)) IsSuccess = false;
                        else if (!File.Exists(originalPath)) IsSuccess = false;
                        else
                        {
                            File.Copy(srcPath, originalPath, true);
                            n = n + 1;
                        }
                    }
                    catch
                    {
                        IsSuccess = false;
                    }
                }

                // Check if method was successful, if not, return false
                int i = modInfo.GetContent().Count();
                if (i == n)
                    IsSuccess = true;
                else
                {
                    timeRecord.Stop();
                    TimeSpan timeFail = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteLine("Fail " + timeFail.ToString(@"ss\:fff"));

                    return false;
                }

                // Edit Mod .json file isInstalled property
                Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, false);

                timeRecord.Stop();
                TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"));

                return IsSuccess;
            }
            catch (Exception e)
            {
                LogFile.WriteError(e);
                return false;
            }
        }
        public static Boolean Install(Mod modInfo)
        {
            string originalPath = string.Empty;
            string srcPath = string.Empty;
            bool IsSuccess = false;
            int n = 0;

            try
            {
                if (modInfo.isInstalled()) { return false; }

                LogFile.Write("Installing mod: " + modInfo.GetName() + " . . .  ");
                var timeRecord = System.Diagnostics.Stopwatch.StartNew();

                // Backup original files
                FileBackup(modInfo);

                // Install Mod Content files one-by-one
                foreach (string modFile in modInfo.GetContent())
                {
                    srcPath = modFile;
                    originalPath = modFile.Remove(0, Profiles.Default.GetGame().GetFolderMods().Length + "\\".Length + modInfo.GetName().Length + "\\".Length);

                    File.Copy(srcPath, originalPath, true);
                    n = n + 1;
                }

                // Check if method was successful, if not, return false
                if (modInfo.GetContent().Count() == n)
                    IsSuccess = true;
                else
                {
                    timeRecord.Stop();
                    TimeSpan timeFail = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                    LogFile.WriteLine("Fail " + timeFail.ToString(@"ss\:fff"));

                    return false;
                }

                // Edit Mod .json file isInstalled property
                Keraplz.JSON.Write.ModDefinion.Edit.Installed(modInfo, true);

                timeRecord.Stop();
                TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);
                LogFile.WriteLine("Done " + time.ToString(@"ss\:fff"));

                return IsSuccess;
            }
            catch (Exception e)
            {
                LogFile.WriteError(e);
                return false;
            }
        }

        public static IList<IList<Mod>> GetBannedMods(Game game_info, IList<Mod> modList)
        {
            IList<IList<Mod>> BannedMods = new List<IList<Mod>>();

            foreach (Mod modInfo in modList)
            {
                foreach (string ModContent in modInfo.GetContent())
                    BannedMods.Add(new List<Mod>(Read.Mods.GetContainsMod(ModContent.Remove(0, Path.Combine(game_info.GetFolderMods(), modInfo.GetName()).Length + "\\".Length), game_info.GetFolderMods())));
            }

            if (BannedMods.Count > 0) return BannedMods;
            else return null;
        }
        public static IList<IList<Mod>> GetBannedMods(Game game_info)
        {
            IList<IList<Mod>> BannedMods = new List<IList<Mod>>();

            foreach (string modPath in Directory.GetFiles(game_info.GetFolderMods(), "*.json"))
            {
                string modName = Path.GetFileNameWithoutExtension(modPath);

                foreach (string ModContent in Read.Mods.GetContent(modName, game_info.GetFolderMods()))
                    BannedMods.Add(new List<Mod>(Read.Mods.GetContainsMod(ModContent.Remove(0, game_info.GetFolderMods().Length + 2 + modName.Length + 2), game_info.GetFolderMods())));
            }

            if (BannedMods.Count > 0) return BannedMods;
            else return null;
        }

        private static string GetOriginalPath(string path, string input_extension = null)
        {
            string extension = string.Empty;

            if (input_extension == null)
                extension = Path.GetExtension(path);
            else extension = input_extension;

            foreach (string filePath in Directory.GetFiles(Profiles.Default.GetGame().GetFolderContent(), "*" + extension, SearchOption.AllDirectories))
                if (filePath.ToLower() == path.ToLower()) return filePath;
            return string.Empty;
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
                // Get stack trace for the exception with source file information
                var trace = new StackTrace(e, true);
                // Get the top stack frame
                var frame = trace.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                LogFile.WriteError(e); // ModsManager.IsRepeated(IList<String> " + "), line " + line);
                //LogFile.WriteLine(e.Message);

                return true;
            }
        }
        private static void FileBackup(Mod modInfo)
        {
            try
            {
                string sPath = Profiles.Default.GetGame().GetFolderContent() + "\\";
                string dPath = Path.Combine(Profiles.Default.GetProgramName(), "_backup", Profiles.Default.GetGame().GetFolderContent() + " - " + modInfo.GetName());

                foreach (string modFile_ in modInfo.GetContent())
                {
                    string modFile = modFile_.Remove(0, Path.Combine(Profiles.Default.GetGame().GetFolderMods(), modInfo.GetName()).Length + "\\".Length);
                    sPath = Profiles.Default.GetGame().GetFolderContent() + "\\";

                    if (modFile.ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                        sPath = modFile;
                    else sPath = sPath + modFile;

                    string cDir = dPath + "\\" + Path.GetDirectoryName(sPath).Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length);

                    Directory.CreateDirectory(cDir);
                    File.Copy(sPath, Path.Combine(cDir, Path.GetFileName(modFile)), true);
                }
            }
            catch (Exception e)
            {
                LogFile.WriteError(e);
            }
        }
        private static async Task FileBackupAsync(Mod modInfo)
        {
            try
            {
                string sPath = Profiles.Default.GetGame().GetFolderContent() + "\\";
                string dPath = Path.Combine(Profiles.Default.GetProgramName(),"_backup", Profiles.Default.GetGame().GetFolderContent() + " - " + modInfo.GetName());

                await Task.Run(() =>
                {
                    foreach (string modFile_ in modInfo.GetContent())
                    {
                        string modFile = modFile_.Remove(0, Path.Combine(Profiles.Default.GetGame().GetFolderMods(), modInfo.GetName()).Length + "\\".Length);
                        sPath = Profiles.Default.GetGame().GetFolderContent() + "\\";

                        if (modFile.ToLower().StartsWith(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                            sPath = modFile;
                        else sPath = sPath + modFile;

                        string cDir = dPath + "\\" + Path.GetDirectoryName(sPath).Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length);

                        Directory.CreateDirectory(cDir);
                        File.Copy(sPath, Path.Combine(cDir, Path.GetFileName(modFile)), true);
                    }
                });
            }
            catch (Exception e)
            {
                LogFile.WriteError(e);
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
                LogFile.WriteError(e);
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


        internal static void NormalizeLoad(Mod mod)
        {
            throw new NotImplementedException();
        }

        internal static void PreventLoad(Mod mod)
        {
            throw new NotImplementedException();
        }

        internal static void Ban(Mod mod)
        {
            throw new NotImplementedException();
        }

        internal static void Unban(Mod mod)
        {
            throw new NotImplementedException();
        }

        internal static void Load(Mod mod)
        {
            throw new NotImplementedException();
        }

        internal static void Unload(Mod mod)
        {
            throw new NotImplementedException();
        }
    }

    public class ModStatus
    {
        // Members

        private Boolean m_ShouldLoad;
        //private Boolean m_IsLoaded;

        // Constructor

        public ModStatus(Boolean ShouldLoad = true)
        {
            m_ShouldLoad = ShouldLoad;
            //m_IsLoaded = IsLoaded;
        }

        // Getters

        public Boolean GetShouldLoad() { return m_ShouldLoad; }
        //public Boolean IsLoaded() { return m_IsLoaded; }
    }
}