using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootSimulator.LootTypes
{
    class Epic : Loot
    {
        public string FlavorText { get; set; }
        public string OnEquip { get; set; }
        public string ItemAbility { get; set; }
        public string TierSet { get; set; }
        public Epic(string flavorText, string onEquip, string itemAbility, string tierSet)
        {
            FlavorText = flavorText;
            OnEquip = onEquip;
            ItemAbility = itemAbility;
            TierSet = tierSet;
        }
    }
}
