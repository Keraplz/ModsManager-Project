using System;
using System.Windows.Forms;

namespace Keraplz.AutoUpdate
{
    internal partial class AutoUpdateAcceptForm : Form
    {
        private IAutoUpdate applicationInfo;

        private AutoUpdateXml updateInfo;

        private AutoUpdateInfoForm updateInfoForm;

        internal AutoUpdateAcceptForm(IAutoUpdate applicationInfo, AutoUpdateXml updateInfo)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            this.Text = this.applicationInfo.ApplicationName + " - Update Available";

            if (this.applicationInfo.ApplicationIcon != null)
            {
                this.Icon = this.applicationInfo.ApplicationIcon;
                this.pictureBox.Image = applicationInfo.ApplicationIcon.ToBitmap();
            }

            this.label_newVersion.Text = string.Format("New Version: {0}",
                this.updateInfo.Version.ToString());
        }

        private void button_yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button_no_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void button_details_Click(object sender, EventArgs e)
        {
            if (this.updateInfoForm == null)
                this.updateInfoForm = new AutoUpdateInfoForm(this.applicationInfo, this.updateInfo);

            this.updateInfoForm.ShowDialog(this);
        }
    }
}
