using Keraplz.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModsManager
{
    class Search
    {
        public static IList<String> SearchXNB(String sDir, Boolean shouldWrite)
        {
            IList<String> FilesList = new List<String>();

            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, "*.xnb"/*, SearchOption.AllDirectories*/))
                    {
                        string extension = Path.GetExtension(f);
                        if (extension != null && (extension.Equals(".xnb")))
                        {
                            Definitions.xnbPath.Add(f);
                            if (Check.Ignored(Path.GetFileName(f), Path.GetDirectoryName(f)))
                            {
                                Definitions.ignoredList.Add(Definitions.ignoredType + " IGNORED" + Definitions.ignoredFile);
                            }
                            else
                            {
                                Definitions.outputName.Add(Path.GetDirectoryName(f) + "  =>  " + Path.GetFileName(f));

                                FilesList.Add(f);
                            }
                        }
                    }

                    SearchXNB(d, shouldWrite);
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
    }
}