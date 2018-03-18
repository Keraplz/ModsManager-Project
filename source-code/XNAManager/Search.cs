using Keraplz.JSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ModsManager
{
    class Search
    {
        public static IList<string> SearchXNB(String sDir, Boolean shouldWrite)
        {
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

                                Definitions.fileList.Add(f);
                            }
                        }
                    }

                    SearchXNB(d, shouldWrite);
                }

                if (shouldWrite)
                {
                    Definitions.input_type = Path.GetFileName(Path.GetDirectoryName(sDir));
                    Definitions.input_filepath = sDir;

                    foreach (string extension in Definitions.fileExtensions)
                    {
                        foreach (string list in Directory.GetFiles(sDir, "*" + extension).Select(Path.GetFileName))
                        {
                            Definitions.input_files.Add(list);
                        }
                    }

                    Write.WriteJSON(Definitions.input_type, Definitions.input_filepath, Definitions.input_files, Path.GetFileName(sDir));
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.Search.SearchXNB(" + sDir + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }

            return Definitions.fileList;
        }
    }
}