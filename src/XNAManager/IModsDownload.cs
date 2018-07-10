using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ModsManager
{
    public interface IModsDownload
    {
        Game Game { get; }
        String ModificationName { get; }
        Int32 ModificationVersion { get; }
        Icon ModificationPreview { get; }
        Assembly ApplicationAssembly { get; }
        Uri XmlLocation { get; }
        //Form Context { get; }
    }
}