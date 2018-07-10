#undef AllowResize

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class BetaMMUI : Form
    {
        //public static List<MMUIMod> MMUIModsList;

        //int ModListItemWidth;

        int panel_MenuWidth;
        int panel_ToolsWidth;
        int panel_ConfigWidth;

        bool Hidden = true;
        bool IsTicking;


        PictureBox Fade01;
        PictureBox Fade02;
        PictureBox Fade03;
        PictureBox Fade04;
        PictureBox Fade05;

        private void start()
        {
            Application.Run(new MMUISplashScreen());
        }
        public BetaMMUI()
        {
            Thread t = new Thread(new ThreadStart(start));
            t.Start();

            while (t.IsAlive) { } // pause until thread stops

            // --
            
            InitializeComponent();
            Setup();

            // --

            //MMUIModsList = new List<MMUIMod>();

            // ----

            //Fade01 = new PictureBox();
            //Fade02 = new PictureBox();
            //Fade03 = new PictureBox();
            //Fade04 = new PictureBox();
            //Fade05 = new PictureBox();
            //
            //Fade01.BackColor = MMUIResources.Secondary;
            //Fade02.BackColor = MMUIResources.Secondary;
            //Fade03.BackColor = MMUIResources.Secondary;
            //Fade04.BackColor = MMUIResources.Secondary;
            //Fade05.BackColor = MMUIResources.Secondary;
            //
            //Size FadeSize = new Size(this.Width / 5, this.Height);
            //
            //Fade01.Size = FadeSize;
            //Fade02.Size = FadeSize;
            //Fade03.Size = FadeSize;
            //Fade04.Size = FadeSize;
            //Fade05.Size = FadeSize;
            //
            //Fade01.Location = new Point(0, 0);
            //Fade02.Location = new Point(FadeSize.Width, 0);
            //Fade03.Location = new Point(FadeSize.Width * 2, 0);
            //Fade04.Location = new Point(FadeSize.Width * 3, 0);
            //Fade05.Location = new Point(FadeSize.Width * 4, 0);
            //
            //Fade01.Name = "pictureBox_Fade01";
            //Fade02.Name = "pictureBox_Fade02";
            //Fade03.Name = "pictureBox_Fade03";
            //Fade04.Name = "pictureBox_Fade04";
            //Fade05.Name = "pictureBox_Fade05";
            //
            //this.Controls.Add(Fade01);
            //this.Controls.Add(Fade02);
            //this.Controls.Add(Fade03);
            //this.Controls.Add(Fade04);
            //this.Controls.Add(Fade05);
            //
            //Fade01.BringToFront();
            //Fade02.BringToFront();
            //Fade03.BringToFront();
            //Fade04.BringToFront();
            //Fade05.BringToFront();

            // ----

            //panel_ModsList.AutoScroll = false;
            //panel_ModsList.HorizontalScroll.Maximum = 0;
            //panel_ModsList.HorizontalScroll.Enabled = false;
            //panel_ModsList.HorizontalScroll.Visible = false;
            //panel_ModsList.VerticalScroll.Maximum = 0;
            //panel_ModsList.VerticalScroll.Enabled = false;
            //panel_ModsList.VerticalScroll.Visible = false;
            //panel_ModsList.AutoScroll = true;

            panel_MenuWidth = panel_Menu.MaximumSize.Width;
            panel_ToolsWidth = panel_Tools.MaximumSize.Width;
            panel_ConfigWidth = panel_Config.MaximumSize.Width;

            //Profiles.Default = new Profile(Profiles.Blank.GetProgramName(), Games.SpeedRunners);

            //panel_ModsList.Size = new Size(button_RightScrollMods.Width/*MMUIMod.ItemSize.Width + MMUIMod.Padding.X*/, panel_ModsList.Height);

            //int i = 0;
            //foreach (Mod modInfo in Profiles.Default.GetMods())
            //{
            //    MMUIMod MMUIModInfo = new MMUIMod(i, modInfo, this.Width - panel_Tabs.Width);
            //    MMUIModsList.Add(MMUIModInfo);
            //    ModListItemWidth = MMUIModInfo.Structure.Width;
            //    panel_ModsList.Size = new Size(panel_ModsList.Width + MMUIMod.ItemSize.Width + MMUIMod.Padding.X, panel_ModsList.Height);
            //    panel_ModsList.Controls.Add(MMUIModInfo.Structure);
            //    i++;
            //}

            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            //timer_Start.Start();
        }

        // Main Menu
        private void button_Menu_Click(object sender, EventArgs e)
        {
            if (!IsTicking && Hidden)
                timer_Menu.Start();
            else if (!IsTicking && !Hidden)
            {
                panel_Menu.Width = panel_MenuWidth;
                panel_Tools.Width = 0;
                panel_Config.Width = 0;
                this.Refresh();
            }
        }
        private void button_MenuClose_Click(object sender, EventArgs e)
        {
            if (!IsTicking && !Hidden)
            {
                panel_Menu.Width = 0;
                Hidden = true;
                //timer_Menu.Start();
            }
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
            else if (!IsTicking && !Hidden)
            {
                panel_Tools.Width = panel_ToolsWidth;
                panel_Menu.Width = 0;
                panel_Config.Width = 0;
                this.Refresh();
            }
        }
        private void button_CloseTools_Click(object sender, EventArgs e)
        {
            if (!IsTicking && !Hidden)
            {
                panel_Tools.Width = 0;
                Hidden = true;
                //timer_Tools.Start();
            }
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
                timer_Config.Start();
            else if (!IsTicking && !Hidden)
            {
                panel_Config.Width = panel_ConfigWidth;
                panel_Menu.Width = 0;
                panel_Tools.Width = 0;
                this.Refresh();
            }
        }
        private void button_CloseConfig_Click(object sender, EventArgs e)
        {
            if (!IsTicking && !Hidden)
            {
                panel_Config.Width = 0;
                Hidden = true;
                //timer_Config.Start();
            }
        }
        private void timer_Config_Tick(object sender, EventArgs e)
        {
            IsTicking = true;
            if (Hidden)
            {
                panel_Config.Width = panel_Config.Width + 10;
                if (panel_Config.Width >= panel_ConfigWidth)
                {
                    timer_Config.Stop();
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
                    timer_Config.Stop();
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

        private void DisplayChild(object ChildForm)
        {
            if (this.panel_ChildDisplay.Controls.Count > 0)
                this.panel_ChildDisplay.Controls.RemoveAt(0);

            Form FormDisplay = ChildForm as Form;
            FormDisplay.TopLevel = false;
            FormDisplay.Dock = DockStyle.Fill;
            this.panel_ChildDisplay.Controls.Add(FormDisplay);
            this.panel_ChildDisplay.Tag = FormDisplay;
            FormDisplay.Show();
        }


        // Other Events

        bool TogMove;
        int MValX;
        int MValY;

        #region Left Bar Movement

        private void panel_Tabs_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel_Tabs_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = false;
        }

        private void panel_Tabs_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY - panel_Tabs.Width);
            }
        }

        #endregion
        #region Top Bar Movement

        
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
            if (false) Maximize();
        }
        private void panel_Top_DoubleClick(object sender, EventArgs e)
        {
            if (false) Maximize();
        }
        private void button_Minimize_Click(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void Maximize()
        {
            FormWindowState NextState = new FormWindowState();

            if (WindowState == FormWindowState.Normal)
            {
                NextState = FormWindowState.Maximized;
                panel_MenuWidth = panel_Menu.MaximumSize.Width * 2;
                panel_ToolsWidth = panel_Tools.MaximumSize.Width * 2;
                panel_ConfigWidth = panel_Config.MaximumSize.Width * 2;
                button_Maximize.BackgroundImage = MMUIResources.IconNormalize;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                NextState = FormWindowState.Normal;
                panel_MenuWidth = panel_Menu.MaximumSize.Width / 2;
                panel_ToolsWidth = panel_Tools.MaximumSize.Width / 2;
                panel_ConfigWidth = panel_Config.MaximumSize.Width / 2;
                button_Maximize.BackgroundImage = MMUIResources.IconMaximize;
            }
            panel_Menu.MaximumSize = new System.Drawing.Size(panel_MenuWidth, 0);
            panel_Tools.MaximumSize = new System.Drawing.Size(panel_ToolsWidth, 0);
            panel_Config.MaximumSize = new System.Drawing.Size(panel_ConfigWidth, 0);

            if (panel_Menu.Size.Width != 0)
                panel_Menu.Size = panel_Menu.MaximumSize;
            if (panel_Tools.Size.Width != 0)
                panel_Tools.Size = panel_Tools.MaximumSize;
            if (panel_Config.Size.Width != 0)
                panel_Config.Size = panel_Config.MaximumSize;

            this.Refresh();
            WindowState = NextState;
        }

        #endregion

        private void button_ModsFolder_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Profiles.Default.GetGame().GetFolderMods()))
                Directory.CreateDirectory(Profiles.Default.GetGame().GetFolderMods());
            Process.Start(Profiles.Default.GetGame().GetFolderMods());
        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            DisplayChild(new MMUIChildModsList());
        }

        private void button_AdvOption_Click(object sender, EventArgs e)
        {
            MMUIAdvOption AdvOptionForm = new MMUIAdvOption();
            AdvOptionForm.Show();
        }

        private void button_ReportBug_Click(object sender, EventArgs e)
        {
            MMUIProgramInfo _Info = new MMUIProgramInfo(Games.SpeedRunners);
            MMUIBugReport ReportForm = new MMUIBugReport(_Info);
            ReportForm.Show();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {

        }

        private void button_OpenConverter_Click(object sender, EventArgs e)
        {
            MMUIConverter ConverterForm = new MMUIConverter();
            ConverterForm.Show();
        }


        private void timer_Start_Tick(object sender, EventArgs e)
        {
            int Delay = 600;
            
            Thread.Sleep(TimeSpan.FromMilliseconds(Delay));
            
            timer_Start_Fade01.Start();
            
            Thread.Sleep(TimeSpan.FromMilliseconds(Delay));
            
            timer_Start_Fade02.Start();
            
            Thread.Sleep(TimeSpan.FromMilliseconds(Delay));
            
            timer_Start_Fade03.Start();
            
            Thread.Sleep(TimeSpan.FromMilliseconds(Delay));
            
            timer_Start_Fade04.Start();
            
            Thread.Sleep(TimeSpan.FromMilliseconds(Delay));
            
            timer_Start_Fade05.Start();

            timer_Start.Stop();
            this.Refresh();
        }

        private void timer_Start_Fade01_Tick(object sender, EventArgs e)
        {
            Fade01.Height = Fade01.Height - 10;
            if (Fade01.Height >= this.Height)
            {
                timer_Start_Fade01.Stop();
                this.Refresh();
            }
        }

        private void timer_Start_Fade02_Tick(object sender, EventArgs e)
        {
            Fade02.Height = Fade02.Height - 10;
            if (Fade02.Height >= this.Height)
            {
                timer_Start_Fade02.Stop();
                this.Refresh();
            }
        }

        private void timer_Start_Fade03_Tick(object sender, EventArgs e)
        {
            Fade03.Height = Fade03.Height - 10;
            if (Fade03.Height >= this.Height)
            {
                timer_Start_Fade03.Stop();
                this.Refresh();
            }
        }

        private void timer_Start_Fade04_Tick(object sender, EventArgs e)
        {
            Fade04.Height = Fade04.Height - 10;
            if (Fade04.Height >= this.Height)
            {
                timer_Start_Fade04.Stop();
                this.Refresh();
            }
        }

        private void timer_Start_Fade05_Tick(object sender, EventArgs e)
        {
            Fade05.Height = Fade05.Height - 10;
            if (Fade05.Height >= this.Height)
            {
                timer_Start_Fade05.Stop();
                this.Refresh();
            }
        }

        private void button_ModsOnline_Click(object sender, EventArgs e)
        {
            MMUIModsOnline ModsOnlineForm = new MMUIModsOnline();
            ModsOnlineForm.Show();
        }

        #region Bottom-Right Resize spot
#if AllowResize
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.panel_Game.Width, this.panel_Game.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(new Rectangle(this.panel_Game.Width - tolerance, this.panel_Game.Height - tolerance, tolerance, tolerance));
            this.panel_Game.Region = region;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush Brush = new SolidBrush(this.panel_Game.BackColor);
            e.Graphics.FillRectangle(Brush, sizeGripRectangle);
            
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
#endif
        #endregion

    }
}