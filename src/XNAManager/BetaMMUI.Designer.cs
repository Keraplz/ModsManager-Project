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
            this.label_Title = new System.Windows.Forms.Label();
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
            this.button_Refresh = new System.Windows.Forms.Button();
            this.comboBox_Games = new System.Windows.Forms.ComboBox();
            this.button_Play = new System.Windows.Forms.Button();
            this.button_ModsFolder = new System.Windows.Forms.Button();
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.button_ModsOnline = new System.Windows.Forms.Button();
            this.panel_MenuTop = new System.Windows.Forms.Panel();
            this.label_MenuTitle = new System.Windows.Forms.Label();
            this.button_CloseMenu = new System.Windows.Forms.Button();
            this.panel_Config = new System.Windows.Forms.Panel();
            this.button_AdvOption = new System.Windows.Forms.Button();
            this.panel_ConfigBottom = new System.Windows.Forms.Panel();
            this.button_ReportBug = new System.Windows.Forms.Button();
            this.panel_ConfigTop = new System.Windows.Forms.Panel();
            this.button_CloseConfig = new System.Windows.Forms.Button();
            this.label_OptionsTitle = new System.Windows.Forms.Label();
            this.panel_Tools = new System.Windows.Forms.Panel();
            this.button_OpenConverter = new System.Windows.Forms.Button();
            this.panel_ToolsTop = new System.Windows.Forms.Panel();
            this.label_ToolsTitle = new System.Windows.Forms.Label();
            this.button_CloseTools = new System.Windows.Forms.Button();
            this.toolTip_MainButtons = new System.Windows.Forms.ToolTip(this.components);
            this.timer_Tools = new System.Windows.Forms.Timer(this.components);
            this.timer_Config = new System.Windows.Forms.Timer(this.components);
            this.timer_Start = new System.Windows.Forms.Timer(this.components);
            this.timer_Start_Fade01 = new System.Windows.Forms.Timer(this.components);
            this.timer_Start_Fade02 = new System.Windows.Forms.Timer(this.components);
            this.timer_Start_Fade03 = new System.Windows.Forms.Timer(this.components);
            this.timer_Start_Fade04 = new System.Windows.Forms.Timer(this.components);
            this.timer_Start_Fade05 = new System.Windows.Forms.Timer(this.components);
            this.panel_ChildDisplay = new System.Windows.Forms.Panel();
            this.flatButton2 = new MMUIControls.FlatButton();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel_Tabs.SuspendLayout();
            this.panel_Game.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            this.panel_MenuTop.SuspendLayout();
            this.panel_Config.SuspendLayout();
            this.panel_ConfigBottom.SuspendLayout();
            this.panel_ConfigTop.SuspendLayout();
            this.panel_Tools.SuspendLayout();
            this.panel_ToolsTop.SuspendLayout();
            this.panel_ChildDisplay.SuspendLayout();
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
            this.panel_Top.Size = new System.Drawing.Size(1020, 50);
            this.panel_Top.TabIndex = 1;
            this.panel_Top.DoubleClick += new System.EventHandler(this.panel_Top_DoubleClick);
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
            this.label_Title.Size = new System.Drawing.Size(0, 30);
            this.label_Title.TabIndex = 8;
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // button_Maximize
            // 
            this.button_Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Maximize.BackColor = System.Drawing.Color.Transparent;
            this.button_Maximize.BackgroundImage = global::ModsManager.Properties.Resources.Gray_Fit_to_Width_100px;
            this.button_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Maximize.Enabled = false;
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
            this.button_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.timer_Menu.Interval = 8;
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
            this.panel_Tabs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Tabs_MouseDown);
            this.panel_Tabs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Tabs_MouseMove);
            this.panel_Tabs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Tabs_MouseUp);
            // 
            // button_Tools
            // 
            this.button_Tools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Tools.BackColor = System.Drawing.Color.Transparent;
            this.button_Tools.BackgroundImage = global::ModsManager.Properties.Resources.White_Wrench_100px;
            this.button_Tools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.button_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.button_Config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
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
            this.panel_Game.Controls.Add(this.flatButton2);
            this.panel_Game.Controls.Add(this.button_Refresh);
            this.panel_Game.Controls.Add(this.comboBox_Games);
            this.panel_Game.Controls.Add(this.button_Play);
            this.panel_Game.Controls.Add(this.button_ModsFolder);
            this.panel_Game.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Game.Location = new System.Drawing.Point(50, 550);
            this.panel_Game.Name = "panel_Game";
            this.panel_Game.Size = new System.Drawing.Size(970, 50);
            this.panel_Game.TabIndex = 3;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.button_Refresh.BackgroundImage = global::ModsManager.Properties.Resources.White_Refresh_100px;
            this.button_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Refresh.Location = new System.Drawing.Point(870, 0);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(50, 50);
            this.button_Refresh.TabIndex = 5;
            this.toolTip_MainButtons.SetToolTip(this.button_Refresh, "Refresh Mods");
            this.button_Refresh.UseVisualStyleBackColor = false;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
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
            this.comboBox_Games.Location = new System.Drawing.Point(670, 0);
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
            this.button_Play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Play.Location = new System.Drawing.Point(920, 0);
            this.button_Play.Name = "button_Play";
            this.button_Play.Size = new System.Drawing.Size(50, 50);
            this.button_Play.TabIndex = 4;
            this.toolTip_MainButtons.SetToolTip(this.button_Play, "Play Game");
            this.button_Play.UseVisualStyleBackColor = false;
            this.button_Play.Click += new System.EventHandler(this.button_Play_Click);
            // 
            // button_ModsFolder
            // 
            this.button_ModsFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ModsFolder.BackColor = System.Drawing.Color.Transparent;
            this.button_ModsFolder.BackgroundImage = global::ModsManager.Properties.Resources.White_Extensions_Folder_100px;
            this.button_ModsFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ModsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ModsFolder.Location = new System.Drawing.Point(820, 0);
            this.button_ModsFolder.Name = "button_ModsFolder";
            this.button_ModsFolder.Size = new System.Drawing.Size(50, 50);
            this.button_ModsFolder.TabIndex = 3;
            this.toolTip_MainButtons.SetToolTip(this.button_ModsFolder, "Open Mods Folder");
            this.button_ModsFolder.UseVisualStyleBackColor = false;
            this.button_ModsFolder.Click += new System.EventHandler(this.button_ModsFolder_Click);
            // 
            // panel_Menu
            // 
            this.panel_Menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Menu.Controls.Add(this.button_ModsOnline);
            this.panel_Menu.Controls.Add(this.panel_MenuTop);
            this.panel_Menu.Location = new System.Drawing.Point(50, 50);
            this.panel_Menu.MaximumSize = new System.Drawing.Size(230, 0);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(0, 500);
            this.panel_Menu.TabIndex = 5;
            // 
            // button_ModsOnline
            // 
            this.button_ModsOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ModsOnline.BackColor = System.Drawing.Color.Transparent;
            this.button_ModsOnline.BackgroundImage = global::ModsManager.Properties.Resources.White_Automation_100px;
            this.button_ModsOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ModsOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ModsOnline.Location = new System.Drawing.Point(180, 450);
            this.button_ModsOnline.Name = "button_ModsOnline";
            this.button_ModsOnline.Size = new System.Drawing.Size(50, 50);
            this.button_ModsOnline.TabIndex = 4;
            this.toolTip_MainButtons.SetToolTip(this.button_ModsOnline, "Download Mods");
            this.button_ModsOnline.UseVisualStyleBackColor = false;
            this.button_ModsOnline.Click += new System.EventHandler(this.button_ModsOnline_Click);
            // 
            // panel_MenuTop
            // 
            this.panel_MenuTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_MenuTop.Controls.Add(this.label_MenuTitle);
            this.panel_MenuTop.Controls.Add(this.button_CloseMenu);
            this.panel_MenuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_MenuTop.Location = new System.Drawing.Point(0, 0);
            this.panel_MenuTop.Name = "panel_MenuTop";
            this.panel_MenuTop.Size = new System.Drawing.Size(0, 50);
            this.panel_MenuTop.TabIndex = 3;
            // 
            // label_MenuTitle
            // 
            this.label_MenuTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_MenuTitle.AutoSize = true;
            this.label_MenuTitle.BackColor = System.Drawing.Color.Transparent;
            this.label_MenuTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_MenuTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MenuTitle.ForeColor = System.Drawing.Color.White;
            this.label_MenuTitle.Location = new System.Drawing.Point(-220, 10);
            this.label_MenuTitle.Name = "label_MenuTitle";
            this.label_MenuTitle.Size = new System.Drawing.Size(70, 30);
            this.label_MenuTitle.TabIndex = 2;
            this.label_MenuTitle.Text = "Menu";
            this.label_MenuTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            // panel_Config
            // 
            this.panel_Config.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Config.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Config.Controls.Add(this.button_AdvOption);
            this.panel_Config.Controls.Add(this.panel_ConfigBottom);
            this.panel_Config.Controls.Add(this.panel_ConfigTop);
            this.panel_Config.Location = new System.Drawing.Point(50, 50);
            this.panel_Config.MaximumSize = new System.Drawing.Size(230, 0);
            this.panel_Config.Name = "panel_Config";
            this.panel_Config.Size = new System.Drawing.Size(0, 500);
            this.panel_Config.TabIndex = 6;
            // 
            // button_AdvOption
            // 
            this.button_AdvOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AdvOption.BackColor = System.Drawing.Color.Transparent;
            this.button_AdvOption.BackgroundImage = global::ModsManager.Properties.Resources.White_More_100px;
            this.button_AdvOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_AdvOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AdvOption.Location = new System.Drawing.Point(-230, 400);
            this.button_AdvOption.MinimumSize = new System.Drawing.Size(230, 50);
            this.button_AdvOption.Name = "button_AdvOption";
            this.button_AdvOption.Size = new System.Drawing.Size(230, 50);
            this.button_AdvOption.TabIndex = 7;
            this.toolTip_MainButtons.SetToolTip(this.button_AdvOption, "Advanced Options");
            this.button_AdvOption.UseVisualStyleBackColor = false;
            this.button_AdvOption.Click += new System.EventHandler(this.button_AdvOption_Click);
            // 
            // panel_ConfigBottom
            // 
            this.panel_ConfigBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_ConfigBottom.Controls.Add(this.button_ReportBug);
            this.panel_ConfigBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_ConfigBottom.Location = new System.Drawing.Point(0, 450);
            this.panel_ConfigBottom.Name = "panel_ConfigBottom";
            this.panel_ConfigBottom.Size = new System.Drawing.Size(0, 50);
            this.panel_ConfigBottom.TabIndex = 4;
            // 
            // button_ReportBug
            // 
            this.button_ReportBug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ReportBug.BackColor = System.Drawing.Color.Transparent;
            this.button_ReportBug.BackgroundImage = global::ModsManager.Properties.Resources.White_Bug_100px;
            this.button_ReportBug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ReportBug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ReportBug.Location = new System.Drawing.Point(-230, 0);
            this.button_ReportBug.Name = "button_ReportBug";
            this.button_ReportBug.Size = new System.Drawing.Size(50, 50);
            this.button_ReportBug.TabIndex = 6;
            this.toolTip_MainButtons.SetToolTip(this.button_ReportBug, "Report Bug");
            this.button_ReportBug.UseVisualStyleBackColor = false;
            this.button_ReportBug.Click += new System.EventHandler(this.button_ReportBug_Click);
            // 
            // panel_ConfigTop
            // 
            this.panel_ConfigTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_ConfigTop.Controls.Add(this.button_CloseConfig);
            this.panel_ConfigTop.Controls.Add(this.label_OptionsTitle);
            this.panel_ConfigTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ConfigTop.Location = new System.Drawing.Point(0, 0);
            this.panel_ConfigTop.Name = "panel_ConfigTop";
            this.panel_ConfigTop.Size = new System.Drawing.Size(0, 50);
            this.panel_ConfigTop.TabIndex = 3;
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
            // label_OptionsTitle
            // 
            this.label_OptionsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_OptionsTitle.AutoSize = true;
            this.label_OptionsTitle.BackColor = System.Drawing.Color.Transparent;
            this.label_OptionsTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_OptionsTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OptionsTitle.ForeColor = System.Drawing.Color.White;
            this.label_OptionsTitle.Location = new System.Drawing.Point(-220, 10);
            this.label_OptionsTitle.Name = "label_OptionsTitle";
            this.label_OptionsTitle.Size = new System.Drawing.Size(91, 30);
            this.label_OptionsTitle.TabIndex = 2;
            this.label_OptionsTitle.Text = "Options";
            this.label_OptionsTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel_Tools
            // 
            this.panel_Tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_Tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_Tools.Controls.Add(this.button_OpenConverter);
            this.panel_Tools.Controls.Add(this.panel_ToolsTop);
            this.panel_Tools.Location = new System.Drawing.Point(50, 50);
            this.panel_Tools.MaximumSize = new System.Drawing.Size(230, 0);
            this.panel_Tools.Name = "panel_Tools";
            this.panel_Tools.Size = new System.Drawing.Size(0, 500);
            this.panel_Tools.TabIndex = 6;
            // 
            // button_OpenConverter
            // 
            this.button_OpenConverter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OpenConverter.BackColor = System.Drawing.Color.Transparent;
            this.button_OpenConverter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_OpenConverter.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_OpenConverter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_OpenConverter.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OpenConverter.ForeColor = System.Drawing.Color.White;
            this.button_OpenConverter.Location = new System.Drawing.Point(-230, 50);
            this.button_OpenConverter.Name = "button_OpenConverter";
            this.button_OpenConverter.Size = new System.Drawing.Size(230, 50);
            this.button_OpenConverter.TabIndex = 3;
            this.button_OpenConverter.Text = " File Converter";
            this.toolTip_MainButtons.SetToolTip(this.button_OpenConverter, "Open File Converter");
            this.button_OpenConverter.UseVisualStyleBackColor = false;
            this.button_OpenConverter.Click += new System.EventHandler(this.button_OpenConverter_Click);
            // 
            // panel_ToolsTop
            // 
            this.panel_ToolsTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_ToolsTop.Controls.Add(this.label_ToolsTitle);
            this.panel_ToolsTop.Controls.Add(this.button_CloseTools);
            this.panel_ToolsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ToolsTop.Location = new System.Drawing.Point(0, 0);
            this.panel_ToolsTop.Name = "panel_ToolsTop";
            this.panel_ToolsTop.Size = new System.Drawing.Size(0, 50);
            this.panel_ToolsTop.TabIndex = 2;
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
            // toolTip_MainButtons
            // 
            this.toolTip_MainButtons.AutomaticDelay = 100;
            this.toolTip_MainButtons.UseAnimation = false;
            this.toolTip_MainButtons.UseFading = false;
            // 
            // timer_Tools
            // 
            this.timer_Tools.Interval = 8;
            this.timer_Tools.Tick += new System.EventHandler(this.timer_Tools_Tick);
            // 
            // timer_Config
            // 
            this.timer_Config.Interval = 8;
            this.timer_Config.Tick += new System.EventHandler(this.timer_Config_Tick);
            // 
            // timer_Start
            // 
            this.timer_Start.Interval = 20;
            this.timer_Start.Tick += new System.EventHandler(this.timer_Start_Tick);
            // 
            // timer_Start_Fade01
            // 
            this.timer_Start_Fade01.Interval = 20;
            this.timer_Start_Fade01.Tick += new System.EventHandler(this.timer_Start_Fade01_Tick);
            // 
            // timer_Start_Fade02
            // 
            this.timer_Start_Fade02.Interval = 20;
            this.timer_Start_Fade02.Tick += new System.EventHandler(this.timer_Start_Fade02_Tick);
            // 
            // timer_Start_Fade03
            // 
            this.timer_Start_Fade03.Interval = 20;
            this.timer_Start_Fade03.Tick += new System.EventHandler(this.timer_Start_Fade03_Tick);
            // 
            // timer_Start_Fade04
            // 
            this.timer_Start_Fade04.Interval = 20;
            this.timer_Start_Fade04.Tick += new System.EventHandler(this.timer_Start_Fade04_Tick);
            // 
            // timer_Start_Fade05
            // 
            this.timer_Start_Fade05.Interval = 20;
            this.timer_Start_Fade05.Tick += new System.EventHandler(this.timer_Start_Fade05_Tick);
            // 
            // panel_ChildDisplay
            // 
            this.panel_ChildDisplay.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel_ChildDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ChildDisplay.Location = new System.Drawing.Point(50, 50);
            this.panel_ChildDisplay.Name = "panel_ChildDisplay";
            this.panel_ChildDisplay.Size = new System.Drawing.Size(970, 500);
            this.panel_ChildDisplay.TabIndex = 7;
            // 
            // flatButton2
            // 
            this.flatButton2.BorderThickness = 2F;
            this.flatButton2.Location = new System.Drawing.Point(7, 4);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Size = new System.Drawing.Size(75, 23);
            this.flatButton2.TabIndex = 6;
            this.flatButton2.Text = "flatButton2";
            // 
            // BetaMMUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1020, 600);
            this.Controls.Add(this.panel_ChildDisplay);
            this.Controls.Add(this.panel_Config);
            this.Controls.Add(this.panel_Tools);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.panel_Game);
            this.Controls.Add(this.panel_Tabs);
            this.Controls.Add(this.panel_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1020, 600);
            this.Name = "BetaMMUI";
            this.Text = "BetaMMUI";
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel_Tabs.ResumeLayout(false);
            this.panel_Game.ResumeLayout(false);
            this.panel_Menu.ResumeLayout(false);
            this.panel_MenuTop.ResumeLayout(false);
            this.panel_MenuTop.PerformLayout();
            this.panel_Config.ResumeLayout(false);
            this.panel_ConfigBottom.ResumeLayout(false);
            this.panel_ConfigTop.ResumeLayout(false);
            this.panel_ConfigTop.PerformLayout();
            this.panel_Tools.ResumeLayout(false);
            this.panel_ToolsTop.ResumeLayout(false);
            this.panel_ToolsTop.PerformLayout();
            this.panel_ChildDisplay.ResumeLayout(false);
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
        private System.Windows.Forms.Button button_ModsFolder;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Button button_Tools;
        private System.Windows.Forms.Panel panel_Config;
        private System.Windows.Forms.Panel panel_Tools;
        private System.Windows.Forms.Button button_CloseTools;
        private System.Windows.Forms.Button button_CloseConfig;
        private System.Windows.Forms.ToolTip toolTip_MainButtons;
        private System.Windows.Forms.Timer timer_Tools;
        private System.Windows.Forms.Timer timer_Config;
        private System.Windows.Forms.Panel panel_ToolsTop;
        private System.Windows.Forms.Label label_ToolsTitle;
        private System.Windows.Forms.Panel panel_ConfigTop;
        private System.Windows.Forms.Label label_OptionsTitle;
        private System.Windows.Forms.Button button_AdvOption;
        private System.Windows.Forms.Panel panel_ConfigBottom;
        private System.Windows.Forms.Button button_ReportBug;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_OpenConverter;
        private System.Windows.Forms.Timer timer_Start;
        private System.Windows.Forms.Timer timer_Start_Fade01;
        private System.Windows.Forms.Timer timer_Start_Fade02;
        private System.Windows.Forms.Timer timer_Start_Fade03;
        private System.Windows.Forms.Timer timer_Start_Fade04;
        private System.Windows.Forms.Timer timer_Start_Fade05;
        private System.Windows.Forms.Button button_ModsOnline;
        private System.Windows.Forms.Panel panel_MenuTop;
        private System.Windows.Forms.Label label_MenuTitle;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Panel panel_ChildDisplay;
        private MMUIControls.FlatButton flatButton2;
    }
}