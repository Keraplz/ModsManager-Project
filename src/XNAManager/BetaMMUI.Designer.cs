namespace ModsManager
{
    partial class BetaMMUI
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
            this.components = new System.ComponentModel.Container();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.button_Maximize = new System.Windows.Forms.Button();
            this.button_Minimize = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.timer_Menu = new System.Windows.Forms.Timer(this.components);
            this.panel_Tabs = new System.Windows.Forms.Panel();
            this.button_Tools = new System.Windows.Forms.Button();
            this.button_Menu = new System.Windows.Forms.Button();
            this.button_Config = new System.Windows.Forms.Button();
            this.panel_Game = new System.Windows.Forms.Panel();
            this.HScrollBar_ModsList = new System.Windows.Forms.HScrollBar();
            this.comboBox_Games = new System.Windows.Forms.ComboBox();
            this.button_Play = new System.Windows.Forms.Button();
            this.button_ModsList = new System.Windows.Forms.Button();
            this.button_CloseMenu = new System.Windows.Forms.Button();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.panel_Config = new System.Windows.Forms.Panel();
            this.button_CloseConfig = new System.Windows.Forms.Button();
            this.panel_Tools = new System.Windows.Forms.Panel();
            this.panel_ConfigTop = new System.Windows.Forms.Panel();
            this.label_ToolsTitle = new System.Windows.Forms.Label();
            this.button_CloseTools = new System.Windows.Forms.Button();
            this.panel_ModsList = new System.Windows.Forms.Panel();
            this.toolTip_MainButtons = new System.Windows.Forms.ToolTip(this.components);
            this.timer_Tools = new System.Windows.Forms.Timer(this.components);
            this.timer_Options = new System.Windows.Forms.Timer(this.components);
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel_Tabs.SuspendLayout();
            this.panel_Game.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            this.panel_Config.SuspendLayout();
            this.panel_Tools.SuspendLayout();
            this.panel_ConfigTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Black;
            this.panel_Top.Controls.Add(this.button_Maximize);
            this.panel_Top.Controls.Add(this.button_Minimize);
            this.panel_Top.Controls.Add(this.Logo);
            this.panel_Top.Controls.Add(this.button_Exit);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(1020, 50);
            this.panel_Top.TabIndex = 1;
            this.panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // button_Maximize
            // 
            this.button_Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Maximize.BackColor = System.Drawing.Color.Transparent;
            this.button_Maximize.BackgroundImage = global::ModsManager.Properties.Resources.White_Fit_to_Width_100px;
            this.button_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Maximize.Location = new System.Drawing.Point(920, 0);
            this.button_Maximize.Name = "button_Maximize";
            this.button_Maximize.Size = new System.Drawing.Size(50, 50);
            this.button_Maximize.TabIndex = 5;
            this.button_Maximize.UseVisualStyleBackColor = false;
            this.button_Maximize.Click += new System.EventHandler(this.button_Maximize_Click);
            // 
            // button_Minimize
            // 
            this.button_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.button_Minimize.BackgroundImage = global::ModsManager.Properties.Resources.White_Minimize_Window_96px;
            this.button_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Minimize.Location = new System.Drawing.Point(870, 0);
            this.button_Minimize.Name = "button_Minimize";
            this.button_Minimize.Size = new System.Drawing.Size(50, 50);
            this.button_Minimize.TabIndex = 4;
            this.button_Minimize.UseVisualStyleBackColor = false;
            this.button_Minimize.Click += new System.EventHandler(this.button_Minimize_Click);
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
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Location = new System.Drawing.Point(970, 0);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(50, 50);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // timer_Menu
            // 
            this.timer_Menu.Interval = 30;
            this.timer_Menu.Tick += new System.EventHandler(this.timer_Menu_Tick);
            // 
            // panel_Tabs
            // 
            this.panel_Tabs.BackColor = System.Drawing.Color.Black;
            this.panel_Tabs.Controls.Add(this.button_Tools);
            this.panel_Tabs.Controls.Add(this.button_Menu);
            this.panel_Tabs.Controls.Add(this.button_Config);
            this.panel_Tabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Tabs.Location = new System.Drawing.Point(0, 50);
            this.panel_Tabs.Name = "panel_Tabs";
            this.panel_Tabs.Size = new System.Drawing.Size(50, 550);
            this.panel_Tabs.TabIndex = 0;
            // 
            // button_Tools
            // 
            this.button_Tools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Tools.BackColor = System.Drawing.Color.Transparent;
            this.button_Tools.BackgroundImage = global::ModsManager.Properties.Resources.White_Wrench_100px;
            this.button_Tools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Tools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Tools.Location = new System.Drawing.Point(0, 450);
            this.button_Tools.Name = "button_Tools";
            this.button_Tools.Size = new System.Drawing.Size(50, 50);
            this.button_Tools.TabIndex = 4;
            this.toolTip_MainButtons.SetToolTip(this.button_Tools, "Tools");
            this.button_Tools.UseVisualStyleBackColor = false;
            this.button_Tools.Click += new System.EventHandler(this.button_Tools_Click);
            // 
            // button_Menu
            // 
            this.button_Menu.BackColor = System.Drawing.Color.Transparent;
            this.button_Menu.BackgroundImage = global::ModsManager.Properties.Resources.White_User_Menu_Male_100px;
            this.button_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Menu.Location = new System.Drawing.Point(0, 0);
            this.button_Menu.Name = "button_Menu";
            this.button_Menu.Size = new System.Drawing.Size(50, 50);
            this.button_Menu.TabIndex = 3;
            this.toolTip_MainButtons.SetToolTip(this.button_Menu, "Profile Info");
            this.button_Menu.UseVisualStyleBackColor = false;
            this.button_Menu.Click += new System.EventHandler(this.button_Menu_Click);
            // 
            // button_Config
            // 
            this.button_Config.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Config.BackColor = System.Drawing.Color.Transparent;
            this.button_Config.BackgroundImage = global::ModsManager.Properties.Resources.White_Automation_100px;
            this.button_Config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Config.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Config.Location = new System.Drawing.Point(0, 500);
            this.button_Config.Name = "button_Config";
            this.button_Config.Size = new System.Drawing.Size(50, 50);
            this.button_Config.TabIndex = 2;
            this.toolTip_MainButtons.SetToolTip(this.button_Config, "Options");
            this.button_Config.UseVisualStyleBackColor = false;
            this.button_Config.Click += new System.EventHandler(this.button_Config_Click);
            // 
            // panel_Game
            // 
            this.panel_Game.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_Game.Controls.Add(this.HScrollBar_ModsList);
            this.panel_Game.Controls.Add(this.comboBox_Games);
            this.panel_Game.Controls.Add(this.button_Play);
            this.panel_Game.Controls.Add(this.button_ModsList);
            this.panel_Game.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Game.Location = new System.Drawing.Point(50, 550);
            this.panel_Game.Name = "panel_Game";
            this.panel_Game.Size = new System.Drawing.Size(970, 50);
            this.panel_Game.TabIndex = 3;
            // 
            // HScrollBar_ModsList
            // 
            this.HScrollBar_ModsList.Location = new System.Drawing.Point(0, 16);
            this.HScrollBar_ModsList.Name = "HScrollBar_ModsList";
            this.HScrollBar_ModsList.Size = new System.Drawing.Size(970, 25);
            this.HScrollBar_ModsList.TabIndex = 0;
            this.HScrollBar_ModsList.Visible = false;
            // 
            // comboBox_Games
            // 
            this.comboBox_Games.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Games.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_Games.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox_Games.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Games.FormattingEnabled = true;
            this.comboBox_Games.ItemHeight = 44;
            this.comboBox_Games.Items.AddRange(new object[] {
            "SpeedRunners",
            "Bloons TD Battles"});
            this.comboBox_Games.Location = new System.Drawing.Point(720, 0);
            this.comboBox_Games.Name = "comboBox_Games";
            this.comboBox_Games.Size = new System.Drawing.Size(150, 50);
            this.comboBox_Games.TabIndex = 5;
            this.comboBox_Games.Text = "GAME_NAME";
            // 
            // button_Play
            // 
            this.button_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Play.BackColor = System.Drawing.Color.Transparent;
            this.button_Play.BackgroundImage = global::ModsManager.Properties.Resources.White_Play_100px;
            this.button_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Play.Location = new System.Drawing.Point(920, 0);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(50, 50);
            this.button_Play.TabIndex = 4;
            this.toolTip_MainButtons.SetToolTip(this.button_Play, "Play Game");
            this.button_Play.UseVisualStyleBackColor = false;
            // 
            // button_ModsList
            // 
            this.button_ModsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ModsList.BackColor = System.Drawing.Color.Transparent;
            this.button_ModsList.BackgroundImage = global::ModsManager.Properties.Resources.White_Dragon_100px;
            this.button_ModsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_ModsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ModsList.Location = new System.Drawing.Point(870, 0);
            this.button_ModsList.Name = "button_ModsList";
            this.button_ModsList.Size = new System.Drawing.Size(50, 50);
            this.button_ModsList.TabIndex = 3;
            this.toolTip_MainButtons.SetToolTip(this.button_ModsList, "Mods List");
            this.button_ModsList.UseVisualStyleBackColor = false;
            this.button_ModsList.Click += new System.EventHandler(this.button_ModsList_Click);
            // 
            // button_CloseMenu
            // 
            this.button_CloseMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CloseMenu.BackColor = System.Drawing.Color.Transparent;
            this.button_CloseMenu.BackgroundImage = global::ModsManager.Properties.Resources.White_Close_100px;
            this.button_CloseMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CloseMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CloseMenu.Location = new System.Drawing.Point(-50, 0);
            this.button_CloseMenu.Name = "button_CloseMenu";
            this.button_CloseMenu.Size = new System.Drawing.Size(50, 50);
            this.button_CloseMenu.TabIndex = 1;
            this.button_CloseMenu.UseVisualStyleBackColor = false;
            this.button_CloseMenu.Click += new System.EventHandler(this.button_MenuClose_Click);
            // 
            // panel_Menu
            // 
            this.panel_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Menu.Controls.Add(this.button_CloseMenu);
            this.panel_Menu.Location = new System.Drawing.Point(50, 50);
            this.panel_Menu.MaximumSize = new System.Drawing.Size(230, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(0, 500);
            this.panel_Menu.TabIndex = 5;
            // 
            // panel_Config
            // 
            this.panel_Config.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Config.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Config.Controls.Add(this.button_CloseConfig);
            this.panel_Config.Location = new System.Drawing.Point(50, 50);
            this.panel_Config.MaximumSize = new System.Drawing.Size(230, 0);
            this.panel_Config.Name = "panel_Config";
            this.panel_Config.Size = new System.Drawing.Size(0, 500);
            this.panel_Config.TabIndex = 6;
            // 
            // button_CloseConfig
            // 
            this.button_CloseConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CloseConfig.BackColor = System.Drawing.Color.Transparent;
            this.button_CloseConfig.BackgroundImage = global::ModsManager.Properties.Resources.White_Close_100px;
            this.button_CloseConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CloseConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CloseConfig.Location = new System.Drawing.Point(-50, 0);
            this.button_CloseConfig.Name = "button_CloseConfig";
            this.button_CloseConfig.Size = new System.Drawing.Size(50, 50);
            this.button_CloseConfig.TabIndex = 1;
            this.button_CloseConfig.UseVisualStyleBackColor = false;
            this.button_CloseConfig.Click += new System.EventHandler(this.button_CloseConfig_Click);
            // 
            // panel_Tools
            // 
            this.panel_Tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Tools.Controls.Add(this.panel_ConfigTop);
            this.panel_Tools.Location = new System.Drawing.Point(50, 50);
            this.panel_Tools.MaximumSize = new System.Drawing.Size(230, 0);
            this.panel_Tools.Name = "panel_Tools";
            this.panel_Tools.Size = new System.Drawing.Size(0, 500);
            this.panel_Tools.TabIndex = 6;
            // 
            // panel_ConfigTop
            // 
            this.panel_ConfigTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_ConfigTop.Controls.Add(this.label_ToolsTitle);
            this.panel_ConfigTop.Controls.Add(this.button_CloseTools);
            this.panel_ConfigTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ConfigTop.Location = new System.Drawing.Point(0, 0);
            this.panel_ConfigTop.Name = "panel_ConfigTop";
            this.panel_ConfigTop.Size = new System.Drawing.Size(0, 50);
            this.panel_ConfigTop.TabIndex = 2;
            // 
            // label_ToolsTitle
            // 
            this.label_ToolsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ToolsTitle.AutoSize = true;
            this.label_ToolsTitle.BackColor = System.Drawing.Color.Transparent;
            this.label_ToolsTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_ToolsTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ToolsTitle.ForeColor = System.Drawing.Color.White;
            this.label_ToolsTitle.Location = new System.Drawing.Point(-220, 10);
            this.label_ToolsTitle.Name = "label_ToolsTitle";
            this.label_ToolsTitle.Size = new System.Drawing.Size(64, 30);
            this.label_ToolsTitle.TabIndex = 2;
            this.label_ToolsTitle.Text = "Tools";
            this.label_ToolsTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button_CloseTools
            // 
            this.button_CloseTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CloseTools.BackColor = System.Drawing.Color.Transparent;
            this.button_CloseTools.BackgroundImage = global::ModsManager.Properties.Resources.White_Close_100px;
            this.button_CloseTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_CloseTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CloseTools.Location = new System.Drawing.Point(-50, 0);
            this.button_CloseTools.Name = "button_CloseTools";
            this.button_CloseTools.Size = new System.Drawing.Size(50, 50);
            this.button_CloseTools.TabIndex = 1;
            this.button_CloseTools.UseVisualStyleBackColor = false;
            this.button_CloseTools.Click += new System.EventHandler(this.button_CloseTools_Click);
            // 
            // panel_ModsList
            // 
            this.panel_ModsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_ModsList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_ModsList.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel_ModsList.Location = new System.Drawing.Point(50, 50);
            this.panel_ModsList.MinimumSize = new System.Drawing.Size(970, 500);
            this.panel_ModsList.Name = "panel_ModsList";
            this.panel_ModsList.Size = new System.Drawing.Size(970, 500);
            this.panel_ModsList.TabIndex = 6;
            // 
            // toolTip_MainButtons
            // 
            this.toolTip_MainButtons.AutomaticDelay = 100;
            this.toolTip_MainButtons.UseAnimation = false;
            this.toolTip_MainButtons.UseFading = false;
            // 
            // timer_Tools
            // 
            this.timer_Tools.Interval = 30;
            this.timer_Tools.Tick += new System.EventHandler(this.timer_Tools_Tick);
            // 
            // timer_Options
            // 
            this.timer_Options.Interval = 30;
            this.timer_Options.Tick += new System.EventHandler(this.timer_Options_Tick);
            // 
            // BetaMMUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1020, 600);
            this.Controls.Add(this.panel_Config);
            this.Controls.Add(this.panel_Tools);
            this.Controls.Add(this.panel_Game);
            this.Controls.Add(this.panel_Tabs);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.panel_ModsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1020, 600);
            this.Name = "BetaMMUI";
            this.Text = "BetaMMUI";
            this.panel_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel_Tabs.ResumeLayout(false);
            this.panel_Game.ResumeLayout(false);
            this.panel_Menu.ResumeLayout(false);
            this.panel_Config.ResumeLayout(false);
            this.panel_Tools.ResumeLayout(false);
            this.panel_ConfigTop.ResumeLayout(false);
            this.panel_ConfigTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Button button_CloseMenu;
        private System.Windows.Forms.Timer timer_Menu;
        private System.Windows.Forms.Panel panel_Tabs;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button button_Maximize;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.Panel panel_Game;
        private System.Windows.Forms.Button button_Config;
        private System.Windows.Forms.Button button_Menu;
        private System.Windows.Forms.ComboBox comboBox_Games;
        private System.Windows.Forms.Button button_Play;
        private System.Windows.Forms.Button button_ModsList;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Panel panel_ModsList;
        private System.Windows.Forms.HScrollBar HScrollBar_ModsList;
        private System.Windows.Forms.Button button_Tools;
        private System.Windows.Forms.Panel panel_Config;
        private System.Windows.Forms.Panel panel_Tools;
        private System.Windows.Forms.Button button_CloseTools;
        private System.Windows.Forms.Button button_CloseConfig;
        private System.Windows.Forms.ToolTip toolTip_MainButtons;
        private System.Windows.Forms.Timer timer_Tools;
        private System.Windows.Forms.Timer timer_Options;
        private System.Windows.Forms.Panel panel_ConfigTop;
        private System.Windows.Forms.Label label_ToolsTitle;
    }
}