using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ModsManager
{
    internal class ModsXml
    {
            private String name;
            private Int32 version;
            private Uri uri;
            private Uri preview;
            private String description;

            internal String Name
            {
                get { return this.name; }
            }
            internal Int32 Version
            {
                get { return this.version; }
            }
            internal Uri Uri
            {
                get { return this.uri; }
            }
            internal Uri Preview
            {
                get { return this.preview; }
            }
            internal String Description
            {
                get { return this.description; }
            }

            internal ModsXml(String name, Int32 version, Uri uri, Uri preview, String description)
            {
                this.name = name;
                this.version = version;
                this.uri = uri;
                this.preview = preview;
                this.description = description;
            }

            internal Boolean IsNewerThan(Int32 version)
            {
                return this.version > version;
            }

            internal static Boolean ExistsOnServer(Uri location)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    response.Close();

                    return response.StatusCode == HttpStatusCode.OK;
                }
                catch { return false; }
            }

            internal static ModsXml Parse(Uri location, String GameName, String ModificationName)
            {
                String name = string.Empty;
                Int32 version = 0;
                String url = string.Empty;
                String preview = string.Empty;
                String description = string.Empty;

                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(location.AbsoluteUri);

                    XmlNode node = document.DocumentElement.SelectSingleNode("//mods[@game='" + GameName + "']").SelectSingleNode("//mod[@name='" + ModificationName + "']");

                    if (node == null)
                        return null;

                    name = node["name"].InnerText;
                    version = Int32.Parse(node["version"].InnerText);
                    url = node["url"].InnerText;
                    preview = node["preview"].InnerText;
                    description = node["description"].InnerText;

                    return new ModsXml(name, version, new Uri(url), new Uri(preview), description);

                }
                catch { return null; }

            }

            internal static IList<ModsXml> Parse(Uri location, String GameName)
            {
                IList<ModsXml> XmlList = new List<ModsXml>();

                String name = string.Empty;
                Int32 version = 0;
                String url = string.Empty;
                String preview = string.Empty;
                String description = string.Empty;

                try
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(location.AbsoluteUri);

                    //XmlNode node = document.DocumentElement.SelectSingleNode("//mods[@game='" + GameName + "']");

                    XmlNodeList nodeList = document.DocumentElement.SelectSingleNode("//mods[@game='" + GameName + "']").ChildNodes;//.SelectNodes("//mod");

                    foreach (XmlNode node in nodeList)
                    {
                        name = node["name"].InnerText;
                        version = Int32.Parse(node["version"].InnerText);
                        url = node["url"].InnerText;
                        preview = node["preview"].InnerText;
                        description = node["description"].InnerText;

                        XmlList.Add(new ModsXml(name, version, new Uri(url), new Uri(preview), description));
                    }

                    return XmlList;

                }
                catch { return null; }

            }
    }
}