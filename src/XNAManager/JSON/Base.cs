using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using ModsManager;

namespace Keraplz.JSON
{
    class Base
    {
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
            [JsonProperty("name")]
            public String Name { get; set; }

            [JsonProperty("isInstalled")]
            public Boolean isInstalled { get; set; }

            [JsonProperty("preventLoad")]
            public Boolean preventLoad { get; set; }

            [JsonProperty("type")]
            public IList<String> Type { get; set; }

            [JsonProperty("content")]
            public IList<String> Content { get; set; }

        }
        public class Configuration
        {
            [JsonProperty("ProgramName")]
            public String ProgramName { get; set; }

            [JsonProperty("Game")]
            public Game Game { get; set; }
        }
        public class UpdateSetup
        {
            public string ShouldReinstall { get; set; }
        }

        public class Reader
        {
            public Dictionary<string, SpeedRunners> Files { set; get; }
        }
    }
}