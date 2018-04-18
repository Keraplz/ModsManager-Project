using System;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
            Setup.MainSetup();
        }
    }
}