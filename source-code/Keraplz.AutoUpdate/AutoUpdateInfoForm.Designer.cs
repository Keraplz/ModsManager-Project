namespace Keraplz.AutoUpdate
{
    partial class AutoUpdateInfoForm
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
            this.label_versions = new System.Windows.Forms.Label();
            this.TextBox_description = new System.Windows.Forms.RichTextBox();
            this.label_description = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(80, 80);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label_versions
            // 
            this.label_versions.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_versions.Location = new System.Drawing.Point(104, 25);
            this.label_versions.Name = "label_versions";
            this.label_versions.Size = new System.Drawing.Size(168, 54);
            this.label_versions.TabIndex = 1;
            this.label_versions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextBox_description
            // 
            this.TextBox_description.BackColor = System.Drawing.SystemColors.Control;
            this.TextBox_description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBox_description.Cursor = System.Windows.Forms.Cursors.Default;
            this.TextBox_description.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_description.Location = new System.Drawing.Point(12, 116);
            this.TextBox_description.Name = "TextBox_description";
            this.TextBox_description.ReadOnly = true;
            this.TextBox_description.Size = new System.Drawing.Size(260, 96);
            this.TextBox_description.TabIndex = 2;
            this.TextBox_description.TabStop = false;
            this.TextBox_description.Text = "";
            this.TextBox_description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_description_KeyDown);
            // 
            // label_description
            // 
            this.label_description.AutoSize = true;
            this.label_description.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_description.Location = new System.Drawing.Point(9, 100);
            this.label_description.Name = "label_description";
            this.label_description.Size = new System.Drawing.Size(66, 13);
            this.label_description.TabIndex = 3;
            this.label_description.Text = "Description";
            // 
            // button_back
            // 
            this.button_back.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.Location = new System.Drawing.Point(105, 223);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(73, 23);
            this.button_back.TabIndex = 4;
            this.button_back.TabStop = false;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // AutoUpdateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 254);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label_description);
            this.Controls.Add(this.TextBox_description);
            this.Controls.Add(this.label_versions);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoUpdateInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label_versions;
        private System.Windows.Forms.RichTextBox TextBox_description;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.Button button_back;
    }
}