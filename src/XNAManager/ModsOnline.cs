﻿using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;

namespace ModsManager
{
    public class ModOnline : IModsDownload
    {
        // Members

        private Stream m_Preview;

        private String m_Name;
        private Int32 m_Version;
        //private IList<String> m_Types = new List<String>();
        //private IList<String> m_Content = new List<String>();

        private string m_Size;
        private long m_PureSize;
        //private IList<File> m_Content = new List<File>();


        // Constructor

        public ModOnline(String Name, Uri Preview)//, Int32 Version)
        {
            this.m_Name = Name;
            this.m_Version = 0;
            //m_Types = Types;
            //m_Content = Content; 


            // Get Icon from Uri Preview
            try
            {
                if (Preview != null)
                {
                    WebRequest req = WebRequest.Create(Preview);
                    WebResponse response = req.GetResponse();
                    Stream stream = response.GetResponseStream();
                    byte[] imageData = null;
                    using (BinaryReader sr = new BinaryReader(stream))
                    {
                        imageData = sr.ReadBytes((int)stream.Length);
                    }
                    MemoryStream ms = new MemoryStream(imageData);
                    this.m_Preview = ms;
                    ms.Close();
                    stream.Close();
                }
            }
            catch { }



            //foreach (string Ext in Games.SpeedRunners.GetExtensions())
            //{
            //    foreach (string file in Directory.GetFiles(Path.Combine(Games.SpeedRunners.GetFolderMods(), m_Name), "*" + Ext, SearchOption.AllDirectories))
            //    {
            //        FileInfo info = new FileInfo(file);
            //        m_PureSize += info.Length;
            //    }
            //}
            //
            //m_Size = SizeSuffix(m_PureSize, 3);
        }

        // Getters
        /*
        public String GetName() { return m_Name; }
        public Boolean isInstalled() { return m_isInstalled; }
        public IList<String> GetTypes() { return m_Types; }
        public String GetTypesString() {
            string Types = string.Empty;
            int i = 0;

            foreach (string Type in m_Types)
                foreach (string GameType in Keraplz.JSON.Read.Content.GetTypes(Profiles.Default.GetGame().GetFolderContent()))
                    if (GameType.ToLower() == Type.ToLower())
                    {
                        Types += GameType;
                        i = i + 1;

                        if (i < m_Types.Count)
                            Types += ", ";
                    }

            return Types;
        }
        public IList<String> GetContent(bool test = false) {

            if (test)
            {
                int i = m_Content.Count;
                int n = 0;
                string srcPath = string.Empty;
                IList<String> newContent = new List<String>();

                while (i > n)
                {
                    foreach (string modContent in m_Content)
                    {
                        srcPath = modContent.Remove(0, Profiles.Default.GetGame().GetFolderMods().Length + "\\".Length + m_Name.Length + "\\".Length + Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length);
                        foreach (string ext in Profiles.Default.GetGame().GetExtensions())
                        {
                            foreach (string filePath in Directory.GetFiles(Profiles.Default.GetGame().GetFolderContent(), "*" + ext, SearchOption.AllDirectories))
                            {
                                if (filePath.Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length).ToLower() == srcPath.ToLower())
                                {
                                    if (File.Exists(filePath) && File.Exists(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), m_Name, filePath)))
                                    {
                                        newContent.Add(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), m_Name, filePath));
                                        //newContent.Add(filePath.Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length));
                                        n = n + 1;
                                    }
                                    else if (File.Exists(filePath) && File.Exists(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), m_Name, Profiles.Default.GetGame().GetFolderContent(), filePath)))
                                    {
                                        newContent.Add(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), m_Name, Profiles.Default.GetGame().GetFolderContent(), filePath));
                                        //newContent.Add(filePath);
                                        n = n + 1;
                                    }
                                }
                                if (newContent.Count == i) break;
                            }
                            if (newContent.Count == i) break;
                        }
                        if (newContent.Count == i) break;
                    }
                    if (newContent.Count == i) break;
                }

                m_Content.Clear();
                m_Content = newContent;
            }

            return m_Content;
        }
        public string GetSize() { return m_Size; }
        public long GetPureSize() { return m_PureSize; }
        */

        // IModsDownload

        public Game Game
        {
            get { return Games.SpeedRunners; }
        }

        public String ModificationName
        {
            get { return this.m_Name; }
        }

        public Int32 ModificationVersion
        {
            get { return this.m_Version; }
        }

        public Icon ModificationPreview
        {
            get { return new Icon(this.m_Preview); }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Uri XmlLocation
        {
            get { return new Uri(Profiles.Default.GetXmlUrl()); }
        }

        // Methods

        public void Download()
        {
            ModsDownload downloader = new ModsDownload(this);
            downloader.DoDownload();
        }

        /*
        public Boolean Refresh()
        {
            this.m_isInstalled = Keraplz.JSON.Read.Mods.IsInstalled(m_Name, Profiles.Default.GetGame().GetFolderMods());

            bool denied = false;

            //int i = 0;
            string oriType = string.Empty;
            IList<String> newTypes = new List<String>();

            bool shouldStop = false;
            while (!denied && !shouldStop)
            {
                string modPath_ = string.Empty;
                m_Types.Clear();

                foreach (string modPath in Directory.GetDirectories(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), m_Name)))
                    if (modPath.ToLower().Contains(Profiles.Default.GetGame().GetFolderContent().ToLower()))
                    {
                        modPath_ = Path.Combine(Profiles.Default.GetGame().GetFolderMods(), m_Name, Profiles.Default.GetGame().GetFolderContent());
                        break;
                    } else modPath_ = Path.Combine(Profiles.Default.GetGame().GetFolderMods(), m_Name);

                foreach (string modPath in Directory.GetDirectories(modPath_))
                    foreach (string path in Directory.GetDirectories(Profiles.Default.GetGame().GetFolderContent()))
                    {
                        oriType = path.Remove(0, Profiles.Default.GetGame().GetFolderContent().Length + "\\".Length);
                        if (modPath.ToLower().Contains(oriType.ToLower())) m_Types.Add(oriType);
                    }

                if (m_Types.Count > 0) shouldStop = true;
            }


            return denied;
        }
        public Boolean isLoaded() { return Profiles.Default.isLoaded(this); }
        public Boolean isBanned() { return Profiles.Default.isBanned(this); }
        public Boolean ShouldLoad(Boolean IsBanned = false) {
            //if (!shouldLoad) ModsManager.PreventLoad(new Mod(m_Name, m_isInstalled, m_Types, m_Content));
            //else ModsManager.NormalizeLoad(new Mod(m_Name, m_isInstalled, m_Types, m_Content));

            if (IsBanned) return false;
            bool shouldLoad = true;

            try {
                shouldLoad = !Keraplz.JSON.Read.Mods.PreventLoad(this.m_Name, Profiles.Default.GetGame().GetFolderMods());
            } catch { }

            return shouldLoad;
        }
        public void Load() { ModsManager.Load(this); }
        public void Unload() { ModsManager.Unload(this); }
        public void Ban() { ModsManager.Ban(this); }
        public void Unban() { ModsManager.Unban(this); }
        public Boolean Contains(String Name) {
            if (this.m_Name == Name) return true;
            else return false;
        }
        public Boolean Contains(IList<String> Types) {
            if (this.m_Types == Types) return true;
            else return false;
        }
        //public Boolean Contains(String Type)
        //{
        //    if (m_Types.Contains(Type)) return true;
        //    else return false;
        //}
        //public Boolean Contains(IList<String> Content)
        //{
        //    if (m_Content == Content) return true;
        //    else return false;
        //}
        //public Boolean Contains(String Content)
        //{
        //    if (m_Content.Contains(Content)) return true;
        //    else return false;
        //}

        public class ModFile
        {
            private string m_Path;
            private string m_Type;
            private string m_Extension;

            public ModFile(string Path, string Type, string Extension)
            {
                m_Path = Path;
                m_Type = Type;
                m_Extension = Extension;
            }

            public string GetPath() { return m_Path; }
            public string GetTypeTag() { return m_Type; }
            public string GetExtension() { return m_Extension; }
        }
         * */

        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        private static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
        }

    }
}