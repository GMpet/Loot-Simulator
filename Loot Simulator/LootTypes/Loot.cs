using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LootSimulator.LootTypes
{
    public enum Rarity
    {
        Common = 1,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    public enum ArmorType
    {
        Cloth = 1,
        Leather,
        Mail,
        Plate,
        Ring,
        Trinket,
        Relic
    }
    public enum WeaponType
    {
        Staff = 1,
        Wand,
        Bow,
        Crossbow,
        Gun,
        Dagger,
        Mace,
        Polearm,
        Sword,
        Axe,
    }
    public enum LootType
    {
        Armor = 1,
        Weapon
    }
    public abstract class Loot
    {

        public string ItemName { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Stamina { get; set; }
        public int ArmorValue { get; set; }
        public int WeaponDamage { get; set; }
        public Rarity Rarity { get; set; }
        public ArmorType ArmorType { get; set; }
        public WeaponType WeaponType { get; set; }
        public LootType LootType { get; set; }
        public int Level { get; set; }
        public float SellPrice { get; set; }
        public void Disenchant()
        {
            Random rand = new Random();
            Console.WriteLine($"{ItemName} was disenchanted" +
                $"\n+{rand.Next(1, 4)} {Rarity} Dust!");
        }
        public void Equip()
        {
            Console.WriteLine($"{ItemName} was equipped!");
        }
        public void Inspect()
        {
            Console.WriteLine($"{ItemName}");
        }
    }
}
