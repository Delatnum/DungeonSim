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
                Controls.Add(name);
                Encounter.Instance.AddMonster(Encounter.Instance.AllMonsters[0]);
                name.SelectedIndexChanged += new EventHandler((object s, EventArgs etwo) =>
                {
                    Encounter.Instance.Monsters[Encounter.Instance.Monsters.Count-1] = Encounter.Instance.Monsterlib.getMonster(name.SelectedValue.ToString());
                });
            }
            if (Tag.Equals("Party"))
            {
                int i = Encounter.Instance.Party.Count;
                TextBox heroName = new TextBox();
                heroName.Text = $"Hero {i}";
                heroName.Location = new Point(button1.Location.X + 30, button1.Location.Y);
                heroName.Width = 75;
                Controls.Add(heroName);
                Encounter.Instance.Party.Add(new Combatant());
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

        }
    }
}
