
namespace ModsManager
{
    public class FileManager
    {
        private string m_Name;
        private string m_Path;
        private string m_Type;
        private string m_Extension;
        private long m_Size;

        public FileManager(string Name, string Path, string Type, string Extension, long Size = 0)
        {
            m_Name = Name;
            m_Path = Path;
            m_Type = Type;
            m_Extension = Extension;
            m_Size = Size;
        }

        public string GetName() { return m_Name; }
        public string GetPath() { return m_Path; }
        //public string GetType() { return m_Type; }
        public string GetExtension() { return m_Extension; }
        public long GetSize() { return m_Size; }
    }
}