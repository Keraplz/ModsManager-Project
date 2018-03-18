using System;
using System.Windows.Forms;

namespace ModsManager
{
    public partial class Startup : Form
    {
        public Startup(Game input_game)
        {
            InitializeComponent();
            Setup.MainSetup();
        }
    }
}