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
        public static readonly string LogPath = Path.Combine(Application.StartupPath, "ModsManager", "ModsManager.log");
        private static TextWriter logWriter;
        private static bool useTimeStamp = true;
        private static bool IsLineEmpty = true;

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

        //public static void WriteLine()
        //{
        //    if (logWriter == null) return;
        //    logWriter.WriteLine(Environment.NewLine);
        //}

        public static void WriteLine(string message = null/*, bool end = false*/)
        {
            if (logWriter == null) return;
            if (message != null)
            {
                string logMessage = string.Empty;

                if (useTimeStamp) logMessage += DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]: ");
                logMessage += message;

                if (!IsLineEmpty) logWriter.WriteLine(message);
                else logWriter.WriteLine(logMessage);

                IsLineEmpty = true;
            }
            else logWriter.WriteLine(Environment.NewLine);

            logWriter.Flush();
        }

        public static void Write(string message)
        {
            if (logWriter == null) return;
            string logMessage = string.Empty;

            if (useTimeStamp) logMessage += DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]: ");
            logMessage += message;

            IsLineEmpty = false;

            logWriter.Write(logMessage);
            logWriter.Flush();
        }

        public static void WriteError(Exception e)
        {
            if (logWriter == null) return;
            string message = string.Empty;

            //if (!IsLineEmpty) message += Environment.NewLine;

            // Get method name
            MethodBase site = e.TargetSite;
            string methodName = site == null ? null : site.Name;

            // Get stack trace for the exception with source file information
            StackTrace trace = new StackTrace(e, true);
            // Get the top stack frame
            StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();
            // Get file name from Exception
            string fileName = Path.GetFileName(frame.GetFileName());

            message += /*DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]: ") + */"Error found in " + site;
            if (line != 0) message += ", line " + line;
            if (fileName != string.Empty) message += " in " + fileName;

            WriteLine(message);
            WriteLine(e.Message);
        }

        public static void WriteInfo(Game GameInfo, String Mode = "")
        {
            if (logWriter == null) return;

            Assembly _Assembly = Assembly.GetCallingAssembly();

            bool oldTimeStamp = useTimeStamp;
            useTimeStamp = false;

            //Mode = "[Dev Mode] ";

            OSystem OSInfo = new OSystem();
            string GInfo = string.Empty;

            if (GameInfo.GetName().ToLower() == "speedrunners") GInfo = GameInfo.GetName() + " " + Check.GetCurrentVersion();
            else GInfo = GameInfo.GetName();

            WriteLine("    " + Mode + "Program Info:");
            WriteLine("        " + _Assembly.GetName().Name);
            WriteLine("        Version: " + _Assembly.GetName().Version.ToString());
            WriteLine("        Game: " + GInfo);
            WriteLine("        OS: " + OSInfo.GetOSInfo());
            //WriteLine("        Resources Library: ");
            WriteLine();

            useTimeStamp = oldTimeStamp;
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