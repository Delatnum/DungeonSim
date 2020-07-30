using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DungeonSim
{/*
    Class for calculating spell damage, as a note it does not factor in saves (if a character saves the dex check 
        on a fireball, the damage is halved, that is not calculated by this class.
  */
    class SpellLibrary
    {
        public bool spellCastable = false; // last spell was a valid cast
        public bool lastSpellSaves = false; // last casted spell is a save
        public string lastSpellsaveType = ""; // This should be STR, DEX, CON, INT, WIS, CHA based on the save
        public SpellLibrary() 
        { 
        
        }

        /*
            Method for casting spells, requires the spell name and the level input (if level is less than minimum casting
                requirnment return 0 (Ex. Wish is a 9th level spell and fireball is a 3rd level spell))

            returns a damage type array.
         */
        public int[] cast(string spell, int level) 
        {
            Dice diceTower = new Dice();
            int[] damageDone = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            /*
             switch statement for spells, in alphabetical order
             */
            // Types of Damage:  0 acid, 1 bludgeoning, 2 cold, 3 fire, 4 force, 5 lightning, 6 necrotic, 7 piercing, 8 poison, 9 psychic, 10 radiant, 11 slashing, and 12 thunder.
            string editSpell = spell.ToLower();
            switch (editSpell) 
            {
                /*
                    Cast Fireball
                 */
                case "fireball":
                    if (level < 3)
                    {
                        spellCastable = false;
                        break;
                    }
                    else if (level >= 3 && level <= 9)
                    {
                        spellCastable = true;
                        lastSpellsaveType = "DEX";
                        lastSpellSaves = true;

                        if (level == 3)
                        {
                            damageDone[3] += diceTower.roll("8d6");
                        }
                        else if (level == 4)
                        {
                            damageDone[3] += diceTower.roll("9d6");
                        }
                        else if (level == 5)
                        {
                            damageDone[3] += diceTower.roll("10d6");
                        }
                        else if (level == 6)
                        {
                            damageDone[3] += diceTower.roll("11d6");
                        }
                        else if (level == 7)
                        {
                            damageDone[3] += diceTower.roll("12d6");
                        }
                        else if (level == 8)
                        {
                            damageDone[3] += diceTower.roll("13d6");
                        }
                        else
                        {
                            damageDone[3] += diceTower.roll("14d6");
                        }
                    }
                    else 
                    {
                        spellCastable = false;
                    }
                break;

                default:
                break;
            } 

            return damageDone;
        }
    }
}
