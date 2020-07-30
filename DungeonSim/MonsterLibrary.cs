using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSim
{
    /*
     * This class returns combatants with the stats matching various DnD monsters, additional monsters added as needed.
         */
    public class MonsterLibrary
    {

        public MonsterLibrary() 
        {
        
        }
        /*
         * Gets a monster based on it's name (ex. "Skeleton")
         */
        public Combatant getMonster(string monster) 
        {
            string editMonster = monster.ToLower();

            switch (editMonster)
            {
                /*
                    Skelton stats according to the DnD 5e player's handbook
                 */
                case "skeleton":
                    // The Skelton shortSword and shortBow have +2 damage
                    Weapon shortSword = new Weapon("shortsword", "1d6", "slashing");
                    shortSword.damageMod = 2;
                    Weapon shortBow = new Weapon("shortbow", "1d6", "piercing");
                    shortBow.setRanged(20,60);
                    shortBow.damageMod = 2;

                    BasicMonster skeleton = new BasicMonster(10, 14, 15, 6, 8, 5, 30, 13, shortSword, shortBow);
                    // all Skeleton attacks have a +4 modifier
                    skeleton.hitMod = 4;
                    skeleton.hpmax = 13;
                    skeleton.curHp = 13;
                    return skeleton;
                    /*
                     Zombie stats according to the DnD 5e player's handbook
                     */
                case "zombie":
                    // The zombie slam ability
                    Weapon slam = new Weapon("slam", "1d6", "bludgeoning");
                    slam.damageMod = 1;
                    slam.setRanged(5,5);

                    BasicMonster zombie = new BasicMonster(13, 6, 16, 3, 6, 5, 20, 8, slam, null);
                    // all zombies attacks have a +3 hit modifier
                    zombie.hitMod = 3;
                    zombie.hpmax = 22;
                    zombie.curHp = 22;
                    return zombie;

                default:
                return null;
            }
        }
    }
}
