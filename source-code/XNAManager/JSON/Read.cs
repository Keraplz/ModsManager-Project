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

        public static void ReadJSON(string input_filepath)
        {
            try
            {
                string json = File.ReadAllText(input_filepath);

                Base.SpeedRunners SR_Files = JsonConvert.DeserializeObject<Base.SpeedRunners>(json);

                using (StreamWriter sw = File.AppendText(Definitions.ProgramName + "/_logs/reader_test.txt"))
                {
                    sw.WriteLine("filename = " + Path.GetFileName(input_filepath));
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
                using (StreamWriter SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    SWriterError.WriteLine("Error found in Keraplz.JSON.Read.ReadJSON(" + input_filepath + ")");
                    SWriterError.WriteLine(e.Message);
                }
            }
        }

        public class Content
        {
            public static Int32 GetNFiles()
            {
                int n = 0;

                foreach (string extension in Definitions.fileExtensions)
                    foreach (string fileName in Directory.GetFiles(Definitions.ContentFolder, "*" + extension, SearchOption.AllDirectories))
                        n = n + 1;

                 return n;
            }
            public static IList<String> GetTypes()
            {
                IList<String> Types = new List<String>();

                foreach (string type in Directory.EnumerateDirectories(Definitions.ContentFolder))
                    Types.Add(type);

                return Types;
            }
        }
        public class Configuration
        {
            public static Int32 GetGameBuild()
            {
                Base.Configuration config_info_ = JsonConvert.DeserializeObject<Base.Configuration>(File.ReadAllText(Definitions.configFile));

                if (config_info_.GameBuild != null) return config_info_.GameBuild;
                else return 0;
            }
            public static Int32 GetInstalledBuild()
            {
                Base.Configuration config_info_ = JsonConvert.DeserializeObject<Base.Configuration>(File.ReadAllText(Definitions.configFile));

                if (config_info_.InstalledBuild != null) return config_info_.InstalledBuild;
                else return 0;
            }
        }
        public class Mods
        {
            public static Boolean Exists(string input_modname)
            {
                if (File.Exists(Definitions.ModsFolder + "/" + input_modname + ".json"))
                {
                    return true;
                }
                else return false;
            }
            public static Boolean Contains(string input_filepath)
            {
                foreach (string nameer in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    string ModName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + ModName + ".json"));

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
            public static IDictionary<String, Int32> GetContainsDict(string input_filepath)
            {
                IDictionary<String, Int32> Mods = new Dictionary<String, Int32>();

                foreach (string nameer in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    string ModName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + ModName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            Mods.Add(ModName, GetNContent(ModName));
                        }
                    }
                }

                return Mods;
            }
            public static IList<String> GetContains(string input_filepath)
            {
                IList<String> Mods = new List<String>();

                foreach (string nameer in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    string ModName = Path.GetFileNameWithoutExtension(nameer);
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + ModName + ".json"));

                    foreach (string filename in mods_info_.Content)
                    {
                        if (filename.ToLower().EndsWith(input_filepath.ToLower()))
                        {
                            Mods.Add(ModName);
                        }
                    }
                }

                Mods = Mods.Distinct().ToList();

                return Mods;
            }
            public static Boolean IsOverriding(string input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                return mods_info_.Overriding;
            }
            public static Boolean IsInstalled(string input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                return mods_info_.Installed;
            }
            public static String GetAuthor(string input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                if (mods_info_.Author != null) return mods_info_.Author;
                else return Base.toLabel_modAuthor;
            }
            public static String GetDescription(string input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                if (mods_info_.Description != null) return mods_info_.Description;
                else return Base.toLabel_modDescription;
            }
            public static IList<String> GetType(string input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                return mods_info_.Type;
            }
            public static IList<String> GetContent(string input_modname)
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                return mods_info_.Content;
            }
            public static Int32 GetNOverriding()
            {
                int n = 0;

                foreach (string modName in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                    if (mods_info_.Overriding)
                    {
                        n = n + 1;
                    }
                }

                return n;
            }
            public static Int32 GetNInstalled()
            {
                int n = 0;

                foreach (string modName in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                    if (mods_info_.Installed)
                    {
                        n = n + 1;
                    }
                }

                return n;
            }
            public static Int32 GetNFilesInstalled()
            {
                int n = 0;

                foreach (string modName in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                {
                    Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                    if (mods_info_.Installed)
                    {
                        int i = 0;
                        foreach (string file in mods_info_.Content)
                            i = i + 1;
                        n = n + i;
                    }
                }

                return n;
            }
            public static Int32 GetNType(string input_modname)
            {
                int n = 0;
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                foreach (string file in mods_info_.Type)
                {
                    n = n + 1;
                }

                return n;
            }
            public static Int32 GetNContent(string input_modname)
            {
                int n = 0;
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText(Definitions.ModsFolder + "/" + input_modname + ".json"));

                foreach (string file in mods_info_.Content)
                {
                    n = n + 1;
                }

                return n;
            }
        }

        public static Int32 GetCurrentBuild(string input_filepath)
        {
            try
            {
                Base.Configuration Configuration = JsonConvert.DeserializeObject<Base.Configuration>(File.ReadAllText(input_filepath));

                return Configuration.InstalledBuild;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in Keraplz.JSON.Read.GetCurrentBuild(" + input_filepath + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }

                return 0;
            }
        }
    }
}