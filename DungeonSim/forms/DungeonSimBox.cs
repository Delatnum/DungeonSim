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
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace DungeonSim
{
    public partial class DungeonSimBox : Form
    {
        bool firstRound = true; // true if new round starting
        bool fightFinished = false;
        RoundCalcer round = new RoundCalcer();
        int roundCount = 0;
        int lastRoundRes = 0;
        int lastRoundAllyDamage = 0;
        int lastRoundMonsterDamage = 0;
        LineSeries HeroDamageLine;
        LineSeries MonsterDamageLine;
        public DungeonSimBox()
        {
            
            InitializeComponent();

        }

        private void DungeonSimBox_Load(object sender, EventArgs e)
        {
            plotView1.Model = GridLinesHorizontal();
            plotView1.Model.Title = "Total Damage Done";
            plotView2.Model = GridLinesHorizontal();
            plotView2.Model.Axes[0].Maximum = 100;
            plotView2.Model.Title = "Probabilty of Total Party Kill";
            HeroDamageLine = new LineSeries
            {
                Title = "Damage Done to Monsters",
                Color = OxyColors.Blue,
                TextColor = OxyColors.Blue,
                BrokenLineColor = OxyColors.Blue
            };
            MonsterDamageLine = new LineSeries
            {
                Title = "Damage done to Heroes",
                Color = OxyColors.Red,
                TextColor = OxyColors.Red,
                BrokenLineColor = OxyColors.Red
            };
            plotView1.Model.Series.Add(MonsterDamageLine);
            plotView1.Model.Series.Add(HeroDamageLine);


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
            if (Encounter.Instance.Party.Count == 0 || Encounter.Instance.Monsters.Count == 0 || fightFinished)
            {
                return;
            }
            if (lastRoundRes < 0 && !fightFinished)
            {
                roundCount++; // updated label position as an additonal round
                LblLoss.AutoSize = true;
                LblLoss.Text = String.Format("The party was defeated!");
                LblLoss.Location = new Point(label5.Location.X, label5.Location.Y + 20 );
                fightFinished = true;
                progressBar1.Value = 100; // set fight to finished
                return;
            } else if (lastRoundRes > 0 && !fightFinished) 
            {
                roundCount++; // updated label position as an additonal round
                LblLoss.AutoSize = true;
                LblLoss.Text = String.Format("The monsters were defeated!");
                LblLoss.Location = new Point(label5.Location.X, label5.Location.Y + 20 );
                fightFinished = true;
                progressBar1.Value = 100; // set fight to finished
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


                
                MonsterDamageLine.Points.Add(new DataPoint(roundCount, round.enemyDamage));
                plotView1.Model.Axes[0].Maximum = plotView1.Model.Axes[0].Maximum > round.enemyDamage ? plotView1.Model.Axes[0].Maximum : round.enemyDamage + 5;
                plotView1.Model.InvalidatePlot(true);

                HeroDamageLine.Points.Add(new DataPoint(roundCount, round.allyDamage));
                plotView1.Model.Axes[0].Maximum = plotView1.Model.Axes[0].Maximum > round.allyDamage ? plotView1.Model.Axes[0].Maximum : round.allyDamage + 5;
                plotView1.Model.InvalidatePlot(true);
            } else 
            {
                lastRoundRes = round.damageCalculator(0, firstRound);
                roundCount++;

                
            }
            int roundAllyDamage = round.allyDamage - lastRoundAllyDamage;
            int roundMonsterDamage = round.enemyDamage - lastRoundMonsterDamage;
            LblLoss.Text = String.Format(" Round " + roundCount.ToString() + " Damage Done - Heroes :" + roundAllyDamage.ToString() + " Monsters: " + roundMonsterDamage.ToString());
            lastRoundAllyDamage += roundAllyDamage;
            lastRoundMonsterDamage += roundMonsterDamage;
            LblLoss.Location = new Point(label5.Location.X, label5.Location.Y + 20);
            MonsterDamageLine.Points.Add(new DataPoint(roundCount, round.enemyDamage));
            plotView1.Model.Axes[0].Maximum = plotView1.Model.Axes[0].Maximum > round.enemyDamage ? plotView1.Model.Axes[0].Maximum : round.enemyDamage+5;
            plotView1.Model.InvalidatePlot(true);

            HeroDamageLine.Points.Add(new DataPoint(roundCount, round.allyDamage));
            plotView1.Model.Axes[0].Maximum = plotView1.Model.Axes[0].Maximum > round.allyDamage ? plotView1.Model.Axes[0].Maximum : round.allyDamage+5;
            plotView1.Model.InvalidatePlot(true);
            /*
                    Update progress bar
            */
            if ((1 - round.partyPercent()) >= (1 - round.monsterPercent()))
            {
                progressBar1.Value = Convert.ToInt32((1 - round.partyPercent()) * 100);
            }
            else
            {
                progressBar1.Value = Convert.ToInt32((1 - round.monsterPercent()) * 100);
            }
            

        }

        private void BtnClearParty_Click(object sender, EventArgs e)
        {
            Encounter.Instance.Party.Clear();
            firstRound = true;
            roundCount = 1;
            fightFinished = false;
            lastRoundRes = 0;
        }

        private void BtnClearMonsters_Click(object sender, EventArgs e)
        {
            Encounter.Instance.Monsters.Clear();
            firstRound = true;
            roundCount = 1;
            fightFinished = false;
            lastRoundRes = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void plotView2_Click(object sender, EventArgs e)
        {

        }

        public static PlotModel GridLinesHorizontal()
        {
            var plotModel = new PlotModel();
            plotModel.Title = "";
            var linearAxis1 = new LinearAxis();

            linearAxis1.MajorGridlineStyle = LineStyle.Solid;
            linearAxis1.MinorGridlineStyle = LineStyle.Dot;
            linearAxis1.Maximum = 25;
            linearAxis1.Minimum = 0;
            plotModel.Axes.Add(linearAxis1);


            return plotModel;

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            
            DungeonSimBox reset = new DungeonSimBox();
            reset.FormClosed += (s, args) => Close();
            reset.Load += (s, args) => Hide();
            reset.Show();
            Encounter.Instance.Party.Clear();
            Encounter.Instance.Monsters.Clear();
        }
    }
}
