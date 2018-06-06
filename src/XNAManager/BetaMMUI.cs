using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class BetaMMUI : Form
    {
        int panel_MenuWidth;
        int panel_ToolsWidth;
        int panel_ConfigWidth;

        bool Hidden = true;
        bool IsTicking;

        MMUIMod SampleModInfo0 = new MMUIMod("ModName0", "0Sample Description!");
        MMUIMod SampleModInfo1 = new MMUIMod("ModName1", "1Sample Description!");
        MMUIMod SampleModInfo2 = new MMUIMod("ModName2", "2Sample Description!");

        public BetaMMUI()
        {
            InitializeComponent();
            Setup();

            panel_MenuWidth = panel_Menu.MaximumSize.Width;
            panel_ToolsWidth = panel_Tools.MaximumSize.Width;
            panel_ConfigWidth = panel_Config.MaximumSize.Width;

            panel_ModsList.Controls.Add(SampleModInfo0.Structure);
            panel_ModsList.Controls.Add(SampleModInfo1.Structure);
            panel_ModsList.Controls.Add(SampleModInfo2.Structure);
        }

        // Main Menu
        private void button_Menu_Click(object sender, EventArgs e)
        {
            if (!IsTicking && Hidden)
                timer_Menu.Start();
        }
        private void button_MenuClose_Click(object sender, EventArgs e)
        {
            if (!IsTicking && !Hidden)
                timer_Menu.Start();
        }
        private void timer_Menu_Tick(object sender, EventArgs e)
        {
            IsTicking = true;
            if (Hidden)
            {
                panel_Menu.Width = panel_Menu.Width + 10;
                if (panel_Menu.Width >= panel_MenuWidth)
                {
                    timer_Menu.Stop();
                    Hidden = false;
                    IsTicking = false;
                    this.Refresh();
                }
            }
            else
            {
                panel_Menu.Width = panel_Menu.Width - 10;
                if (panel_Menu.Width <= 0)
                {
                    timer_Menu.Stop();
                    Hidden = true;
                    IsTicking = false;
                    this.Refresh();
                }
            }
        }

        // Tools Menu
        private void button_Tools_Click(object sender, EventArgs e)
        {
            if (!IsTicking && Hidden)
                timer_Tools.Start();
        }
        private void button_CloseTools_Click(object sender, EventArgs e)
        {
            if (!IsTicking && !Hidden)
                timer_Tools.Start();
        }
        private void timer_Tools_Tick(object sender, EventArgs e)
        {
            IsTicking = true;
            if (Hidden)
            {
                panel_Tools.Width = panel_Tools.Width + 10;
                if (panel_Tools.Width >= panel_ToolsWidth)
                {
                    timer_Tools.Stop();
                    Hidden = false;
                    IsTicking = false;
                    this.Refresh();
                }
            }
            else
            {
                panel_Tools.Width = panel_Tools.Width - 10;
                if (panel_Tools.Width <= 0)
                {
                    timer_Tools.Stop();
                    Hidden = true;
                    IsTicking = false;
                    this.Refresh();
                }
            }
        }


        // Configuration Menu
        private void button_Config_Click(object sender, EventArgs e)
        {
            if (!IsTicking && Hidden)
                timer_Options.Start();
        }
        private void button_CloseConfig_Click(object sender, EventArgs e)
        {
            if (!IsTicking && !Hidden)
                timer_Options.Start();
        }
        private void timer_Options_Tick(object sender, EventArgs e)
        {
            IsTicking = true;
            if (Hidden)
            {
                panel_Config.Width = panel_Config.Width + 10;
                if (panel_Config.Width >= panel_ConfigWidth)
                {
                    timer_Options.Stop();
                    Hidden = false;
                    IsTicking = false;
                    this.Refresh();
                }
            }
            else
            {
                panel_Config.Width = panel_Config.Width - 10;
                if (panel_Config.Width <= 0)
                {
                    timer_Options.Stop();
                    Hidden = true;
                    IsTicking = false;
                    this.Refresh();
                }
            }
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
                ButtonInfo.FlatAppearance.MouseOverBackColor = ButtonInfo.BackColor;
                ButtonInfo.BackColorChanged += (s, e) => {
                    ButtonInfo.FlatAppearance.MouseOverBackColor = ButtonInfo.BackColor;
                };
                ButtonInfo.FlatAppearance.MouseDownBackColor = ButtonInfo.BackColor;
                ButtonInfo.BackColorChanged += (s, e) => {
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

        // Other Events
        #region Top Bar Movement

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

        #endregion
        #region Top Bar Buttons
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private void button_Maximize_Click(object sender, EventArgs e)
        {
            FormWindowState NextState = new FormWindowState();

            if (WindowState == FormWindowState.Normal)
            {
                NextState = FormWindowState.Maximized;
                panel_MenuWidth = panel_Menu.MaximumSize.Width * 2;
                button_Maximize.BackgroundImage = MMUIResources.IconNormalize;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                NextState = FormWindowState.Normal;
                panel_MenuWidth = panel_Menu.MaximumSize.Width / 2;
                button_Maximize.BackgroundImage = MMUIResources.IconMaximize;
            }
            panel_Menu.MaximumSize = new System.Drawing.Size(panel_MenuWidth, 4000);

            if (panel_Menu.Size.Width != 0)
            {
                panel_Menu.Size = panel_Menu.MaximumSize;
                this.Refresh();
            }
            WindowState = NextState;
        }
        private void button_Minimize_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }
        #endregion

        private void button_ModsList_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception();
            }
            catch (Exception _Exception)
            {
                MMUIProgramInfo _Info = new MMUIProgramInfo(Games.SpeedRunners);
                MMUIBugReport ReportForm = new MMUIBugReport(_Info, _Exception);
                ReportForm.Show();
            }
        }

    }
}