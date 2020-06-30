using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonSim.forms
{
    public partial class WelcomePopup : Form
    {
        public WelcomePopup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WelcomePopup_Load(object sender, EventArgs e)
        {

        }
    }
}
