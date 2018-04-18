namespace ModsManager
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.listBox_modslist = new System.Windows.Forms.ListBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.label_filesused = new System.Windows.Forms.Label();
            this.label_gui_modslist = new System.Windows.Forms.Label();
            this.listView_modslist = new System.Windows.Forms.ListView();
            this.column_isinstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_modsfolder = new System.Windows.Forms.Button();
            this.label_baseinfo = new System.Windows.Forms.Label();
            this.splitter_mods = new System.Windows.Forms.Splitter();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.label_title_configuration = new System.Windows.Forms.Label();
            this.textBox_NFilesModded = new System.Windows.Forms.TextBox();
            this.textBox_contentFolder = new System.Windows.Forms.TextBox();
            this.textBox_modsFolder = new System.Windows.Forms.TextBox();
            this.textBox_gameName = new System.Windows.Forms.TextBox();
            this.button_installmod = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.image_infobg = new System.Windows.Forms.PictureBox();
            this.label_banned = new System.Windows.Forms.Label();
            this.pictureBox_preview = new System.Windows.Forms.PictureBox();
            this.label_info_gameName = new System.Windows.Forms.Label();
            this.label_info_contentFolder = new System.Windows.Forms.Label();
            this.label_info_modsFolder = new System.Windows.Forms.Label();
            this.label_info_NFilesModded = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_infobg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Location = new System.Drawing.Point(0, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(388, 274);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.listBox_modslist);
            this.tabMain.Controls.Add(this.button_refresh);
            this.tabMain.Controls.Add(this.label_filesused);
            this.tabMain.Controls.Add(this.label_gui_modslist);
            this.tabMain.Controls.Add(this.listView_modslist);
            this.tabMain.Controls.Add(this.button_modsfolder);
            this.tabMain.Controls.Add(this.label_baseinfo);
            this.tabMain.Controls.Add(this.splitter_mods);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(380, 248);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Mods";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // listBox_modslist
            // 
            this.listBox_modslist.FormattingEnabled = true;
            this.listBox_modslist.Location = new System.Drawing.Point(8, 52);
            this.listBox_modslist.Name = "listBox_modslist";
            this.listBox_modslist.Size = new System.Drawing.Size(366, 134);
            this.listBox_modslist.TabIndex = 13;
            this.listBox_modslist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_modslist_MouseClick);
            this.listBox_modslist.SelectedIndexChanged += new System.EventHandler(this.listBox_modslist_SelectedIndexChanged);
            // 
            // button_refresh
            // 
            this.button_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_refresh.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.Location = new System.Drawing.Point(134, 196);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(120, 30);
            this.button_refresh.TabIndex = 20;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // label_filesused
            // 
            this.label_filesused.AutoSize = true;
            this.label_filesused.BackColor = System.Drawing.SystemColors.Control;
            this.label_filesused.Location = new System.Drawing.Point(314, 189);
            this.label_filesused.Name = "label_filesused";
            this.label_filesused.Size = new System.Drawing.Size(60, 13);
            this.label_filesused.TabIndex = 19;
            this.label_filesused.Text = "0000/0000";
            this.label_filesused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_gui_modslist
            // 
            this.label_gui_modslist.AutoSize = true;
            this.label_gui_modslist.BackColor = System.Drawing.SystemColors.Control;
            this.label_gui_modslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_gui_modslist.ForeColor = System.Drawing.Color.Black;
            this.label_gui_modslist.Location = new System.Drawing.Point(12, 20);
            this.label_gui_modslist.Name = "label_gui_modslist";
            this.label_gui_modslist.Size = new System.Drawing.Size(71, 16);
            this.label_gui_modslist.TabIndex = 18;
            this.label_gui_modslist.Text = "Mods List :";
            // 
            // listView_modslist
            // 
            this.listView_modslist.AllowDrop = true;
            this.listView_modslist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_modslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_isinstalled,
            this.column_name,
            this.column_version});
            this.listView_modslist.FullRowSelect = true;
            this.listView_modslist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView_modslist.Location = new System.Drawing.Point(8, 52);
            this.listView_modslist.MultiSelect = false;
            this.listView_modslist.Name = "listView_modslist";
            this.listView_modslist.Size = new System.Drawing.Size(366, 134);
            this.listView_modslist.TabIndex = 17;
            this.listView_modslist.UseCompatibleStateImageBehavior = false;
            this.listView_modslist.View = System.Windows.Forms.View.Details;
            this.listView_modslist.Visible = false;
            this.listView_modslist.SelectedIndexChanged += new System.EventHandler(this.listView_modslist_SelectedIndexChanged);
            // 
            // column_isinstalled
            // 
            this.column_isinstalled.Text = "";
            this.column_isinstalled.Width = 23;
            // 
            // column_name
            // 
            this.column_name.Text = "Name";
            this.column_name.Width = 124;
            // 
            // column_version
            // 
            this.column_version.Text = "Version";
            this.column_version.Width = 48;
            // 
            // button_modsfolder
            // 
            this.button_modsfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_modsfolder.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modsfolder.Location = new System.Drawing.Point(8, 196);
            this.button_modsfolder.Name = "button_modsfolder";
            this.button_modsfolder.Size = new System.Drawing.Size(120, 30);
            this.button_modsfolder.TabIndex = 17;
            this.button_modsfolder.Text = "Mods Folder";
            this.button_modsfolder.UseVisualStyleBackColor = true;
            this.button_modsfolder.Click += new System.EventHandler(this.button_modsfolder_Click);
            // 
            // label_baseinfo
            // 
            this.label_baseinfo.AutoSize = true;
            this.label_baseinfo.BackColor = System.Drawing.SystemColors.Control;
            this.label_baseinfo.Location = new System.Drawing.Point(9, 229);
            this.label_baseinfo.Name = "label_baseinfo";
            this.label_baseinfo.Size = new System.Drawing.Size(359, 13);
            this.label_baseinfo.TabIndex = 14;
            this.label_baseinfo.Text = "Game: no_game_found, Build: 000, SetupTime: 00:000, Installed Mods: 00";
            // 
            // splitter_mods
            // 
            this.splitter_mods.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter_mods.Location = new System.Drawing.Point(3, 3);
            this.splitter_mods.Name = "splitter_mods";
            this.splitter_mods.Size = new System.Drawing.Size(374, 242);
            this.splitter_mods.TabIndex = 8;
            this.splitter_mods.TabStop = false;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.label_info_NFilesModded);
            this.tabOptions.Controls.Add(this.label_info_modsFolder);
            this.tabOptions.Controls.Add(this.label_info_contentFolder);
            this.tabOptions.Controls.Add(this.label_info_gameName);
            this.tabOptions.Controls.Add(this.label_title_configuration);
            this.tabOptions.Controls.Add(this.textBox_NFilesModded);
            this.tabOptions.Controls.Add(this.textBox_contentFolder);
            this.tabOptions.Controls.Add(this.textBox_modsFolder);
            this.tabOptions.Controls.Add(this.textBox_gameName);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(380, 248);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.Text = "Info";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // label_title_configuration
            // 
            this.label_title_configuration.AutoSize = true;
            this.label_title_configuration.Location = new System.Drawing.Point(8, 21);
            this.label_title_configuration.Name = "label_title_configuration";
            this.label_title_configuration.Size = new System.Drawing.Size(69, 13);
            this.label_title_configuration.TabIndex = 3;
            this.label_title_configuration.Text = "Configuration";
            // 
            // textBox_NFilesModded
            // 
            this.textBox_NFilesModded.Location = new System.Drawing.Point(116, 133);
            this.textBox_NFilesModded.Name = "textBox_NFilesModded";
            this.textBox_NFilesModded.ReadOnly = true;
            this.textBox_NFilesModded.Size = new System.Drawing.Size(146, 20);
            this.textBox_NFilesModded.TabIndex = 0;
            // 
            // textBox_contentFolder
            // 
            this.textBox_contentFolder.Location = new System.Drawing.Point(116, 81);
            this.textBox_contentFolder.Name = "textBox_contentFolder";
            this.textBox_contentFolder.ReadOnly = true;
            this.textBox_contentFolder.Size = new System.Drawing.Size(146, 20);
            this.textBox_contentFolder.TabIndex = 0;
            // 
            // textBox_modsFolder
            // 
            this.textBox_modsFolder.Location = new System.Drawing.Point(116, 107);
            this.textBox_modsFolder.Name = "textBox_modsFolder";
            this.textBox_modsFolder.ReadOnly = true;
            this.textBox_modsFolder.Size = new System.Drawing.Size(146, 20);
            this.textBox_modsFolder.TabIndex = 0;
            // 
            // textBox_gameName
            // 
            this.textBox_gameName.Location = new System.Drawing.Point(116, 55);
            this.textBox_gameName.Name = "textBox_gameName";
            this.textBox_gameName.ReadOnly = true;
            this.textBox_gameName.Size = new System.Drawing.Size(146, 20);
            this.textBox_gameName.TabIndex = 0;
            // 
            // button_installmod
            // 
            this.button_installmod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_installmod.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_installmod.Location = new System.Drawing.Point(390, 245);
            this.button_installmod.Name = "button_installmod";
            this.button_installmod.Size = new System.Drawing.Size(231, 30);
            this.button_installmod.TabIndex = 10;
            this.button_installmod.Text = "Install";
            this.button_installmod.UseVisualStyleBackColor = true;
            this.button_installmod.Click += new System.EventHandler(this.button_installmod_Click);
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Arial", 21.75F);
            this.label_title.Location = new System.Drawing.Point(392, 63);
            this.label_title.Name = "label_title";
            this.label_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_title.Size = new System.Drawing.Size(224, 36);
            this.label_title.TabIndex = 4;
            this.label_title.Text = "no_name_found";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_type
            // 
            this.textBox_type.Location = new System.Drawing.Point(390, 219);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.ReadOnly = true;
            this.textBox_type.Size = new System.Drawing.Size(231, 20);
            this.textBox_type.TabIndex = 2;
            this.textBox_type.Text = "no_type_found";
            // 
            // image_infobg
            // 
            this.image_infobg.BackColor = System.Drawing.Color.Transparent;
            this.image_infobg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.image_infobg.Cursor = System.Windows.Forms.Cursors.Default;
            this.image_infobg.Location = new System.Drawing.Point(390, 46);
            this.image_infobg.Name = "image_infobg";
            this.image_infobg.Size = new System.Drawing.Size(231, 193);
            this.image_infobg.TabIndex = 19;
            this.image_infobg.TabStop = false;
            this.image_infobg.Visible = false;
            // 
            // label_banned
            // 
            this.label_banned.Font = new System.Drawing.Font("Arial", 20F);
            this.label_banned.ForeColor = System.Drawing.Color.Gray;
            this.label_banned.Location = new System.Drawing.Point(392, 99);
            this.label_banned.Name = "label_banned";
            this.label_banned.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_banned.Size = new System.Drawing.Size(224, 36);
            this.label_banned.TabIndex = 20;
            this.label_banned.Text = "BANNED";
            this.label_banned.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_banned.Visible = false;
            // 
            // pictureBox_preview
            // 
            this.pictureBox_preview.Location = new System.Drawing.Point(462, 133);
            this.pictureBox_preview.Name = "pictureBox_preview";
            this.pictureBox_preview.Size = new System.Drawing.Size(80, 80);
            this.pictureBox_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_preview.TabIndex = 21;
            this.pictureBox_preview.TabStop = false;
            // 
            // label_info_gameName
            // 
            this.label_info_gameName.AutoSize = true;
            this.label_info_gameName.Location = new System.Drawing.Point(8, 58);
            this.label_info_gameName.Name = "label_info_gameName";
            this.label_info_gameName.Size = new System.Drawing.Size(35, 13);
            this.label_info_gameName.TabIndex = 4;
            this.label_info_gameName.Text = "Game";
            // 
            // label_info_contentFolder
            // 
            this.label_info_contentFolder.AutoSize = true;
            this.label_info_contentFolder.Location = new System.Drawing.Point(8, 84);
            this.label_info_contentFolder.Name = "label_info_contentFolder";
            this.label_info_contentFolder.Size = new System.Drawing.Size(76, 13);
            this.label_info_contentFolder.TabIndex = 4;
            this.label_info_contentFolder.Text = "Content Folder";
            // 
            // label_info_modsFolder
            // 
            this.label_info_modsFolder.AutoSize = true;
            this.label_info_modsFolder.Location = new System.Drawing.Point(8, 110);
            this.label_info_modsFolder.Name = "label_info_modsFolder";
            this.label_info_modsFolder.Size = new System.Drawing.Size(65, 13);
            this.label_info_modsFolder.TabIndex = 4;
            this.label_info_modsFolder.Text = "Mods Folder";
            // 
            // label_info_NFilesModded
            // 
            this.label_info_NFilesModded.AutoSize = true;
            this.label_info_NFilesModded.Location = new System.Drawing.Point(8, 136);
            this.label_info_NFilesModded.Name = "label_info_NFilesModded";
            this.label_info_NFilesModded.Size = new System.Drawing.Size(81, 13);
            this.label_info_NFilesModded.TabIndex = 4;
            this.label_info_NFilesModded.Text = "N Files Modded";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 279);
            this.Controls.Add(this.pictureBox_preview);
            this.Controls.Add(this.label_banned);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.textBox_type);
            this.Controls.Add(this.button_installmod);
            this.Controls.Add(this.image_infobg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_infobg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Splitter splitter_mods;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.Button button_installmod;
        private System.Windows.Forms.ListBox listBox_modslist;
        private System.Windows.Forms.Label label_baseinfo;
        private System.Windows.Forms.Button button_modsfolder;
        private System.Windows.Forms.Label label_gui_modslist;
        private System.Windows.Forms.ListView listView_modslist;
        private System.Windows.Forms.ColumnHeader column_name;
        private System.Windows.Forms.ColumnHeader column_version;
        private System.Windows.Forms.PictureBox image_infobg;
        private System.Windows.Forms.Label label_filesused;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Label label_banned;
        private System.Windows.Forms.ColumnHeader column_isinstalled;
        private System.Windows.Forms.PictureBox pictureBox_preview;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.TextBox textBox_NFilesModded;
        private System.Windows.Forms.TextBox textBox_contentFolder;
        private System.Windows.Forms.TextBox textBox_modsFolder;
        private System.Windows.Forms.TextBox textBox_gameName;
        private System.Windows.Forms.Label label_title_configuration;
        private System.Windows.Forms.Label label_info_NFilesModded;
        private System.Windows.Forms.Label label_info_modsFolder;
        private System.Windows.Forms.Label label_info_contentFolder;
        private System.Windows.Forms.Label label_info_gameName;
    }
}