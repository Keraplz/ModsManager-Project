namespace ModsManager
{
    partial class MMUIBugReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MMUIBugReport));
            this.panel_Top = new System.Windows.Forms.Panel();
            this.label_BugReportTitle = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.pictureBox_Send = new System.Windows.Forms.PictureBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.pictureBox_NotSend = new System.Windows.Forms.PictureBox();
            this.button_NotSend = new System.Windows.Forms.Button();
            this.label_Seperator = new System.Windows.Forms.Label();
            this.label_Oops = new System.Windows.Forms.Label();
            this.label_ErrorType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_UserDesc = new System.Windows.Forms.TextBox();
            this.button_ToggleAdditionalData = new System.Windows.Forms.Button();
            this.button_ToggleAnonymous = new System.Windows.Forms.Button();
            this.pictureBox_ToggleAnonymous = new System.Windows.Forms.PictureBox();
            this.pictureBox_ToggleAdditionalData = new System.Windows.Forms.PictureBox();
            this.pictureBox_Bug = new System.Windows.Forms.PictureBox();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Send)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NotSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ToggleAnonymous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ToggleAdditionalData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bug)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Black;
            this.panel_Top.Controls.Add(this.label_BugReportTitle);
            this.panel_Top.Controls.Add(this.Logo);
            this.panel_Top.Controls.Add(this.button_Close);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(450, 50);
            this.panel_Top.TabIndex = 0;
            this.panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // label_BugReportTitle
            // 
            this.label_BugReportTitle.AutoSize = true;
            this.label_BugReportTitle.BackColor = System.Drawing.Color.Transparent;
            this.label_BugReportTitle.Enabled = false;
            this.label_BugReportTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_BugReportTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BugReportTitle.ForeColor = System.Drawing.Color.White;
            this.label_BugReportTitle.Location = new System.Drawing.Point(106, 9);
            this.label_BugReportTitle.Name = "label_BugReportTitle";
            this.label_BugReportTitle.Size = new System.Drawing.Size(125, 30);
            this.label_BugReportTitle.TabIndex = 6;
            this.label_BugReportTitle.Text = "Bug Report";
            this.label_BugReportTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.Logo.TabIndex = 4;
            this.Logo.TabStop = false;
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.BackColor = System.Drawing.Color.Transparent;
            this.button_Close.BackgroundImage = global::ModsManager.Properties.Resources.Close_100px;
            this.button_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Close.Enabled = false;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Location = new System.Drawing.Point(400, 0);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(50, 50);
            this.button_Close.TabIndex = 3;
            this.button_Close.TabStop = false;
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // panel_Left
            // 
            this.panel_Left.BackColor = System.Drawing.Color.Black;
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 50);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(50, 500);
            this.panel_Left.TabIndex = 1;
            this.panel_Left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Left_MouseDown);
            this.panel_Left.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Left_MouseMove);
            this.panel_Left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Left_MouseUp);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel_Bottom.Controls.Add(this.pictureBox_Send);
            this.panel_Bottom.Controls.Add(this.button_Send);
            this.panel_Bottom.Controls.Add(this.pictureBox_NotSend);
            this.panel_Bottom.Controls.Add(this.button_NotSend);
            this.panel_Bottom.Controls.Add(this.label_Seperator);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(50, 500);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(400, 50);
            this.panel_Bottom.TabIndex = 4;
            // 
            // pictureBox_Send
            // 
            this.pictureBox_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Send.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Send.BackgroundImage = global::ModsManager.Properties.Resources.White_Send_Email_100px;
            this.pictureBox_Send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Send.Enabled = false;
            this.pictureBox_Send.Location = new System.Drawing.Point(350, 0);
            this.pictureBox_Send.Name = "pictureBox_Send";
            this.pictureBox_Send.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_Send.TabIndex = 9;
            this.pictureBox_Send.TabStop = false;
            // 
            // button_Send
            // 
            this.button_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Send.BackColor = System.Drawing.Color.Transparent;
            this.button_Send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Send.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_Send.ForeColor = System.Drawing.Color.White;
            this.button_Send.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Send.Location = new System.Drawing.Point(205, 0);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(195, 50);
            this.button_Send.TabIndex = 8;
            this.button_Send.Text = "        Send";
            this.button_Send.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Send.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Send.UseVisualStyleBackColor = false;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // pictureBox_NotSend
            // 
            this.pictureBox_NotSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_NotSend.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_NotSend.BackgroundImage = global::ModsManager.Properties.Resources.White_Close_100px;
            this.pictureBox_NotSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_NotSend.Enabled = false;
            this.pictureBox_NotSend.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_NotSend.Name = "pictureBox_NotSend";
            this.pictureBox_NotSend.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_NotSend.TabIndex = 7;
            this.pictureBox_NotSend.TabStop = false;
            // 
            // button_NotSend
            // 
            this.button_NotSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_NotSend.BackColor = System.Drawing.Color.Transparent;
            this.button_NotSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_NotSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_NotSend.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_NotSend.ForeColor = System.Drawing.Color.White;
            this.button_NotSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_NotSend.Location = new System.Drawing.Point(0, 0);
            this.button_NotSend.Name = "button_NotSend";
            this.button_NotSend.Size = new System.Drawing.Size(195, 50);
            this.button_NotSend.TabIndex = 3;
            this.button_NotSend.Text = "            Don\'t Send";
            this.button_NotSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_NotSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_NotSend.UseVisualStyleBackColor = false;
            this.button_NotSend.Click += new System.EventHandler(this.button_NotSend_Click);
            // 
            // label_Seperator
            // 
            this.label_Seperator.AutoSize = true;
            this.label_Seperator.BackColor = System.Drawing.Color.Transparent;
            this.label_Seperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Seperator.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seperator.ForeColor = System.Drawing.Color.White;
            this.label_Seperator.Location = new System.Drawing.Point(186, -4);
            this.label_Seperator.Name = "label_Seperator";
            this.label_Seperator.Size = new System.Drawing.Size(31, 47);
            this.label_Seperator.TabIndex = 13;
            this.label_Seperator.Text = "|";
            this.label_Seperator.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_Oops
            // 
            this.label_Oops.AutoSize = true;
            this.label_Oops.BackColor = System.Drawing.Color.Transparent;
            this.label_Oops.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Oops.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Oops.ForeColor = System.Drawing.Color.White;
            this.label_Oops.Location = new System.Drawing.Point(131, 65);
            this.label_Oops.Name = "label_Oops";
            this.label_Oops.Size = new System.Drawing.Size(88, 30);
            this.label_Oops.TabIndex = 7;
            this.label_Oops.Text = "Oops... ";
            this.label_Oops.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label_ErrorType
            // 
            this.label_ErrorType.AutoSize = true;
            this.label_ErrorType.BackColor = System.Drawing.Color.Transparent;
            this.label_ErrorType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_ErrorType.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ErrorType.ForeColor = System.Drawing.Color.White;
            this.label_ErrorType.Location = new System.Drawing.Point(131, 95);
            this.label_ErrorType.Name = "label_ErrorType";
            this.label_ErrorType.Size = new System.Drawing.Size(314, 30);
            this.label_ErrorType.TabIndex = 8;
            this.label_ErrorType.Text = "An unexpected error occurred.";
            this.label_ErrorType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 136);
            this.label1.TabIndex = 9;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox_UserDesc
            // 
            this.textBox_UserDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_UserDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_UserDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_UserDesc.ForeColor = System.Drawing.Color.White;
            this.textBox_UserDesc.Location = new System.Drawing.Point(50, 267);
            this.textBox_UserDesc.Multiline = true;
            this.textBox_UserDesc.Name = "textBox_UserDesc";
            this.textBox_UserDesc.Size = new System.Drawing.Size(400, 120);
            this.textBox_UserDesc.TabIndex = 10;
            // 
            // button_ToggleAdditionalData
            // 
            this.button_ToggleAdditionalData.BackColor = System.Drawing.Color.Transparent;
            this.button_ToggleAdditionalData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ToggleAdditionalData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ToggleAdditionalData.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_ToggleAdditionalData.ForeColor = System.Drawing.Color.White;
            this.button_ToggleAdditionalData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ToggleAdditionalData.Location = new System.Drawing.Point(56, 393);
            this.button_ToggleAdditionalData.Name = "button_ToggleAdditionalData";
            this.button_ToggleAdditionalData.Size = new System.Drawing.Size(255, 50);
            this.button_ToggleAdditionalData.TabIndex = 10;
            this.button_ToggleAdditionalData.Text = "          Send Additional Data";
            this.button_ToggleAdditionalData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ToggleAdditionalData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ToggleAdditionalData.UseVisualStyleBackColor = false;
            this.button_ToggleAdditionalData.Click += new System.EventHandler(this.button_ToggleAdditionalData_Click);
            // 
            // button_ToggleAnonymous
            // 
            this.button_ToggleAnonymous.BackColor = System.Drawing.Color.Transparent;
            this.button_ToggleAnonymous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ToggleAnonymous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ToggleAnonymous.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_ToggleAnonymous.ForeColor = System.Drawing.Color.White;
            this.button_ToggleAnonymous.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ToggleAnonymous.Location = new System.Drawing.Point(56, 446);
            this.button_ToggleAnonymous.Name = "button_ToggleAnonymous";
            this.button_ToggleAnonymous.Size = new System.Drawing.Size(255, 50);
            this.button_ToggleAnonymous.TabIndex = 12;
            this.button_ToggleAnonymous.Text = "          Send As Anonymous";
            this.button_ToggleAnonymous.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ToggleAnonymous.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ToggleAnonymous.UseVisualStyleBackColor = false;
            this.button_ToggleAnonymous.Click += new System.EventHandler(this.button_ToggleAnonymous_Click);
            // 
            // pictureBox_ToggleAnonymous
            // 
            this.pictureBox_ToggleAnonymous.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ToggleAnonymous.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_Off_100px;
            this.pictureBox_ToggleAnonymous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_ToggleAnonymous.Enabled = false;
            this.pictureBox_ToggleAnonymous.Location = new System.Drawing.Point(56, 446);
            this.pictureBox_ToggleAnonymous.Name = "pictureBox_ToggleAnonymous";
            this.pictureBox_ToggleAnonymous.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_ToggleAnonymous.TabIndex = 11;
            this.pictureBox_ToggleAnonymous.TabStop = false;
            // 
            // pictureBox_ToggleAdditionalData
            // 
            this.pictureBox_ToggleAdditionalData.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ToggleAdditionalData.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_On_100px;
            this.pictureBox_ToggleAdditionalData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_ToggleAdditionalData.Enabled = false;
            this.pictureBox_ToggleAdditionalData.Location = new System.Drawing.Point(56, 393);
            this.pictureBox_ToggleAdditionalData.Name = "pictureBox_ToggleAdditionalData";
            this.pictureBox_ToggleAdditionalData.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_ToggleAdditionalData.TabIndex = 10;
            this.pictureBox_ToggleAdditionalData.TabStop = false;
            // 
            // pictureBox_Bug
            // 
            this.pictureBox_Bug.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Bug.BackgroundImage = global::ModsManager.Properties.Resources.White_Bug_100px;
            this.pictureBox_Bug.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Bug.Enabled = false;
            this.pictureBox_Bug.Location = new System.Drawing.Point(50, 50);
            this.pictureBox_Bug.Name = "pictureBox_Bug";
            this.pictureBox_Bug.Size = new System.Drawing.Size(75, 75);
            this.pictureBox_Bug.TabIndex = 5;
            this.pictureBox_Bug.TabStop = false;
            // 
            // MMUIBugReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(450, 550);
            this.Controls.Add(this.pictureBox_ToggleAnonymous);
            this.Controls.Add(this.button_ToggleAnonymous);
            this.Controls.Add(this.pictureBox_ToggleAdditionalData);
            this.Controls.Add(this.button_ToggleAdditionalData);
            this.Controls.Add(this.textBox_UserDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_ErrorType);
            this.Controls.Add(this.label_Oops);
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.pictureBox_Bug);
            this.Controls.Add(this.panel_Left);
            this.Controls.Add(this.panel_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MMUIBugReport";
            this.Text = "MMUIBugReport";
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Send)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NotSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ToggleAnonymous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ToggleAdditionalData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Bug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.PictureBox pictureBox_Bug;
        private System.Windows.Forms.Label label_BugReportTitle;
        private System.Windows.Forms.Label label_Oops;
        private System.Windows.Forms.Label label_ErrorType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_UserDesc;
        private System.Windows.Forms.PictureBox pictureBox_Send;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.PictureBox pictureBox_NotSend;
        private System.Windows.Forms.Button button_NotSend;
        private System.Windows.Forms.PictureBox pictureBox_ToggleAdditionalData;
        private System.Windows.Forms.Button button_ToggleAdditionalData;
        private System.Windows.Forms.PictureBox pictureBox_ToggleAnonymous;
        private System.Windows.Forms.Button button_ToggleAnonymous;
        private System.Windows.Forms.Label label_Seperator;
    }
}