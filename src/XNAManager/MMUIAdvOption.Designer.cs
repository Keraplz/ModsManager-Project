namespace ModsManager
{
    partial class MMUIAdvOption
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
            this.panel_Top = new System.Windows.Forms.Panel();
            this.label_Title = new System.Windows.Forms.Label();
            this.button_Maximize = new System.Windows.Forms.Button();
            this.button_Minimize = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Seperator02 = new System.Windows.Forms.Label();
            this.pictureBox_Apply = new System.Windows.Forms.PictureBox();
            this.button_Apply = new System.Windows.Forms.Button();
            this.pictureBox_ResetSettings = new System.Windows.Forms.PictureBox();
            this.button_ResetSettings = new System.Windows.Forms.Button();
            this.label_Seperator03 = new System.Windows.Forms.Label();
            this.label_Seperator01 = new System.Windows.Forms.Label();
            this.label_SpeedRunners_Title = new System.Windows.Forms.Label();
            this.textBox_SpeedRunnersFolder = new System.Windows.Forms.TextBox();
            this.button_SelectFolder = new System.Windows.Forms.Button();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ResetSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Black;
            this.panel_Top.Controls.Add(this.label_Title);
            this.panel_Top.Controls.Add(this.button_Maximize);
            this.panel_Top.Controls.Add(this.button_Minimize);
            this.panel_Top.Controls.Add(this.Logo);
            this.panel_Top.Controls.Add(this.button_Exit);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(760, 50);
            this.panel_Top.TabIndex = 2;
            this.panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.BackColor = System.Drawing.Color.Transparent;
            this.label_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(106, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(194, 30);
            this.label_Title.TabIndex = 7;
            this.label_Title.Text = "Advanced Options";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseDown);
            this.label_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseMove);
            this.label_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseUp);
            // 
            // button_Maximize
            // 
            this.button_Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Maximize.BackColor = System.Drawing.Color.Transparent;
            this.button_Maximize.BackgroundImage = global::ModsManager.Properties.Resources.Gray_Fit_to_Width_100px;
            this.button_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Maximize.Enabled = false;
            this.button_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Maximize.Location = new System.Drawing.Point(660, 0);
            this.button_Maximize.Name = "button_Maximize";
            this.button_Maximize.Size = new System.Drawing.Size(50, 50);
            this.button_Maximize.TabIndex = 5;
            this.button_Maximize.UseVisualStyleBackColor = false;
            // 
            // button_Minimize
            // 
            this.button_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.button_Minimize.BackgroundImage = global::ModsManager.Properties.Resources.White_Minimize_Window_96px;
            this.button_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Minimize.Location = new System.Drawing.Point(610, 0);
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.Size = new System.Drawing.Size(50, 50);
            this.button_Minimize.TabIndex = 4;
            this.button_Minimize.UseVisualStyleBackColor = false;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImage = global::ModsManager.Properties.Resources.Logo_100x50;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Logo.Enabled = false;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(100, 50);
            this.Logo.TabIndex = 3;
            this.Logo.TabStop = false;
            // 
            // button_Exit
            // 
            this.button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Exit.BackColor = System.Drawing.Color.Transparent;
            this.button_Exit.BackgroundImage = global::ModsManager.Properties.Resources.White_Close_100px;
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Location = new System.Drawing.Point(710, 0);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(50, 50);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.Color.Black;
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 50);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(50, 390);
            this.panel_Left.TabIndex = 3;
            this.panel_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Left_MouseDown);
            this.panel_Left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Left_MouseMove);
            this.panel_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Left_MouseUp);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_Bottom.Controls.Add(this.pictureBox1);
            this.panel_Bottom.Controls.Add(this.button_Cancel);
            this.panel_Bottom.Controls.Add(this.label_Seperator02);
            this.panel_Bottom.Controls.Add(this.pictureBox_Apply);
            this.panel_Bottom.Controls.Add(this.button_Apply);
            this.panel_Bottom.Controls.Add(this.pictureBox_ResetSettings);
            this.panel_Bottom.Controls.Add(this.button_ResetSettings);
            this.panel_Bottom.Controls.Add(this.label_Seperator03);
            this.panel_Bottom.Controls.Add(this.label_Seperator01);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(50, 390);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(710, 50);
            this.panel_Bottom.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::ModsManager.Properties.Resources.White_Close_100px;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(420, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.button_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cancel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_Cancel.ForeColor = System.Drawing.Color.White;
            this.button_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Cancel.Location = new System.Drawing.Point(420, 0);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(128, 50);
            this.button_Cancel.TabIndex = 15;
            this.button_Cancel.Text = "          Cancel";
            this.button_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label_Seperator02
            // 
            this.label_Seperator02.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Seperator02.AutoSize = true;
            this.label_Seperator02.BackColor = System.Drawing.Color.Transparent;
            this.label_Seperator02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Seperator02.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seperator02.ForeColor = System.Drawing.Color.White;
            this.label_Seperator02.Location = new System.Drawing.Point(400, -4);
            this.label_Seperator02.Name = "label_Seperator02";
            this.label_Seperator02.Size = new System.Drawing.Size(31, 47);
            this.label_Seperator02.TabIndex = 17;
            this.label_Seperator02.Text = "|";
            this.label_Seperator02.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBox_Apply
            // 
            this.pictureBox_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Apply.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Apply.BackgroundImage = global::ModsManager.Properties.Resources.White_Advance_100px;
            this.pictureBox_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Apply.Enabled = false;
            this.pictureBox_Apply.Location = new System.Drawing.Point(660, 0);
            this.pictureBox_Apply.Name = "pictureBox_Apply";
            this.pictureBox_Apply.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Apply.TabIndex = 9;
            this.pictureBox_Apply.TabStop = false;
            // 
            // button_Apply
            // 
            this.button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Apply.BackColor = System.Drawing.Color.Transparent;
            this.button_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Apply.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_Apply.ForeColor = System.Drawing.Color.White;
            this.button_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Apply.Location = new System.Drawing.Point(560, 0);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(150, 50);
            this.button_Apply.TabIndex = 8;
            this.button_Apply.Text = "    Apply";
            this.button_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Apply.UseVisualStyleBackColor = false;
            // 
            // pictureBox_ResetSettings
            // 
            this.pictureBox_ResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_ResetSettings.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ResetSettings.BackgroundImage = global::ModsManager.Properties.Resources.Gray_Close_100px;
            this.pictureBox_ResetSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_ResetSettings.Enabled = false;
            this.pictureBox_ResetSettings.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_ResetSettings.Name = "pictureBox_ResetSettings";
            this.pictureBox_ResetSettings.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_ResetSettings.TabIndex = 7;
            this.pictureBox_ResetSettings.TabStop = false;
            // 
            // button_ResetSettings
            // 
            this.button_ResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ResetSettings.BackColor = System.Drawing.Color.Transparent;
            this.button_ResetSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ResetSettings.Enabled = false;
            this.button_ResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ResetSettings.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_ResetSettings.ForeColor = System.Drawing.Color.White;
            this.button_ResetSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ResetSettings.Location = new System.Drawing.Point(0, 0);
            this.button_ResetSettings.Name = "button_ResetSettings";
            this.button_ResetSettings.Size = new System.Drawing.Size(195, 50);
            this.button_ResetSettings.TabIndex = 3;
            this.button_ResetSettings.Text = "          Reset Settings";
            this.button_ResetSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ResetSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ResetSettings.UseVisualStyleBackColor = false;
            // 
            // label_Seperator03
            // 
            this.label_Seperator03.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Seperator03.AutoSize = true;
            this.label_Seperator03.BackColor = System.Drawing.Color.Transparent;
            this.label_Seperator03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Seperator03.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seperator03.ForeColor = System.Drawing.Color.White;
            this.label_Seperator03.Location = new System.Drawing.Point(540, -4);
            this.label_Seperator03.Name = "label_Seperator03";
            this.label_Seperator03.Size = new System.Drawing.Size(31, 47);
            this.label_Seperator03.TabIndex = 13;
            this.label_Seperator03.Text = "|";
            this.label_Seperator03.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_Seperator01
            // 
            this.label_Seperator01.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Seperator01.AutoSize = true;
            this.label_Seperator01.BackColor = System.Drawing.Color.Transparent;
            this.label_Seperator01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Seperator01.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seperator01.ForeColor = System.Drawing.Color.White;
            this.label_Seperator01.Location = new System.Drawing.Point(188, -4);
            this.label_Seperator01.Name = "label_Seperator01";
            this.label_Seperator01.Size = new System.Drawing.Size(31, 47);
            this.label_Seperator01.TabIndex = 14;
            this.label_Seperator01.Text = "|";
            this.label_Seperator01.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_SpeedRunners_Title
            // 
            this.label_SpeedRunners_Title.AutoSize = true;
            this.label_SpeedRunners_Title.BackColor = System.Drawing.Color.Transparent;
            this.label_SpeedRunners_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_SpeedRunners_Title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SpeedRunners_Title.ForeColor = System.Drawing.Color.White;
            this.label_SpeedRunners_Title.Location = new System.Drawing.Point(91, 134);
            this.label_SpeedRunners_Title.Name = "label_SpeedRunners_Title";
            this.label_SpeedRunners_Title.Size = new System.Drawing.Size(222, 30);
            this.label_SpeedRunners_Title.TabIndex = 8;
            this.label_SpeedRunners_Title.Text = "SpeedRunners Folder";
            this.label_SpeedRunners_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_SpeedRunnersFolder
            // 
            this.textBox_SpeedRunnersFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_SpeedRunnersFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_SpeedRunnersFolder.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SpeedRunnersFolder.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox_SpeedRunnersFolder.Location = new System.Drawing.Point(50, 168);
            this.textBox_SpeedRunnersFolder.Multiline = true;
            this.textBox_SpeedRunnersFolder.Name = "textBox_SpeedRunnersFolder";
            this.textBox_SpeedRunnersFolder.ReadOnly = true;
            this.textBox_SpeedRunnersFolder.Size = new System.Drawing.Size(575, 38);
            this.textBox_SpeedRunnersFolder.TabIndex = 9;
            this.textBox_SpeedRunnersFolder.TabStop = false;
            // 
            // button_SelectFolder
            // 
            this.button_SelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_SelectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_SelectFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_SelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SelectFolder.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_SelectFolder.ForeColor = System.Drawing.Color.White;
            this.button_SelectFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_SelectFolder.Location = new System.Drawing.Point(625, 168);
            this.button_SelectFolder.Name = "button_SelectFolder";
            this.button_SelectFolder.Size = new System.Drawing.Size(135, 38);
            this.button_SelectFolder.TabIndex = 10;
            this.button_SelectFolder.Text = "Select Folder";
            this.button_SelectFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_SelectFolder.UseVisualStyleBackColor = false;
            this.button_SelectFolder.Click += new System.EventHandler(this.button_SelectFolder_Click);
            // 
            // MMUIAdvOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(760, 440);
            this.Controls.Add(this.button_SelectFolder);
            this.Controls.Add(this.textBox_SpeedRunnersFolder);
            this.Controls.Add(this.label_SpeedRunners_Title);
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.panel_Left);
            this.Controls.Add(this.panel_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MMUIAdvOption";
            this.Text = "MMUIAdvOption";
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ResetSettings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Button button_Maximize;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.PictureBox pictureBox_Apply;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.PictureBox pictureBox_ResetSettings;
        private System.Windows.Forms.Button button_ResetSettings;
        private System.Windows.Forms.Label label_Seperator03;
        private System.Windows.Forms.Label label_Seperator01;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Seperator02;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_SpeedRunners_Title;
        private System.Windows.Forms.TextBox textBox_SpeedRunnersFolder;
        private System.Windows.Forms.Button button_SelectFolder;
    }
}