using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class RoundCalcer
{
    public List<Combatant> Combatants = new List<Combatant>();
    /*
        pupulate combatants for fight
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

        int allyDamage = 0;
        int enemyDamage = 0;

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
            // Proceed to calculate a round

        }


        return 0;
    }

    /*
        Add a user to the combat
    */
    public void addCombatant(Combatant c)
    {
        Combatants.Add(c);
    }
}

