using System.IO;
using System.Reflection;

namespace ModsManager
{
    public class ResourceTweaker
    {
        public static void Extract(string NameSpace, string InternalPath, string ResourceName, string outDir = "")
        {
            Assembly _Assembly = Assembly.GetCallingAssembly();

            if (!Directory.Exists(outDir) && outDir != "")
                Directory.CreateDirectory(outDir);

            using (Stream s = _Assembly.GetManifestResourceStream(NameSpace + "." + (InternalPath == "" ? "" : InternalPath + ".") + ResourceName))
            using (BinaryReader br = new BinaryReader(s))
            using (FileStream fs = new FileStream(Path.Combine(outDir, ResourceName), FileMode.OpenOrCreate))
            using (BinaryWriter bw = new BinaryWriter(fs))
                bw.Write(br.ReadBytes((int)s.Length));
        }
    }
}