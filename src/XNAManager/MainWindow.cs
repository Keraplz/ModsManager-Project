using Keraplz.AutoUpdate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ModsManager
{
    public partial class MainWindow : Form, IAutoUpdate
    {
        private AutoUpdate updater;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont, uint cbfont, IntPtr pdv, [In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        private IList<Mod> BannedMods;

        public MainWindow(Profile info_profile)
        {
            try
            {
                if (File.Exists("Keraplz.AutoUpdate.dll")) File.Delete("Keraplz.AutoUpdate.dll");
                if (File.Exists("Keraplz.JSON.dll")) File.Delete("Keraplz.JSON.dll");
                if (File.Exists("Keraplz.Resources.dll")) File.Delete("Keraplz.Resources.dll");
                if (Directory.Exists("SRModManager")) Directory.Delete("SRModManager", true);
            }
            catch { }

            BannedMods = Profiles.Default.GetBannedMods();

            //Profiles.Default = new Profile(Keraplz.JSON.Read.Configuration.GetProgramName(), Games.SpeedRunners, Keraplz.JSON.Read.Configuration.GetUIGraphics());

            //Startup StartupWindow_ = new Startup();
            InitializeComponent();
            this.Text = Profiles.Default.GetWindowName() + " [" + this.ApplicationAssembly.GetName().Version.ToString() + "]";
            updater = new AutoUpdate(this);

            textBox_gameName.Text = Profiles.Default.GetGame().GetName() + " " + Check.GetCurrentVersion();
            textBox_contentFolder.Text = Profiles.Default.GetGame().GetFolderContent();
            textBox_modsFolder.Text = Profiles.Default.GetGame().GetFolderMods();
            textBox_NFilesModded.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + " | " + Keraplz.JSON.Read.Content.GetNFiles().ToString("0000");

            label_baseinfo.Text = Definitions.toLabel_baseinfo;
            //label_filesused.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + "/" + Keraplz.JSON.Read.Content.GetNFiles().ToString("0000");

            int n = 0;
            foreach (string modName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
            {
                if (Directory.Exists(Profiles.Default.GetGame().GetFolderMods() + "/" + Path.GetFileNameWithoutExtension(modName)))
                {
                    listBox_modslist.Items.Insert(n, Path.GetFileNameWithoutExtension(modName));
            //        ListViewItem item = new ListViewItem(new String[] { "", Path.GetFileNameWithoutExtension(modName), "Test" });
            //        item.UseItemStyleForSubItems = false;
            //        item.SubItems[0].BackColor = Color.Gray;
            //        listView_modslist.Items.Insert(n, item);
                    n = n + 1;
                }
                else File.Delete(modName);
            }
            //listView_modslist.Items[0].SubItems[0].BackColor = Color.Red;
            //listView_modslist.Items[0].SubItems[0].ForeColor = Color.Red;

            //if (button_previewmod.Enabled) button_previewmod.Enabled = false;
            //if (button_previewmod.BackColor != Color.LightGray) button_previewmod.BackColor = Color.LightGray;
            if (button_installmod.Enabled) button_installmod.Enabled = false;
            if (button_installmod.BackColor != Color.LightGray) button_installmod.BackColor = Color.LightGray;

            if (n != 0)
            {
                listBox_modslist.SelectedIndex = 0;
                modsList_IndexChanged(listBox_modslist.SelectedIndex);
            }

            updater.DoUpdate();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SetFont(label_title, global::ModsManager.Properties.Resources.Coolvetica, 21.75F);
            SetFont(label_banned, global::ModsManager.Properties.Resources.Coolvetica, 20F);

            if (label_title.Visible) TransparentBackground(label_title);
            if (label_title.Visible) TransparentBackground(label_banned);
            if (label_baseinfo.Visible) TransparentBackground(label_baseinfo);
        }

        private void listView_modslist_MouseClick(object sender, MouseEventArgs e)
        {
            //string tolabel_types = "";
            //string baseName = Definitions.toLabel_modName;
            //foreach (string modName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
            //{
            //    Definitions.toLabel_modName = Path.GetFileNameWithoutExtension(modName);
            //    if (Definitions.toLabel_modName == listView_modslist.SelectedItems.ToString())
            //    {
            //        label_title.Text = listView_modslist.SelectedItems.ToString();
            //        textBox_author.Text = Keraplz.JSON.Read.Mods.GetAuthor(Definitions.toLabel_modName);
            //
            //        #region Set "button_installmod" Text and Behavior
            //
            //        if (Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
            //        {
            //            button_installmod.Text = "Uninstall";
            //        }
            //        else button_installmod.Text = "Install";
            //
            //        #endregion
            //
            //        #region Get mod Type List and set textBox_type.Text
            //
            //        int n = 0;
            //        if (n < Keraplz.JSON.Read.Mods.GetNType(Definitions.toLabel_modName))
            //        {
            //            foreach (string type in Keraplz.JSON.Read.Mods.GetType(Definitions.toLabel_modName))
            //            {
            //                tolabel_types = tolabel_types + type;
            //                n = n + 1;
            //
            //                if (n < Keraplz.JSON.Read.Mods.GetNType(Definitions.toLabel_modName))
            //                {
            //                    tolabel_types = tolabel_types + ", ";
            //                }
            //            }
            //
            //            textBox_type.Text = tolabel_types;
            //        }
            //
            //        #endregion
            //
            //        #region Enable Buttons
            //
            //        //if (!button_previewmod.Enabled) button_previewmod.Enabled = true;
            //        //if (button_previewmod.BackColor != Color.Transparent) button_previewmod.BackColor = Color.Transparent;
            //        if (!button_installmod.Enabled) button_installmod.Enabled = true;
            //        if (button_installmod.BackColor != Color.Transparent) button_installmod.BackColor = Color.Transparent;
            //
            //        #endregion
            //
            //        #region Check if mod is banned and change install button behavior
            //
            //        if (Check.GetModsToBan() != null)
            //        {
            //            foreach (string bannedmod in Check.GetModsToBan())
            //            {
            //                if (bannedmod == listBox_modslist.SelectedItem.ToString())
            //                {
            //                    if (Keraplz.JSON.Read.Mods.IsInstalled(bannedmod))
            //                    {
            //                        Setup.UninstallMod_(listBox_modslist.SelectedItem.ToString());
            //                        //if (ModsManager.IsSuccessful())
            //                        //{
            //                        if (!Keraplz.JSON.Read.Mods.IsInstalled(listBox_modslist.SelectedItem.ToString()))
            //                            button_installmod.Text = "Install";
            //
            //                        Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods - 1;
            //                        Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
            //                        //}
            //                    }
            //
            //                    //button_installmod.Text = "Banned";
            //                    if (button_installmod.Enabled) button_installmod.Enabled = false;
            //                    if (button_installmod.BackColor != Color.LightGray) button_installmod.BackColor = Color.LightGray;
            //                    if (label_title.ForeColor != Color.Gray) label_title.ForeColor = Color.Gray;
            //
            //                    break;
            //                }
            //                else
            //                {
            //                    //button_installmod.Text = "Banned";
            //                    if (!button_installmod.Enabled) button_installmod.Enabled = true;
            //                    if (button_installmod.BackColor != Color.Transparent) button_installmod.BackColor = Color.Transparent;
            //                    if (label_title.ForeColor != Color.Black) label_title.ForeColor = Color.Black;
            //                }
            //            }
            //        }
            //
            //        #endregion
            //
            //        #region Set mod Preview if available
            //
            //        if (label_title.Text == Definitions.toLabel_modName)
            //        {
            //            Boolean shouldbreak = false;
            //            foreach (string extension in Definitions.previewExtensions)
            //            {
            //                foreach (string preview in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods() + "/" + label_title.Text, "*" + extension))
            //                {
            //                    if (preview != null)
            //                    {
            //                        //this.image_infobg.Image = new Bitmap(Image.FromFile(preview));
            //                        this.image_infobg.Image = Image.FromFile(preview);
            //                        shouldbreak = true;
            //                        break;
            //                    }
            //                }
            //                if (shouldbreak) break;
            //            }
            //
            //            if (shouldbreak)
            //                this.image_infobg.Image = null;
            //        }
            //        else this.image_infobg.Image = null;
            //
            //        #endregion
            //
            //        textBox_description.Text = "    " + Keraplz.JSON.Read.Mods.GetDescription(Definitions.toLabel_modName);
            //    }
            //
            //    Definitions.toLabel_modName = baseName;
            //}
            //
            //#region Disable/Enable Preview button based on existence of image file
            //
            //int nPreview = 0;
            //foreach (string extension in Definitions.previewExtensions)
            //{
            //    foreach (string preview in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods() + "/" + label_title.Text, "*" + extension))
            //    {
            //        nPreview = nPreview + 1;
            //    }
            //}
            //
            //if (nPreview == 0)
            //{
            //    button_previewmod.Enabled = false;
            //    button_previewmod.BackColor = Color.LightGray;
            //}
            //else
            //{
            //    button_previewmod.Enabled = true;
            //    button_previewmod.BackColor = Color.Transparent;
            //
            //    nPreview = 0;
            //}
            //
            //#endregion
        }

        private void listView_modslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_modslist.SelectedItems.Count > 0)
            {
                ListViewItem item = listView_modslist.SelectedItems[0];
            }
            else
            {
            }
        }
        private void listBox_modslist_MouseClick(object sender, MouseEventArgs e)
        {
            //Setup.Maintenance_(Profiles.Default, true, true, true);

            int index = this.listBox_modslist.IndexFromPoint(e.Location);

            modsList_IndexChanged(index);
        }
        private void listBox_modslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            modsList_IndexChanged(listBox_modslist.SelectedIndex);
        }

        private void button_installmod_Click(object sender, EventArgs e)
        {
            if (button_installmod.Text == "Uninstall")
            {
                ModsManager.uninstallMod(Keraplz.JSON.Read.Mods.GetModByName(label_title.Text));
                //if (ModsManager.IsSuccessful())
                //{
                if (!Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
                    button_installmod.Text = "Install";

                Profiles.Default.RefreshBannedMods();
                BannedMods = Profiles.Default.GetBannedMods();

                Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods - 1;
                Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
                //}
            }
            else if (button_installmod.Text == "Install")
            {
                ModsManager.installMod(Keraplz.JSON.Read.Mods.GetModByName(label_title.Text));
                //if (ModsManager.IsSuccessful())
                //{
                if (Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
                    button_installmod.Text = "Uninstall";

                Profiles.Default.RefreshBannedMods();
                BannedMods = Profiles.Default.GetBannedMods();

                Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods + 1;
                Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
                //}
            }
        }
        private void button_previewmod_Click(object sender, EventArgs ea)
        {
            try
            {
                Boolean catchPreview = false;
                if (label_title.Text != Definitions.toLabel_modName)
                {
                    foreach (string extension in Profiles.Default.GetPreviewExt())
                    {
                        if (catchPreview == false)
                            foreach (string preview in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods() + "/" + label_title.Text, "*" + extension))
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
                LogFile.WriteLine("Error found in ModsManager.button_previewmod_Click()");
                LogFile.WriteLine(e.Message);
            }
        }
        private void button_modsfolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                Directory.CreateDirectory(Profiles.Default.GetGame().GetFolderMods());
            Process.Start(Profiles.Default.GetGame().GetFolderMods());
        }
        private void button_refresh_Click(object sender, EventArgs ea)
        {
            try
            {
                button_refresh.Enabled = false;
                button_modsfolder.Enabled = false;

                listBox_modslist.Enabled = false;
                listView_modslist.Enabled = false;

                listBox_modslist.Items.Clear();
                listView_modslist.Items.Clear();

                Setup.Maintenance_(Profiles.Default.GetProgramName(), Profiles.Default.GetGame(), Profiles.Default.GetMaintenancePaths(), Profiles.Default.GetMaintenanceFiles(), true, false);

                int n = 0;
                foreach (string modName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    if (Directory.Exists(Profiles.Default.GetGame().GetFolderMods() + "/" + Path.GetFileNameWithoutExtension(modName)))
                    {
                        listBox_modslist.Items.Insert(n, Path.GetFileNameWithoutExtension(modName));
                        //listView_modslist.Items.Insert(n, new ListViewItem(new String[] { "", Path.GetFileNameWithoutExtension(modName), "Test" }));
                        n = n + 1;
                    }
                    else File.Delete(modName);
                }
                n = 0;

                listBox_modslist.SelectedIndex = listBox_modslist.Items.Count - 1;

                listBox_modslist.Enabled = true;
                listView_modslist.Enabled = true;

                button_refresh.Enabled = true;
                button_modsfolder.Enabled = true;
            }
            catch (Exception e)
            {
                LogFile.WriteLine("Error found in ModsManager.button_refresh_Click()");
                LogFile.WriteLine(e.Message);
            }
        }

        private void modsList_IndexChanged(Int32 input_index)
        {
            int n = 0;
            string tolabel_types = "";

            if (input_index != System.Windows.Forms.ListBox.NoMatches)
            {
                string baseName = Definitions.toLabel_modName;
                foreach (string modPath in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json"))
                {
                    Definitions.toLabel_modName = Path.GetFileNameWithoutExtension(modPath);
                    if (Definitions.toLabel_modName == listBox_modslist.SelectedItem.ToString())
                    {
                        label_title.Text = listBox_modslist.SelectedItem.ToString();
                        //textBox_author.Text = Keraplz.JSON.Read.Mods.GetAuthor(Definitions.toLabel_modName);

                        #region Set "button_installmod" Text and Behavior

                        if (Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
                        {
                            button_installmod.Text = "Uninstall";
                        }
                        else button_installmod.Text = "Install";

                        #endregion

                        #region Get mod Type List and set textBox_type.Text

                        if (n < Keraplz.JSON.Read.Mods.GetNType(Definitions.toLabel_modName))
                        {
                            foreach (string type in Keraplz.JSON.Read.Mods.GetType(Definitions.toLabel_modName))
                            {
                                tolabel_types = tolabel_types + type;
                                n = n + 1;

                                if (n < Keraplz.JSON.Read.Mods.GetNType(Definitions.toLabel_modName))
                                {
                                    tolabel_types = tolabel_types + ", ";
                                }
                            }

                            textBox_type.Text = tolabel_types;
                        }

                        #endregion

                        #region Enable Buttons

                        //if (!button_previewmod.Enabled) button_previewmod.Enabled = true;
                        //if (button_previewmod.BackColor != Color.Transparent) button_previewmod.BackColor = Color.Transparent;
                        if (!button_installmod.Enabled) button_installmod.Enabled = true;
                        if (button_installmod.BackColor != Color.Transparent) button_installmod.BackColor = Color.Transparent;

                        #endregion

                        #region Check if mod is banned and change install button behavior

                        if (BannedMods != null)
                        {
                            Boolean IsBanned = false;
                            foreach (Mod bannedmod in BannedMods)
                            {
                                string banned_modName = bannedmod.GetName();
                                if (banned_modName == listBox_modslist.SelectedItem.ToString())
                                {
                                    if (Keraplz.JSON.Read.Mods.IsInstalled(banned_modName))
                                    {
                                        ModsManager.uninstallMod(Keraplz.JSON.Read.Mods.GetModByName(listBox_modslist.SelectedItem.ToString()));
                                        //if (ModsManager.IsSuccessful())
                                        //{
                                        if (!Keraplz.JSON.Read.Mods.IsInstalled(listBox_modslist.SelectedItem.ToString()))
                                            button_installmod.Text = "Install";

                                        Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods - 1;
                                        Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
                                        //}
                                    }

                                    IsBanned = true;

                                    //button_installmod.Text = "Banned";
                                    if (button_installmod.Enabled) button_installmod.Enabled = false;
                                    if (button_installmod.BackColor != Color.LightGray) button_installmod.BackColor = Color.LightGray;
                                    if (label_title.ForeColor != Color.Gray) label_title.ForeColor = Color.Gray;
                                    if (!label_banned.Visible) label_banned.Visible = true;

                                    break;
                                }
                                else IsBanned = false;
                            }
                            if (!IsBanned)
                            {
                                //button_installmod.Text = "Banned";
                                if (!button_installmod.Enabled) button_installmod.Enabled = true;
                                if (button_installmod.BackColor != Color.Transparent) button_installmod.BackColor = Color.Transparent;
                                if (label_title.ForeColor != Color.Black) label_title.ForeColor = Color.Black;
                                if (label_banned.Visible) label_banned.Visible = false;
                            }
                        }

                        #endregion

                        #region Set mod Preview if available

                        if (label_title.Text == Definitions.toLabel_modName)
                        {
                            Boolean shouldbreak = false;
                            foreach (string extension in Profiles.Default.GetPreviewExt())
                            {
                                foreach (string preview in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods() + "/" + label_title.Text, "*" + extension))
                                {
                                    if (preview != null)
                                    {
                                        //this.image_infobg.Image = new Bitmap(Image.FromFile(preview));
                                        if (Image.FromFile(preview).Height == Image.FromFile(preview).Width && Image.FromFile(preview).Height < 301 && Image.FromFile(preview).Width < 301)
                                        {
                                            if (Profiles.Default.IsBanned(Keraplz.JSON.Read.Mods.GetModByName(label_title.Text)))
                                            {
                                                SetBrightness(this.pictureBox_preview, new Bitmap(Image.FromFile(preview)));
                                                shouldbreak = true;
                                                break;
                                            }
                                            this.pictureBox_preview.Image = Image.FromFile(preview);
                                            shouldbreak = true;
                                            break;
                                        }
                                    }
                                }
                                if (shouldbreak) break;
                                else this.pictureBox_preview.Image = null;
                            }

                            if (shouldbreak)
                                this.image_infobg.Image = null;
                        }
                        else this.image_infobg.Image = null;

                        #endregion

                        //textBox_description.Text = "    " + Keraplz.JSON.Read.Mods.GetDescription(Definitions.toLabel_modName);
                    }

                    Definitions.toLabel_modName = baseName;
                }
            }
        }

        private void Label_UpdateInstalledCount(int input_installedMods)
        {
            Definitions.toLabel_baseinfo = "Game: " + Profiles.Default.GetGame().GetName() + ", Build: " + Definitions.toLabel_baseinfo_CurrentBuild + ", SetupTime: " + Definitions.toLabel_baseinfo_SetupTime + ", Installed Mods: " + input_installedMods.ToString("00");
            label_baseinfo.Text = Definitions.toLabel_baseinfo;

            label_filesused.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + "/" + Keraplz.JSON.Read.Content.GetNFiles().ToString("0000");
            textBox_NFilesModded.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + " | " + Keraplz.JSON.Read.Content.GetNFiles().ToString("0000");
        }


        private void TransparentBackground(Control C)
        {
            Boolean IsVisible = false;
            if (C.Visible) IsVisible = true;

            C.Visible = false;

            try
            {
                C.Refresh();
                Application.DoEvents();

                Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
                int titleHeight = screenRectangle.Top - this.Top;
                int Right = screenRectangle.Left - this.Left;
                Bitmap bmp = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                Bitmap bmpImage = new Bitmap(bmp);
                bmp = bmpImage.Clone(new Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
                C.BackgroundImage = bmp;
            }
            catch (ArgumentException e)
            {
                LogFile.WriteLine("Error found in ModsManager.MainWindow.TransparentBackground(Control " + C.Name + ")");
                LogFile.WriteLine(e.Message);
            }

            if (IsVisible) C.Visible = true;
        }
        private void SetFont(Label input_label, byte[] input_font, float input_size)
        {
            byte[] fontArray = input_font;
            int dataLength = input_font.Length;

            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);

            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;

            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            System.Drawing.Text.PrivateFontCollection pfc = new System.Drawing.Text.PrivateFontCollection();

            pfc.AddMemoryFont(ptrData, dataLength);

            Marshal.FreeCoTaskMem(ptrData);

            ff = pfc.Families[0];
            font = new Font(ff, input_size);

            input_label.Font = font;
        }
        private void SetBrightness(PictureBox pictureBox, Bitmap image, float limit = 0.5f)
        {
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color c = image.GetPixel(i, j);
                    if (c.GetBrightness() > limit)
                    {
                        image.SetPixel(i, j, Color.White);
                    }
                }
            }

            pictureBox.Image = image;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            IList<Bitmap> images = new List<Bitmap>();

            //images.Add(global::ModsManager.Properties.Resources.preview_xl);
            //images.Add(global::ModsManager.Properties.Resources.PreviewBorder);

            if (images.Count != 0)
                foreach (Bitmap myBitmap in images)
                {
                    // Create a Bitmap object from an image file.
                    //Bitmap myBitmap = new Bitmap(Image.FromFile(image));

                    // Get the color of a background pixel.
                    //Color backColor = myBitmap.GetPixel(1, 1);

                    // Make backColor transparent for myBitmap.
                    myBitmap.MakeTransparent(Color.FromArgb(0));

                    // Draw myBitmap to the screen.
                    e.Graphics.DrawImage(myBitmap, image_infobg.Location.X, image_infobg.Location.Y, myBitmap.Width, myBitmap.Height);
                    //e.Graphics.DrawImage(myBitmap, image_infobg.Location.X, image_infobg.Location.Y, image_infobg.Width, image_infobg.Height);
                }
        }


        public String ApplicationName
        {
            get { return "SRModManager"; }
        }

        public String ApplicationID
        {
            get { return "SRModManager"; }
        }

        public Assembly ApplicationAssembly
        {
            get { return Assembly.GetExecutingAssembly(); }
        }

        public Icon ApplicationIcon
        {
            get { return this.Icon; }
        }

        public Uri UpdateXmlLocation
        {
            get { return new Uri(Profiles.Default.GetXmlUrl()); }
        }

        public Form Context
        {
            get { return this; }
        }
    }
}