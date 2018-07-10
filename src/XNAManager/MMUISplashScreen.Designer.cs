namespace ModsManager
{
    partial class MMUISplashScreen
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
            this.label_ActionName = new System.Windows.Forms.Label();
            this.timer_ProgressBar = new System.Windows.Forms.Timer(this.components);
            this.progressBar_BackGround = new System.Windows.Forms.Panel();
            this.progressBar_Color = new System.Windows.Forms.PictureBox();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.progressBar_BackGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar_Color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ActionName
            // 
            this.label_ActionName.AutoSize = true;
            this.label_ActionName.BackColor = System.Drawing.Color.Transparent;
            this.label_ActionName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_ActionName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ActionName.ForeColor = System.Drawing.Color.White;
            this.label_ActionName.Location = new System.Drawing.Point(106, 16);
            this.label_ActionName.Name = "label_ActionName";
            this.label_ActionName.Size = new System.Drawing.Size(123, 30);
            this.label_ActionName.TabIndex = 12;
            this.label_ActionName.Text = "LBL_INTRO";
            this.label_ActionName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label_ActionName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseDown);
            this.label_ActionName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseMove);
            this.label_ActionName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseUp);
            // 
            // timer_ProgressBar
            // 
            this.timer_ProgressBar.Interval = 8;
            this.timer_ProgressBar.Tick += new System.EventHandler(this.timer_ProgressBar_Tick);
            // 
            // progressBar_BackGround
            // 
            this.progressBar_BackGround.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBar_BackGround.Controls.Add(this.progressBar_Color);
            this.progressBar_BackGround.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar_BackGround.Location = new System.Drawing.Point(0, 0);
            this.progressBar_BackGround.Name = "progressBar_BackGround";
            this.progressBar_BackGround.Size = new System.Drawing.Size(260, 5);
            this.progressBar_BackGround.TabIndex = 13;
            // 
            // progressBar_Color
            // 
            this.progressBar_Color.BackColor = System.Drawing.Color.White;
            this.progressBar_Color.Location = new System.Drawing.Point(0, 0);
            this.progressBar_Color.Name = "progressBar_Color";
            this.progressBar_Color.Size = new System.Drawing.Size(0, 5);
            this.progressBar_Color.TabIndex = 0;
            this.progressBar_Color.TabStop = false;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Logo.Enabled = false;
            this.Logo.Location = new System.Drawing.Point(0, 5);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(100, 50);
            this.Logo.TabIndex = 3;
            this.Logo.TabStop = false;
            this.Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseDown);
            this.Logo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseMove);
            this.Logo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseUp);
            // 
            // MMUISplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(260, 55);
            this.Controls.Add(this.progressBar_BackGround);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.label_ActionName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MMUISplashScreen";
            this.Text = "MMUIAdvOption";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MMUISplashScreen_MouseUp);
            this.progressBar_BackGround.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBar_Color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label label_ActionName;
        private System.Windows.Forms.Timer timer_ProgressBar;
        private System.Windows.Forms.Panel progressBar_BackGround;
        private System.Windows.Forms.PictureBox progressBar_Color;
    }
}