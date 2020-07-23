using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

class RoundCalcer
{
    public int allyHP = 0;
    public int enemyHP = 0;

    public int allyMaxHp = 0;
    public int enemyMaxHP = 0;

    public List<Combatant> Combatants = new List<Combatant>();
    /*
        populate combatants for fight
        */

    public RoundCalcer()
    {
    }
    
    /*
        Calculates overall damage, returns the damage as a sum for one side. Negative if the hostiles win, Posative if the allies win. TODO: calculate combat results
    */
    public int damageCalculator()
    {
        Combatant[] combatantArray = new Combatant[Combatants.Count];
        Combatant[] listAllies = new Combatant[Combatants.Count];
        Combatant[] listEnemies = new Combatant[Combatants.Count];

        int enemies = 1;
        int allies = 1;
        /*
         roll initiative and sort based on the rolls
         */
        int indexer = 0;
        foreach (Combatant c in Combatants)
        {
            c.rollInit();
            combatantArray[indexer] = c;
            indexer++;
        }

        

        Array.Sort(combatantArray);
        /*
         Simulate combat rounds
         */
        while (allies != 0 || enemies != 0)
        {
            

            allies = 0;
            enemies = 0;

            // Count enemies and allies still standing
            foreach (Combatant c in Combatants)
            {
                if (!c.isUnconcious || !c.isDead)
                {
                    if (c.isFriendly)
                    {
                        allies++;
                    }
                    else
                    {
                        enemies++;
                    }
                }
            }

        }


        return 0;
    }

    /*
        Add a Combatant to the combat Note: if there are no enemies or allies one side will automatically win
        if the ally is == true the combatant will be considered ally.
    */
    public void addCombatant(Combatant c, bool ally)
    {
        c.setAlly(ally);
        Combatants.Add(c);
    }
}

