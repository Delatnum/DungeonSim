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
        public List<Combatant> Party { get; set; }
        public List<Combatant> Monsters { get; set; }
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

    }
}
