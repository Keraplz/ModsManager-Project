namespace ModsManager
{
    partial class MMUIChildModsList
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
            this.pictureBox_ModsList_EndRight = new System.Windows.Forms.PictureBox();
            this.pictureBox_ModsList_EndLeft = new System.Windows.Forms.PictureBox();
            this.button_RightScrollMods = new System.Windows.Forms.Button();
            this.button_LeftScrollMods = new System.Windows.Forms.Button();
            this.panel_ModsList = new System.Windows.Forms.Panel();
            this.timer_ModsList_Right_Hold = new System.Windows.Forms.Timer(this.components);
            this.timer_ModsList_Left_Hold = new System.Windows.Forms.Timer(this.components);
            this.timer_ModsList_Right = new System.Windows.Forms.Timer(this.components);
            this.timer_ModsList_Left = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ModsList_EndRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ModsList_EndLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_ModsList_EndRight
            // 
            this.pictureBox_ModsList_EndRight.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_ModsList_EndRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox_ModsList_EndRight.Enabled = false;
            this.pictureBox_ModsList_EndRight.Location = new System.Drawing.Point(915, 0);
            this.pictureBox_ModsList_EndRight.Name = "pictureBox_ModsList_EndRight";
            this.pictureBox_ModsList_EndRight.Size = new System.Drawing.Size(5, 500);
            this.pictureBox_ModsList_EndRight.TabIndex = 15;
            this.pictureBox_ModsList_EndRight.TabStop = false;
            // 
            // pictureBox_ModsList_EndLeft
            // 
            this.pictureBox_ModsList_EndLeft.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox_ModsList_EndLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox_ModsList_EndLeft.Enabled = false;
            this.pictureBox_ModsList_EndLeft.Location = new System.Drawing.Point(50, 0);
            this.pictureBox_ModsList_EndLeft.Name = "pictureBox_ModsList_EndLeft";
            this.pictureBox_ModsList_EndLeft.Size = new System.Drawing.Size(5, 500);
            this.pictureBox_ModsList_EndLeft.TabIndex = 14;
            this.pictureBox_ModsList_EndLeft.TabStop = false;
            // 
            // button_RightScrollMods
            // 
            this.button_RightScrollMods.BackColor = System.Drawing.Color.Transparent;
            this.button_RightScrollMods.BackgroundImage = global::ModsManager.Properties.Resources.White_Forward_100px;
            this.button_RightScrollMods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_RightScrollMods.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_RightScrollMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_RightScrollMods.Location = new System.Drawing.Point(920, 0);
            this.button_RightScrollMods.Name = "button_RightScrollMods";
            this.button_RightScrollMods.Size = new System.Drawing.Size(50, 500);
            this.button_RightScrollMods.TabIndex = 13;
            this.button_RightScrollMods.UseVisualStyleBackColor = false;
            this.button_RightScrollMods.Click += new System.EventHandler(this.button_RightScrollMods_Click);
            this.button_RightScrollMods.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_RightScrollMods_MouseDown);
            this.button_RightScrollMods.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_RightScrollMods_MouseUp);
            // 
            // button_LeftScrollMods
            // 
            this.button_LeftScrollMods.BackColor = System.Drawing.Color.Transparent;
            this.button_LeftScrollMods.BackgroundImage = global::ModsManager.Properties.Resources.White_Back_100px;
            this.button_LeftScrollMods.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_LeftScrollMods.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_LeftScrollMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LeftScrollMods.Location = new System.Drawing.Point(0, 0);
            this.button_LeftScrollMods.Name = "button_LeftScrollMods";
            this.button_LeftScrollMods.Size = new System.Drawing.Size(50, 500);
            this.button_LeftScrollMods.TabIndex = 12;
            this.button_LeftScrollMods.UseVisualStyleBackColor = false;
            this.button_LeftScrollMods.Click += new System.EventHandler(this.button_LeftScrollMods_Click);
            this.button_LeftScrollMods.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_LeftScrollMods_MouseDown);
            this.button_LeftScrollMods.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_LeftScrollMods_MouseUp);
            // 
            // panel_ModsList
            // 
            this.panel_ModsList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_ModsList.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel_ModsList.Location = new System.Drawing.Point(50, 0);
            this.panel_ModsList.MinimumSize = new System.Drawing.Size(0, 500);
            this.panel_ModsList.Name = "panel_ModsList";
            this.panel_ModsList.Size = new System.Drawing.Size(870, 500);
            this.panel_ModsList.TabIndex = 11;
            // 
            // timer_ModsList_Right_Hold
            // 
            this.timer_ModsList_Right_Hold.Interval = 8;
            this.timer_ModsList_Right_Hold.Tick += new System.EventHandler(this.timer_ModsList_Right_Hold_Tick);
            // 
            // timer_ModsList_Left_Hold
            // 
            this.timer_ModsList_Left_Hold.Interval = 8;
            this.timer_ModsList_Left_Hold.Tick += new System.EventHandler(this.timer_ModsList_Left_Hold_Tick);
            // 
            // timer_ModsList_Right
            // 
            this.timer_ModsList_Right.Interval = 8;
            this.timer_ModsList_Right.Tick += new System.EventHandler(this.timer_ModsList_Right_Tick);
            // 
            // timer_ModsList_Left
            // 
            this.timer_ModsList_Left.Interval = 8;
            this.timer_ModsList_Left.Tick += new System.EventHandler(this.timer_ModsList_Left_Tick);
            // 
            // MMUIChildModsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.Controls.Add(this.pictureBox_ModsList_EndRight);
            this.Controls.Add(this.pictureBox_ModsList_EndLeft);
            this.Controls.Add(this.button_RightScrollMods);
            this.Controls.Add(this.button_LeftScrollMods);
            this.Controls.Add(this.panel_ModsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MMUIChildModsList";
            this.Text = "MMUIBugReport";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ModsList_EndRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ModsList_EndLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_ModsList_EndRight;
        private System.Windows.Forms.PictureBox pictureBox_ModsList_EndLeft;
        private System.Windows.Forms.Button button_RightScrollMods;
        private System.Windows.Forms.Button button_LeftScrollMods;
        private System.Windows.Forms.Panel panel_ModsList;
        private System.Windows.Forms.Timer timer_ModsList_Right_Hold;
        private System.Windows.Forms.Timer timer_ModsList_Left_Hold;
        private System.Windows.Forms.Timer timer_ModsList_Right;
        private System.Windows.Forms.Timer timer_ModsList_Left;

    }
}