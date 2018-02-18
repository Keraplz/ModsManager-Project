using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class MainWindow : Form
    {
        static int n = 0;
        public MainWindow()
        {
            Startup StartupWindow_ = new Startup(Games.SpeedRunners);

            InitializeComponent();

            //Setup.MainSetup();

            label_baseinfo.Text = Definitions.toLabel_baseinfo;

            foreach (string modName in Directory.GetFiles(Setup.GetFolderMods(), "*.json"))
            {
                listBox_modslist.Items.Insert(n, Path.GetFileNameWithoutExtension(modName));
                n = n + 1;
            }
            n = 0;


            button_previewmod.Enabled = false;
            button_previewmod.BackColor = Color.LightGray;
            button_installmod.Enabled = false;
            button_installmod.BackColor = Color.LightGray;
        }

        private void listBox_modslist_MouseClick(object sender, MouseEventArgs e)
        {
            Maintenance.WriteModDefinitions(true);

            int index = this.listBox_modslist.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                string baseName = Definitions.toLabel_modName;
                foreach (string modName in Directory.GetFiles(Setup.GetFolderMods(), "*.json"))
                {
                    Definitions.toLabel_modName = Path.GetFileNameWithoutExtension(modName);
                    if (Definitions.toLabel_modName == listBox_modslist.SelectedItem.ToString())
                    {
                        label_title.Text = listBox_modslist.SelectedItem.ToString();
                        textBox_author.Text = Keraplz.JSON.Read.mods_GetAuthor(Definitions.toLabel_modName);
                        textBox_type.Text = Keraplz.JSON.Read.mods_GetType(Definitions.toLabel_modName);
                        textBox_description.Text = "    " + Keraplz.JSON.Read.mods_GetDescription(Definitions.toLabel_modName);
                    }

                    Definitions.toLabel_modName = baseName;
                }

                #region Enable Buttons

                button_previewmod.Enabled = true;
                button_previewmod.BackColor = Color.Transparent;
                button_installmod.Enabled = true;
                button_installmod.BackColor = Color.Transparent;

                #endregion

                #region Disable/Enable Preview button based on existence of image file

                int nPreview = 0;
                foreach (string extension in Definitions.previewExtensions)
                {
                    foreach (string preview in Directory.GetFiles(Setup.GetFolderMods() + "/" + label_title.Text, "*" + extension))
                    {
                        nPreview = nPreview + 1;
                    }
                }

                if (nPreview == 0)
                {
                    button_previewmod.Enabled = false;
                    button_previewmod.BackColor = Color.LightGray;
                }
                else
                {
                    button_previewmod.Enabled = true;
                    button_previewmod.BackColor = Color.Transparent;
                }

                #endregion

                #region Set "button_installmod" Text and Behavior

                if (Keraplz.JSON.Read.mods_GetInstalled(label_title.Text))
                {
                    button_installmod.Text = "Uninstall";
                }
                else button_installmod.Text = "Install";

                #endregion
            }
        }

        private void button_installmod_Click(object sender, EventArgs e)
        {
            if (button_installmod.Text == "Uninstall")
            {
                Setup.UninstallMod_(label_title.Text);
                if (!Keraplz.JSON.Read.mods_GetInstalled(label_title.Text))
                    button_installmod.Text = "Install";

                Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods - 1;
                Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
            }
            else if (button_installmod.Text == "Install")
            {
                Setup.InstallMod_(label_title.Text);
                if (Keraplz.JSON.Read.mods_GetInstalled(label_title.Text))
                    button_installmod.Text = "Uninstall";

                Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods + 1;
                Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
            }
        }

        private void button_previewmod_Click(object sender, EventArgs ea)
        {
            try
            {
                Boolean catchPreview = false;
                if (label_title.Text != Definitions.toLabel_modName)
                {
                    foreach (string extension in Definitions.previewExtensions)
                    {
                        if (catchPreview == false)
                            foreach (string preview in Directory.GetFiles(Setup.GetFolderMods() + "/" + label_title.Text, "*" + extension))
                            {
                                string path = System.IO.Directory.GetCurrentDirectory() + "/" + preview;
                                Process.Start(path);
                                catchPreview = true;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in XNAManager.button_previewmod_Click(" + sender.ToString() + ", " + ea.ToString() + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Program.Startup_.Close();
        }

        private void Label_UpdateInstalledCount(int input_installedMods)
        {
            Definitions.toLabel_baseinfo = "Game: " + Setup.GetGameName() + ", Build: " + Definitions.toLabel_baseinfo_CurrentBuild + ", SetupTime: " + Definitions.toLabel_baseinfo_SetupTime + ", Installed Mods: " + input_installedMods.ToString("00");
            label_baseinfo.Text = Definitions.toLabel_baseinfo;
        }
    }
}