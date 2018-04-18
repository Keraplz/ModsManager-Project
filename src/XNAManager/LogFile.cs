using System;
using System.IO;
using System.Windows.Forms;


namespace ModsManager
{
    public static class LogFile
    {
        //Variables/Constants
        public static readonly string LogPath = Path.Combine(Application.StartupPath, Keraplz.JSON.Read.Configuration.GetProgramName()) + "\\" + Keraplz.JSON.Read.Configuration.GetProgramName() + ".log";
        private static TextWriter logWriter;
        private static bool useTimeStamp = true;

        //Methods
        public static void Initialize(bool createNewFile = true, bool useTimeStampBool = true)
        {
            try
            {
                useTimeStamp = useTimeStampBool;
                if (createNewFile)
                    logWriter = File.CreateText(LogPath);
                else
                {
                    logWriter = File.AppendText(LogPath);
                    logWriter.WriteLine(Environment.NewLine + "======== New Session ========" + Environment.NewLine);
                }
            }
            catch { }
        }

        public static void WriteLine()
        {
            if (logWriter == null) return;
            logWriter.WriteLine(Environment.NewLine);
        }

        public static void WriteLine(string message)
        {
            if (logWriter == null) return;
            string logMessage = string.Empty;

            if (useTimeStamp) logMessage += DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]: ");
            logMessage += message;

            logWriter.WriteLine(logMessage + Environment.NewLine);
            logWriter.Flush();
        }

        public static void Write(string message)
        {
            if (logWriter == null) return;
            string logMessage = string.Empty;

            if (useTimeStamp) logMessage += DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]: ");
            logMessage += message;

            logWriter.Write(logMessage);
            logWriter.Flush();
        }

        public static void WriteEnd(string message)
        {
            if (logWriter == null) return;

            logWriter.Write(message + Environment.NewLine);
            logWriter.Flush();
        }

        public static void Close()
        {
            if (logWriter == null) return;
            logWriter.Close();
        }
    }
}