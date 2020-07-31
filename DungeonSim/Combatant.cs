using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Combatant : IComparable<Combatant>
{
    // Resistances
    public bool[] resistances = { false, false, false, false, false, false, false, false, false, false, false, false, false };
    public bool[] immunities = { false, false, false, false, false, false, false, false, false, false, false, false, false };
    public bool[] vulnerabilites = { false, false, false, false, false, false, false, false, false, false, false, false, false };

    // Stats
    public int[] stats = { 0, 0, 0, 0, 0, 0 }; // STR, DEX, CON, INT, WIS, CHA
    public int movement = 30;
    public int AC;

    // Weapons
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;

    public bool action = true;
    public bool bonusAction = true;
    public bool reaction = true;

    public int hpmax;
    public int curHp;
    public int curIniative; // The current iniative of the combatant

    // Status
    public bool isDead = false;
    public bool isUnconcious = false;
    public bool isFriendly = false;

    // DeathFails and saves for heroes/bosses
    public int deathSaves = 0;
    public int deathFails = 0;

    // Targets
    public Combatant focusedTar; // Target being attacked
    public int rangeToFocus; // distance between the target and combatant
    public Combatant()
    {
    }

    /*     
        Set the resistances of the Combatant         
    */
    public void setResistance(string resistance, bool setResis)
    {
        switch (resistance)
        {
            case "acid":
                resistances[0] = setResis;
                break;
            case "bludgeoning":
                resistances[1] = setResis;
                break;
            case "cold":
                resistances[2] = setResis;
                break;
            case "fire":
                resistances[3] = setResis;
                break;
            case "force":
                resistances[4] = setResis;
                break;
            case "lightning":
                resistances[5] = setResis;
                break;
            case "necrotic":
                resistances[6] = setResis;
                break;
            case "piercing":
                resistances[7] = setResis;
                break;
            case "poison":
                resistances[8] = setResis;
                break;
            case "psychic":
                resistances[9] = setResis;
                break;
            case "radiant":
                resistances[10] = setResis;
                break;
            case "slashing":
                resistances[11] = setResis;
                break;
            case "thunder":
                resistances[12] = setResis;
                break;

            default:
                break;
        }
    }

    /*     
        Set the Immunities of the Combatant         
    */
    public void setImmunities(string immunity, bool setImmune)
    {
        switch (immunity)
        {
            case "acid":
                immunities[0] = setImmune;
                break;
            case "bludgeoning":
                immunities[1] = setImmune;
                break;
            case "cold":
                immunities[2] = setImmune;
                break;
            case "fire":
                immunities[3] = setImmune;
                break;
            case "force":
                immunities[4] = setImmune;
                break;
            case "lightning":
                immunities[5] = setImmune;
                break;
            case "necrotic":
                immunities[6] = setImmune;
                break;
            case "piercing":
                immunities[7] = setImmune;
                break;
            case "poison":
                immunities[8] = setImmune;
                break;
            case "psychic":
                immunities[9] = setImmune;
                break;
            case "radiant":
                immunities[10] = setImmune;
                break;
            case "slashing":
                immunities[11] = setImmune;
                break;
            case "thunder":
                immunities[12] = setImmune;
                break;

            default:
                break;
        }
    }

    /*     
       Set the vulnerabilites of the Combatant         
   */
    public void setVulnerabilites(string vulnerablity, bool setVulnerable)
    {
        switch (vulnerablity)
        {
            case "acid":
                vulnerabilites[0] = setVulnerable;
                break;
            case "bludgeoning":
                vulnerabilites[1] = setVulnerable;
                break;
            case "cold":
                vulnerabilites[2] = setVulnerable;
                break;
            case "fire":
                vulnerabilites[3] = setVulnerable;
                break;
            case "force":
                vulnerabilites[4] = setVulnerable;
                break;
            case "lightning":
                vulnerabilites[5] = setVulnerable;
                break;
            case "necrotic":
                vulnerabilites[6] = setVulnerable;
                break;
            case "piercing":
                vulnerabilites[7] = setVulnerable;
                break;
            case "poison":
                vulnerabilites[8] = setVulnerable;
                break;
            case "psychic":
                vulnerabilites[9] = setVulnerable;
                break;
            case "radiant":
                vulnerabilites[10] = setVulnerable;
                break;
            case "slashing":
                vulnerabilites[11] = setVulnerable;
                break;
            case "thunder":
                vulnerabilites[12] = setVulnerable;
                break;

            default:
                break;
        }
    }

    public bool saves(string saveType, int saveDC)
    {
        bool dodgin = true;
        Dice diceTower = new Dice();

        while (dodgin)
        {

            System.Threading.Thread.Sleep(0); // Notes: if this is not here Random gets the same clock time and generates the same number over and over again

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
                    break;
            }

            dodgin = false;

        }
        return false;
    }

    /*
        Default damage taken algorthim, note that heroes and bosses may have additional effects. Return the amount of damage the Combatant actually took
    */

    public int takeDamage(int[] incomingDamage)
    {
        int totalDamage = 0;

        for (int i = 0; i < resistances.Length; i++)
        {
            if (immunities[i])
            {
                totalDamage += 0;
            }
            else if (resistances[i])
            {
                totalDamage += (incomingDamage[i] / 2);
            }
            else if (vulnerabilites[i])
            {
                totalDamage += (incomingDamage[i] * 2);
            }
            else
            {
                totalDamage += incomingDamage[i];
            }
        }

        curHp -= totalDamage;

        if (curHp < 0)
        {
            curHp = 0;
            isUnconcious = true;
        }

        return totalDamage;
    }


    /*
       resets the approriate attributes for a new round
    */
    public void newRound()
    {

        action = true;
        bonusAction = true;
        reaction = true;

    }


    /*
        Roll initiative - returns the value rolled + the DEX modifier
    */

    public int rollInit()
    {
        Dice diceTower = new Dice();
        curIniative = diceTower.roll("1d20") + ((stats[1] - 10) / 2);
        return curIniative;
    }

    /*
        set the friendly status of a combatant
    */

    public void setAlly(bool status)
    {
        isFriendly = status;
    }

    /*
     
        Comparator based on iniative (higher initiative is a higher priority (more likely to be the zero index))
        Dexterity is the tie breaker, in the even that they are the same order does not matter.

     */
    public int CompareTo(Combatant other)
    {
        if (other.curIniative - this.curIniative == 0)
        {
            return other.stats[1] - this.stats[1];
        }
        else
        {
            return other.curIniative - this.curIniative;
        }
    }
    /*
        sample save n number of times to get an approximate chance of success. Returns a double represting the chance of saving.
     */
    public double sampleSaves(int n, string saveType, int saveDC)
    {
        int saves = 0;
        for (int x = 0; x < n; x++)
        {
            if (this.saves(saveType, saveDC))
            {
                saves++;
            }
        }
        return (saves / n);
    }
    /*
        CalcRound method, returns an array of zeroes unless a child class uses the method.
     */
    public virtual int[] calcRound(Combatant c)
    {
        int[] damageDone = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        return damageDone;
    }

    /*
       resets the approriate attributes for a long rest (6+ hour rest in game)
    */
    public void longRest()
    {
        curHp = hpmax;
    }
}

