using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    class Convert
    {
        //static System.Diagnostics.Process process = new System.Diagnostics.Process();
        //static System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

        public static void XNB_PNG()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WorkingDirectory = System.IO.Directory.GetCurrentDirectory(),
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                using (Process p = Process.Start(startInfo))
                {
                    foreach (string s in Directory.GetFiles("Content", "*.xnb", SearchOption.AllDirectories))
                    {
                        if (s.ToLower().Contains("atlas") || s.ToLower().Contains("sfx")) { }
                        else
                        {
                            string sDir;
                            if (Path.GetDirectoryName(s).Length >= 10)
                            {
                                sDir = Path.GetDirectoryName(s).Remove(0, 8);
                            }
                            else sDir = Path.GetDirectoryName(s).Remove(0, 8);
                            string sFile = Path.GetFileNameWithoutExtension(s);

                            //Console.WriteLine(" s => " + s);

                            p.StandardInput.WriteLine(@"xnb_node extract " + s + @" XNAManager\_content\" + sDir + sFile + ".yaml");
                        }
                    }

                    p.StandardInput.WriteLine("exit");
                    p.WaitForExit();
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.Convert.XNB_PNG()");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }
        }

    }
}
