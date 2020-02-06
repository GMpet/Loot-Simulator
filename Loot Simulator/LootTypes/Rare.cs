using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootSimulator.LootTypes
{
    class Rare : Loot
    {
        public string OnEquip { get; set; }
        public string ItemAbility { get; set; }
        public string TierSet { get; set; }
        public Rare(string onEquip, string itemAbility, string tierSet)
        {
            OnEquip = onEquip;
            ItemAbility = itemAbility;
            TierSet = tierSet;
        }
    }
}
