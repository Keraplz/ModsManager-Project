using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                using (StreamWriter sw = File.AppendText("ModsManager/_logs/reader_test.txt"))
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
                using (StreamWriter SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    SWriterError.WriteLine("Error found in Keraplz.JSON.Read.ReadJSON(" + input_filepath + ")");
                    SWriterError.WriteLine(e.Message);
                }
            }
        }


        public static Boolean mods_GetInstalled(string input_modname)
        {
            Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText("mods/" + input_modname + ".json"));

            return mods_info_.Installed;
        }
        public static string mods_GetType(string input_modname)
        {
            Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText("mods/" + input_modname + ".json"));

            if (mods_info_.Type != null) return mods_info_.Type;
            else return Base.toLabel_modType;
        }
        public static string mods_GetAuthor(string input_modname)
        {
            Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText("mods/" + input_modname + ".json"));

            if (mods_info_.Author != null) return mods_info_.Author;
            else return Base.toLabel_modAuthor;
        }
        public static string mods_GetDescription(string input_modname)
        {
            Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText("mods/" + input_modname + ".json"));

            if (mods_info_.Description != null) return mods_info_.Description;
            else return Base.toLabel_modDescription;
        }
        public static IList<String> mods_GetContent(string input_modname)
        {
            Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText("mods/" + input_modname + ".json"));
            
            return mods_info_.Content;
        }
        public static int mods_GetNInstalled()
        {
            int n = 0;

            foreach (string modName in Directory.GetFiles("mods", "*.json"))
            {
                Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText("mods/" + Path.GetFileNameWithoutExtension(modName) + ".json"));

                if (mods_info_.Installed)
                {
                    n = n + 1;
                }
            }

            return n;
        }
        public static int mods_GetNContent(string input_modname)
        {
            int n = 0;
            Base.Mods mods_info_ = JsonConvert.DeserializeObject<Base.Mods>(File.ReadAllText("mods/" + input_modname + ".json"));

            foreach (string file in mods_info_.Content)
            {
                n = n + 1;
            }

            return n;
        }


        public static string GetCurrentBuild(string input_filepath)
        {
            Base.Configuration Configuration_File = JsonConvert.DeserializeObject<Base.Configuration>(File.ReadAllText(input_filepath));

            return Configuration_File.CurrentBuild;
        }
    }
}