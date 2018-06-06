using ModsManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Keraplz.JSON
{
    public class Write
    {
        public static int n = 0;
        //static string typeer;
        static string pather;

        static Boolean oneuse = true;
        static string typefi;
        static string filepathfi;
        static string filenamefi;

        public static void WriteJSON(String input_type, String input_filepath, IList<String> input_files, String json_filename)
        {
            try
            {
                input_filepath = input_filepath.Replace("\\", "/");

                //setType(input_type);
                setPath(input_filepath);

                using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/writer.txt"))
                {
                    sw.WriteLine((n + 1).ToString("0000") + " - " + input_filepath + "  =>  " + pather);
                }

                n = n + 1;

                if (input_files == null || input_files.Count == 0) { }
                else
                {
                    if (oneuse)
                    {
                        typefi = input_type;
                        filepathfi = input_filepath;
                        filenamefi = json_filename;

                        oneuse = false;
                    }

                    Base.SpeedRunners SR_Files = new Base.SpeedRunners
                    {
                        Type = input_type,
                        Filepath = input_filepath,
                        Files = input_files
                    };

                    string FLjson;

                    if (json_filename.EndsWith(".json")) FLjson = json_filename;
                    else FLjson = json_filename + ".json";

                    if (!Directory.Exists(Profiles.Default.GetProgramName() + "/_content/" + pather))
                        Directory.CreateDirectory(Profiles.Default.GetProgramName() + "/_content/" + pather);

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText(Profiles.Default.GetProgramName() + "/_content/" + pather + "/" + FLjson))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, SR_Files);
                        file.Close();
                    }

                    input_files.Clear();
                }
            }
            catch (Exception e)
            {
                LogFile.WriteError(e); // Keraplz.JSON.Write.WriteJSON(" + typefi + ", " + filepathfi + ", " + "IList<string>" + ", " + filenamefi + ")");
                //LogFile.WriteLine(e.Message);
            }
        }

        public class ModDefinion
        {
            public static void ModConfig(Mod mod_info, Game game_info)
            {
                try
                {
                    Base.Mods Mod = new Base.Mods
                    {
                        Name = mod_info.GetName(),
                        isInstalled = mod_info.isInstalled(),
                        Type = mod_info.GetTypes(),
                        Content = mod_info.GetContent()
                    };

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText(game_info.GetFolderMods() + "/" + mod_info.GetName() + ".json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, Mod);
                        file.Close();
                    }
                }
                catch (Exception e)
                {
                    LogFile.WriteError(e); // Keraplz.JSON.Write.ModDefinion(Mod " + mod_info.GetName() + ", " + game_info.GetName() + ")");
                    //LogFile.WriteLine(e.Message);
                }
            }

            public class Edit
            {
                public static bool Load(Mod modInfo, Boolean shouldLoad)
                {
                    try
                    {
                        modInfo.Refresh();

                        Base.Mods Mod = new Base.Mods
                        {
                            Name = modInfo.GetName(),
                            isInstalled = modInfo.isInstalled(),
                            preventLoad = !shouldLoad,
                            Type = modInfo.GetTypes(),
                            Content = modInfo.GetContent()
                        };

                        // serialize JSON directly to a file
                        using (StreamWriter file = File.CreateText(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), modInfo.GetName() + ".json")))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, Mod);
                            file.Close();
                        }

                        return true;
                    }
                    catch (Exception e)
                    {
                        LogFile.WriteError(e); // Keraplz.JSON.Write.ModDefinion.Edit.Installed(Mod " + modInfo.GetName() + ", Boolean " + shouldLoad.ToString() + ")");
                        //LogFile.WriteLine(e.Message);
                    }

                    return false;
                }
                public static void Installed(Mod mod_info)
                {
                    IList<String> towrite_types = new List<String>();
                    IList<String> towrite_content = new List<String>();

                    try
                    {
                        foreach (String toClean in mod_info.GetTypes())
                            towrite_types.Add(toClean);

                        foreach (String toClean in mod_info.GetContent())
                            towrite_content.Add(toClean.Replace("\\", "/"));

                        Base.Mods Mod = new Base.Mods
                        {
                            Name = mod_info.GetName(),
                            isInstalled = !mod_info.isInstalled(),
                            Type = mod_info.GetTypes(),
                            Content = mod_info.GetContent()
                        };

                        // serialize JSON directly to a file
                        using (StreamWriter file = File.CreateText(Profiles.Default.GetGame().GetFolderMods() + "/" + mod_info.GetName() + ".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, Mod);
                            file.Close();
                        }

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                    catch (Exception e)
                    {
                        LogFile.WriteError(e); // Keraplz.JSON.Write.ModDefinion.Edit.Installed(Mod " + mod_info.GetName() + ")");
                        //LogFile.WriteLine(e.Message);

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                }
                public static void Installed(Mod modInfo, Boolean input_isInstalled)
                {
                    try
                    {
                        modInfo.Refresh();

                        Base.Mods Mod = new Base.Mods
                        {
                            Name = modInfo.GetName(),
                            isInstalled = input_isInstalled,
                            Type = modInfo.GetTypes(),
                            Content = modInfo.GetContent()
                        };

                        // serialize JSON directly to a file
                        using (StreamWriter file = File.CreateText(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), modInfo.GetName() + ".json")))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, Mod);
                            file.Close();
                        }
                    }
                    catch (Exception e)
                    {
                        LogFile.WriteError(e); // Keraplz.JSON.Write.ModDefinion.Edit.Installed(Mod " + modInfo.GetName() + ", Boolean " + input_isInstalled.ToString() + ")");
                        //LogFile.WriteLine(e.Message);
                    }
                }
                public static void Installed(String json_filename, Boolean input_isInstalled)
                {
                    IList<String> towrite_types = new List<String>();
                    IList<String> towrite_content = new List<String>();

                    try
                    {
                        foreach (String toClean in Read.Mods.GetType(json_filename))
                            towrite_types.Add(toClean);

                        foreach (String toClean in Read.Mods.GetContent(json_filename))
                            towrite_content.Add(toClean.Replace("\\", "/"));

                        Base.Mods Mod = new Base.Mods
                        {
                            isInstalled = input_isInstalled,
                            Type = towrite_types,
                            Content = towrite_content
                        };

                        // serialize JSON directly to a file
                        using (StreamWriter file = File.CreateText(Profiles.Default.GetGame().GetFolderMods() + "/" + json_filename + ".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, Mod);
                            file.Close();
                        }

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                    catch (Exception e)
                    {
                        LogFile.WriteError(e); // Keraplz.JSON.Write.ModDefinion_edit_installed(" + json_filename + ", " + input_isInstalled.ToString() + ")");
                        //LogFile.WriteLine(e.Message);

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                }
            }
        }

        /*
        public static IList<Mod> Configuration(String ProgramName, Game Game, String[] MaintenancePaths, String[] MaintenanceFiles)
        {
            IList<Mod> Mods = new List<Mod>();

            try
            {
                Mods = Setup.Maintenance_(ProgramName, Game, MaintenancePaths, MaintenanceFiles);

                Base.Configuration Config = new Base.Configuration
                {
                    ProgramName = ProgramName,
                    Game = Game
                };

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(ProgramName + "/Configuration.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, Config);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                LogFile.WriteError(e); // Keraplz.JSON.Write.Configuration(String " + ProgramName + ", Game " + Game.GetName() + ", String[], String[])");
                //LogFile.WriteLine(e.Message);
            }

            return Mods;
        }
        public static IList<Mod> Configuration(String ProgramName, Game Game)
        {
            IList<Mod> Mods = new List<Mod>();

            try
            {
                Mods = Setup.Maintenance_(ProgramName, Game, Profiles.Default.GetMaintenancePaths(), Profiles.Default.GetMaintenanceFiles());

                Base.Configuration Config = new Base.Configuration
                {
                    ProgramName = ProgramName,
                    Game = Game
                };

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(ProgramName + "/Configuration.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, Config);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                LogFile.WriteError(e); // Keraplz.JSON.Write.Configuration(String " + ProgramName + ", Game " + Game.GetName() + ")");
                //LogFile.WriteLine(e.Message);
            }

            return Mods;
        }
        public static void Configuration(Profile input_Profile)
        {
            try
            {
                Setup.Maintenance_(input_Profile.GetProgramName(), input_Profile.GetGame(), Profiles.Default.GetMaintenancePaths(), Profiles.Default.GetMaintenanceFiles());

                Base.Configuration Config = new Base.Configuration
                {
                    ProgramName = input_Profile.GetProgramName(),
                    Game = input_Profile.GetGame()
                };

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(input_Profile.GetProgramName() + "/Configuration.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, Config);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                LogFile.WriteError(e); // Keraplz.JSON.Write.Configuration(" + input_Profile.GetGame().GetName() + ")");
                //LogFile.WriteLine(e.Message);
            }
        }
        public static void Configuration()
        {
            try
            {
                Base.Configuration Config = new Base.Configuration
                {
                    ProgramName = Profiles.Default.GetProgramName(),
                    Game = Profiles.Default.GetGame()
                };

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(Profiles.Default.GetProgramName() + "/Configuration.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, Config);
                    file.Close();
                }

                //if (true) {
                //
                //    Int32 IBuild = 0;
                //    Int32 GBuild = 0;
                //
                //    if (!File.Exists(json_filename)) { File.Create(json_filename); }
                //    else {
                //    if (Read.Configuration.GetInstalledBuild() != 0)
                //        IBuild = Read.Configuration.GetInstalledBuild();
                //    }
                //
                //    GBuild = Int32.Parse(File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt").First().Split('(', ')')[1]);
                //
                //    Base.Configuration ManagerConfig = new Base.Configuration
                //    {
                //        GameBuild = GBuild,
                //        InstalledBuild = IBuild
                //    };
                //
                //    // serialize JSON directly to a file
                //    using (StreamWriter file = File.CreateText(json_filename))
                //    {
                //        JsonSerializer serializer = new JsonSerializer();
                //        serializer.Formatting = Formatting.Indented;
                //        serializer.Serialize(file, ManagerConfig);
                //        file.Close();
                //    }
                //
                //}
                //else
                //{
                //
                //    //----------------
                //
                //    DataSet dataSet = new DataSet("dataSet");
                //    dataSet.Namespace = "NetFrameWork";
                //    DataTable table = new DataTable();
                //    DataColumn idColumn = new DataColumn("id", typeof(int));
                //    idColumn.AutoIncrement = true;
                //
                //    DataColumn itemColumn = new DataColumn("item");
                //    table.Columns.Add(idColumn);
                //    table.Columns.Add(itemColumn);
                //    dataSet.Tables.Add(table);
                //
                //    for (int i = 0; i < 2; i++)
                //    {
                //        DataRow newRow = table.NewRow();
                //        newRow["item"] = "item " + i;
                //        table.Rows.Add(newRow);
                //    }
                //
                //    dataSet.AcceptChanges();
                //
                //    //----------------
                //
                //    //if (input_pathfiles == null || input_pathfiles.Count == 0) { }
                //    //else
                //    //{
                //    IList<String> input_mods = new List<String>();
                //    IList<String> input_lastbackup = new List<String>();
                //    string dt = (DateTime.Now.Minute + "/" + DateTime.Now.Hour + "/" + DateTime.Now.DayOfYear).ToString();
                //
                //    foreach (string s in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                //    {
                //        input_mods.Add(s.Replace("\\", "/"));
                //        input_lastbackup.Add(Path.GetFileNameWithoutExtension(s) + @""": """ + dt);
                //    }
                //
                //    Base.Configuration ManagerConfig = new Base.Configuration
                //    {
                //        //CurrentBuild = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt").First().Split('(', ')')[1],
                //        Mods = input_mods,
                //        //FirstTimeSetup = input_firsttimesetup,
                //        LastBackup = dataSet
                //    };
                //
                //    // serialize JSON directly to a file
                //    using (StreamWriter file = File.CreateText(json_filename))
                //    {
                //        JsonSerializer serializer = new JsonSerializer();
                //        serializer.Formatting = Formatting.Indented;
                //        serializer.Serialize(file, ManagerConfig);
                //        file.Close();
                //    }
                //
                //    //input_pathfiles.Clear();
                //    //}
                //}
            }
            catch (Exception e)
            {
                LogFile.WriteError(e); // Keraplz.JSON.Write.Configuration(" + ")");
                //LogFile.WriteLine(e.Message);
            }
        }
        */

        private static void setPath(string path)
        {
            foreach (String type in Read.Content.GetTypes(Profiles.Default.GetGame().GetFolderContent()))
            {
                if (path.EndsWith(type + "/") || path.EndsWith(type))
                {
                    pather = type;
                    break;
                }
                else if (Path.GetDirectoryName(path).Length >= 10)
                {
                    string helper = Path.GetDirectoryName(path).Replace('\\', '/').Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + 1);
                    pather = helper;
                    break;
                }
                else { /*Console.WriteLine(" Ignored path => " + path);*/ }
            }
        }
    }
}