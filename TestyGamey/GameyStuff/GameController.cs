using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameyStuff
{
    public class GameController
    {
        // list active heroes
        // list active missions
        // list available missions

        public List<Hero> Heroes;

        public GameController()
        {
            Heroes = new List<Hero>();
            for (int i = 0; i < 10; i++)
            {
                AddHero("name" + i.ToString(), Type.Offensive, Quality.Rare, 0, new List<IEquipment>(), new List<IAbilities>());
            }
        }

        private void AddHero(string name, Type type, Quality quality, int experience, List<IEquipment> equipment, List<IAbilities> abilities)
        {
            Heroes.Add(new Hero(name, type, quality, experience, equipment, abilities));
        }

        public void GiveExp(string heroname, int exp)
        {
            foreach (var item in Heroes)
            {
                if (item.Name == heroname)
                {
                    item.AddExp(exp);
                    break;
                }
            }
        }
    }
}
