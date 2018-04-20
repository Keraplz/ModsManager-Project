using Keraplz.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModsManager
{
    class Search
    {
        private static String ignoredType = string.Empty;
        private static String ignoredFile = string.Empty;

        public static IList<String> SearchXNB(String sDir, Boolean shouldWrite)
        {
            IList<String> FilesList = new List<String>();

            try
            {
                foreach (string type in Directory.GetDirectories(sDir))
                {
                    foreach (string filePath in Directory.GetFiles(type, "*.xnb"/*, SearchOption.AllDirectories*/))
                    {
                        string extension = Path.GetExtension(filePath);
                        if (extension != null && (extension.Equals(".xnb")))
                        {
                            if (Ignored(Path.GetFileName(filePath), Path.GetDirectoryName(filePath)))
                            {
                                using (StreamWriter sw = File.AppendText(Profiles.Default.GetProgramName() + "/_logs/search.txt"))
                                    sw.Write(ignoredType + " IGNORED" + ignoredFile);
                            }
                            else
                            {
                                FilesList.Add(filePath);
                            }
                        }
                    }

                    SearchXNB(type, shouldWrite);
                }

                if (shouldWrite)
                {
                    IList<String> Files = new List<String>();

                    foreach (string extension in Profiles.Default.GetGame().GetExtensions().ToArray())
                    {
                        foreach (string list in Directory.GetFiles(sDir, "*" + extension).Select(Path.GetFileName))
                        {
                            Files.Add(list);
                        }
                    }

                    Write.WriteJSON(Path.GetFileName(Path.GetDirectoryName(sDir)), sDir, Files, Path.GetFileName(sDir));
                }
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.Search.SearchXNB(String " + sDir + ", Boolean " + shouldWrite.ToString() + ")");
                LogFile.WriteLine(e.Message);
            }

            return FilesList;
        }

        private static Boolean Ignored(String filename, String directory)
        {
            if (ContainsSFX(filename, directory) || ContainsATLAS(filename))
            {
                return true;
            }
            else return false;
        }

        private static Boolean ContainsSFX(String filename, String directory)
        {
            String[] directories = directory.Split(Path.DirectorySeparatorChar);

            ignoredType = "SFX";
            ignoredFile = "   :: " + filename;

            if (directories.ToLookup(i => i.ToLower()).Contains("sfx"))
                return true;
            else return false;
        }
        private static Boolean ContainsATLAS(String filename)
        {
            ignoredType = "ATLAS";
            ignoredFile = " :: " + filename;

            if (filename.ToLower().Contains("atlas"))
                return true;
            else return false;
        }
    }
}