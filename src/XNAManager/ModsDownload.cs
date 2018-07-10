using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ModsManager
{
    class ModsDownload
    {
        private IModsDownload modificationInfo;
        private BackgroundWorker bgWorker;

        public ModsDownload(IModsDownload applicationInfo)
        {
            this.modificationInfo = applicationInfo;

            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        }

        public void DoDownload()
        {
            if (!this.bgWorker.IsBusy)
                this.bgWorker.RunWorkerAsync(this.modificationInfo);
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IModsDownload modification = (IModsDownload)e.Argument;

            if (!ModsXml.ExistsOnServer(modification.XmlLocation))
                e.Cancel = true;
            else e.Result = ModsXml.Parse(modification.XmlLocation, modification.Game.GetName(), modification.ModificationName);
        }
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                ModsXml modXml = (ModsXml)e.Result;

                if (modXml != null && modXml.IsNewerThan(this.modificationInfo.ModificationVersion))
                {
                    this.Download(modXml);
                }
            }
        }

        private void Download(ModsXml modXml)
        {
            //String tempFile = Path.GetTempFileName();
            WebClient webClient = new WebClient();
            String ModDir = Path.Combine(Path.GetDirectoryName(this.modificationInfo.ApplicationAssembly.Location), this.modificationInfo.Game.GetFolderMods(), modXml.Name, Path.GetFileName(modXml.Uri.ToString()));

            if (!Directory.Exists(Path.GetDirectoryName(ModDir)))
                Directory.CreateDirectory(Path.GetDirectoryName(ModDir));

            try { webClient.DownloadFileAsync(modXml.Uri, ModDir); }
            catch { }
        }
    }
}