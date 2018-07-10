using System;
using System.IO;
using System.IO.Compression;

namespace ModsManager
{
    public class CompressedFileHandle
    {
        public static void ExtractZip(Stream ZipStream, String OutDir)
        {
            if (ZipStream.Length == 0) return;

            if (!Directory.Exists(OutDir))
                Directory.CreateDirectory(OutDir);

            ZipArchive archive = new ZipArchive(ZipStream);

            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                string FileName = entry.FullName.Substring(entry.FullName.IndexOf("/") + 1);

                //if (entry.FullName.EndsWith(".log", StringComparison.OrdinalIgnoreCase))
                //{
                if (!Path.HasExtension(FileName))
                {
                    if (!Directory.Exists(Path.Combine(OutDir, FileName)))
                        Directory.CreateDirectory(Path.Combine(OutDir, FileName));
                }
                else if (Path.HasExtension(FileName))
                {
                    if (!Directory.Exists(Path.Combine(OutDir, Path.GetDirectoryName(FileName))))
                        Directory.CreateDirectory(Path.Combine(OutDir, Path.GetDirectoryName(FileName)));

                    using (Stream fileStream = entry.Open()) // .Open will return a stream
                    {
                        using (BinaryReader br = new BinaryReader(fileStream))
                        using (FileStream fs = new FileStream(Path.Combine(OutDir, FileName), FileMode.OpenOrCreate))
                        using (BinaryWriter bw = new BinaryWriter(fs))
                            bw.Write(br.ReadBytes((int)entry.Length));//(int)fileStream.Length));
                    }
                }
                //}

            }
        }
    }
}