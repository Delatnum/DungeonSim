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


        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddPartyButton_Click(object sender, EventArgs e)
        {
            AddForm FormAddParty = new AddForm();
            FormAddParty.Tag = "Party";
            FormAddParty.Text = "Add Party";
            FormAddParty.Show();
        }

        private void AddMonsterButton_Click(object sender, EventArgs e)
        {
            AddForm FormAddMonster = new AddForm();
            FormAddMonster.Tag = "Monsters";
            FormAddMonster.Text = "Add Monsters";
            FormAddMonster.Show();
        }
        
        private void BtnSimTurnClick(object sender, EventArgs e)
        {
            RoundCalcer round = new RoundCalcer();
            foreach (var hero in Encounter.Instance.Party)
            {
                round.addCombatant(hero, true);
            }
            foreach (var monster in Encounter.Instance.Monsters)
            {
                round.addCombatant(monster, false);
            }
            int damage = round.damageCalculator(10, true);
            Encounter.Instance.Round++;

            // Display damage
            Label Lbldamage = new Label();
            Lbldamage.Text = $"Damage done on round {Encounter.Instance.Round}: {damage}";
            Lbldamage.Location = new Point(label5.Location.X, label5.Location.Y + 20 * Encounter.Instance.Round);
            Controls.Add(Lbldamage);

        }

        private void BtnClearParty_Click(object sender, EventArgs e)
        {
            Encounter.Instance.Party.Clear();
        }

        private void BtnClearMonsters_Click(object sender, EventArgs e)
        {
            Encounter.Instance.Monsters.Clear();
        }
    }
}
