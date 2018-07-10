using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public class MMUIMod : MMUIResources
    {
        // Members
        public Panel Structure;
        public Panel Item;
        public Panel Top;
        public Panel Bottom;
        private Button Delete;
        //private Button Download;
        private Button Install;
        private PictureBox Info;
        private PictureBox Preview;
        private PictureBox IconInstall;
        private Label Name;
        private Label Seperator;

        private Image DefaultPreview = global::ModsManager.Properties.Resources.White_Unchecked_Checkbox_100px;
        public static Size ItemSize = new Size(200, 250);
        private Size IconSize = new Size(25, 25);
        public static Point Padding = new Point(50, 50);
        //public static Point Padding = new Point(43, 30);

        private Mod ModInfo;

        private string _Install = "        Install";
        private string _Uninstall = "        Uninstall";

        private int Index = 0;
        private string ModName = string.Empty;
        private string SmallDesc = string.Empty;

        private int FormSize = 0;

        // Constructor
        public MMUIMod(int Index, Mod modInfo, int FormSize = 0)
        {
            this.ModInfo = modInfo;
            this.Index = Index;
            this.ModName = modInfo.GetName();
            this.SmallDesc = modInfo.GetTypesString() + "\r\n" + modInfo.GetSize();
            this.FormSize = FormSize;
            Structure = new Panel();

            Structure.Paint += new PaintEventHandler(Structure_draw);
            Structure.Refresh();
        }
        private void Structure_draw(object sender, PaintEventArgs pe)
        {
            // Panel Item
            Item = new Panel();

            Item.BackColor = Secondary;
            Item.Name = "panel_Item";
            Item.Size = ItemSize;
            Item.Dock = DockStyle.None;
            Item.Location = Padding;
            Item.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));

            
            // Calculate Pos based on Index
            int StructPosX = 0;
            for (int i = 0; i < Index; i++)
            {
                StructPosX += Item.Width + Padding.X;
            }

            //int x = FormSize / 2 - Item.Width / 2 - Padding.X * 2 - Item.Width;


            // Panel Structure
            Structure.BackColor = Transparent;
            Structure.Name = "panel_Structure";
            Structure.Dock = DockStyle.None;
            Structure.MinimumSize = new Size(Item.Width + Padding.X, 500);
            Structure.Size = new Size(Item.Width + Padding.X, 500);
            Structure.Location = new Point(StructPosX, 0);
            Structure.Anchor = AnchorStyles.None;
            Structure.TabIndex = Index;
            

            // Label Seperator

            Seperator = new Label();

            Seperator.AutoSize = true;
            Seperator.BackColor = Tertiary;
            Seperator.Size = new Size(31, 47);
            Seperator.FlatStyle = FlatStyle.Flat;
            Seperator.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            Seperator.ForeColor = Color.White;
            //Seperator.Location = new Point((Item.Width / 2) - (Seperator.Width / 2), -4);
            Seperator.Location = new Point(Item.Width - Seperator.Width - (IconSize.Width * 2), -4);
            Seperator.Name = "label_Seperator";
            Seperator.Text = "|";
            Seperator.TextAlign = ContentAlignment.BottomCenter;
            Seperator.RightToLeft = RightToLeft.No;


            // Buttons

            Delete = new Button();
            //Download = new Button();
            Install = new Button();

            //if (false)
            //{
            //    Delete.BackColor = Transparent;
            //    Delete.Name = "button_Delete";
            //    Delete.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            //    Delete.Size = IconSize;
            //    Delete.Location = new Point(Item.Width - Delete.Width, 0);
            //    Delete.BackgroundImage = global::ModsManager.Properties.Resources.White_Trash_100px;
            //    Delete.BackgroundImageLayout = ImageLayout.Stretch;
            //    Delete.FlatStyle = FlatStyle.Flat;
            //    //Delete.FlatAppearance.MouseOverBackColor = Delete.BackColor;
            //    //Delete.BackColorChanged += (s, e) => { Delete.FlatAppearance.MouseOverBackColor = Delete.BackColor; };
            //    //Delete.FlatAppearance.MouseDownBackColor = Delete.BackColor;
            //    //Delete.BackColorChanged += (s, e) => { Delete.FlatAppearance.MouseDownBackColor = Delete.BackColor; };
            //    Delete.TabStop = false;
            //    Delete.FlatAppearance.BorderSize = 0;
            //    Delete.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            //}

            //Download.BackColor = Transparent;
            //Download.Name = "button_Download";
            //Download.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            //Download.Size = IconSize;
            //Download.Location = new Point(0, 0);
            //Download.BackgroundImage = global::ModsManager.Properties.Resources.White_Download_100px;
            //Download.BackgroundImageLayout = ImageLayout.Stretch;
            //Download.FlatStyle = FlatStyle.Flat;
            //Download.FlatAppearance.MouseOverBackColor = Download.BackColor;
            //Download.BackColorChanged += (s, e) => { Download.FlatAppearance.MouseOverBackColor = Download.BackColor; };
            //Download.FlatAppearance.MouseDownBackColor = Download.BackColor;
            //Download.BackColorChanged += (s, e) => { Download.FlatAppearance.MouseDownBackColor = Download.BackColor; };
            //Download.TabStop = false;
            //Download.FlatAppearance.BorderSize = 0;
            //Download.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            Install.BackColor = Transparent;
            Install.Name = "button_Install";
            Install.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            //Install.Size = new Size((Item.Width / 2) - (Seperator.Width / 2), 30);
            Install.Size = new Size(Item.Width - Seperator.Width - (IconSize.Width * 2), 30);
            //Install.Location = new Point(0, Item.Height - Install.Height);
            Install.Location = new Point(0, 0);
            //Install.Image = global::ModsManager.Properties.Resources.White_Software_Installer_100px;
            //Install.Image.Size = new Size(Install.Height, Install.Height);
            //Install.ImageAlign = ContentAlignment.TopLeft;
            Install.FlatStyle = FlatStyle.Flat;
            Install.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Install.ForeColor = Color.White;

            if (ModInfo.isInstalled()) Install.Text = _Uninstall;
            else Install.Text = _Install;

            Install.TextAlign = ContentAlignment.MiddleLeft;
            Install.FlatAppearance.MouseOverBackColor = Install.BackColor;
            Install.BackColorChanged += (s, e) => { Install.FlatAppearance.MouseOverBackColor = Install.BackColor; };
            Install.FlatAppearance.MouseDownBackColor = Install.BackColor;
            Install.BackColorChanged += (s, e) => { Install.FlatAppearance.MouseDownBackColor = Install.BackColor; };
            Install.TabStop = false;
            Install.FlatAppearance.BorderSize = 0;
            Install.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            Install.Click += new EventHandler(this.Install_Click);


            // Panel Bottom

            Bottom = new Panel();

            Bottom.BackColor = Tertiary;
            Bottom.Name = "pictureBox_Bottom";
            Bottom.Size = new Size(Item.Width, Install.Height);
            Bottom.Dock = DockStyle.None;
            Bottom.Location = new Point(0, Item.Height - Install.Height);
            Bottom.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right)));


            // Panel Top

            Top = new Panel();

            Top.BackColor = Tertiary;
            Top.Name = "pictureBox_Top";
            Top.Size = new Size(Item.Width, IconSize.Height);
            Top.Dock = DockStyle.None;
            Top.Location = new Point(0, 0);
            Top.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));


            // Preview Box

            Preview = new PictureBox();
            Info = new PictureBox();
            IconInstall = new PictureBox();

            Preview.Anchor = AnchorStyles.None;
            Preview.BackColor = Secondary;
            Preview.BackgroundImageLayout = ImageLayout.Zoom;
            Preview.BackgroundImage = DefaultPreview;
            Preview.Size = new Size(100, 100);
            Preview.Location = new Point((Item.Width - Preview.Width) / 2, (Item.Height - Preview.Height) / 3);
            Preview.Name = "pictureBox_Name";

            Info.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            Info.BackColor = Transparent;
            Info.BackgroundImage = global::ModsManager.Properties.Resources.White_Information_100px;
            Info.BackgroundImageLayout = ImageLayout.Zoom;
            Info.Size = IconSize;
            Info.Location = new Point(Item.Width - Info.Width, 0);
            Info.Name = "pictureBox_Info";

            IconInstall.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            IconInstall.BackColor = Transparent;
            IconInstall.BackgroundImage = global::ModsManager.Properties.Resources.White_Installing_100px;
            IconInstall.BackgroundImageLayout = ImageLayout.Zoom;
            IconInstall.Enabled = false;
            IconInstall.Size = new Size(Install.Height, Install.Height);
            IconInstall.Location = new Point(0, 0);
            IconInstall.Name = "pictureBox_IconInstall";


            // Label Name

            Name = new Label();

            Name.BackColor = Secondary;
            Name.Size = new Size(Item.Width - (Item.Width / 12), 24);
            Name.Location = new Point((Item.Width - Name.Width) / 2, Preview.Height + Preview.Location.Y + 4);
            Name.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            Name.ForeColor = Color.White;
            Name.Name = "label_Name";
            Name.Text = ModName;
            Name.TextAlign = ContentAlignment.TopCenter;
            Name.RightToLeft = RightToLeft.No;


            // ToolTip Information

            ToolTip TTip = new ToolTip();

            TTip.SetToolTip(Info, SmallDesc);


            // Check if mod is banned

            if (ModInfo.isBanned())
            {
                Install.Enabled = false;
                Install.ForeColor = Color.Gray;
            }


            // Add Controls to Panel Structure
            //Item.Controls.Add(Download);

            Bottom.Controls.Add(IconInstall);
            Bottom.Controls.Add(Install);
            Bottom.Controls.Add(Seperator);
            Bottom.Controls.Add(Delete);
            Top.Controls.Add(Info);
            Item.Controls.Add(Preview);
            Item.Controls.Add(Name);
            Item.Controls.Add(Top);
            Item.Controls.Add(Bottom);

            Item.Refresh();
            Structure.Controls.Add(Item);
            Structure.Paint -= new PaintEventHandler(Structure_draw);
        }


        private async void Install_Click(object sender, EventArgs e)
        {
            if (this.Install.Text == _Uninstall)
            {
                this.Install.Enabled = false;

                Boolean Success = await Task.Run(() => ModsManager.UninstallAsync(this.ModInfo));
                if (Success)
                {
                    await Task.Run(() => this.ModInfo.RefreshAsync());
                    if (!this.ModInfo.isInstalled())
                        this.Install.Text = _Install;

                    //await Task.Run(() => Profiles.Default.RefreshAsync());
                    //BannedMods = Profiles.Default.GetBannedMods();

                    //NInstalledMods = NInstalledMods - 1;
                    //Label_UpdateInfo(Profiles.Default.GetGame());
                }
            }
            else if (this.Install.Text == _Install)
            {
                this.Install.Enabled = false;

                Boolean Success = await Task.Run(() => ModsManager.InstallAsync(this.ModInfo));
                if (Success)
                {
                    await Task.Run(() => this.ModInfo.RefreshAsync());
                    if (this.ModInfo.isInstalled())
                        this.Install.Text = _Uninstall;

                    //await Task.Run(() => Profiles.Default.RefreshAsync());
                    //BannedMods = Profiles.Default.GetBannedMods();

                    //NInstalledMods = NInstalledMods + 1;
                    //Label_UpdateInfo(Profiles.Default.GetGame());
                }
            }

            await Task.Run(() => Profiles.Default.RefreshAsync());
            UpdateAll(MMUIChildModsList.MMUIModsList);
            this.Install.Enabled = true;
        }

        // Custom Methods

        private void DisableAll(List<MMUIMod> ModsList)
        {
            foreach (MMUIMod modInfo in ModsList)
            {
                modInfo.Install.Enabled = false;
            }
        }
        private void EnableAll(List<MMUIMod> ModsList)
        {
            foreach (MMUIMod modInfo in ModsList)
            {
                modInfo.Install.Enabled = true;
            }
        }
        private void UpdateAll(List<MMUIMod> ModsList)
        {
            if (Profiles.Default.GetBannedMods() == null)
                return;

            foreach (MMUIMod modInfo in ModsList)
            {
                modInfo.Update();
            }
        }

        public void Update()
        {
            if (this.ModInfo.isBanned())
            {
                this.Install.Enabled = false;
                this.Install.ForeColor = Color.Gray;
            }
            else
            {
                this.Install.Enabled = true;
                this.Install.ForeColor = Color.White;
            }
        }

    }
}