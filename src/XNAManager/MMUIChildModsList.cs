using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class MMUIChildModsList : Form
    {
        public static List<MMUIMod> MMUIModsList;

        public MMUIChildModsList()
        {
            InitializeComponent();
            Setup();

            MMUIModsList = new List<MMUIMod>();

            panel_ModsList.AutoScroll = false;
            panel_ModsList.HorizontalScroll.Maximum = 0;
            panel_ModsList.HorizontalScroll.Enabled = false;
            panel_ModsList.HorizontalScroll.Visible = false;
            panel_ModsList.VerticalScroll.Maximum = 0;
            panel_ModsList.VerticalScroll.Enabled = false;
            panel_ModsList.VerticalScroll.Visible = false;
            panel_ModsList.AutoScroll = true;

            panel_ModsList.Size = new Size(button_RightScrollMods.Width, panel_ModsList.Height);

            int i = 0;
            foreach (Mod modInfo in Profiles.Default.GetMods())
            {
                MMUIMod MMUIModInfo = new MMUIMod(i, modInfo, this.Width);
                MMUIModsList.Add(MMUIModInfo);
                panel_ModsList.Size = new Size(panel_ModsList.Width + MMUIMod.ItemSize.Width + MMUIMod.Padding.X, panel_ModsList.Height);
                panel_ModsList.Controls.Add(MMUIModInfo.Structure);
                i++;
            }
        }

        #region Mods List Panel Movement

        int Speed_ModsList = 0;
        int loop_ModsList = 0;
        int n_ModsList = 10;
        bool IsTicking_ModsList;
        bool TogMove_ModsList;

        // Buttom Click - Commented
        private void button_RightScrollMods_Click(object sender, EventArgs e)
        {
            //if (!IsTicking_ModsList)
            //{
            //    ModsListSpeed = (ModListItemWidth + MMUIMod.Padding.X) / n;
            //    timer_ModsList_Right.Start();
            //}
            //else n = n + 10;
        }
        private void button_LeftScrollMods_Click(object sender, EventArgs e)
        {
            //if (!IsTicking_ModsList)
            //{
            //    ModsListSpeed = (ModListItemWidth + MMUIMod.Padding.X) / n;
            //    timer_ModsList_Left.Start();
            //}
            //else n = n + 10;
        }

        private void timer_ModsList_Right_Tick(object sender, EventArgs e)
        {
            IsTicking_ModsList = true;

            if (loop_ModsList < n_ModsList)
            {
                panel_ModsList.Location = new Point(panel_ModsList.Location.X - Speed_ModsList, panel_ModsList.Location.Y);
                loop_ModsList++;
            }
            else
            {
                IsTicking_ModsList = false;
                Speed_ModsList = 0;
                loop_ModsList = 0;
                n_ModsList = 10;

                timer_ModsList_Right.Stop();
                this.Refresh();
            }
        }
        private void timer_ModsList_Left_Tick(object sender, EventArgs e)
        {
            IsTicking_ModsList = true;

            if (loop_ModsList < n_ModsList)
            {
                panel_ModsList.Location = new Point(panel_ModsList.Location.X + Speed_ModsList, panel_ModsList.Location.Y);
                loop_ModsList++;
            }
            else
            {
                IsTicking_ModsList = false;
                Speed_ModsList = 0;
                loop_ModsList = 0;
                n_ModsList = 10;

                timer_ModsList_Left.Stop();
                this.Refresh();
            }
        }

        // Buttom Hold
        private void button_RightScrollMods_MouseDown(object sender, MouseEventArgs e)
        {
            if (!IsTicking_ModsList)
            {
                TogMove_ModsList = true;
                timer_ModsList_Right_Hold.Start();
            }
        }
        private void button_LeftScrollMods_MouseDown(object sender, MouseEventArgs e)
        {
            if (!IsTicking_ModsList)
            {
                TogMove_ModsList = true;
                timer_ModsList_Left_Hold.Start();
            }
        }

        private void button_RightScrollMods_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove_ModsList = false;
        }
        private void button_LeftScrollMods_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove_ModsList = false;
        }

        private void timer_ModsList_Right_Hold_Tick(object sender, EventArgs e)
        {
            IsTicking_ModsList = true;

            if (!TogMove_ModsList)
            {
                IsTicking_ModsList = false;
                timer_ModsList_Right_Hold.Stop();
                this.Refresh();
            }
            else if (panel_ModsList.Location.X <= button_RightScrollMods.Location.X - panel_ModsList.Width)
            {
                panel_ModsList.Location = new Point(button_RightScrollMods.Location.X - panel_ModsList.Width, panel_ModsList.Location.Y);
                TogMove_ModsList = false;
            }
            else
            {
                panel_ModsList.Location = new Point(panel_ModsList.Location.X - 10, panel_ModsList.Location.Y);

            }
        }
        private void timer_ModsList_Left_Hold_Tick(object sender, EventArgs e)
        {
            IsTicking_ModsList = true;

            if (!TogMove_ModsList)
            {
                IsTicking_ModsList = false;
                timer_ModsList_Left_Hold.Stop();
                this.Refresh();
            }
            else if (panel_ModsList.Location.X >= button_LeftScrollMods.Location.X + button_LeftScrollMods.Width)
            {
                panel_ModsList.Location = new Point(button_LeftScrollMods.Location.X + button_LeftScrollMods.Width, panel_ModsList.Location.Y);
                TogMove_ModsList = false;
            }
            else
            {
                panel_ModsList.Location = new Point(panel_ModsList.Location.X + 10, panel_ModsList.Location.Y);
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