using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DungeonSim.forms
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Encounter.Instance.Party.Count == 7 || Encounter.Instance.Monsters.Count == 7)
            {
                button1.Visible = false;
            }
            if (Tag.Equals("Monsters"))
            {
                int i = Encounter.Instance.Monsters.Count;
                ComboBox name = new ComboBox();
                name.DataSource = Encounter.Instance.AllMonsters;
                name.Location = new Point(button1.Location.X + 30, button1.Location.Y);
                name.Width = 75;
                CmboMonsters.Add(name);
                Controls.Add(CmboMonsters[i]);
                Encounter.Instance.AddMonster(Encounter.Instance.AllMonsters[i]);
                /*CmboMonsters[i].SelectedIndexChanged += new EventHandler((object s, EventArgs etwo) =>
                {
                    Encounter.Instance.Monsters[i] = Encounter.Instance.Monsterlib.getMonster(name.SelectedValue.ToString());
                });*/
            }
            if (Tag.Equals("Party"))
            {
                int i = Encounter.Instance.Party.Count;
                Combatant newHero = AddHeroForm(i);
                Encounter.Instance.Party.Add(newHero);
            }
            button1.Location = new Point(button1.Location.X, button1.Location.Y + 40);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LblCha_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            int partySize = 0;
            if (Tag.Equals("Monsters"))
            {
                partySize = Encounter.Instance.Monsters.Count;
                /*ComboBox name = new ComboBox();
                name.DataSource = Encounter.Instance.AllMonsters;
                name.Location = new Point(button1.Location.X + 30, button1.Location.Y);
                name.Width = 75;
                Controls.Add(name);
                Encounter.Instance.AddMonster(Encounter.Instance.AllMonsters[0]);
                name.SelectedIndexChanged += new EventHandler((object s, EventArgs etwo) =>
                {
                    Encounter.Instance.Monsters[Encounter.Instance.Monsters.Count - 1] = Encounter.Instance.Monsterlib.getMonster(name.SelectedValue.ToString());
                });*/
            }
            if (Tag.Equals("Party"))
            {
                partySize = Encounter.Instance.Party.Count;
                int curHero = 0;
                foreach (var Hero in Encounter.Instance.Party)
                {
                    AddHeroForm(curHero++, Hero);
                    button1.Location = new Point(button1.Location.X, button1.Location.Y + 40);
                }
            }
            if (partySize == 8)
            {
                button1.Visible = false;
            }
     
        }

        private Combatant AddHeroForm(int curHero, Combatant Hero=null)
        {
            if (Hero == null)
                Hero = new Fighter(0,0,0,0,0,0,0,new Weapon("shortsword", "1d6", "slashing"), new Weapon("shortsword", "1d6", "slashing"));
            TextBox heroName = new TextBox();
            heroName.Text = $"Hero {curHero}";
            heroName.Location = new Point(button1.Location.X + 30, button1.Location.Y);
            heroName.Width = 75;
            TxtStats.Add($"heroName{curHero}", heroName);
            Controls.Add(TxtStats[$"heroName{curHero}"]);
            for (int j = 0; j < Hero.stats.Length; ++j)
            {
                TextBox stat = new TextBox();
                stat.Text = Hero.stats[j].ToString();
                stat.Location = new Point((button1.Location.X + 90)+ 30 * (j+1), button1.Location.Y);
                stat.Width = 25;
                string statName = "";
                switch (j)
                {
                    case 0:
                        statName = "STR";
                        break;
                    case 1:
                        statName = "DEX";
                        break;
                    case 2:
                        statName = "CON";
                        break;
                    case 3:
                        statName = "INT";
                        break;
                    case 4:
                        statName = "WIS";
                        break;
                    case 5:
                        statName = "CHA";
                        break;
                }
                TxtStats.Add($"heroName{curHero}{statName}", stat);
                Controls.Add(TxtStats[$"heroName{curHero}{statName}"]);
            }

            //Hero.movement;
            TextBox movement = new TextBox();
            movement.Text = Hero.movement.ToString();
            movement.Location = new Point(button1.Location.X + 90 + 30 * 7, button1.Location.Y);
            movement.Width = 50;
            TxtStats.Add($"heroName{curHero}movement", movement);
            Controls.Add(TxtStats[$"heroName{curHero}movement"]);

            TextBox ac = new TextBox();
            ac.Text = Hero.AC.ToString();
            ac.Location = new Point(button1.Location.X + 90 + 30 * 9, button1.Location.Y);
            ac.Width = 25;
            TxtStats.Add($"heroName{curHero}ac", ac);
            Controls.Add(TxtStats[$"heroName{curHero}ac"]);
            // Hero.primaryWeapon = _primary;
            // Hero.secondaryWeapon = _secondary;
            return Hero;
           
        }
    }
}
