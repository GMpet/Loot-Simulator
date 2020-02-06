using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootSimulator.LootTypes
{
    class Legendary : Loot
    {
        public string FlavorText { get; set; }
        public string OnEquip { get; set; }
        public string ItemAbility { get; set; }
        public int StatBonus { get; set; }
        public string TierSet { get; set; }
        public Legendary(string flavorText, string onEquip, string itemAbility, string tierSet, int statBonus)
        {
            FlavorText = flavorText;
            OnEquip = onEquip;
            ItemAbility = itemAbility;
            StatBonus = statBonus;
            TierSet = tierSet;
        }
    }
}
