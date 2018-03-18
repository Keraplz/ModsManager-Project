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

        DirectoryInfo info;

        private IList<String> bannedMods = new List<String>();

        public MainWindow()
        {
            if (File.Exists("Keraplz.AutoUpdate.dll")) File.Delete("Keraplz.AutoUpdate.dll");
            if (File.Exists("Keraplz.JSON.dll")) File.Delete("Keraplz.JSON.dll");
            if (File.Exists("Keraplz.Resources.dll")) File.Delete("Keraplz.Resources.dll");

            //if (Directory.Exists(Definitions.ProgramName + "/_content/"))
            //{
            //    info = new DirectoryInfo(Definitions.ProgramName + "/_content/");
            //    foreach (FileInfo file in info.GetFiles())
            //        if (file.Exists)
            //            file.Delete();
            //    foreach (DirectoryInfo dir in info.GetDirectories())
            //        if (dir.Exists)
            //            dir.Delete(true);
            //}

            Startup StartupWindow_ = new Startup(Games.SpeedRunners);

            bannedMods = Definitions.BannedMods;

            InitializeComponent();

            this.Text = Definitions.WindowName + " [" + this.ApplicationAssembly.GetName().Version.ToString() + "]";
            updater = new AutoUpdate(this);

            label_baseinfo.Text = Definitions.toLabel_baseinfo;
            label_filesused.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + "/" + Definitions.NContent.ToString("0000");

            int n = 0;
            foreach (string modName in Directory.GetFiles(Setup.GetFolderMods(), "*.json"))
            {
                if (Directory.Exists(Setup.GetFolderMods() + "/" + Path.GetFileNameWithoutExtension(modName)))
                {
                    listBox_modslist.Items.Insert(n, Path.GetFileNameWithoutExtension(modName));
                    //listView_modslist.Items.Insert(n, new ListViewItem(new String[] { "", Path.GetFileNameWithoutExtension(modName), "Test" }));
                    n = n + 1;
                }
                else File.Delete(modName);
            }
            n = 0;

            listBox_modslist.SelectedIndex = 0;
            modsList_IndexChanged(listBox_modslist.SelectedIndex);

            if (button_previewmod.Enabled) button_previewmod.Enabled = false;
            if (button_previewmod.BackColor != Color.LightGray) button_previewmod.BackColor = Color.LightGray;
            if (button_installmod.Enabled) button_installmod.Enabled = false;
            if (button_installmod.BackColor != Color.LightGray) button_installmod.BackColor = Color.LightGray;

            textBox_description.Visible = false;
            textBox_author.Visible = false;
            label_author.Visible = false;

            updater.DoUpdate();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            loadFont_title(global::ModsManager.Properties.Resources.Coolvetica, 21.75F);

            if (label_title.Visible) TransparentBackground(label_title);
            if (label_author.Visible) TransparentBackground(label_author);
            if (label_type.Visible) TransparentBackground(label_type);
            if (label_description.Visible) TransparentBackground(label_description);
            if (label_baseinfo.Visible) TransparentBackground(label_baseinfo);
        }

        private void listView_modslist_MouseClick(object sender, MouseEventArgs e)
        {
            //string tolabel_types = "";
            //string baseName = Definitions.toLabel_modName;
            //foreach (string modName in Directory.GetFiles(Setup.GetFolderMods(), "*.json"))
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
            //                foreach (string preview in Directory.GetFiles(Setup.GetFolderMods() + "/" + label_title.Text, "*" + extension))
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
            //    foreach (string preview in Directory.GetFiles(Setup.GetFolderMods() + "/" + label_title.Text, "*" + extension))
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

        private void listBox_modslist_MouseClick(object sender, MouseEventArgs e)
        {
            Maintenance.WriteModDefinitions(true);

            int index = this.listBox_modslist.IndexFromPoint(e.Location);

            modsList_IndexChanged(index);
        }

        private void button_installmod_Click(object sender, EventArgs e)
        {
            if (button_installmod.Text == "Uninstall")
            {
                Setup.UninstallMod_(label_title.Text);
                if (ModsManager.IsSuccessful())
                {
                    if (!Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
                        button_installmod.Text = "Install";

                    Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods - 1;
                    Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
                }
            }
            else if (button_installmod.Text == "Install")
            {
                Setup.InstallMod_(label_title.Text);
                if (ModsManager.IsSuccessful())
                {
                    if (Keraplz.JSON.Read.Mods.IsInstalled(label_title.Text))
                        button_installmod.Text = "Uninstall";

                    Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods + 1;
                    Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
                }
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
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.button_previewmod_Click()");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }
        }
        private void button_modsfolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Definitions.ModsFolder);
            }
            catch (Win32Exception win32Exception)
            {
                // The system cannot find the directory specified...
                //Console.WriteLine(win32Exception.Message);

                Directory.CreateDirectory(Definitions.ModsFolder);
                Process.Start(Definitions.ModsFolder);
            }
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

                int n = 0;
                foreach (string modName in Directory.GetFiles(Setup.GetFolderMods(), "*.json"))
                {
                    if (Directory.Exists(Setup.GetFolderMods() + "/" + Path.GetFileNameWithoutExtension(modName)))
                    {
                        listBox_modslist.Items.Insert(n, Path.GetFileNameWithoutExtension(modName));
                        //listView_modslist.Items.Insert(n, new ListViewItem(new String[] { "", Path.GetFileNameWithoutExtension(modName), "Test" }));
                        n = n + 1;
                    }
                    else File.Delete(modName);
                }
                n = 0;

                bannedMods = Check.GetModsToBan();

                listBox_modslist.Enabled = true;
                listView_modslist.Enabled = true;

                button_refresh.Enabled = true;
                button_modsfolder.Enabled = true;
            }
            catch (Exception e)
            {
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.button_refresh_Click()");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }
        }

        private void modsList_IndexChanged(Int32 input_index)
        {
            int n = 0;
            string tolabel_types = "";

            if (input_index != System.Windows.Forms.ListBox.NoMatches)
            {
                string baseName = Definitions.toLabel_modName;
                foreach (string modName in Directory.GetFiles(Setup.GetFolderMods(), "*.json"))
                {
                    Definitions.toLabel_modName = Path.GetFileNameWithoutExtension(modName);
                    if (Definitions.toLabel_modName == listBox_modslist.SelectedItem.ToString())
                    {
                        label_title.Text = listBox_modslist.SelectedItem.ToString();
                        textBox_author.Text = Keraplz.JSON.Read.Mods.GetAuthor(Definitions.toLabel_modName);

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

                        if (bannedMods != null)
                        {
                            foreach (string bannedmod in bannedMods)
                            {
                                if (bannedmod == listBox_modslist.SelectedItem.ToString())
                                {
                                    if (Keraplz.JSON.Read.Mods.IsInstalled(bannedmod))
                                    {
                                        Setup.UninstallMod_(listBox_modslist.SelectedItem.ToString());
                                        //if (ModsManager.IsSuccessful())
                                        //{
                                        if (!Keraplz.JSON.Read.Mods.IsInstalled(listBox_modslist.SelectedItem.ToString()))
                                            button_installmod.Text = "Install";

                                        Definitions.toLabel_baseinfo_InstalledMods = Definitions.toLabel_baseinfo_InstalledMods - 1;
                                        Label_UpdateInstalledCount(Definitions.toLabel_baseinfo_InstalledMods);
                                        //}
                                    }

                                    //button_installmod.Text = "Banned";
                                    if (button_installmod.Enabled) button_installmod.Enabled = false;
                                    if (button_installmod.BackColor != Color.LightGray) button_installmod.BackColor = Color.LightGray;
                                    if (label_title.ForeColor != Color.Gray) label_title.ForeColor = Color.Gray;

                                    break;
                                }
                                else
                                {
                                    //button_installmod.Text = "Banned";
                                    if (!button_installmod.Enabled) button_installmod.Enabled = true;
                                    if (button_installmod.BackColor != Color.Transparent) button_installmod.BackColor = Color.Transparent;
                                    if (label_title.ForeColor != Color.Black) label_title.ForeColor = Color.Black;
                                }
                            }
                        }

                        #endregion

                        #region Set mod Preview if available

                        if (label_title.Text == Definitions.toLabel_modName)
                        {
                            Boolean shouldbreak = false;
                            foreach (string extension in Definitions.previewExtensions)
                            {
                                foreach (string preview in Directory.GetFiles(Setup.GetFolderMods() + "/" + label_title.Text, "*" + extension))
                                {
                                    if (preview != null)
                                    {
                                        //this.image_infobg.Image = new Bitmap(Image.FromFile(preview));
                                        this.image_infobg.Image = Image.FromFile(preview);
                                        shouldbreak = true;
                                        break;
                                    }
                                }
                                if (shouldbreak) break;
                            }

                            if (shouldbreak)
                                this.image_infobg.Image = null;
                        }
                        else this.image_infobg.Image = null;

                        #endregion

                        textBox_description.Text = "    " + Keraplz.JSON.Read.Mods.GetDescription(Definitions.toLabel_modName);
                    }

                    Definitions.toLabel_modName = baseName;
                }

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

                    nPreview = 0;
                }

                #endregion
            }
        }
        private void Label_UpdateInstalledCount(int input_installedMods)
        {
            Definitions.toLabel_baseinfo = "Game: " + Setup.GetGameName() + ", Build: " + Definitions.toLabel_baseinfo_CurrentBuild + ", SetupTime: " + Definitions.toLabel_baseinfo_SetupTime + ", Installed Mods: " + input_installedMods.ToString("00");
            label_baseinfo.Text = Definitions.toLabel_baseinfo;

            label_filesused.Text = Keraplz.JSON.Read.Mods.GetNFilesInstalled().ToString("0000") + "/" + Definitions.NContent.ToString("0000");
        }


        private void TransparentBackground(Control C)
        {
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
                using (Definitions.SWriterError = File.AppendText(Definitions.ProgramName + "/_logs/errorlog.txt"))
                {
                    Definitions.SWriterError.WriteLine("Error found in ModsManager.MainWindow.TransparentBackground(" + C.Name + ")");
                    Definitions.SWriterError.WriteLine(e.Message);
                }
            }

            C.Visible = true;
        }
        private void loadFont_title(byte[] input_font, float input_size)
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

            label_title.Font = font;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            IList<Bitmap> images = new List<Bitmap>();

            images.Add(global::ModsManager.Properties.Resources.preview_hothead);
            images.Add(global::ModsManager.Properties.Resources.PreviewBorder);

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
            get { return new Uri(Definitions.XmlUrl); }
        }

        public Form Context
        {
            get { return this; }
        }
    }
}