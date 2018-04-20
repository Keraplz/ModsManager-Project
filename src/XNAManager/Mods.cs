using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    public class Mod
    {
        // Members

        [Newtonsoft.Json.JsonProperty("name")]
        private String m_Name;

        [Newtonsoft.Json.JsonProperty("isInstalled")]
        private Boolean m_isInstalled;

        [Newtonsoft.Json.JsonProperty("type")]
        private IList<String> m_Types = new List<String>();

        [Newtonsoft.Json.JsonProperty("content")]
        private IList<String> m_Content = new List<String>();

        // Constructor

        [Newtonsoft.Json.JsonConstructor]
        public Mod(String Name, Boolean isInstalled, IList<String> Types, IList<String> Content)
        {
            m_Name = Name;
            m_isInstalled = isInstalled;
            m_Types = Types;
            m_Content = Content;
        }

        // Getters

        public String GetName() { return m_Name; }
        public Boolean isInstalled() { return m_isInstalled; }
        public IList<String> GetTypes() { return m_Types; }
        public IList<String> GetContent() { return m_Content; }

        // ----------------

        public Boolean Contains(String Name)
        {
            if (m_Name == Name) return true;
            else return false;
        }
        public Boolean Contains(IList<String> Types)
        {
            if (m_Types == Types) return true;
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

    }
}
