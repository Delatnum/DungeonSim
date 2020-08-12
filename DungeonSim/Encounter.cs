using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonSim
{
    public sealed class Encounter
    {
        private static Encounter instance = null;
        public List<Combatant> Party = new List<Combatant>();
        public List<Combatant> Monsters = new List<Combatant>();

        public List<string> AllMonsters = new List<string> { "skeleton", "zombie", "goblin", "dire wolf" };
        public List<string> AllSpells = new List<string> { "fireball", "magic missle" };
        public List<string> AllWeapons = new List<string> { "shortsword", "shortbow" , "slam", "bite", "scimitar", "none"};
        public MonsterLibrary Monsterlib = new MonsterLibrary();
        public int Round { get; set; }
        public bool Active { get; set; }

        private Encounter() { }
        public static Encounter Instance
        {
            get
            {
                if (instance == null)
                    instance = new Encounter();
                return instance;
            }
        }

        public void ClearAll()
        {
            Party.Clear();
            Monsters.Clear();
            Round = 1;
            Active = false;
        }

        public void AddMonster(string monster)
        {
            Monsters.Add(Monsterlib.getMonster(monster));
        }

    }
}
