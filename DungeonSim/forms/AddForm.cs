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
                Combatant newMonster = AddMonsterForm(i);
                Encounter.Instance.Monsters.Add(newMonster);
                
            }
            if (Tag.Equals("Party"))
            {
                int i = Encounter.Instance.Party.Count;
                Combatant newHero = AddHeroForm(i);
                Encounter.Instance.Party.Add(newHero);
            }
            button1.Location = new Point(button1.Location.X, button1.Location.Y + 40);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            int partySize = 0;
            if (Tag.Equals("Monsters"))
            {
                partySize = Encounter.Instance.Monsters.Count;
                int curMonster =0;
                foreach (var Monster in Encounter.Instance.Monsters)
                {
                    AddMonsterForm(curMonster++, Monster);
                    button1.Location = new Point(button1.Location.X, button1.Location.Y + 40);
                }
                if (partySize == 8)
                {
                    button1.Visible = false;
                }
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
            {
                Hero = new Fighter(10, 10, 10, 10, 10, 10, 10, new Weapon("shortsword", "1d6", "slashing"), new Weapon("shortsword", "1d6", "slashing"));
                Hero.AC = 10;
            }
            TextBox heroName = new TextBox();
            heroName.Text = Hero.Name;
            heroName.Location = new Point(button1.Location.X + 30, button1.Location.Y);
            heroName.Width = 75;
            TxtNames.Add(heroName);
            Controls.Add(TxtNames[curHero]);
            for (int j = 0; j < Hero.stats.Length; ++j)
            {
                TextBox stat = new TextBox();
                stat.Text = Hero.stats[j].ToString();
                stat.Location = new Point((button1.Location.X + 90)+ 30 * (j+1), button1.Location.Y);
                stat.Width = 25;
                switch (j)
                {
                    case 0:
                        TxtStr.Add(stat);
                        Controls.Add(TxtStr[curHero]);
                        break;
                    case 1:
                        TxtDex.Add(stat);
                        Controls.Add(TxtDex[curHero]);
                        break;
                    case 2:
                        TxtCon.Add(stat);
                        Controls.Add(TxtCon[curHero]);
                        break;
                    case 3:
                        TxtInt.Add(stat);
                        Controls.Add(TxtInt[curHero]);
                        break;
                    case 4:
                        TxtWis.Add(stat);
                        Controls.Add(TxtWis[curHero]);
                        break;
                    case 5:
                        TxtCha.Add(stat);
                        Controls.Add(TxtCha[curHero]);
                        break;
                }
                
            }

            //Hero.movement;
            TextBox movement = new TextBox();
            movement.Text = Hero.movement.ToString();
            movement.Location = new Point(button1.Location.X + 90 + 30 * 7, button1.Location.Y);
            movement.Width = 50;
            TxtMov.Add(movement);
            Controls.Add(TxtMov[curHero]);

            TextBox ac = new TextBox();
            ac.Text = Hero.AC.ToString();
            ac.Location = new Point(button1.Location.X + 90 + 30 * 9, button1.Location.Y);
            ac.Width = 25;
            TxtAc.Add(ac);
            Controls.Add(TxtAc[curHero]);

            ComboBox primaryWeapon = new ComboBox();
            primaryWeapon.DataSource = Encounter.Instance.AllWeapons;
            primaryWeapon.Location = new Point(button1.Location.X + 90 + 30 * 10, button1.Location.Y);
            primaryWeapon.Width = 75;
            primaryWeapon.BindingContext = new BindingContext();
            ComboPrimary.Add(primaryWeapon);
            string pwname = Hero.primaryWeapon == null ? "none" : Hero.primaryWeapon.name.ToString();
            primaryWeapon.SelectedIndex = Encounter.Instance.AllWeapons.IndexOf(pwname);
            Controls.Add(ComboPrimary[curHero]);
            

            ComboBox secondaryWeapon = new ComboBox();
            secondaryWeapon.DataSource = Encounter.Instance.AllWeapons;
            secondaryWeapon.Location = new Point(button1.Location.X + 90 + 30 * 13, button1.Location.Y);
            secondaryWeapon.Width = 75;
            secondaryWeapon.BindingContext = new BindingContext();
            ComboSecondary.Add(secondaryWeapon);
            string swname = Hero.secondaryWeapon == null ? "none" : Hero.secondaryWeapon.name.ToString();
            secondaryWeapon.SelectedIndex = Encounter.Instance.AllWeapons.IndexOf(swname);
            Controls.Add(ComboSecondary[curHero]);
            
            return Hero;
           
        }

        private Combatant AddMonsterForm(int curMonster, Combatant Monster=null)
        {
            if (Monster == null)
            {
                Monster = Encounter.Instance.Monsterlib.getMonster("skeleton");
            }
            ComboBox name = new ComboBox();
            name.BindingContext = new BindingContext();
            name.DataSource = Encounter.Instance.AllMonsters;
            name.Location = new Point(button1.Location.X + 30, button1.Location.Y);
            name.Width = 75;
            Controls.Add(name);
            name.SelectedIndex = Encounter.Instance.AllMonsters.IndexOf(Monster.Name);
            int i = curMonster;
            name.SelectedIndexChanged += new EventHandler((object s, EventArgs etwo) =>
            {
                Encounter.Instance.Monsters[i] = Encounter.Instance.Monsterlib.getMonster(name.SelectedValue.ToString());
                Combatant monster = Encounter.Instance.Monsters[i];
                TxtMStr[i].Text = monster.stats[0].ToString();
                TxtMDex[i].Text = monster.stats[1].ToString();
                TxtMCon[i].Text = monster.stats[2].ToString();
                TxtMInt[i].Text = monster.stats[3].ToString();
                TxtMWis[i].Text = monster.stats[4].ToString();
                TxtMCha[i].Text = monster.stats[5].ToString();
                TxtMMov[i].Text = monster.movement.ToString();
                TxtMAc[i].Text = monster.AC.ToString();
                ComboMPrimary[i].SelectedIndex = Encounter.Instance.AllWeapons.IndexOf(monster.primaryWeapon.name);
                string SWname = Monster.secondaryWeapon == null ? "none" : Monster.secondaryWeapon.name.ToString();
                ComboMSecondary[i].SelectedIndex = Encounter.Instance.AllWeapons.IndexOf(SWname);
            });
            CmboMonsters.Add(name);
            for (int j = 0; j < Monster.stats.Length; ++j)
            {
                TextBox stat = new TextBox();
                stat.Text = Monster.stats[j].ToString();
                stat.ReadOnly = true;
                stat.Location = new Point((button1.Location.X + 90) + 30 * (j + 1), button1.Location.Y);
                stat.Width = 25;
                switch (j)
                {
                    case 0:
                        TxtMStr.Add(stat);
                        Controls.Add(TxtMStr[curMonster]);
                        break;
                    case 1:
                        TxtMDex.Add(stat);
                        Controls.Add(TxtMDex[curMonster]);
                        break;
                    case 2:
                        TxtMCon.Add(stat);
                        Controls.Add(TxtMCon[curMonster]);
                        break;
                    case 3:
                        TxtMInt.Add(stat);
                        Controls.Add(TxtMInt[curMonster]);
                        break;
                    case 4:
                        TxtMWis.Add(stat);
                        Controls.Add(TxtMWis[curMonster]);
                        break;
                    case 5:
                        TxtMCha.Add(stat);
                        Controls.Add(TxtMCha[curMonster]);
                        break;
                }

            }

            //Hero.movement;
            TextBox movement = new TextBox();
            movement.ReadOnly = true;
            movement.Text = Monster.movement.ToString();
            movement.Location = new Point(button1.Location.X + 90 + 30 * 7, button1.Location.Y);
            movement.Width = 50;
            TxtMMov.Add(movement);
            Controls.Add(TxtMMov[curMonster]);

            TextBox ac = new TextBox();
            ac.ReadOnly = true;
            ac.Text = Monster.AC.ToString();
            ac.Location = new Point(button1.Location.X + 90 + 30 * 9, button1.Location.Y);
            ac.Width = 25;
            TxtMAc.Add(ac);
            Controls.Add(TxtMAc[curMonster]);

            ComboBox primaryWeapon = new ComboBox();
            primaryWeapon.DataSource = Encounter.Instance.AllWeapons;
            primaryWeapon.Location = new Point(button1.Location.X + 90 + 30 * 10, button1.Location.Y);
            primaryWeapon.Width = 75;
            primaryWeapon.BindingContext = new BindingContext();
            ComboMPrimary.Add(primaryWeapon);
            string pwname = Monster.primaryWeapon == null ? "none" : Monster.primaryWeapon.name.ToString();
            primaryWeapon.SelectedIndex = Encounter.Instance.AllWeapons.IndexOf(pwname);
            Controls.Add(ComboMPrimary[curMonster]);


            ComboBox secondaryWeapon = new ComboBox();
            secondaryWeapon.DataSource = Encounter.Instance.AllWeapons;
            secondaryWeapon.Location = new Point(button1.Location.X + 90 + 30 * 13, button1.Location.Y);
            secondaryWeapon.Width = 75;
            secondaryWeapon.BindingContext = new BindingContext();
            ComboMSecondary.Add(secondaryWeapon);
            string swname = Monster.secondaryWeapon == null ? "none" : Monster.secondaryWeapon.name.ToString();
            secondaryWeapon.SelectedIndex = Encounter.Instance.AllWeapons.IndexOf(swname);
            Controls.Add(ComboMSecondary[curMonster]);

            return Monster;
        }

        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int curHero = 0;
            if (Tag.Equals("Party"))
            {
                foreach (var Hero in Encounter.Instance.Party)
                {
                    //int STR, int DEX, int CON, int INT, int WIS, int CHA, int _movement, Weapon _primary, Weapon _secondary
                    Hero.Name = TxtNames[curHero].Text;
                    Hero.stats[0] = Convert.ToInt32(TxtStr[curHero].Text);
                    Hero.stats[1] = Convert.ToInt32(TxtDex[curHero].Text);
                    Hero.stats[2] = Convert.ToInt32(TxtCon[curHero].Text);
                    Hero.stats[3] = Convert.ToInt32(TxtInt[curHero].Text);
                    Hero.stats[4] = Convert.ToInt32(TxtWis[curHero].Text);
                    Hero.stats[5] = Convert.ToInt32(TxtCha[curHero].Text);
                    Hero.movement = Convert.ToInt32(TxtMov[curHero].Text);
                    Hero.AC = Convert.ToInt32(TxtAc[curHero].Text);
                    Hero.primaryWeapon = Encounter.Instance.WeaponLib.getWeapon(ComboPrimary[curHero].SelectedValue.ToString());
                    Hero.secondaryWeapon = Encounter.Instance.WeaponLib.getWeapon(ComboSecondary[curHero].SelectedValue.ToString());
                    curHero++;
                }
                
            }
        }
    }
}
