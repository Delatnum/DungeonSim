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
    secondaryWeapon = _secondary;
    }

    /*

       Simulate one round of combat for the fighter returning an array where each index is a seperate damage type

   */

    public int[] calcRound(int targetAC, int rangeToTarget)
    {
        int[] damageDone = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        if (curHp <= 0) 
        {
            curHp = 0;
            return damageDone;
        }

        Dice diceTower = new Dice();
        // Assumed actions during a round
        while (action)
        {
            // if out of range move closer
            if (rangeToTarget > (movement))
            {
                if (primaryWeapon.isRanged())
                {
                    int[] damageHit = primaryWeapon.calcDamage();
                    for (int i = 0; i < damageDone.Length; i++)
                    {

                        damageDone[i] += damageHit[i];
                    }
                } 
                else if (secondaryWeapon.isRanged()) 
                {                    
                    int[] damageHit = secondaryWeapon.calcDamage();
                    for (int i = 0; i < damageDone.Length; i++)
                    {

                        damageDone[i] += damageHit[i];
                    }
                }
                action = false; // action used to move double speed
            }

            if (action)
            {
                /*
                 First Attack
                 */
                int roll = (diceTower.roll("1d20"));
                if ((roll == 20)) // Criticals do DOUBLE dice damage AND ALWAYS HIT
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
                else if (targetAC <= (roll + ((stats[0]) - 10) / 2))
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
                               
                action = false;
            }
        }

        return damageDone;
    }
    public void newRound()
    {

        action = true;

    }
    
}

