using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    public class MMUIProgramInfo
    {
        private string Mode;
        private string AssemblyName;
        private string AssemblyVersion;
        private string GameInfo;
        private string OSInfo;

        public MMUIProgramInfo(Game GameInfo, String Mode = "")
        {
            Assembly _Assembly = Assembly.GetCallingAssembly();
            OSystem OSInfo = new OSystem();
            string GInfo = string.Empty;

            if (GameInfo.GetName().ToLower() == "speedrunners") GInfo = GameInfo.GetName() + " " + Check.GetCurrentVersion();
            else GInfo = GameInfo.GetName();


            this.Mode = "    " + Mode + "Program Info:";
            this.AssemblyName = "        " + _Assembly.GetName().Name;
            this.AssemblyVersion = "        Version: " + _Assembly.GetName().Version.ToString();
            this.GameInfo = "        Game: " + GInfo;
            this.OSInfo = "        OS: " + OSInfo.GetOSInfo();
        }

        public string GetMode() { return this.Mode; }
        public string GetName() { return this.AssemblyName; }
        public string GetVersion() { return this.AssemblyVersion; }
        public string GetGameInfo() { return this.GameInfo; }
        public string GetOSInfo() { return this.OSInfo; }
    }
}
