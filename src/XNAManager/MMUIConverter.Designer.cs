namespace ModsManager
{
    partial class MMUIConverter
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
            this.button_Minimize = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.button_Exit = new System.Windows.Forms.Button();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.pictureBox_Apply = new System.Windows.Forms.PictureBox();
            this.button_Apply = new System.Windows.Forms.Button();
            this.label_Seperator = new System.Windows.Forms.Label();
            this.pictureBox_DragFiles = new System.Windows.Forms.PictureBox();
            this.listBox_FilesList = new System.Windows.Forms.ListBox();
            this.comboBox_FileInput = new System.Windows.Forms.ComboBox();
            this.comboBox_FileOutput = new System.Windows.Forms.ComboBox();
            this.pictureBox_ArrowPointer = new System.Windows.Forms.PictureBox();
            this.pictureBox_ToggleCompressed = new System.Windows.Forms.PictureBox();
            this.button_ToggleCompressed = new System.Windows.Forms.Button();
            this.label_BugReportTitle = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.button_ClearListBox = new System.Windows.Forms.Button();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Apply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DragFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ArrowPointer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ToggleCompressed)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.Color.Black;
            this.panel_Top.Controls.Add(this.label_Title);
            this.panel_Top.Controls.Add(this.button_Minimize);
            this.panel_Top.Controls.Add(this.Logo);
            this.panel_Top.Controls.Add(this.button_Exit);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(362, 50);
            this.panel_Top.TabIndex = 2;
            this.panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseDown);
            this.panel_Top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseMove);
            this.panel_Top.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Top_MouseUp);
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.BackColor = System.Drawing.Color.Transparent;
            this.label_Title.Enabled = false;
            this.label_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Title.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(106, 9);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(110, 30);
            this.label_Title.TabIndex = 7;
            this.label_Title.Text = "Converter";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseDown);
            this.label_Title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseMove);
            this.label_Title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_Title_MouseUp);
            // 
            // button_Minimize
            // 
            this.button_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.button_Minimize.BackgroundImage = global::ModsManager.Properties.Resources.White_Minimize_Window_96px;
            this.button_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Minimize.Location = new System.Drawing.Point(256, 0);
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
            this.button_Exit.Location = new System.Drawing.Point(312, 0);
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
            this.panel_Bottom.Controls.Add(this.pictureBox_Apply);
            this.panel_Bottom.Controls.Add(this.button_Apply);
            this.panel_Bottom.Controls.Add(this.label_Seperator);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(50, 390);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(312, 50);
            this.panel_Bottom.TabIndex = 5;
            // 
            // pictureBox_Apply
            // 
            this.pictureBox_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Apply.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Apply.BackgroundImage = global::ModsManager.Properties.Resources.White_Wrench_100px;
            this.pictureBox_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Apply.Enabled = false;
            this.pictureBox_Apply.Location = new System.Drawing.Point(262, 0);
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
            this.button_Apply.Location = new System.Drawing.Point(162, 0);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(150, 50);
            this.button_Apply.TabIndex = 8;
            this.button_Apply.Text = "  Convert";
            this.button_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_Apply.UseVisualStyleBackColor = false;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // label_Seperator
            // 
            this.label_Seperator.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_Seperator.AutoSize = true;
            this.label_Seperator.BackColor = System.Drawing.Color.Transparent;
            this.label_Seperator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Seperator.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Seperator.ForeColor = System.Drawing.Color.White;
            this.label_Seperator.Location = new System.Drawing.Point(142, -4);
            this.label_Seperator.Name = "label_Seperator";
            this.label_Seperator.Size = new System.Drawing.Size(31, 47);
            this.label_Seperator.TabIndex = 13;
            this.label_Seperator.Text = "|";
            this.label_Seperator.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pictureBox_DragFiles
            // 
            this.pictureBox_DragFiles.AllowDrop = true;
            this.pictureBox_DragFiles.BackColor = System.Drawing.Color.Gray;
            this.pictureBox_DragFiles.BackgroundImage = global::ModsManager.Properties.Resources.White_DragFile_300x200px;
            this.pictureBox_DragFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_DragFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_DragFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_DragFiles.Location = new System.Drawing.Point(56, 99);
            this.pictureBox_DragFiles.Name = "pictureBox_DragFiles";
            this.pictureBox_DragFiles.Size = new System.Drawing.Size(300, 200);
            this.pictureBox_DragFiles.TabIndex = 6;
            this.pictureBox_DragFiles.TabStop = false;
            this.pictureBox_DragFiles.VisibleChanged += new System.EventHandler(this.pictureBox_DragFiles_VisibleChanged);
            this.pictureBox_DragFiles.Click += new System.EventHandler(this.pictureBox_DragFiles_Click);
            this.pictureBox_DragFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragFiles_DragDrop);
            this.pictureBox_DragFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragFiles_DragEnter);
            // 
            // listBox_FilesList
            // 
            this.listBox_FilesList.AllowDrop = true;
            this.listBox_FilesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_FilesList.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_FilesList.FormattingEnabled = true;
            this.listBox_FilesList.ItemHeight = 15;
            this.listBox_FilesList.Location = new System.Drawing.Point(56, 99);
            this.listBox_FilesList.Name = "listBox_FilesList";
            this.listBox_FilesList.Size = new System.Drawing.Size(300, 195);
            this.listBox_FilesList.TabIndex = 7;
            this.listBox_FilesList.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_FilesList_DragDrop);
            this.listBox_FilesList.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_FilesList_DragEnter);
            // 
            // comboBox_FileInput
            // 
            this.comboBox_FileInput.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_FileInput.Enabled = false;
            this.comboBox_FileInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_FileInput.FormattingEnabled = true;
            this.comboBox_FileInput.Items.AddRange(new object[] {
            "PNG"});
            this.comboBox_FileInput.Location = new System.Drawing.Point(56, 56);
            this.comboBox_FileInput.Name = "comboBox_FileInput";
            this.comboBox_FileInput.Size = new System.Drawing.Size(119, 23);
            this.comboBox_FileInput.TabIndex = 8;
            this.comboBox_FileInput.Text = "PNG";
            // 
            // comboBox_FileOutput
            // 
            this.comboBox_FileOutput.Enabled = false;
            this.comboBox_FileOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.comboBox_FileOutput.FormattingEnabled = true;
            this.comboBox_FileOutput.Items.AddRange(new object[] {
            "XNB"});
            this.comboBox_FileOutput.Location = new System.Drawing.Point(237, 56);
            this.comboBox_FileOutput.Name = "comboBox_FileOutput";
            this.comboBox_FileOutput.Size = new System.Drawing.Size(119, 23);
            this.comboBox_FileOutput.TabIndex = 9;
            this.comboBox_FileOutput.Text = "XNB";
            // 
            // pictureBox_ArrowPointer
            // 
            this.pictureBox_ArrowPointer.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ArrowPointer.BackgroundImage = global::ModsManager.Properties.Resources.White_Advance_100px;
            this.pictureBox_ArrowPointer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_ArrowPointer.Enabled = false;
            this.pictureBox_ArrowPointer.Location = new System.Drawing.Point(181, 42);
            this.pictureBox_ArrowPointer.Name = "pictureBox_ArrowPointer";
            this.pictureBox_ArrowPointer.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_ArrowPointer.TabIndex = 10;
            this.pictureBox_ArrowPointer.TabStop = false;
            // 
            // pictureBox_ToggleCompressed
            // 
            this.pictureBox_ToggleCompressed.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ToggleCompressed.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_On_100px;
            this.pictureBox_ToggleCompressed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_ToggleCompressed.Enabled = false;
            this.pictureBox_ToggleCompressed.Location = new System.Drawing.Point(56, 305);
            this.pictureBox_ToggleCompressed.Name = "pictureBox_ToggleCompressed";
            this.pictureBox_ToggleCompressed.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_ToggleCompressed.TabIndex = 14;
            this.pictureBox_ToggleCompressed.TabStop = false;
            // 
            // button_ToggleCompressed
            // 
            this.button_ToggleCompressed.BackColor = System.Drawing.Color.Transparent;
            this.button_ToggleCompressed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ToggleCompressed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ToggleCompressed.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_ToggleCompressed.ForeColor = System.Drawing.Color.White;
            this.button_ToggleCompressed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ToggleCompressed.Location = new System.Drawing.Point(56, 305);
            this.button_ToggleCompressed.Name = "button_ToggleCompressed";
            this.button_ToggleCompressed.Size = new System.Drawing.Size(175, 50);
            this.button_ToggleCompressed.TabIndex = 15;
            this.button_ToggleCompressed.Text = "          Compressed";
            this.button_ToggleCompressed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ToggleCompressed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ToggleCompressed.UseVisualStyleBackColor = false;
            this.button_ToggleCompressed.Click += new System.EventHandler(this.button_ToggleCompressed_Click);
            // 
            // label_BugReportTitle
            // 
            this.label_BugReportTitle.AutoSize = true;
            this.label_BugReportTitle.BackColor = System.Drawing.Color.Transparent;
            this.label_BugReportTitle.Enabled = false;
            this.label_BugReportTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_BugReportTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_BugReportTitle.ForeColor = System.Drawing.Color.White;
            this.label_BugReportTitle.Location = new System.Drawing.Point(412, -133);
            this.label_BugReportTitle.Name = "label_BugReportTitle";
            this.label_BugReportTitle.Size = new System.Drawing.Size(125, 30);
            this.label_BugReportTitle.TabIndex = 13;
            this.label_BugReportTitle.Text = "Bug Report";
            this.label_BugReportTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(50, 361);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(312, 30);
            this.progressBar.TabIndex = 16;
            this.progressBar.Visible = false;
            // 
            // button_ClearListBox
            // 
            this.button_ClearListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearListBox.BackColor = System.Drawing.SystemColors.Window;
            this.button_ClearListBox.BackgroundImage = global::ModsManager.Properties.Resources.Gray_Close_100px;
            this.button_ClearListBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_ClearListBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ClearListBox.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button_ClearListBox.ForeColor = System.Drawing.Color.White;
            this.button_ClearListBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ClearListBox.Location = new System.Drawing.Point(331, 99);
            this.button_ClearListBox.Name = "button_ClearListBox";
            this.button_ClearListBox.Size = new System.Drawing.Size(25, 25);
            this.button_ClearListBox.TabIndex = 14;
            this.button_ClearListBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ClearListBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ClearListBox.UseVisualStyleBackColor = false;
            this.button_ClearListBox.Click += new System.EventHandler(this.button_ClearListBox_Click);
            // 
            // MMUIConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(362, 440);
            this.Controls.Add(this.pictureBox_DragFiles);
            this.Controls.Add(this.button_ClearListBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pictureBox_ToggleCompressed);
            this.Controls.Add(this.button_ToggleCompressed);
            this.Controls.Add(this.label_BugReportTitle);
            this.Controls.Add(this.comboBox_FileOutput);
            this.Controls.Add(this.comboBox_FileInput);
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.panel_Left);
            this.Controls.Add(this.panel_Top);
            this.Controls.Add(this.listBox_FilesList);
            this.Controls.Add(this.pictureBox_ArrowPointer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MMUIConverter";
            this.Text = "MMUIConverter";
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Apply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DragFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ArrowPointer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ToggleCompressed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Button button_Minimize;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.PictureBox pictureBox_Apply;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Label label_Seperator;
        private System.Windows.Forms.PictureBox pictureBox_DragFiles;
        private System.Windows.Forms.ListBox listBox_FilesList;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.ComboBox comboBox_FileInput;
        private System.Windows.Forms.ComboBox comboBox_FileOutput;
        private System.Windows.Forms.PictureBox pictureBox_ArrowPointer;
        private System.Windows.Forms.PictureBox pictureBox_ToggleCompressed;
        private System.Windows.Forms.Button button_ToggleCompressed;
        private System.Windows.Forms.Label label_BugReportTitle;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button button_ClearListBox;
    }
}