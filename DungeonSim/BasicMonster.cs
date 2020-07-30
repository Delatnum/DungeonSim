using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Basic monsters typically have only one attack, if this were a skeleton (for example). It would only be able to attack with the weapons it has equipped.
*/
public class BasicMonster : Combatant
{
    public int hitMod = 0; // some monsters have increase hit modifiers to help their chance to hit (zero by default)

    public BasicMonster(int STR, int DEX, int CON, int INT, int WIS, int CHA, int _movement, int AC, Weapon _primary, Weapon _secondary)
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
    if(_secondary == null)
        secondaryWeapon = primaryWeapon;
    }

    /*

       Simulate one round of combat for the fighter returning an array where each index is a seperate damage type

   */

    public int[] calcRound(Combatant c)
    {
        // Basic Monsters don't get death saves and automatically die unless the DM says otherwise or the group is roleplaying a capture scenario
        if (isUnconcious) 
        {
            isDead = isUnconcious;
        }

        int[] damageDone = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /*
            Return zero damage if dead
         */
        if (isDead) 
        {
            curHp = 0;
            return damageDone;
        }

        Dice diceTower = new Dice();
        // Assumed actions during a round
        while (action)
        {
            // if out of range move closer
            if (rangeToFocus > (movement))
            {
                /*
                    Check for ranged weapon and make attack
                 */
                rangeToFocus -= movement;
                if (rangeToFocus < 0)
                {
                    rangeToFocus = 0;// in melee range
                }

                if (primaryWeapon.isRanged() && primaryWeapon.disAdvRange >= rangeToFocus && rangeToFocus != 0)
                {
                    int roll = (diceTower.roll("1d20"));
                    if (rangeToFocus > primaryWeapon.range)
                    {
                        int disAdvRoll = (diceTower.roll("1d20"));
                        if (disAdvRoll < roll)
                        {
                            roll = disAdvRoll;
                        }
                    }

                    if ((roll == 20)) // Criticals do DOUBLE dice damage AND ALWAYS HIT
                    {
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
                    } else if (c.AC <= (roll + ((stats[0]) - 10) / 2) + hitMod) 
                    {
                        int [] damageHit = primaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {
                            damageDone[i] += damageHit[i];
                        }
                    }
                    action = false; // attack made
                }
                else if (secondaryWeapon.isRanged() && secondaryWeapon.disAdvRange >= rangeToFocus && rangeToFocus != 0)
                {
                    int roll = (diceTower.roll("1d20"));
                    if (rangeToFocus > secondaryWeapon.range)
                    {
                        int disAdvRoll = (diceTower.roll("1d20"));
                        if (disAdvRoll < roll)
                        {
                            roll = disAdvRoll;
                        }
                    }

                    if ((roll == 20)) // Criticals do DOUBLE dice damage AND ALWAYS HIT
                    {
                        int[] damageHit = secondaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {
                            damageDone[i] += damageHit[i];
                        }
                        damageHit = secondaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {
                            damageDone[i] += damageHit[i];
                        }
                    } // Standard hits MUST meet the targets AC to hit
                    else if (c.AC <= (roll + ((stats[0]) - 10) / 2) + hitMod)
                    {
                        int[] damageHit = secondaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {
                            damageDone[i] += damageHit[i];
                        }
                    }
                    action = false;// attack made
                }
                else 
                {
                    rangeToFocus -= movement;
                    if (rangeToFocus < 0)
                    {
                        rangeToFocus = 0;// in melee range
                    }
                    action = false; // aciton used for movement
                }
                
            }
            /*
                If no ranged action as made AND the target didnt dash (move twice at the cost of an action), then we assume the monster will melee attack
             */
            if (action)
            {
                /*
                 Melee Attack
                 */
                int roll = (diceTower.roll("1d20"));
                if ((roll == 20)) // Criticals do DOUBLE dice damage AND ALWAYS HIT
                {
                    if (primaryWeapon == null)
                    {
                        damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                        damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                    }
                    else
                    {
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
                }
                else if (c.AC <= (roll + ((stats[0]) - 10) / 2) + hitMod)
                {
                    if (primaryWeapon == null)
                    {
                        damageDone[1] += (1 + (((stats[0]) - 10) / 2)); // unarmed strikes deal 1 + strength mod damage
                    }
                    else
                    {
                        int[] damageHit = primaryWeapon.calcDamage();
                        for (int i = 0; i < damageDone.Length; i++)
                        {
                            damageDone[i] += damageHit[i];
                        }
                    }
                }
                               
                action = false;
            }
        }

        return damageDone;
    }
    
}

