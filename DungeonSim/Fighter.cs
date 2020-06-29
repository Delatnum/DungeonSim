using System;
/*
    
    Represents the Dungeons and Dragons 5th Edition fighter class
 
     */
public class Fighter : Combatant
{

    // Fighter special actions

    public bool secondWind = true; // Can be used once per long/short rest (once in comabt) as a bonus action restores
    public bool actionSurge = false; // Can be used once per long/short rest (once in comabt) as a bonus action restores
    public bool secondAttack = false;
    public bool championArch = false; // archetype grants passive bonuses (using champion for our simulation)
    public bool indominatableRankOne = false;
    public bool indominatableRankTwo = false;
    public bool indominatableRankThree = false;

    public int level = 1;


    // Combat Stats
    public int ac = 12; // armorclass defaulting to 12, may add a higher base class later
    // passive stats
    public int proficiencyBonus;

    public Fighter(int STR, int DEX, int CON, int INT, int WIS, int CHA, int _movement, Weapon _primary, Weapon _secondary) 
    {
        /*
            Note: an average civilian has a value of 10, (an intelligence value of 8 implies stupidity 12 implies cleverness)

         */

        stats[0] = STR;
        stats[1] = DEX;
        stats[2] = CON;
        stats[3] = INT;
        stats[4] = WIS;
        stats[5] = CHA;

        movement = _movement;

        primaryWeapon = _primary;
        secondaryWeapon = _secondary;
    }

    /*
     
        Simulate one round of combat for the fighter returning an array where each index is a seperate damage type
         
    */

    public int[] calcRound(int targetAC, int rangeToTarget)
    {

        int[] damageDone = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        if(isDead)
        {
            return damageDone;
        }

        if (curHp <= 0)
        {
            curHp = 0;
            runUnconcious(); // force saves 
            return damageDone;
        }

        Dice diceTower = new Dice();
        // Assumed actions during a round
        while (action || bonusAction) {
            // if out of range move closer
            if (rangeToTarget > (2 * movement))
            {
                rangeToTarget -= (movement * 2);
                if (rangeToTarget < 0) 
                {
                    rangeToTarget = 0;
                }
                action = false; // action used to move double speed
            }

            if (action)
            {
                /*
                 First Attack
                 */
                int roll = (diceTower.roll("1d20"));
                if ((roll == 20) || ((roll == 19) && championArch)) // Criticals do DOUBLE dice damage AND ALWAYS HIT
                {
                    if (primaryWeapon == null)
                    {
                        damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                        damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                    }
                    int[] damageHit = primaryWeapon.calcDamage();
                    for (int i = 0; i < damageDone.Length; i++)
                    {

                        damageDone[i] += damageHit[i];
                    }
                    damageHit = primaryWeapon.calcDamage();
                    for (int i = 0; i < damageDone.Length; i++)
                    {

                        damageDone[i] += damageHit[i];
                    }
                } 
                else if (targetAC <= ((roll + ((stats[0]) - 10) / 2) + proficiencyBonus)) 
                {
                    if (primaryWeapon == null)
                    {
                        damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                    }
                    int[] damageHit = primaryWeapon.calcDamage();
                    for (int i = 0; i < damageDone.Length; i++)
                    {

                        damageDone[i] += damageHit[i];
                    }
                }

                /*
                 Second Attack, if level 4+
                 */

                if (secondAttack) 
                {
                    roll = (diceTower.roll("1d20"));
                    if ((roll == 20) || ((roll == 19) && championArch)) // Criticals do DOUBLE dice damage AND ALWAYS HIT
                    {
                        if (primaryWeapon == null)
                        {
                            damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                            damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                        }
                        int[] damageHit = primaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {

                            damageDone[i] += damageHit[i];
                        }
                        damageHit = primaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {

                            damageDone[i] += damageHit[i];
                        }
                    }
                    else if (targetAC <= ((roll + ((stats[0]) - 10) / 2) + proficiencyBonus))
                    {
                        if (primaryWeapon == null)
                        {
                            damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                        }
                        int[] damageHit = primaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {

                            damageDone[i] += damageHit[i];
                        }
                    }
                }
                action = false;
            }

            if (bonusAction && secondWind && (curHp < (hpmax/2))) 
            {
                bonusAction = false;
                secondWind = false;

                curHp += (level + diceTower.roll("1d10"));
            }

            if (level >= 2) 
            {
                actionSurge = false; // burn actionSurge for extra action
                action = true;
            }
        }

        return damageDone;
    }

    /*
        Make a save against an effect, taking 2 parameters
        The first is the type of save, the second is the DC to save
    */

    public bool saves (string saveType, int saveDC)
    {
        bool dodgin = true;
        Dice diceTower = new Dice();

        while (dodgin) 
        {

            int roll = (diceTower.roll("1d20"));

            // Crit Rolls always save
            if (roll == 20) 
            {
                return true;
            }



            /*
                check a non crit
             */           
            switch (saveType) 
            {                
                case "STR":
                    if (saveDC <= (roll + ((stats[0] - 10) / 2)))
                    {
                        return true;
                    }
                    break;
                case "DEX":
                    if (saveDC <= (roll + ((stats[1] - 10) / 2))) 
                    {
                        return true;
                    }
                    break;
                case "CON":
                    if (saveDC <= (roll + ((stats[2] - 10) / 2)))
                    {
                        return true;
                    }
                    break;
                case "INT":
                    if (saveDC <= (roll + ((stats[3] - 10) / 2)))
                    {
                        return true;
                    }
                    break;
                case "WIS":
                    if (saveDC <= (roll + ((stats[4] - 10) / 2)))
                    {
                        return true;
                    }
                    break;
                case "CHA":
                    if (saveDC <= (roll + ((stats[5] - 10) / 2)))
                    {
                        return true;
                    }
                    break;
                default:
                    throw new Exception("Failure to enter a save type");
            }
            dodgin = false;
            if (indominatableRankOne || indominatableRankTwo || indominatableRankThree) 
            {
                if (indominatableRankOne)
                {
                    indominatableRankOne = false;
                } 
                else if (indominatableRankTwo)
                {
                    indominatableRankTwo = false;
                }
                else 
                {
                    indominatableRankThree = false;
                }
                dodgin = true;
            }


        }
        return false;
    }

    /*
       resets the approriate attributes for a long rest (6+ hour rest in game)
    */
    public void longRest()
    {

        action = true;
        bonusAction = true;
        reaction = true;
        secondWind = true;

        if (level >= 2)
        {
            actionSurge = true;
        }

        if (level >= 3)
        {
            championArch = true;
        }

        if (level >= 9)
        {
            indominatableRankOne = true; // Allows the reroll of a save once per long rest
        }

    }

    /*
        Update level
    */
    public void levelUp() 
    {
        if (level == 20) 
        {
            return;
        }

        if (level < 20) 
        {
            level++;
            hpmax = (10 + stats[2] + (level - 1) * (6 + stats[2]));
            curHp = hpmax;
        }
        /*
            Proficiency Handling
         */
        if (level < 5)
        {
            proficiencyBonus = 2;
        }
        else if (level < 9)
        {
            proficiencyBonus = 3;
        }
        else if (level < 13)
        {
            proficiencyBonus = 4;
        }
        else if (level < 17)
        {
            proficiencyBonus = 5;
        }
        else 
        {
            proficiencyBonus = 6;
        }
        /*
         
            Level Specific features 
        
         */

        if (level == 2)
        {
            actionSurge = true;
        }

        if (level == 3) 
        {
            championArch = true;
        }

        if (level == 4) 
        {
            stats[2] += 2; // defaulting to a constituion increase at level 4
        }

        if (level == 5)
        {
            secondAttack = true; // at Level 4 fighters get 2 attacks per action
        }

        if (level == 6)
        {
            stats[1] += 2; // defaulting to a strength increas at level 6
        }

        if (level == 7)
        {
            // Remarkable Athlete unlocked (proficency bonus for RP checks, won't be simulated as it usually accounts for actions taken before a fight)
        }

        if (level == 8)
        {
            stats[1] += 2; // defaulting to a strength increas at level 8
        }

        if (level == 9)
        {
            indominatableRankOne = true; // Allows the reroll of a save once per long rest
        }
    }

    /*
     
        Run mechanics for an unconcious player
     
     */
    public void runUnconcious() 
    {
        Dice diceTower = new Dice();
        int roll = (diceTower.roll("1d20"));

        // If Unconcious and stabilized the character can't act unless healed above 0
        if (deathSaves >= 3) 
        {
            return;
        }

        if (roll == 1)
        {
            deathFails += 2;
        }
        else if (roll < 10)
        {
            deathFails += 1;
        }
        else if (roll > 10 && roll < 20)
        {
            deathSaves += 1;
        }
        else 
        {
            curHp = 1;
            deathSaves = 0;
            deathFails = 0;
        }

        // If a character reaches 3 deathFails they die

        if (deathFails == 3) 
        {
            isDead = true;
        }
    }
}
