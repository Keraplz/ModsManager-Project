using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Keraplz.JSON
{
    class Base
    {
        public static String toLabel_modType = "no_type_found";
        public static String toLabel_modAuthor = "no_author_found";
        public static String toLabel_modDescription = "no_description_found";

        public class SpeedRunners
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("filepath")]
            public string Filepath { get; set; }

            [JsonProperty("files")]
            public IList<string> Files { get; set; }

        }
        public class Mods
        {
            [JsonProperty("installed")]
            public Boolean Installed { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("author")]
            public string Author { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("content")]
            public IList<string> Content { get; set; }

        }
        public class Configuration
        {
            [JsonProperty("mods")]
            public IList<String> Mods { get; set; }

            [JsonProperty("first_time_setup")]
            public Boolean FirstTimeSetup { get; set; }

            [JsonProperty("current_build")]
            public String CurrentBuild { get; set; }

            [JsonProperty("last_backup")]
            public IList<String> LastBackup { get; set; }

            [JsonProperty("lastBackup_")]
            public Dictionary<String, String> LastBackup_ { get; set; }

        }
        public class Tag
        {
            public string SFX { get; set; }
            public string Characters { get; set; }
            public string UI { get; set; }
        }

        public class Reader
        {
            public Dictionary<string, SpeedRunners> Files { set; get; }
        }
    }
}