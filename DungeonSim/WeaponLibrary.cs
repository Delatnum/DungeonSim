using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSim
{
    class WeaponLibrary
    {
        public Weapon getWeapon(string weapon)
        {
            weapon = weapon.ToLower();

            switch (weapon)
            {
                case "shortsword":
                    // The Skelton shortSword and shortBow have +2 damage
                    return new Weapon("shortsword", "1d6", "slashing");
                case "shortbow":
                    return new Weapon("shortbow", "1d6", "piercing");
                case "slam":
                    return new Weapon("slam", "1d6", "blugeoning");
                case "scimitar":
                    return new Weapon("scimitar", "1d6", "slashing");
                case "bite":
                    return new Weapon("bite", "2d6", "piercing");
                default:
                    return null;
            }
        }
    }
}
