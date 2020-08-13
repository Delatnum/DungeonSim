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
        bool firstRound = true; // true if new round starting
        RoundCalcer round = new RoundCalcer();
        int roundCount = 1;
        int lastRoundRes = 0;
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
            /*
                Will not simulate another round if the Encounter has no monsters, no heroes, or the simulator has determined a result
             */
            if (Encounter.Instance.Party.Count == 0 || Encounter.Instance.Monsters.Count == 0 || lastRoundRes != 0) 
            {
                return;
            }
            /*
                Add heroes and monsters to the roundcalcer
             */
            if (firstRound)
            {
                foreach (var hero in Encounter.Instance.Party)
                {
                    round.addCombatant(hero, true);
                    hero.longRest();
                }
                foreach (var monster in Encounter.Instance.Monsters)
                {
                    round.addCombatant(monster, false);
                    monster.longRest();
                }
                lastRoundRes = round.damageCalculator(10, firstRound);
                roundCount++;
                firstRound = false;
            } else 
            {
                lastRoundRes = round.damageCalculator(0, firstRound);
                roundCount++;
            }

            // Display damage dealth by party
            Label Lbldamage = new Label();
            Lbldamage.AutoSize = true;
            Lbldamage.Text = String.Format("Damage done on round " + roundCount + ": " + round.allyDamage, Lbldamage.Text);
            Lbldamage.Location = new Point(label5.Location.X, label5.Location.Y + 20 * roundCount);
            Controls.Add(Lbldamage);

        }

        private void BtnClearParty_Click(object sender, EventArgs e)
        {
            Encounter.Instance.Party.Clear();
            firstRound = true;
            roundCount = 1;
        }

        private void BtnClearMonsters_Click(object sender, EventArgs e)
        {
            Encounter.Instance.Monsters.Clear();
            firstRound = true;
            roundCount = 1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
