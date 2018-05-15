using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
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

        public static void WriteLine(string message, bool end = false)
        {
            if (logWriter == null) return;
            string logMessage = string.Empty;

            if (useTimeStamp) logMessage += DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]: ");
            logMessage += message;

            if (end) logWriter.WriteLine(message);
            else logWriter.WriteLine(logMessage);
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

        public static void WriteError(Exception e)
        {
            if (logWriter == null) return;
            string message = string.Empty;

            // Get method name
            MethodBase site = e.TargetSite;
            string methodName = site == null ? null : site.Name;

            // Get stack trace for the exception with source file information
            var trace = new StackTrace(e, true);
            // Get the top stack frame
            var frame = trace.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();

            message = "Error found in " + site + ", line " + line;

            WriteLine(message);
            WriteLine(e.Message);
        }

        //public static void WriteEnd(string message)
        //{
        //    if (logWriter == null) return;
        //
        //    logWriter.Write(message + Environment.NewLine);
        //    logWriter.Flush();
        //}

        public static void Close()
        {
            if (logWriter == null) return;
            logWriter.Close();
        }

    }
}