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
                    skeleton.Name = "skeleton";
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
                    zombie.Name = "zombie";
                    return zombie;
                /*
                    Goblin stats according to the DnD 5e player's handbook
                */
                case "goblin":
                    Weapon scimitar = new Weapon("scimitar", "1d6", "slashing");
                    scimitar.damageMod = 2;
                    shortBow = new Weapon("shortbow", "1d6", "piercing");
                    shortBow.setRanged(80, 320);
                    shortBow.damageMod = 2;
                    BasicMonster goblin = new BasicMonster(8, 14, 10, 10, 8, 8, 30, 15, scimitar, shortBow);
                    goblin.hitMod = 4;
                    goblin.hpmax = 7;
                    goblin.curHp = 7;
                    goblin.Name = "skeleton";
                    return goblin;
                /*
                     Dire wolf stats according to the DnD 5e player's handbook
                */
                case "dire wolf":
                    Weapon bite = new Weapon("bite", "2d6", "piercing");
                    bite.damageMod = 3;
                    BasicMonster direWolf = new BasicMonster(17, 15, 15, 3, 12, 7, 50, 14, bite, null);
                    direWolf.hitMod = 5;
                    direWolf.hpmax = 37;
                    direWolf.curHp = 37;
                    direWolf.Name = "dire wolf";
                    return direWolf;

                default:
                return null;
            }
        }
    }
}
