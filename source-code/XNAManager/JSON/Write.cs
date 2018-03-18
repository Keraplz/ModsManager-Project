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

                using (StreamWriter sw = File.AppendText(Definitions.ProgramName + "/_logs/writer.txt"))
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

                    if (!Directory.Exists(Definitions.ProgramName + "/_content/" + pather))
                        Directory.CreateDirectory(Definitions.ProgramName + "/_content/" + pather);

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText(Definitions.ProgramName + "/_content/" + pather + "/" + FLjson))
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
                using (StreamWriter sw = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    sw.WriteLine("Error found in Keraplz.JSON.Write.WriteJSON(" + typefi + ", " + filepathfi + ", " + "IList<string>" + ", " + filenamefi + ")");
                    sw.WriteLine(e.Message);
                }
            }
        }

        public class ModDefinion
        {
            public static void ModConfig(String json_filename, IList<String> input_pathfiles){
                IList<String> towrite_types = new List<String>();
                IList<String> towrite_pathfiles = new List<String>();

                try
                {
                    foreach (string newType in Directory.GetDirectories(Definitions.ModsFolder + "/" + json_filename + "/Content/"))
                    {
                        towrite_types.Add(newType.Split('/').Last());
                    }
                    foreach (String toClean in input_pathfiles)
                    {
                        towrite_pathfiles.Add(toClean.Replace("\\", "/"));
                    }

                    towrite_types = towrite_types.Distinct().ToList();
                    //foreach (string toGetTypes in towrite_pathfiles)
                    //{
                    //    Mod_Types = toGetTypes.split('/', StringSplitOptions.RemoveEmptyEntries);
                    //    towrite_types.Add(toGetTypes.split('/', StringSplitOptions.RemoveEmptyEntries));
                    //}

                    if (towrite_pathfiles == null || towrite_pathfiles.Count == 0) { }
                    else
                    {
                        Base.Mods SR_Mods = new Base.Mods
                        {
                            Overriding = false,
                            Installed = false,
                            Author = Base.toLabel_modAuthor,
                            Description = Base.toLabel_modDescription,
                            Type = towrite_types,
                            Content = towrite_pathfiles
                        };

                        // serialize JSON directly to a file
                        using (StreamWriter file = File.CreateText(Definitions.ModsFolder + "/" + json_filename + ".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, SR_Mods);
                            file.Close();
                        }

                    }

                    towrite_types.Clear();
                    towrite_pathfiles.Clear();
                }
                catch (Exception e)
                {
                    using (StreamWriter sw = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                    {
                        sw.WriteLine("Error found in Keraplz.JSON.Write.ModDefinion(" + json_filename + ", " + "IList<string>" + ")");
                        sw.WriteLine(e.Message);
                    }

                    towrite_types.Clear();
                    towrite_pathfiles.Clear();
                }
            }

            public class Edit
            {
                public static void Installed(String json_filename, Boolean input_isInstalled)
                {
                    IList<String> towrite_types = new List<String>();
                    IList<String> towrite_content = new List<String>();

                    try
                    {
                        foreach (String toClean in Read.Mods.GetType(json_filename))
                        {
                            towrite_types.Add(toClean);
                        }
                        foreach (String toClean in Read.Mods.GetContent(json_filename))
                        {
                            towrite_content.Add(toClean.Replace("\\", "/"));
                        }

                        towrite_types = towrite_types.Distinct().ToList();

                        Base.Mods SR_Mods = new Base.Mods
                        {
                            Overriding = Read.Mods.IsOverriding(json_filename),
                            Installed = input_isInstalled,
                            Author = Read.Mods.GetAuthor(json_filename),
                            Description = Read.Mods.GetDescription(json_filename),
                            Type = towrite_types,
                            Content = towrite_content
                        };

                        // serialize JSON directly to a file
                        using (StreamWriter file = File.CreateText(Definitions.ModsFolder + "/" + json_filename + ".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, SR_Mods);
                            file.Close();
                        }

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                    catch (Exception e)
                    {
                        using (StreamWriter sw = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                        {
                            sw.WriteLine("Error found in Keraplz.JSON.Write.ModDefinion_edit_installed(" + json_filename + ", " + input_isInstalled.ToString() + ")");
                            sw.WriteLine(e.Message);
                        }

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                }
                public static void Overriding(String json_filename, Boolean input_isOverriding)
                {
                    IList<String> towrite_types = new List<String>();
                    IList<String> towrite_content = new List<String>();

                    try
                    {
                        foreach (String toClean in Read.Mods.GetType(json_filename))
                        {
                            towrite_types.Add(toClean);
                        }
                        foreach (String toClean in Read.Mods.GetContent(json_filename))
                        {
                            towrite_content.Add(toClean.Replace("\\", "/"));
                        }

                        towrite_types = towrite_types.Distinct().ToList();

                        Base.Mods SR_Mods = new Base.Mods
                        {
                            Overriding = input_isOverriding,
                            Installed = Read.Mods.IsInstalled(json_filename),
                            Author = Read.Mods.GetAuthor(json_filename),
                            Description = Read.Mods.GetDescription(json_filename),
                            Type = towrite_types,
                            Content = towrite_content
                        };

                        // serialize JSON directly to a file
                        using (StreamWriter file = File.CreateText(Definitions.ModsFolder + "/" + json_filename + ".json"))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            serializer.Formatting = Formatting.Indented;
                            serializer.Serialize(file, SR_Mods);
                            file.Close();
                        }

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                    catch (Exception e)
                    {
                        using (StreamWriter sw = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                        {
                            sw.WriteLine("Error found in Keraplz.JSON.Write.ModDefinion_edit_installed(" + json_filename + ", " + input_isOverriding.ToString() + ")");
                            sw.WriteLine(e.Message);
                        }

                        towrite_types.Clear();
                        towrite_content.Clear();
                    }
                }
            }
        }

        // Deactivated
        public static void Configuration(String json_filename)
        {
            try
            {
                if (true) {

                    Int32 IBuild = 0;
                    Int32 GBuild = 0;

                    if (!File.Exists(json_filename)) { File.Create(json_filename); }
                    else {
                    if (Read.Configuration.GetInstalledBuild() != 0)
                        IBuild = Read.Configuration.GetInstalledBuild();
                    }

                    GBuild = Int32.Parse(File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt").First().Split('(', ')')[1]);

                    Base.Configuration ManagerConfig = new Base.Configuration
                    {
                        GameBuild = GBuild,
                        InstalledBuild = IBuild
                    };

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText(json_filename))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, ManagerConfig);
                        file.Close();
                    }

                }
                else
                {

                    //----------------

                    DataSet dataSet = new DataSet("dataSet");
                    dataSet.Namespace = "NetFrameWork";
                    DataTable table = new DataTable();
                    DataColumn idColumn = new DataColumn("id", typeof(int));
                    idColumn.AutoIncrement = true;

                    DataColumn itemColumn = new DataColumn("item");
                    table.Columns.Add(idColumn);
                    table.Columns.Add(itemColumn);
                    dataSet.Tables.Add(table);

                    for (int i = 0; i < 2; i++)
                    {
                        DataRow newRow = table.NewRow();
                        newRow["item"] = "item " + i;
                        table.Rows.Add(newRow);
                    }

                    dataSet.AcceptChanges();

                    //----------------

                    //if (input_pathfiles == null || input_pathfiles.Count == 0) { }
                    //else
                    //{
                    IList<String> input_mods = new List<String>();
                    IList<String> input_lastbackup = new List<String>();
                    string dt = (DateTime.Now.Minute + "/" + DateTime.Now.Hour + "/" + DateTime.Now.DayOfYear).ToString();

                    foreach (string s in Directory.GetFiles(Definitions.ModsFolder, "*.json"))
                    {
                        input_mods.Add(s.Replace("\\", "/"));
                        input_lastbackup.Add(Path.GetFileNameWithoutExtension(s) + @""": """ + dt);
                    }

                    Base.Configuration ManagerConfig = new Base.Configuration
                    {
                        //CurrentBuild = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt").First().Split('(', ')')[1],
                        Mods = input_mods,
                        //FirstTimeSetup = input_firsttimesetup,
                        LastBackup = dataSet
                    };

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText(json_filename))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, ManagerConfig);
                        file.Close();
                    }

                    //input_pathfiles.Clear();
                    //}
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    sw.WriteLine("Error found in Keraplz.JSON.Write.Configuration(" + json_filename + ")");
                    sw.WriteLine(e.Message);
                }
            }
        }

        private static void setPath(string path)
        {
            foreach (String type_ in Read.Content.GetTypes())
            {
                string type = Path.GetFileName(type_);
                if (path.EndsWith(type + "/") || path.EndsWith(type))
                {
                    pather = type;
                    break;
                }
                else if (Path.GetDirectoryName(path).Length >= 10)
                {
                    string helper = Path.GetDirectoryName(path).Replace('\\', '/').Remove(0, Definitions.ContentFolder.Length + 1);
                    pather = helper;
                    break;
                }
                else { /*Console.WriteLine(" Ignored path => " + path);*/ }
            }
        }
    }
}