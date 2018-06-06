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

        Color Default = SystemColors.Window;
        Color Installed = Color.LightGreen;
        Color Banned = Color.Red;
        Color nonLoaded = Color.Yellow;
        Color Selected = SystemColors.Highlight;

        private Game CurrentGame = Games.SpeedRunners;

        private string GameVer = string.Empty;
        private string StartupTime = string.Empty;
        private int NInstalledMods = 0;

        private IList<Mod> BannedMods;

        private bool Dev = false;

        public MainWindow(string uptime, bool m_Dev = false)
        {
            try
            {
                if (File.Exists("Keraplz.AutoUpdate.dll")) File.Delete("Keraplz.AutoUpdate.dll");
                if (File.Exists("Keraplz.JSON.dll")) File.Delete("Keraplz.JSON.dll");
                if (File.Exists("Keraplz.Resources.dll")) File.Delete("Keraplz.Resources.dll");
                if (Directory.Exists("SRModManager")) Directory.Delete("SRModManager", true);
            }
            catch { }

            InitializeComponent();

            string Mode = string.Empty;
            if (m_Dev) Mode = "[Beta]";
            LogFile.WriteInfo(CurrentGame, Mode);

            var timeRecord = System.Diagnostics.Stopwatch.StartNew();

            // ----

            Profiles.Default = new Profile(Profiles.Blank.GetProgramName(), CurrentGame);
            //Profiles.CurrentProfile = Profiles.Default;

            // ----

            timeRecord.Stop();
            TimeSpan time = TimeSpan.FromMilliseconds(timeRecord.ElapsedMilliseconds);

            uptime = time.ToString(@"ss\:fff");
            BannedMods = Profiles.Default.GetBannedMods();
            Dev = m_Dev;

            //Profiles.Default = new Profile(Keraplz.JSON.Read.Configuration.GetProgramName(), Games.SpeedRunners, Keraplz.JSON.Read.Configuration.GetUIGraphics());

            //Startup StartupWindow_ = new Startup();
            this.Text = Profiles.Default.GetWindowName() + " [" + this.ApplicationAssembly.GetName().Version.ToString() + "]";
            updater = new AutoUpdate(this);

            GameVer = Check.GetCurrentVersion();
            StartupTime = uptime;
            NInstalledMods = Keraplz.JSON.Read.Mods.GetNInstalled();

            textBox_gameName.Text = Profiles.Default.GetGame().GetName() + " " + Check.GetCurrentVersion();
            textBox_contentFolder.Text = Profiles.Default.GetGame().GetFolderContent();
            textBox_modsFolder.Text = Profiles.Default.GetGame().GetFolderMods();

            Label_UpdateInfo(Profiles.Default.GetGame());

            IList<Mod> modList = new List<Mod>();
            int n = 0;
            string modTypes = string.Empty;
            Color modStatus = Color.Empty;

            //foreach (string modName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json")) modList.Add(Keraplz.JSON.Read.Mods.GetModByName(Path.GetFileNameWithoutExtension(modName)));
            //foreach (Mod modInfo in modList)
            foreach (Mod modInfo in Profiles.Default.GetMods())
            {
                if (Directory.Exists(Profiles.Default.GetGame().GetFolderMods() + "/" + modInfo.GetName()))
                {
                    modTypes = string.Empty;
                    modStatus = Color.Empty;

                    int i = 0;
                    if (i < modInfo.GetTypes().Count)
                    {
                        foreach (string modType in modInfo.GetTypes())
                        {
                            foreach (string gameType in Keraplz.JSON.Read.Content.GetTypes(Profiles.Default.GetGame().GetFolderContent()))
                            {
                                if (gameType.ToLower() == modType.ToLower())
                                {
                                    modTypes += gameType;
                                    i = i + 1;

                                    if (i < modInfo.GetTypes().Count)
                                        modTypes += ", ";
                                }
                            }
                        }
                    }
                    if (modInfo.isInstalled()) modStatus = Installed;
                    else if (modInfo.isBanned()) modStatus = Banned;

                    ListViewItem modItem = new ListViewItem(new String[] { string.Empty, modInfo.GetName(), modTypes });
                    modItem.UseItemStyleForSubItems = false;
                    modItem.SubItems[0].BackColor = modStatus;
                    modItem.SubItems[0].ForeColor = modStatus;
                    listView_modslist.Items.Insert(n, modItem);

                    n = n + 1;
                }
                else File.Delete(modInfo.GetName());
            }

            //if (button_previewmod.Enabled) button_previewmod.Enabled = false;
            //if (button_previewmod.BackColor != Color.LightGray) button_previewmod.BackColor = Color.LightGray;
            if (button_installmod.Enabled) button_installmod.Enabled = false;
            if (button_installmod.BackColor != Color.LightGray) button_installmod.BackColor = Color.LightGray;

            if (n != 0)
            {
                listView_modslist.Items[0].Selected = true;
                IndexChanged(0);
            }

            if (Dev) button_unload.Visible = true;
            if (Dev) button_hardreset.Visible = true;

            button_refresh.Visible = false;

            updater.DoUpdate();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            SetFont(label_title, global::ModsManager.Properties.Resources.Coolvetica, 21.75F);
            //SetFont(label_modStatus, global::ModsManager.Properties.Resources.Coolvetica, 20F);

            if (label_title.Visible) TransparentBackground(label_title);
            if (label_modStatus.Visible) TransparentBackground(label_modStatus);
            if (label_baseinfo.Visible) TransparentBackground(label_baseinfo);
        }

        private void listView_modslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_modslist.SelectedItems.Count == 1)
            {
                IndexChanged(listView_modslist.SelectedIndices[0]);

                // Deselect ListView to hide Highlight Color
                if (listView_modslist.FocusedItem != null)
                    listView_modslist.FocusedItem.Focused = false;
                if (listView_modslist.SelectedItems.Count != 0)
                    listView_modslist.SelectedItems[0].Selected = false;
            }
            else
            {
            }
        }

        private void button_hardreset_Click(object sender, EventArgs e)
        {

        }
        private void button_unload_Click(object sender, EventArgs e)
        {
            try {
                //Mod SelectedMod = Keraplz.JSON.Read.Mods.GetModByName(listView_modslist.SelectedItems[listView_modslist.SelectedIndices[1]].SubItems[1].Text);
            } catch { }

            Mod SelectedMod = Keraplz.JSON.Read.Mods.GetModByName(label_title.Text);

            if (button_unload.Text == "Unload")
            {
                Boolean Success = Profiles.Default.Unload(SelectedMod);
                if (Success)
                {
                    if (!Profiles.Default.isLoaded(SelectedMod))
                        button_unload.Text = "Load";

                    if (Dev) BannedMods.Remove(SelectedMod);
                    else BannedMods = Profiles.Default.GetBannedMods();
                }
            }
            else if (button_unload.Text == "Load")
            {
                Boolean Success = Profiles.Default.Load(SelectedMod);
                if (Success)
                {
                    if (Profiles.Default.isLoaded(SelectedMod))
                        button_unload.Text = "Unload";

                    if (Dev) BannedMods.Add(SelectedMod);
                    else BannedMods = Profiles.Default.GetBannedMods();
                }
            }

            //Profiles.Default.Unload(SelectedMod);
        }
        private void button_installmod_Click(object sender, EventArgs e)
        {
            if (button_installmod.Text == "Uninstall")
            {
                Boolean Success = ModsManager.Uninstall(Keraplz.JSON.Read.Mods.GetModByName(label_title.Text));
                if (Success)
                {
                    if (!Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
                        button_installmod.Text = "Install";

                    Profiles.Default.Refresh();
                    BannedMods = Profiles.Default.GetBannedMods();

                    NInstalledMods = NInstalledMods - 1;
                    Label_UpdateInfo(Profiles.Default.GetGame());
                }
            }
            else if (button_installmod.Text == "Install")
            {
                Boolean Success = ModsManager.Install(Keraplz.JSON.Read.Mods.GetModByName(label_title.Text));
                if (Success)
                {
                    if (Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
                        button_installmod.Text = "Uninstall";

                    Profiles.Default.Refresh();
                    BannedMods = Profiles.Default.GetBannedMods();

                    NInstalledMods = NInstalledMods + 1;
                    Label_UpdateInfo(Profiles.Default.GetGame());
                }
            }

            Label_UpdateStatus(label_title.Text);
            RefreshListViewColors(Keraplz.JSON.Read.Mods.GetModByName(label_title.Text), false, true);
        }
        private void button_modsfolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                Directory.CreateDirectory(Profiles.Default.GetGame().GetFolderMods());
            Process.Start(Profiles.Default.GetGame().GetFolderMods());
        }
        private void button_refresh_Click(object sender, EventArgs ea)
        {
            IList<Mod> modList = new List<Mod>();
            int n = 0;
            string modTypes = string.Empty;
            Color modStatus = Color.Empty;

            button_refresh.Enabled = false;
            button_modsfolder.Enabled = false;
            button_installmod.Enabled = false;

            listView_modslist.Enabled = false;

            try
            {
                listView_modslist.Items.Clear();

                Setup.Maintenance_(Profiles.Default.GetProgramName(), Profiles.Default.GetGame(), Profiles.Default.GetMaintenancePaths(), Profiles.Default.GetMaintenanceFiles(), true, false);

                Profiles.Default.Refresh();
                BannedMods = Profiles.Default.GetBannedMods();

                //foreach (string modName in Directory.GetFiles(Profiles.Default.GetGame().GetFolderMods(), "*.json")) modList.Add(Keraplz.JSON.Read.Mods.GetModByName(Path.GetFileNameWithoutExtension(modName)));
                //foreach (Mod modInfo in modList)
                foreach (Mod modInfo in Profiles.Default.GetMods())
                {
                    if (!modInfo.isLoaded())
                    {
                        ListViewItem modItem = new ListViewItem(new String[] { string.Empty, modInfo.GetName(), string.Empty });
                        modItem.UseItemStyleForSubItems = false;
                        modItem.SubItems[0].BackColor = nonLoaded;
                        modItem.SubItems[0].ForeColor = nonLoaded;
                        listView_modslist.Items.Insert(n, modItem);

                        n = n + 1;
                    }
                    else
                    {
                        if (Directory.Exists(Path.Combine(Profiles.Default.GetGame().GetFolderMods(), modInfo.GetName())))
                        {
                            modTypes = string.Empty;
                            int i = 0;
                            if (i < modInfo.GetTypes().Count)
                            {
                                foreach (string modType in modInfo.GetTypes())
                                {
                                    modTypes += modType;
                                    i = i + 1;

                                    if (i < modInfo.GetTypes().Count)
                                        modTypes += ", ";
                                }
                            }

                            ListViewItem modItem = new ListViewItem(new String[] { string.Empty, modInfo.GetName(), modTypes });
                            modItem.UseItemStyleForSubItems = false;
                            modItem.SubItems[0].BackColor = Default;
                            modItem.SubItems[0].ForeColor = Default;
                            listView_modslist.Items.Insert(n, modItem);

                            n = n + 1;
                        }
                        else File.Delete(modInfo.GetName());
                    }
                }
                if (n != 0)
                {
                    listView_modslist.Items[0].Selected = true;
                    IndexChanged(0);
                }
            }
            catch (Exception e)
            {
                LogFile.WriteError(e); // ModsManager.button_refresh_Click(), line " + line);
                //LogFile.WriteLine(e.Message);
            }

            Label_UpdateStatus(label_title.Text);

            listView_modslist.Enabled = true;

            button_refresh.Enabled = true;
            button_modsfolder.Enabled = true;
            button_installmod.Enabled = true;
        }

        private void IndexChanged(Int32 Index)
        {
            Boolean IsSelected = false;
            Boolean IsBanned = false;
            Boolean IsInstalled = false;
            Boolean IsLoaded = false;

            if (Index != System.Windows.Forms.ListBox.NoMatches)
            {
                foreach (Mod modInfo in Profiles.Default.GetMods())
                {
                    //if (Definitions.toLabel_modName == listBox_modslist.SelectedItem.ToString())
                    if (modInfo.GetName() == listView_modslist.Items[Index].SubItems[1].Text)
                    {
                        IsSelected = true;

                        //label_title.Text = listBox_modslist.SelectedItem.ToString();
                        label_title.Text = listView_modslist.Items[Index].SubItems[1].Text;
                        //textBox_author.Text = Keraplz.JSON.Read.Mods.GetAuthor(Definitions.toLabel_modName);
                        #region Set "button_installmod" Text and Behavior

                        if (Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text)) IsInstalled = true;
                        else IsInstalled = false;

                        if (IsInstalled)
                        {
                            button_installmod.Text = "Uninstall";
                        }
                        else button_installmod.Text = "Install";

                        #endregion

                        if (Profiles.Default.isLoaded(modInfo)) IsLoaded = true;
                        else IsLoaded = false;

                        if (IsLoaded)
                        {
                            button_unload.Text = "Unload";
                        }
                        else button_unload.Text = "Load";


                        #region Enable Buttons

                        //if (!button_previewmod.Enabled) button_previewmod.Enabled = true;
                        //if (button_previewmod.BackColor != Color.Transparent) button_previewmod.BackColor = Color.Transparent;
                        //if (!button_installmod.Enabled) button_installmod.Enabled = true;
                        if (button_installmod.BackColor != Color.Transparent) button_installmod.BackColor = Color.Transparent;

                        #endregion

                        #region Check if mod is banned and change install button behavior

                        if (BannedMods != null)
                        {
                            foreach (Mod BannedModInfo in BannedMods)
                            {
                                string BannedModName = BannedModInfo.GetName();
                                //if (banned_modName == listBox_modslist.SelectedItem.ToString())
                                if (BannedModName == listView_modslist.Items[Index].SubItems[1].Text)
                                {
                                    if (BannedModInfo.isInstalled())
                                    {
                                        ModsManager.Uninstall(BannedModInfo);
                                        //if (ModsManager.IsSuccessful())
                                        //{
                                        //if (!Keraplz.JSON.Read.Mods.IsInstalled(listBox_modslist.SelectedItem.ToString()))
                                        if (!BannedModInfo.isInstalled())
                                            button_installmod.Text = "Install";

                                        NInstalledMods = NInstalledMods - 1;
                                        Label_UpdateInfo(Profiles.Default.GetGame());
                                        //}
                                    }

                                    IsBanned = true;

                                    //button_installmod.Text = "Banned";
                                    //if (button_installmod.Enabled) button_installmod.Enabled = false;
                                    //if (button_installmod.BackColor != Color.LightGray) button_installmod.BackColor = Color.LightGray;
                                    //if (label_title.ForeColor != Color.Gray) label_title.ForeColor = Color.Gray;
                                    //if (!label_modStatus.Visible) label_modStatus.Visible = true;

                                    break;
                                }
                                else IsBanned = false;
                            }
                            if (!IsBanned)
                            {
                                //button_installmod.Text = "Banned";
                                //if (!button_installmod.Enabled) button_installmod.Enabled = true;
                                //if (button_installmod.BackColor != Color.Transparent) button_installmod.BackColor = Color.Transparent;
                                //if (label_title.ForeColor != Color.Black) label_title.ForeColor = Color.Black;
                                //if (label_modStatus.Visible) label_modStatus.Visible = false;
                            }
                        }

                        #endregion

                        #region Set mod Preview if available

                        if (label_title.Text == modInfo.GetName())
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
                                            //if (Profiles.Default.isBanned(Keraplz.JSON.Read.Mods.GetModByName(label_title.Text)))
                                            //{
                                            //    SetBrightness(this.pictureBox_preview, new Bitmap(Image.FromFile(preview)));
                                            //    shouldbreak = true;
                                            //    break;
                                            //}
                                            this.pictureBox_preview.Image = Image.FromFile(preview);
                                            shouldbreak = true;
                                            break;
                                        }
                                    }
                                }
                                if (shouldbreak) break;
                                else this.pictureBox_preview.Image = null;
                            }

                            if (!shouldbreak)
                            {
                                label_title.Location = new System.Drawing.Point(9, label_title.Location.Y);
                                label_modStatus.Location = new System.Drawing.Point(9, label_modStatus.Location.Y);
                                label_modSize.Location = new System.Drawing.Point(9, label_modSize.Location.Y);
                            }
                            else
                            {
                                label_title.Location = new System.Drawing.Point(91, label_title.Location.Y);
                                label_modStatus.Location = new System.Drawing.Point(91, label_modStatus.Location.Y);
                                label_modSize.Location = new System.Drawing.Point(91, label_modSize.Location.Y);
                            }

                            //if (shouldbreak)
                            //    this.image_infobg.Image = null;
                        }
                        //else this.image_infobg.Image = null;

                        #endregion

                        label_modSize.Visible = true;
                        label_modSize.Text = modInfo.GetSize();

                        Label_UpdateStatus(modInfo);
                        RefreshListViewColors(modInfo, IsBanned, IsSelected);

                        //textBox_description.Text = "    " + Keraplz.JSON.Read.Mods.GetDescription(Definitions.toLabel_modName);
                    }
                }
            }
        }

        private void Label_UpdateStatus(Mod modInfo)
        {
            if (!modInfo.isLoaded() && !modInfo.isBanned())
            {
                label_modStatus.Text = "DISABLED";

                if (modInfo.isInstalled()) label_modStatus.Text += " - INSTALLED";

                button_installmod.Enabled = false;
                button_installmod.BackColor = Color.LightGray;
            }
            else if (modInfo.isBanned())
            {
                label_modStatus.Text = "BANNED";
                button_installmod.Enabled = false;
                button_installmod.BackColor = Color.LightGray;
            }
            else if (modInfo.isInstalled())
            {
                label_modStatus.Text = "INSTALLED";
                button_installmod.Enabled = true;
                button_installmod.BackColor = Color.Transparent;
            }
            else
            {
                label_modStatus.Text = "IDLE";
                button_installmod.Enabled = true;
                button_installmod.BackColor = Color.Transparent;
            }
            RefreshListViewColors(modInfo, false, true);
        }
        private void Label_UpdateStatus(string modName)
        {
            Mod modInfo = Keraplz.JSON.Read.Mods.GetModByName(modName);
            Label_UpdateStatus(modInfo);
        }
        private void Label_UpdateInfo(Game Game)
        {
            label_baseinfo.Text = "Game: " + Game.GetName() + " " + GameVer + ", StartupTime: " + StartupTime + ", Installed Mods: " + NInstalledMods.ToString("00");

            label_filesused.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + "/" + Keraplz.JSON.Read.Content.GetNFiles().ToString("0000");
            textBox_NFilesModded.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + " | " + Keraplz.JSON.Read.Content.GetNFiles().ToString("0000");
        }

        private void RefreshListViewColors(Mod modInfo, Boolean isBanned = false, Boolean isSelected = true/*, Color Status, Color Name, Color Type*/)
        {
            int n = 0;
            Color Status, Name, Type;

            while (n < listView_modslist.Items.Count)
            {
                Status = Default;
                Name = Default;
                Type = Default;

                if (listView_modslist.Items[n].SubItems[1].Text == modInfo.GetName())
                {
                    if (modInfo.isInstalled() && isBanned)
                        ModsManager.Uninstall(modInfo);

                    if (isSelected) Name = Selected;
                    if (isSelected) Type = Selected;

                    if (modInfo.isLoaded())
                    {
                        if (modInfo.isInstalled()) Status = Installed;
                        else if (modInfo.isBanned()) Status = Banned;
                    }
                    else if (modInfo.isBanned()) Status = Banned;
                    else Status = nonLoaded;
                }
                else
                {
                    Mod modInfo_ = Keraplz.JSON.Read.Mods.GetModByName(listView_modslist.Items[n].SubItems[1].Text);

                    Name = Default;
                    Type = Default;

                    if (modInfo_.isLoaded())
                    {
                        if (modInfo_.isInstalled()) Status = Installed;
                        else if (modInfo_.isBanned()) Status = Banned;
                    }
                    else if (modInfo_.isBanned()) Status = Banned;
                    else Status = nonLoaded;
                }
                
                listView_modslist.Items[n].SubItems[0].BackColor = Status;
                listView_modslist.Items[n].SubItems[0].ForeColor = Status;

                listView_modslist.Items[n].SubItems[1].BackColor = Name;

                listView_modslist.Items[n].SubItems[2].BackColor = Type;

                n = n + 1;
            }
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
                LogFile.WriteError(e);
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
                    /*e.Graphics.DrawImage(myBitmap, image_infobg.Location.X, image_infobg.Location.Y, myBitmap.Width, myBitmap.Height);*/
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