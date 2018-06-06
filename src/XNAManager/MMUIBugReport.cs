using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class MMUIBugReport : Form
    {
        private MailMessage _Mail;
        private SmtpClient _Client;

        private string Body = string.Empty;
        // Mail Body Ex.: "Line one\r\nthis is the second line\r\nthere are 3 lines in total"

        private bool IsOnAdditData;
        private bool IsOnAnonymous;

        public MMUIBugReport(MMUIProgramInfo _Info, Exception e = null)
        {
            InitializeComponent();
            Setup();

            IsOnAdditData = true;
            IsOnAnonymous = false;

            _Client = new SmtpClient("smtp.gmail.com");
            _Client.Port = 587;
            _Client.Credentials = new NetworkCredential("mmuireport@gmail.com", "MMUI34sup");
            _Client.EnableSsl = true;

            Body = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}",
                _Info.GetMode(),
                _Info.GetName(),
                _Info.GetVersion(),
                _Info.GetGameInfo(),
                _Info.GetOSInfo());

            if (e != null)
            {
                string ErrorMessage = string.Empty;

                // Get method name
                MethodBase site = e.TargetSite;
                string methodName = site == null ? null : site.Name;

                // Get stack trace for the exception with source file information
                StackTrace trace = new StackTrace(e, true);
                // Get the top stack frame
                StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                // Get file name from Exception
                string fileName = Path.GetFileName(frame.GetFileName());

                ErrorMessage += "Error found in " + site;
                if (line != 0) ErrorMessage += ", line " + line;
                if (fileName != string.Empty) ErrorMessage += " in " + fileName;

                Body += string.Format("\r\n\r\n{0}\r\n{1}",
                ErrorMessage,
                e.Message);
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (textBox_UserDesc.Text != string.Empty)
            {
                Body += "\r\n\r\n\r\n---------------- User Description ----------------\r\n\r\n";
                Body += textBox_UserDesc.Text;
            }

            string Username = string.Empty;
            if (!IsOnAnonymous)
                Username = " - Katt";

            _Mail = new MailMessage("mmuireport@gmail.com", "mmuireport@gmail.com", "Bug Report" + Username, Body);
            if (IsOnAdditData) _Mail.Attachments.Add(new Attachment("Logo_100x50.png"));

            _Client.Send(_Mail);
            Application.Restart();
            Environment.Exit(Environment.ExitCode);
        }
        private void button_NotSend_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(Environment.ExitCode);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ToggleAdditionalData_Click(object sender, EventArgs e)
        {
            if (IsOnAdditData)
            {
                pictureBox_ToggleAdditionalData.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_Off_100px;
                IsOnAdditData = false;
            }
            else
            {
                pictureBox_ToggleAdditionalData.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_On_100px;
                IsOnAdditData = true;
            }
        }
        private void button_ToggleAnonymous_Click(object sender, EventArgs e)
        {
            if (IsOnAnonymous)
            {
                pictureBox_ToggleAnonymous.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_Off_100px;
                IsOnAnonymous = false;
            }
            else
            {
                pictureBox_ToggleAnonymous.BackgroundImage = global::ModsManager.Properties.Resources.White_Toggle_On_100px;
                IsOnAnonymous = true;
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
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY - 50);
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