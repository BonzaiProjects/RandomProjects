using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameyStuff
{
    public enum Type
    {
        Offensive,
        Defensive,
        Example
    }

    public enum Quality
    {
        Common = 100,
        Uncommon = 1000,
        Rare = 10000,
        Epic = 100000,
        Legendary = 0
    }

    public class Hero
    {
        public string Name { get; private set;  }
        public Type Type { get; private set; }
        public Quality Quality { get; private set; }
        public int Experience { get; private set; }
        public int NeededExperience { get; private set; }
        public List<IEquipment> Equipment { get; private set; }
        public List<IAbilities> Abilities { get; private set; }

        public Hero(string name, Type type, Quality quality, int experience, List<IEquipment> equipment, List<IAbilities> abilities)
        {
            Name = name;
            Type = type;
            Quality = quality;
            Experience = experience;
            Equipment = equipment;
            Abilities = abilities;
            NeededExperience = (int)quality;
        }

        public void AddExp(int exp)
        {
            if (Quality == Quality.Legendary)
            {
                return;
            }
            Experience += exp;
            if (Experience > NeededExperience)
            {
                switch (Quality)
                {
                    case Quality.Common:
                        Quality = Quality.Uncommon;
                        NeededExperience = (int)Quality - (Experience - NeededExperience);
                        break;
                    case Quality.Uncommon:
                        Quality = Quality.Rare;
                        NeededExperience = (int)Quality - (Experience - NeededExperience);
                        break;
                    case Quality.Rare:
                        Quality = Quality.Epic;
                        NeededExperience = (int)Quality - (Experience - NeededExperience);
                        break;
                    case Quality.Epic:
                        Quality = Quality.Legendary;
                        NeededExperience = (int)Quality - (Experience - NeededExperience);
                        break;
                }
            }
        }
    }
}
