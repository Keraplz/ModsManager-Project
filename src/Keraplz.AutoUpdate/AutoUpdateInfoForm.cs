using System;
using System.Windows.Forms;

namespace Keraplz.AutoUpdate
{
    internal partial class AutoUpdateInfoForm : Form
    {
        public AutoUpdateInfoForm(IAutoUpdate applicationInfo, AutoUpdateXml updateInfo)
        {
            InitializeComponent();

            if (applicationInfo.ApplicationIcon != null)
            {
                this.Icon = applicationInfo.ApplicationIcon;
                this.pictureBox.Image = applicationInfo.ApplicationIcon.ToBitmap();
            }

            this.Text = applicationInfo.ApplicationName + " - Update Info";
            this.label_versions.Text = String.Format("Current Version: {0}\nUpdate Version: {1}",
                applicationInfo.ApplicationAssembly.GetName().Version.ToString(),
                updateInfo.Version.ToString());
            this.TextBox_description.Text = updateInfo.Description;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_description_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C))
                e.SuppressKeyPress = true;
        }
    }
}