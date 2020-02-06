using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootSimulator.LootTypes
{
    class Uncommon : Loot
    {
        public string OnEquip { get; set; }
        public string ItemAbility { get; set; }
        public Uncommon(string onEquip, string itemAbility)
        {
            OnEquip = onEquip;
            ItemAbility = itemAbility;
        }
    }
}
