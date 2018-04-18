namespace Keraplz.AutoUpdate
{
    partial class AutoUpdateAcceptForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label_updateAvailable = new System.Windows.Forms.Label();
            this.label_newVersion = new System.Windows.Forms.Label();
            this.button_details = new System.Windows.Forms.Button();
            this.button_no = new System.Windows.Forms.Button();
            this.button_yes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(80, 80);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label_updateAvailable
            // 
            this.label_updateAvailable.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label_updateAvailable.Location = new System.Drawing.Point(106, 8);
            this.label_updateAvailable.Name = "label_updateAvailable";
            this.label_updateAvailable.Size = new System.Drawing.Size(228, 56);
            this.label_updateAvailable.TabIndex = 1;
            this.label_updateAvailable.Text = "An update is available!\r\nWould you like to update?";
            this.label_updateAvailable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_newVersion
            // 
            this.label_newVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label_newVersion.Location = new System.Drawing.Point(143, 69);
            this.label_newVersion.Name = "label_newVersion";
            this.label_newVersion.Size = new System.Drawing.Size(154, 19);
            this.label_newVersion.TabIndex = 2;
            this.label_newVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button_details
            // 
            this.button_details.Location = new System.Drawing.Point(259, 108);
            this.button_details.Name = "button_details";
            this.button_details.Size = new System.Drawing.Size(75, 23);
            this.button_details.TabIndex = 3;
            this.button_details.Text = "Details";
            this.button_details.UseVisualStyleBackColor = true;
            this.button_details.Click += new System.EventHandler(this.button_details_Click);
            // 
            // button_no
            // 
            this.button_no.Location = new System.Drawing.Point(178, 108);
            this.button_no.Name = "button_no";
            this.button_no.Size = new System.Drawing.Size(75, 23);
            this.button_no.TabIndex = 4;
            this.button_no.Text = "No";
            this.button_no.UseVisualStyleBackColor = true;
            this.button_no.Click += new System.EventHandler(this.button_no_Click);
            // 
            // button_yes
            // 
            this.button_yes.Location = new System.Drawing.Point(97, 108);
            this.button_yes.Name = "button_yes";
            this.button_yes.Size = new System.Drawing.Size(75, 23);
            this.button_yes.TabIndex = 5;
            this.button_yes.Text = "Yes";
            this.button_yes.UseVisualStyleBackColor = true;
            this.button_yes.Click += new System.EventHandler(this.button_yes_Click);
            // 
            // AutoUpdateAcceptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 142);
            this.Controls.Add(this.button_yes);
            this.Controls.Add(this.button_no);
            this.Controls.Add(this.button_details);
            this.Controls.Add(this.label_newVersion);
            this.Controls.Add(this.label_updateAvailable);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoUpdateAcceptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label_updateAvailable;
        private System.Windows.Forms.Label label_newVersion;
        private System.Windows.Forms.Button button_details;
        private System.Windows.Forms.Button button_no;
        private System.Windows.Forms.Button button_yes;
    }
}