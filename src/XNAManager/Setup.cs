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
            Maintenance_(Profiles.Default.GetProgramName(), Profiles.Default.GetGame(), Profiles.Default.GetMaintenancePaths(), Profiles.Default.GetMaintenanceFiles());
            Search.SearchXNB(Profiles.Default.GetGame().GetFolderContent(), true);
            WriteJSON_(true);
        }

        public static IList<Mod> Maintenance_(String ProgramName, Game Game, String[] PathArray, String[] FileArray)
        {
            Maintenance.CreatePaths(ProgramName, Game, PathArray);
            Maintenance.ResetLogs(ProgramName, FileArray);
            return Maintenance.WriteModDefinitions(Game);
        }
        public static void Maintenance_(String ProgramName, Game Game, String[] PathArray, String[] FileArray, Boolean shouldWMD = false, Boolean shouldRL = false)
        {
            Maintenance.CreatePaths(ProgramName, Game, PathArray);
            if (shouldRL) Maintenance.ResetLogs(ProgramName, FileArray);
            if (shouldWMD) Maintenance.WriteModDefinitions(Game);
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
                    LogFile.WriteError(e); // ModsManager.Setup.WriteJSON_(" + config.ToString() + ")");
                    //LogFile.WriteLine(e.Message);
                }
            }
        }
        public static void ReadJSON_(String path)
        {
            Keraplz.JSON.Read.ReadJSON(path);
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
                LogFile.WriteError(e); // ModsManager.Check.GetCurrentVersion(" + "" + ")");
                //LogFile.WriteLine(e.Message);

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
                LogFile.WriteError(e); // ModsManager.Check.GetCurrentBuild(" + "" + ")");
                //LogFile.WriteLine(e.Message);

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
        
        public static Boolean IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        public static string jsonIgnored()
        {
            return "json files :: " + Keraplz.JSON.Write.n.ToString("0000") + " => " + (Directory.EnumerateFiles(Profiles.Default.GetProgramName() + "/_content/", "*.json", SearchOption.AllDirectories).Count()).ToString("0000");
        }

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
                LogFile.WriteError(e); // ModsManager.Maintenance.WriteModDefinitions(Game " + Game.GetName() + ")");
                //LogFile.WriteLine(e.Message);
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
                LogFile.WriteError(e); // ModsManager.Maintenance.WriteModDefinitions(Profile, Boolean " + skip.ToString() + ")");
                //LogFile.WriteLine(e.Message);
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
                LogFile.WriteError(e); // ModsManager.Maintenance.WriteModDefinitions(Boolean " + skip.ToString() + ")");
                //LogFile.WriteLine(e.Message);
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
}