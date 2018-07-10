using ModsManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Keraplz.JSON
{
    public class Read
    {
        public static int n = 0;
        private static Profile Profile = Profiles.Blank;

        public static void ReadJSON(string input_filepath)
        {
            try
            {
                string json = File.ReadAllText(input_filepath);

                Base.SpeedRunners SR_Files = JsonConvert.DeserializeObject<Base.SpeedRunners>(json);

                using (StreamWriter sw = File.AppendText(Profile.GetProgramName() + "/_logs/reader_test.txt"))
                {
                    sw.WriteLine("filename = " + Path.GetFileNameWithoutExtension(input_filepath));
                    sw.WriteLine("filepath = " + SR_Files.Filepath);
                    sw.WriteLine("type = " + SR_Files.Type);

                    foreach (string f in SR_Files.Files)
                    {
                        sw.WriteLine("files = " + f);
                    }
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText(Profile.GetProgramName() + "/_logs/errorlog.txt"))
                {
                    sw.WriteLine("Error found in Keraplz.JSON.Read.ReadJSON(" + input_filepath + ")");
                    sw.WriteLine(e.Message);
                }
            }
        }

        public class Content
        {
            public static Int32 GetNFiles()
            {
                int n = 0;

                foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
                    foreach (string fileName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderContent(), "*" + extension, SearchOption.AllDirectories))
                        n = n + 1;

                 return n;
            }
            public static IList<String> GetTypes()
            {
                IList<String> Types = new List<String>();

                foreach (string type in Directory.EnumerateDirectories(Profiles.Default.GetGame().GetFolderContent()))
                    Types.Add(Path.GetFileName(type));

                return Types;
            }
            public static IList<String> GetTypes(string contentDir)
            {
                IList<String> Types = new List<String>();
                if (contentDir == null) contentDir = Profiles.Default.GetGame().GetFolderContent();

                foreach (string type in Directory.EnumerateDirectories(contentDir))
                    Types.Add(Path.GetFileName(type));

                return Types;
            }
        }
        
        /*
        public class Configuration
        {
            public static String GetProgramName()
            {
                if (File.Exists(Profile.GetProgramName() + "/Configuration.json"))
                {
                    Base.Configuration config_info_ = JsonConvert.DeserializeObject<Base.Configuration>(File.ReadAllText(Profile.GetProgramName() + "/Configuration.json"));
        
                    if (config_info_.ProgramName != null) return config_info_.ProgramName;
                    else return Profiles.Blank.GetProgramName();
                }
                else return Profiles.Blank.GetProgramName();
            }
            public static Game GetGame()
            {
                if (File.Exists(Profile.GetProgramName() + "/Configuration.json"))
                {
                    Base.Configuration config_info_ = JsonConvert.DeserializeObject<Base.Configuration>(File.ReadAllText(Profile.GetProgramName() + "/Configuration.json"));
        
                    if (config_info_.Game != null) return config_info_.Game;
                    else return Profiles.Blank.GetGame();
                }
                else return Profiles.Blank.GetGame();
            }
        }
        */

        public class Mods
        {
            public static Boolean Exists(String input_modname, String modsFolder)
            {
                if (File.Exists(modsFolder + "/" + input_modname + ".json"))
                {
                    return true;
                }
                else return false;
            }
            public static Boolean Exists(String input_modname)
            {
                if (File.Exists(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modname + ".json"))
                {
                    return true;
                }
                else return false;
            }
            public static Boolean Contains(String input_filepath, String modsFolder)
            {
                foreach (string nameer in Directory.GetFiles(modsFolder, "*.json"))
                {
                    string ModName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + ModName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            public static Boolean Contains(String input_filepath)
            {
                foreach (string nameer in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    string ModName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + ModName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            public static IDictionary<String, Int32> GetContainsDict(String input_filepath, String modsFolder)
            {
                IDictionary<String, Int32> Mods = new Dictionary<String, Int32>();

                foreach (string nameer in Directory.GetFiles(modsFolder, "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + modName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            Mods.Add(modName, GetNContent(modName, modsFolder));
                        }
                    }
                }

                return Mods;
            }
            public static IDictionary<String, Int32> GetContainsDict(String input_filepath)
            {
                IDictionary<String, Int32> Mods = new Dictionary<String, Int32>();

                foreach (string nameer in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + modName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            Mods.Add(modName, GetNContent(modName));
                        }
                    }
                }

                return Mods;
            }
            public static IEnumerable<Mod> GetContainsMod(String input_filepath, String modsFolder)
            {
                IList<Mod> Mods = new List<Mod>();

                foreach (string nameer in Directory.GetFiles(modsFolder, "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + modName + ".json"));

                    foreach (string filename in mods_info_.Content)
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                            Mods.Add(GetModByName(modName, modsFolder));
                }

                return Mods.Distinct().ToList();
            }
            public static IList<String> GetContains(String input_filepath, String modsFolder)
            {
                IList<String> Mods = new List<String>();

                foreach (string nameer in Directory.GetFiles(modsFolder, "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + modName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            Mods.Add(modName);
                        }
                    }
                }

                Mods = Mods.Distinct().ToList();

                return Mods;
            }
            public static IList<String> GetContains(String input_filepath)
            {
                IList<String> Mods = new List<String>();

                foreach (string nameer in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + modName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            Mods.Add(modName);
                        }
                    }
                }

                Mods = Mods.Distinct().ToList();

                return Mods;
            }
            public static IList<Mod> GetInstalled(String modsFolder)
            {
                IList<Mod> Mods = new List<Mod>();

                try
                {
                    foreach (string nameer in Directory.GetFiles(modsFolder, "*.json"))
                    {
                        string modName = Path.GetFileNameWithoutExtension(nameer);
                        Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + modName + ".json"));

                        if (mods_info_.isInstalled)
                            Mods.Add(GetModByName(modName, modsFolder));
                    }
                }
                catch { }

                return Mods.Distinct().ToList();
            }
            public static IList<Mod> GetInstalled()
            {
                IList<Mod> Mods = new List<Mod>();

                foreach (string nameer in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + modName + ".json"));

                    if (mods_info_.isInstalled)
                        Mods.Add(new Mod(modName, mods_info_.isInstalled, mods_info_.Type, mods_info_.Content));
                }

                return Mods.Distinct().ToList();
            }
            public static Mod GetModByName(String input_modname, String modsFolder)
            {
                foreach (string modPath in Directory.GetFiles(modsFolder, "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(modPath);
                    if (input_modname == modName)
                    {
                        Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + modName + ".json"));
                        return new Mod(modName, mods_info_.isInstalled, mods_info_.Type, mods_info_.Content);
                        //Mod modJson = new Mod(modName, mods_info_.isInstalled, mods_info_.Type, mods_info_.Content);
                        //foreach (Mod modInfo in modList)
                        //{
                        //    if (modInfo.GetName() == modJson.GetName())
                        //        return modInfo;
                        //}
                    }
                }
                return null;
            }
            public static Mod GetModByName(String input_modname, String modsFolder, IList<Mod> modList)
            {
                foreach (string modPath in Directory.GetFiles(modsFolder, "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(modPath);
                    if (input_modname == modName)
                    {
                        Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + modName + ".json"));
                        Mod modJson = new Mod(modName, mods_info_.isInstalled, mods_info_.Type, mods_info_.Content);
                        foreach (Mod modInfo in modList)
                        {
                            if (modInfo.GetName() == modJson.GetName())
                                return modInfo;
                        }
                    }
                }
                return null;
            }
            public static Mod GetModByName(String input_modname)
            {
                foreach (string modPath in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    string modName = Path.GetFileNameWithoutExtension(modPath);
                    if (input_modname == modName)
                    {
                        Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + modName + ".json"));
                        Mod modJson = new Mod(modName, mods_info_.isInstalled, mods_info_.Type, mods_info_.Content);
                        foreach (Mod modInfo in Profiles.Default.GetMods())
                        {
                            if (modInfo.GetName() == modJson.GetName())
                                return modInfo;
                        }
                    }
                }
                return null;
            }
            public static Boolean PreventLoad(String input_modname, String modsFolder)
            {
                try {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + input_modname + ".json")/*, new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Error
                    }*/);

                    return mods_info_.preventLoad;
                } catch (JsonSerializationException) { return false; }
            }
            public static Boolean PreventLoad(String input_modname)
            {
                try
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modname + ".json")/*, new JsonSerializerSettings
                    {
                        MissingMemberHandling = MissingMemberHandling.Error
                    }*/);

                    return mods_info_.preventLoad;
                }
                catch (JsonSerializationException) { return false; }
            }
            public static Boolean IsInstalled(String input_modname, String modsFolder)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + input_modname + ".json"));

                return mods_info_.isInstalled;
            }
            public static Boolean IsInstalled(String input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modname + ".json"));

                return mods_info_.isInstalled;
            }
            public static IList<String> GetType(String input_modname, String modsFolder)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + input_modname + ".json"));

                return mods_info_.Type;
            }
            public static IList<String> GetType(String input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modname + ".json"));

                return mods_info_.Type;
            }
            public static IList<String> GetContent(String input_modname, String modsFolder)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + input_modname + ".json"));

                return mods_info_.Content;
            }
            public static IList<String> GetContent(String input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modname + ".json"));

                return mods_info_.Content;
            }
            public static Int32 GetNInstalled(String modsFolder)
            {
                int n = 0;

                foreach (string modName in Directory.GetFiles(modsFolder, "*.json"))
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                    if (mods_info_.isInstalled)
                    {
                        n = n + 1;
                    }
                }

                return n;
            }
            public static Int32 GetNInstalled()
            {
                int n = 0;

                foreach (string modName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                    if (mods_info_.isInstalled)
                    {
                        n = n + 1;
                    }
                }

                return n;
            }
            public static Int32 GetNFilesInstalled(String modsFolder)
            {
                int n = 0;

                foreach (string modName in Directory.GetFiles(modsFolder, "*.json"))
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                    if (mods_info_.isInstalled)
                    {
                        int i = 0;
                        foreach (string file in mods_info_.Content)
                            i = i + 1;
                        n = n + i;
                    }
                }

                return n;
            }
            public static Int32 GetNFilesInstalled()
            {
                int n = 0;

                foreach (string modName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                    if (mods_info_.isInstalled)
                    {
                        int i = 0;
                        foreach (string file in mods_info_.Content)
                            i = i + 1;
                        n = n + i;
                    }
                }

                return n;
            }
            public static Int32 GetNType(String input_modname, String modsFolder)
            {
                int n = 0;
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + input_modname + ".json"));

                foreach (string file in mods_info_.Type)
                {
                    n = n + 1;
                }

                return n;
            }
            public static Int32 GetNType(String input_modname)
            {
                int n = 0;
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modname + ".json"));

                foreach (string file in mods_info_.Type)
                {
                    n = n + 1;
                }

                return n;
            }
            public static Int32 GetNContent(String input_modname, String modsFolder)
            {
                int n = 0;
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(modsFolder + "/" + input_modname + ".json"));

                foreach (string file in mods_info_.Content)
                {
                    n = n + 1;
                }

                return n;
            }
            public static Int32 GetNContent(String input_modname)
            {
                int n = 0;
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Profiles.Default.GetGame().GetFolderMods() + "/" + input_modname + ".json"));

                foreach (string file in mods_info_.Content)
                {
                    n = n + 1;
                }

                return n;
            }
        }
    }
}