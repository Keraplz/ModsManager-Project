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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_baseinfo = new System.Windows.Forms.Label();
            this.listBox_modslist = new System.Windows.Forms.ListBox();
            this.button_previewmod = new System.Windows.Forms.Button();
            this.button_installmod = new System.Windows.Forms.Button();
            this.splitter_mods = new System.Windows.Forms.Splitter();
            this.label_description = new System.Windows.Forms.Label();
            this.label_type = new System.Windows.Forms.Label();
            this.label_author = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.textBox_type = new System.Windows.Forms.TextBox();
            this.textBox_author = new System.Windows.Forms.TextBox();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabConfig);
            this.tabControl.Location = new System.Drawing.Point(0, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(883, 463);
            this.tabControl.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.dataGridView1);
            this.tabMain.Controls.Add(this.label_baseinfo);
            this.tabMain.Controls.Add(this.listBox_modslist);
            this.tabMain.Controls.Add(this.button_previewmod);
            this.tabMain.Controls.Add(this.button_installmod);
            this.tabMain.Controls.Add(this.splitter_mods);
            this.tabMain.Controls.Add(this.label_description);
            this.tabMain.Controls.Add(this.label_type);
            this.tabMain.Controls.Add(this.label_author);
            this.tabMain.Controls.Add(this.label_title);
            this.tabMain.Controls.Add(this.textBox_description);
            this.tabMain.Controls.Add(this.textBox_type);
            this.tabMain.Controls.Add(this.textBox_author);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(875, 437);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Mods";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(612, 184);
            this.dataGridView1.TabIndex = 15;
            // 
            // label_baseinfo
            // 
            this.label_baseinfo.AutoSize = true;
            this.label_baseinfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label_baseinfo.Location = new System.Drawing.Point(9, 418);
            this.label_baseinfo.Name = "label_baseinfo";
            this.label_baseinfo.Size = new System.Drawing.Size(321, 13);
            this.label_baseinfo.TabIndex = 14;
            this.label_baseinfo.Text = "Game: ERROR, Build: 000, SetupTime: 00:000, Installed Mods: 00";
            // 
            // listBox_modslist
            // 
            this.listBox_modslist.FormattingEnabled = true;
            this.listBox_modslist.Location = new System.Drawing.Point(8, 208);
            this.listBox_modslist.Name = "listBox_modslist";
            this.listBox_modslist.Size = new System.Drawing.Size(612, 199);
            this.listBox_modslist.TabIndex = 13;
            this.listBox_modslist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_modslist_MouseClick);
            // 
            // button_previewmod
            // 
            this.button_previewmod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_previewmod.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_previewmod.Location = new System.Drawing.Point(745, 404);
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
            this.button_installmod.Location = new System.Drawing.Point(638, 404);
            this.button_installmod.Name = "button_installmod";
            this.button_installmod.Size = new System.Drawing.Size(101, 30);
            this.button_installmod.TabIndex = 10;
            this.button_installmod.Text = "Install";
            this.button_installmod.UseVisualStyleBackColor = true;
            this.button_installmod.Click += new System.EventHandler(this.button_installmod_Click);
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
            this.label_description.Location = new System.Drawing.Point(718, 243);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(60, 13);
            this.label_description.TabIndex = 7;
            this.label_description.Text = "Description";
            this.label_description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(637, 193);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(31, 13);
            this.label_type.TabIndex = 6;
            this.label_type.Text = "Type";
            // 
            // label_author
            // 
            this.label_author.AutoSize = true;
            this.label_author.Location = new System.Drawing.Point(637, 154);
            this.label_author.Name = "label_author";
            this.label_author.Size = new System.Drawing.Size(38, 13);
            this.label_author.TabIndex = 5;
            this.label_author.Text = "Author";
            // 
            // label_title
            // 
            System.Drawing.Text.PrivateFontCollection coolvetica = new System.Drawing.Text.PrivateFontCollection();
            coolvetica.AddFontFile("ModsManager\\Resources\\coolvetica.ttf");
            this.label_title.Font = new System.Drawing.Font(coolvetica.Families[0], 21.75F, System.Drawing.FontStyle.Regular);
            //this.label_title.Font = new System.Drawing.Font("Coolvetica", 21.75F);
            this.label_title.Location = new System.Drawing.Point(640, 37);
            this.label_title.Name = "label_title";
            this.label_title.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_title.Size = new System.Drawing.Size(224, 36);
            this.label_title.TabIndex = 4;
            this.label_title.Text = "no_name_found";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(638, 259);
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ReadOnly = true;
            this.textBox_description.Size = new System.Drawing.Size(231, 139);
            this.textBox_description.TabIndex = 3;
            this.textBox_description.Text = "no_description_found";
            // 
            // textBox_type
            // 
            this.textBox_type.Location = new System.Drawing.Point(680, 190);
            this.textBox_type.Name = "textBox_type";
            this.textBox_type.ReadOnly = true;
            this.textBox_type.Size = new System.Drawing.Size(189, 20);
            this.textBox_type.TabIndex = 2;
            this.textBox_type.Text = "no_type_found";
            // 
            // textBox_author
            // 
            this.textBox_author.Location = new System.Drawing.Point(680, 151);
            this.textBox_author.Name = "textBox_author";
            this.textBox_author.ReadOnly = true;
            this.textBox_author.Size = new System.Drawing.Size(189, 20);
            this.textBox_author.TabIndex = 1;
            this.textBox_author.Text = "no_author_found";
            // 
            // tabConfig
            // 
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(875, 437);
            this.tabConfig.TabIndex = 1;
            this.tabConfig.Text = "Options";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 465);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabConfig;
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
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}