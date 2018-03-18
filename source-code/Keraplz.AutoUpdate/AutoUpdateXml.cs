using System;
using System.Net;
using System.Xml;

namespace Keraplz.AutoUpdate
{
    internal class AutoUpdateXml
    {
        private Version version;
        private Uri uri;
        private String fileName;
        private String md5;
        private String description;
        private String launchArgs;

        internal Version Version
        {
            get { return this.version; }
        }
        internal Uri Uri
        {
            get { return this.uri; }
        }
        internal String FileName
        {
            get { return this.fileName; }
        }
        internal String MD5
        {
            get { return this.md5; }
        }
        internal String Description
        {
            get { return this.description; }
        }
        internal String LaunchArgs
        {
            get { return this.launchArgs; }
        }

        internal AutoUpdateXml(Version version, Uri uri, String fileName, String md5, String description, String launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.fileName = fileName;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        internal Boolean IsNewerThan(Version version)
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

        internal static AutoUpdateXml Parse(Uri location, String appID)
        {
            Version version = null;
            String url = "";
            String fileName = "";
            String md5 = "";
            String description = "";
            String launchArgs = "";

            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(location.AbsoluteUri);

                XmlNode node = document.DocumentElement.SelectSingleNode("//update[@appId='" + appID + "']");

                if (node == null)
                    return null;

                version = Version.Parse(node["version"].InnerText);
                url = node["url"].InnerText;
                fileName = node["fileName"].InnerText;
                md5 = node["md5"].InnerText;
                description = node["description"].InnerText;
                launchArgs = node["launchArgs"].InnerText;

                return new AutoUpdateXml(version, new Uri(url), fileName, md5, description, launchArgs);

            }
            catch { return null; }

        }
    }
}