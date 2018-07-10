using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class MMUIAdvOption : Form
    {
        public MMUIAdvOption()
        {
            InitializeComponent();
            Setup();

            MMUICustom.MMUIFolderSelection MMUIFSForm = new MMUICustom.MMUIFolderSelection(Games.SpeedRunners, this.panel_Left.Width, this.panel_Top.Height + 10, this.Width - this.panel_Left.Width);
            this.Controls.Add(MMUIFSForm.m_Structure);
        }


        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Bar Movement

        bool TogMove;
        int MValX;
        int MValY;

        private void panel_Top_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void panel_Top_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }
        private void panel_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void label_Title_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void label_Title_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }
        private void label_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX - label_Title.Location.X, MousePosition.Y - MValY + (panel_Left.Height / 2) - label_Title.Width - label_Title.Location.Y);
            }
        }
        
        private void panel_Left_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void panel_Left_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }
        private void panel_Left_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY - panel_Left.Width);
            }
        }

        #endregion


        // Custom Methods
        private void Setup()
        {
            IList<Button> ButtonList = new List<Button>();
            foreach (Control ControlInfo in GetSelfAndChildrenRecursive(this))
            {
                if (ControlInfo is Button)
                    ButtonList.Add((Button)ControlInfo);
            }
            foreach (Button ButtonInfo in ButtonList)
            {
                if (ButtonInfo.Name == button_Exit.Name)
                {
                    ButtonInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 255, 0, 0);
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 255, 0, 0);
                    };
                    ButtonInfo.FlatAppearance.MouseDownBackColor = Color.Red;
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseDownBackColor = Color.Red;
                    };
                }
                else if (ButtonInfo.Name == button_Maximize.Name)
                {
                    ButtonInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 100, 200);
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 100, 200);
                    };
                    ButtonInfo.FlatAppearance.MouseDownBackColor = Color.Blue;
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseDownBackColor = Color.Blue;
                    };
                }
                else if (ButtonInfo.Name == button_Minimize.Name)
                {
                    ButtonInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 100, 200);
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 100, 200);
                    };
                    ButtonInfo.FlatAppearance.MouseDownBackColor = Color.Blue;
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseDownBackColor = Color.Blue;
                    };
                }
                else
                {
                    ButtonInfo.FlatAppearance.MouseOverBackColor = ButtonInfo.BackColor;
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseOverBackColor = ButtonInfo.BackColor;
                    };
                    ButtonInfo.FlatAppearance.MouseDownBackColor = ButtonInfo.BackColor;
                    ButtonInfo.BackColorChanged += (s, e) =>
                    {
                        ButtonInfo.FlatAppearance.MouseDownBackColor = ButtonInfo.BackColor;
                    };
                }

                ButtonInfo.TabStop = false;
                ButtonInfo.FlatStyle = FlatStyle.Flat;
                ButtonInfo.FlatAppearance.BorderSize = 0;
                ButtonInfo.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            }
        }
        private IEnumerable<Control> GetSelfAndChildrenRecursive(Control parent)
        {
            List<Control> controls = new List<Control>();

            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetSelfAndChildrenRecursive(child));
            }

            controls.Add(parent);

            return controls;
        }

        private void button_SelectFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox_SpeedRunnersFolder.Text = fbd.SelectedPath;
                }
            }
        }
    }
}