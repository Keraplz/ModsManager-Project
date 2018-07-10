using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class MMUISplashScreen : Form
    {
        private bool CanClose = false;

        public MMUISplashScreen(string Intro = "Loading...")
        {
            InitializeComponent();
            Setup();

            label_ActionName.Text = Intro;

            timer_ProgressBar.Start();

            if (Profiles.Default == null)
                Profiles.Default = new Profile(Profiles.Blank.GetProgramName(), Games.SpeedRunners);

            if (!LogFile.IsOpen)
                LogFile.Initialize(false);

            LogFile.WriteInfo(Profiles.Default.GetGame());

            CanClose = true;
        }

        #region Bar Movement

        bool TogMove;
        int MValX;
        int MValY;

        private void MMUISplashScreen_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }
        private void MMUISplashScreen_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }
        private void MMUISplashScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
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

        private void timer_ProgressBar_Tick(object sender, EventArgs e)
        {
            if (progressBar_Color.Width < this.Width)
                progressBar_Color.Width += 2;

            if (progressBar_Color.Width == this.Width && CanClose)
            {
                timer_ProgressBar.Stop();
                this.Close();
            }
        }
    }
}