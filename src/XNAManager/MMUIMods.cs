using System.Drawing;
using System.Windows.Forms;

namespace ModsManager
{
    public class MMUIMod : MMUIResources
    {
        // Members
        public Panel Structure;
        public Panel Item;
        private Button Delete;
        private Button Download;
        private Button Install;
        private PictureBox Info;
        private PictureBox Preview;
        private Label Name;

        private Image DefaultPreview = global::ModsManager.Properties.Resources.White_Unchecked_Checkbox_100px;
        private Size IconSize = new Size(25, 25);
        private Point Padding = new Point(30, 30);

        private string ModName = string.Empty;
        private string SmallDesc = string.Empty;

        // Constructor
        public MMUIMod(string Name = "", string SmallDesc = "")
        {
            Index = Index + 1;
            this.ModName = Name;
            this.SmallDesc = SmallDesc;
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
            Item.Size = new Size(200, 250);
            Item.Dock = DockStyle.None;
            Item.Location = Padding;
            Item.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));


            // Calculate Pos based on Index
            int StructPosX = 0;
            for (int i = 0; i < Index; i++)
            {
                StructPosX += Item.Width + Padding.X;
            }


            // Panel Structure
            Structure.BackColor = Transparent;
            Structure.Name = "panel_Structure";
            Structure.Dock = DockStyle.Left;
            Structure.Size = new Size(Item.Width + Padding.X, 500);
            Structure.Location = new Point(StructPosX, 0);
            Structure.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom)));


            // Buttons

            Delete = new Button();
            Download = new Button();
            Install = new Button();

            Delete.BackColor = Transparent;
            Delete.Name = "button_Delete";
            Delete.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            Delete.Size = IconSize;
            Delete.Location = new Point(Item.Width - (Delete.Width * 2), 0);
            Delete.BackgroundImage = global::ModsManager.Properties.Resources.White_Trash_100px;
            Delete.BackgroundImageLayout = ImageLayout.Stretch;
            Delete.FlatStyle = FlatStyle.Flat;
            Delete.FlatAppearance.MouseOverBackColor = Delete.BackColor;
            Delete.BackColorChanged += (s, e) => { Delete.FlatAppearance.MouseOverBackColor = Delete.BackColor; };
            Delete.FlatAppearance.MouseDownBackColor = Delete.BackColor;
            Delete.BackColorChanged += (s, e) => { Delete.FlatAppearance.MouseDownBackColor = Delete.BackColor; };
            Delete.TabStop = false;
            Delete.FlatAppearance.BorderSize = 0;
            Delete.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            Download.BackColor = Transparent;
            Download.Name = "button_Download";
            Download.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            Download.Size = IconSize;
            Download.Location = new Point(0, 0);
            Download.BackgroundImage = global::ModsManager.Properties.Resources.White_Download_100px;
            Download.BackgroundImageLayout = ImageLayout.Stretch;
            Download.FlatStyle = FlatStyle.Flat;
            Download.FlatAppearance.MouseOverBackColor = Download.BackColor;
            Download.BackColorChanged += (s, e) => { Download.FlatAppearance.MouseOverBackColor = Download.BackColor; };
            Download.FlatAppearance.MouseDownBackColor = Download.BackColor;
            Download.BackColorChanged += (s, e) => { Download.FlatAppearance.MouseDownBackColor = Download.BackColor; };
            Download.TabStop = false;
            Download.FlatAppearance.BorderSize = 0;
            Download.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            Install.BackColor = Transparent;
            Install.Name = "button_Install";
            Install.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
            Install.Size = IconSize;
            Install.Location = new Point(0, Item.Height - Install.Height);
            Install.BackgroundImage = global::ModsManager.Properties.Resources.White_Software_Installer_100px;
            Install.BackgroundImageLayout = ImageLayout.Stretch;
            Install.FlatStyle = FlatStyle.Flat;
            Install.FlatAppearance.MouseOverBackColor = Install.BackColor;
            Install.BackColorChanged += (s, e) => { Install.FlatAppearance.MouseOverBackColor = Install.BackColor; };
            Install.FlatAppearance.MouseDownBackColor = Install.BackColor;
            Install.BackColorChanged += (s, e) => { Install.FlatAppearance.MouseDownBackColor = Install.BackColor; };
            Install.TabStop = false;
            Install.FlatAppearance.BorderSize = 0;
            Install.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);


            // Preview Box

            Preview = new PictureBox();
            Info = new PictureBox();

            Preview.Anchor = AnchorStyles.None;
            Preview.BackColor = Transparent;
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


            // Label Name

            Name = new Label();

            Name.BackColor = Transparent;
            Name.Size = new Size(Item.Width - (Item.Width / 12), 16);
            Name.Location = new Point((Item.Width - Name.Width) / 2, Preview.Height + Preview.Location.Y + 4);
            Name.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            Name.ForeColor = Color.White;
            Name.Name = "label_Name";
            Name.Text = ModName;
            Name.TextAlign = ContentAlignment.TopCenter;
            Name.RightToLeft = System.Windows.Forms.RightToLeft.No;


            // ToolTip Information

            ToolTip TTip = new ToolTip();

            TTip.SetToolTip(Info, SmallDesc);

            // Add Controls to Panel Structure
            Item.Controls.Add(Delete);
            Item.Controls.Add(Download);
            Item.Controls.Add(Install);
            Item.Controls.Add(Preview);
            Item.Controls.Add(Info);
            Item.Controls.Add(Name);

            Item.Refresh();
            Structure.Controls.Add(Item);
        }


        // Custom Methods
    }

}