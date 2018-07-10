using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public class MMUICustom : MMUIResources
    {
        public class MMUIFolderSelection
        {
            // Members
            private Game m_Game;
            private String m_Path;

            private Point m_Pos;

            public Panel m_Structure;
            private TextBox m_TextBox;
            private Button m_Select;

            // Constructor
            public MMUIFolderSelection(Game Game, int X, int Y, int Width, int Height = 40)
            {
                this.m_Game = Game;
                this.m_Pos = new Point(X, Y);
                this.m_Path = "";

                this.m_Structure = new Panel();
                this.m_Structure.BackColor = Secondary;
                this.m_Structure.Size = new Size(Width, Height);
                this.m_Structure.Location = this.m_Pos;
                this.m_Structure.Paint += new PaintEventHandler(Structure_draw);
                this.m_Structure.Refresh();
            }

            private void Structure_draw(object sender, PaintEventArgs pe)
            {
                this.m_TextBox = new TextBox();
                this.m_Select = new Button();

                this.m_TextBox.BackColor = Secondary;
                this.m_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                this.m_TextBox.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.m_TextBox.ForeColor = System.Drawing.SystemColors.Window;
                this.m_TextBox.Location = new System.Drawing.Point(this.m_Structure.Width / (this.m_Structure.Height * 2), this.m_Structure.Height / 4);
                this.m_TextBox.Multiline = true;
                this.m_TextBox.Name = "m_TextBox";
                this.m_TextBox.ReadOnly = true;
                this.m_TextBox.Size = new System.Drawing.Size(this.m_Structure.Width - this.m_Structure.Width / 5 - this.m_TextBox.Location.X, this.m_Structure.Height - this.m_Structure.Height / 4);
                this.m_TextBox.TabIndex = 0;
                this.m_TextBox.TabStop = false;
                this.m_TextBox.Text = this.m_Path;


                this.m_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.m_Select.BackColor = Transparent;
                this.m_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                this.m_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.m_Select.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
                this.m_Select.ForeColor = System.Drawing.Color.White;
                this.m_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.m_Select.Location = new System.Drawing.Point(this.m_TextBox.Width + this.m_TextBox.Location.X, 0);
                this.m_Select.Name = "m_Select";
                this.m_Select.Size = new System.Drawing.Size(this.m_Structure.Width / 5, this.m_Structure.Height);
                this.m_Select.TabIndex = 1;
                this.m_Select.Text = "Select Folder";
                this.m_Select.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                this.m_Select.UseVisualStyleBackColor = false;
                this.m_Select.FlatAppearance.MouseOverBackColor = HoverSecondary;
                this.m_Select.BackColorChanged += (s, e) =>
                {
                    this.m_Select.FlatAppearance.MouseOverBackColor = HoverSecondary;
                };
                this.m_Select.FlatAppearance.MouseDownBackColor = ClickSecondary;
                this.m_Select.BackColorChanged += (s, e) =>
                {
                    this.m_Select.FlatAppearance.MouseDownBackColor = ClickSecondary;
                };
                this.m_Select.TabStop = false;
                this.m_Select.FlatStyle = FlatStyle.Flat;
                this.m_Select.FlatAppearance.BorderSize = 0;
                this.m_Select.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
                this.m_Select.Click += new System.EventHandler(this.m_Select_Click);


                this.m_Structure.Controls.Add(this.m_TextBox);
                this.m_Structure.Controls.Add(this.m_Select);
                this.m_Structure.Paint -= new PaintEventHandler(Structure_draw);
            }


            private void m_Select_Click(object sender, EventArgs e)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        this.m_TextBox.Text = fbd.SelectedPath;
                    }
                }
            }

        }

    }
}