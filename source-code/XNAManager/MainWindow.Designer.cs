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
            this.button_refresh = new System.Windows.Forms.Button();
            this.label_filesused = new System.Windows.Forms.Label();
            this.listBox_modslist = new System.Windows.Forms.ListBox();
            this.label_oops = new System.Windows.Forms.Label();
            this.label_gui_modslist = new System.Windows.Forms.Label();
            this.listView_modslist = new System.Windows.Forms.ListView();
            this.column_isinstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_modsfolder = new System.Windows.Forms.Button();
            this.label_baseinfo = new System.Windows.Forms.Label();
            this.splitter_mods = new System.Windows.Forms.Splitter();
            this.label_description = new System.Windows.Forms.Label();
            this.button_previewmod = new System.Windows.Forms.Button();
            this.button_installmod = new System.Windows.Forms.Button();
            this.label_type = new System.Windows.Forms.Label();
            this.label_author = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.textBox_author = new System.Windows.Forms.TextBox();
            this.image_infobg = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_infobg)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Location = new System.Drawing.Point(0, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(642, 463);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.listBox_modslist);
            this.tabMain.Controls.Add(this.button_refresh);
            this.tabMain.Controls.Add(this.label_filesused);
            this.tabMain.Controls.Add(this.textBox_author);
            this.tabMain.Controls.Add(this.label_oops);
            this.tabMain.Controls.Add(this.label_type);
            this.tabMain.Controls.Add(this.label_gui_modslist);
            this.tabMain.Controls.Add(this.label_author);
            this.tabMain.Controls.Add(this.listView_modslist);
            this.tabMain.Controls.Add(this.textBox_description);
            this.tabMain.Controls.Add(this.button_modsfolder);
            this.tabMain.Controls.Add(this.label_baseinfo);
            this.tabMain.Controls.Add(this.splitter_mods);
            this.tabMain.Controls.Add(this.label_description);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(634, 437);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Mods";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // button_refresh
            // 
            this.button_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_refresh.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_refresh.Location = new System.Drawing.Point(138, 385);
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
            this.label_filesused.Location = new System.Drawing.Point(560, 371);
            this.label_filesused.Name = "label_filesused";
            this.label_filesused.Size = new System.Drawing.Size(60, 13);
            this.label_filesused.TabIndex = 19;
            this.label_filesused.Text = "0000/0000";
            this.label_filesused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_modslist
            // 
            this.listBox_modslist.FormattingEnabled = true;
            this.listBox_modslist.Location = new System.Drawing.Point(8, 52);
            this.listBox_modslist.Name = "listBox_modslist";
            this.listBox_modslist.Size = new System.Drawing.Size(612, 316);
            this.listBox_modslist.TabIndex = 13;
            this.listBox_modslist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_modslist_MouseClick);
            // 
            // label_oops
            // 
            this.label_oops.AutoSize = true;
            this.label_oops.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_oops.Location = new System.Drawing.Point(121, 136);
            this.label_oops.Name = "label_oops";
            this.label_oops.Size = new System.Drawing.Size(382, 29);
            this.label_oops.TabIndex = 0;
            this.label_oops.Text = "Oops! There is nothing here yet!";
            this.label_oops.Visible = false;
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
            this.listView_modslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_isinstalled,
            this.column_name,
            this.column_version});
            this.listView_modslist.FullRowSelect = true;
            this.listView_modslist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listView_modslist.Location = new System.Drawing.Point(8, 52);
            this.listView_modslist.Name = "listView_modslist";
            this.listView_modslist.Size = new System.Drawing.Size(612, 178);
            this.listView_modslist.TabIndex = 17;
            this.listView_modslist.UseCompatibleStateImageBehavior = false;
            this.listView_modslist.View = System.Windows.Forms.View.Details;
            this.listView_modslist.Visible = false;
            this.listView_modslist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_modslist_MouseClick);
            // 
            // column_isinstalled
            // 
            this.column_isinstalled.Text = "Status";
            this.column_isinstalled.Width = 66;
            // 
            // column_name
            // 
            this.column_name.Text = "Name";
            this.column_name.Width = 220;
            // 
            // column_version
            // 
            this.column_version.Text = "Version";
            this.column_version.Width = 59;
            // 
            // button_modsfolder
            // 
            this.button_modsfolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_modsfolder.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modsfolder.Location = new System.Drawing.Point(12, 385);
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
            this.label_baseinfo.Location = new System.Drawing.Point(9, 418);
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
            this.splitter_mods.Size = new System.Drawing.Size(628, 431);
            this.splitter_mods.TabIndex = 8;
            this.splitter_mods.TabStop = false;
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Location = new System.Drawing.Point(560, 371);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(60, 13);
            this.label_description.TabIndex = 7;
            this.label_description.Text = "Description";
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_description.Visible = false;
            // 
            // button_previewmod
            // 
            this.button_previewmod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_previewmod.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_previewmod.Location = new System.Drawing.Point(752, 431);
            this.button_previewmod.Name = "button_previewmod";
            this.button_previewmod.Size = new System.Drawing.Size(124, 30);
            this.button_previewmod.TabIndex = 11;
            this.button_previewmod.Text = "Preview Mod";
            this.button_previewmod.UseVisualStyleBackColor = true;
            this.button_previewmod.Click += new System.EventHandler(this.button_previewmod_Click);
            // 
            // button_installmod
            // 
            this.button_installmod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_installmod.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_installmod.Location = new System.Drawing.Point(645, 431);
            this.button_installmod.Name = "button_installmod";
            this.button_installmod.Size = new System.Drawing.Size(101, 30);
            this.button_installmod.TabIndex = 10;
            this.button_installmod.Text = "Install";
            this.button_installmod.UseVisualStyleBackColor = true;
            this.button_installmod.Click += new System.EventHandler(this.button_installmod_Click);
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(394, 206);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(31, 13);
            this.label_type.TabIndex = 6;
            this.label_type.Text = "Type";
            // 
            // label_author
            // 
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(394, 180);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(38, 13);
            this.label_author.TabIndex = 5;
            this.label_author.Text = "Author";
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Arial", 21.75F);
            this.label_title.Location = new System.Drawing.Point(647, 64);
            this.label_title.Name = "label_title";
            this.label_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_title.Size = new System.Drawing.Size(224, 36);
            this.label_title.TabIndex = 4;
            this.label_title.Text = "no_name_found";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(389, 229);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ReadOnly = true;
            this.textBox_description.Size = new System.Drawing.Size(231, 139);
            this.textBox_description.TabIndex = 3;
            this.textBox_description.Text = "    no_description_found";
            // 
            // textBox_type
            // 
            this.textBox_type.Location = new System.Drawing.Point(644, 322);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.ReadOnly = true;
            this.textBox_type.Size = new System.Drawing.Size(231, 20);
            this.textBox_type.TabIndex = 2;
            this.textBox_type.Text = "no_type_found";
            // 
            // textBox_author
            // 
            this.textBox_author.Location = new System.Drawing.Point(431, 177);
            this.textBox_author.Name = "textBox_author";
            this.textBox_author.ReadOnly = true;
            this.textBox_author.Size = new System.Drawing.Size(189, 20);
            this.textBox_author.TabIndex = 1;
            this.textBox_author.Text = "no_author_found";
            // 
            // image_infobg
            // 
            this.image_infobg.BackColor = System.Drawing.Color.Transparent;
            this.image_infobg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.image_infobg.Cursor = System.Windows.Forms.Cursors.Default;
            this.image_infobg.Location = new System.Drawing.Point(644, 64);
            this.image_infobg.Name = "image_infobg";
            this.image_infobg.Size = new System.Drawing.Size(231, 278);
            this.image_infobg.TabIndex = 19;
            this.image_infobg.TabStop = false;
            this.image_infobg.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 465);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.textBox_type);
            this.Controls.Add(this.button_previewmod);
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
            ((System.ComponentModel.ISupportInitialize)(this.image_infobg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ModsListContextMenu;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.Splitter splitter_mods;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.Label label_author;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.TextBox textBox_type;
        private System.Windows.Forms.TextBox textBox_author;
        private System.Windows.Forms.Button button_installmod;
        private System.Windows.Forms.Button button_previewmod;
        private System.Windows.Forms.ListBox listBox_modslist;
        private System.Windows.Forms.Label label_baseinfo;
        private System.Windows.Forms.Button button_modsfolder;
        private System.Windows.Forms.Label label_oops;
        private System.Windows.Forms.Label label_gui_modslist;
        private System.Windows.Forms.ListView listView_modslist;
        private System.Windows.Forms.ColumnHeader column_isinstalled;
        private System.Windows.Forms.ColumnHeader column_name;
        private System.Windows.Forms.ColumnHeader column_version;
        private System.Windows.Forms.PictureBox image_infobg;
        private System.Windows.Forms.Label label_filesused;
        private System.Windows.Forms.Button button_refresh;
    }
}