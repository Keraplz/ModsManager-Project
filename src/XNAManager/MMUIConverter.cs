using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class MMUIConverter : Form
    {
        IList<string> LoadedFiles = new List<string>();
        bool Compressed = true;

        public MMUIConverter()
        {
            InitializeComponent();
            Setup();

            if (!Convert.XCompress.isItAvailable())
            {
                button_ToggleCompressed.Enabled = false;
                button_ToggleCompressed.ForeColor = Color.Gray;
                if (pictureBox_ToggleCompressed.BackgroundImage == global::ModsManager.Properties.Resources.White_Toggle_On_100px)
                    pictureBox_ToggleCompressed.BackgroundImage = global::ModsManager.Properties.Resources.Gray_Toggle_On_100px;
                if (pictureBox_ToggleCompressed.BackgroundImage == global::ModsManager.Properties.Resources.White_Toggle_Off_100px)
                    pictureBox_ToggleCompressed.BackgroundImage = global::ModsManager.Properties.Resources.Gray_Toggle_Off_100px;
            }
        }

        private void pictureBox_DragFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void pictureBox_DragFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                if (file.ToLower().EndsWith(".png") && !LoadedFiles.Contains(file))
                {
                    LoadedFiles.Add(file);
                    listBox_FilesList.Items.Add(Path.GetFileName(file));
                }

            if (LoadedFiles.Count > 0)
                pictureBox_DragFiles.Visible = false;
        }
        private void listBox_FilesList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        private void listBox_FilesList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                if (file.ToLower().EndsWith(".png") && !LoadedFiles.Contains(file))
                {
                    LoadedFiles.Add(file);
                    listBox_FilesList.Items.Add(Path.GetFileName(file));
                }

            if (LoadedFiles.Count > 0)
                pictureBox_DragFiles.Visible = false;
        }

        private void pictureBox_DragFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD_ = new OpenFileDialog();

            OFD_.Filter = "Portable Network Graphics (.png) | *.png";
            OFD_.Multiselect = true;

            DialogResult DResult = OFD_.ShowDialog();

            if (DResult == DialogResult.OK)
            {
                foreach (string file in OFD_.FileNames)
                {
                    if (file.ToLower().EndsWith(".png") && !LoadedFiles.Contains(file))
                    {
                        LoadedFiles.Add(file);
                        listBox_FilesList.Items.Add(Path.GetFileName(file));
                    }

                    if (LoadedFiles.Count > 0)
                        pictureBox_DragFiles.Visible = false;
                }
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Minimize_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            string sampleDir = "cache\\xnb_output";
            string outputDir = string.Empty;

            for (int n = 1; n > 0; n++)
            {
                if (n > 9999)
                {
                    // show error message about xnb_output being on its limit of 9999 folders
                    MessageBox.Show("Error: Limit of xnb_output folders reached", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Directory.Exists(sampleDir + n.ToString("0000")))
                {
                    outputDir = sampleDir + n.ToString("0000");
                    break;
                }
            }


            if (LoadedFiles.Count > 0)
                foreach (string file in LoadedFiles)
                {
                    Convert.PNG_XNB(file, Path.Combine(outputDir, Path.GetFileNameWithoutExtension(file) + ".xnb"), Compressed);
                }

            Process.Start(outputDir);
        }
        private void button_ToggleCompressed_Click(object sender, EventArgs e)
        {
            if (Compressed)
            {
                pictureBox_ToggleCompressed.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_Off_100px;
                Compressed = false;
            }
            else
            {
                pictureBox_ToggleCompressed.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_On_100px;
                Compressed = true;
            }
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

        private void panel_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void panel_Top_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
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

        private void panel_Left_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY - 50);
            }
        }

        private void panel_Left_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        #endregion

        private void pictureBox_DragFiles_VisibleChanged(object sender, EventArgs e)
        {
            if (!pictureBox_DragFiles.Visible)
            {
                button_Apply.Enabled = true;
                button_Apply.ForeColor = Color.White;
            }
            else
            {
                button_Apply.Enabled = false;
                button_Apply.ForeColor = Color.Gray;
            }
        }

        private void button_ClearListBox_Click(object sender, EventArgs e)
        {
            LoadedFiles.Clear();
            listBox_FilesList.Items.Clear();
            pictureBox_DragFiles.Visible = true;
        }


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


    }
}