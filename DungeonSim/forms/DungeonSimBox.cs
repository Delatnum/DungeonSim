using DungeonSim.forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonSim
{
    public partial class DungeonSimBox : Form
    {
        public DungeonSimBox()
        {
            
            InitializeComponent();

        }

        private void DungeonSimBox_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default["FirstRun"] = true;
            if ((bool)Properties.Settings.Default["FirstRun"] == true)
            {
                Properties.Settings.Default["FirstRun"] = false;
                Properties.Settings.Default.Save();
                WelcomePopup Welcome = new WelcomePopup();
                Welcome.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AddPartyButton_Click(object sender, EventArgs e)
        {
            AddForm test = new AddForm();
            test.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AddMonsterButton_Click(object sender, EventArgs e)
        {
            AddForm test = new AddForm();
            test.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
