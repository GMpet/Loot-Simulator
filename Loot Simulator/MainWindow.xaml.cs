using LootSimulator.LootTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LootSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void submit_Click(object sender, RoutedEventArgs e)
        {
            int tier = GetTier(BossType.Text);
            if (tier > 0)
            {
                Random rand = new Random();
                float RNG = rand.Next(0, 1000);
                float onEquipChance = rand.Next(0, 100);
                float itemAbilityChance = rand.Next(0, 100);
                Console.WriteLine(RNG);
                Loot theLoot;
                if (RNG <= 100.0f * tier && RNG >= 40.0f * tier)
                {
                    theLoot = GenerateLoot(Rarity.Uncommon);
                    ItemNameLabel.Foreground = Brushes.Lime;
                    BonusStatOutput.Text = "";
                    OnEquipText.Text = "";
                    ItemAbility.Text = "";
                    Flavortext.Text = "";
                    TierSet.Text = "";
                    if (onEquipChance <= 30)
                    {
                        OnEquipText.Text = $"Equip: {((Uncommon)theLoot).OnEquip}";
                    }
                    if(itemAbilityChance <= 20)
                    {
                        ItemAbility.Text = $"Use: {((Uncommon)theLoot).ItemAbility}";
                    }
                }
                else if (RNG <= 40.0f * tier && RNG >= 20.0f * tier)
                {
                    theLoot = GenerateLoot(Rarity.Rare);
                    ItemNameLabel.Foreground = Brushes.Blue;
                    BonusStatOutput.Text = "";
                    OnEquipText.Text = "";
                    ItemAbility.Text = "";
                    Flavortext.Text = "";
                    TierSet.Text = ((Rare)theLoot).TierSet;
                    if(onEquipChance <= 50)
                    {
                        OnEquipText.Text = $"Equip: {((Rare)theLoot).OnEquip}";
                    }
                    if (itemAbilityChance <= 40)
                    {
                        ItemAbility.Text = $"Use: {((Rare)theLoot).ItemAbility}";
                    }
                }
                else if (RNG <= 20.0f * tier && RNG >= 10.0f * tier)
                {
                    theLoot = GenerateLoot(Rarity.Epic);
                    ItemNameLabel.Foreground = Brushes.Purple;
                    BonusStatOutput.Text = "";
                    OnEquipText.Text = "";
                    ItemAbility.Text = "";
                    Flavortext.Text = ((Epic)theLoot).FlavorText;
                    TierSet.Text = ((Epic)theLoot).TierSet;
                    if (onEquipChance <= 80)
                    {
                        OnEquipText.Text = $"Equip: {((Epic)theLoot).OnEquip}";
                    }
                    if (itemAbilityChance <= 50)
                    {
                        ItemAbility.Text = $"Use: {((Epic)theLoot).ItemAbility}";
                    }
                }
                else if (RNG <= 10.0f * tier)
                {
                    theLoot = GenerateLoot(Rarity.Legendary);
                    ItemNameLabel.Foreground = Brushes.Gold;
                    BonusStatOutput.Text = $"+{((Legendary)theLoot).StatBonus * 1.25}\n" +
                        $"+{((Legendary)theLoot).StatBonus}\n" +
                        $"+{((Legendary)theLoot).StatBonus}\n" +
                        $"+{((Legendary)theLoot).StatBonus}\n" +
                        $"+{((Legendary)theLoot).StatBonus}\n";
                    OnEquipText.Text = "";
                    ItemAbility.Text = "";
                    Flavortext.Text = ((Legendary)theLoot).FlavorText;
                    TierSet.Text = ((Legendary)theLoot).TierSet;
                    if (onEquipChance <= 100)
                    {
                        OnEquipText.Text = $"Equip: {((Legendary)theLoot).OnEquip}";
                    }
                    if (itemAbilityChance <= 50)
                    {
                        ItemAbility.Text = $"Use: {((Legendary)theLoot).ItemAbility}";
                    }
                }
                else
                {
                    theLoot = GenerateLoot(Rarity.Common);
                    ItemNameLabel.Foreground = Brushes.White;
                    BonusStatOutput.Text = "";
                    OnEquipText.Text = "";
                    ItemAbility.Text = "";
                    Flavortext.Text = "";
                    TierSet.Text = "";
                }
                ItemNameLabel.Content = theLoot.ItemName;
                Level.Text = $"Level {theLoot.Level}";
                string statOutput = $"+{theLoot.Strength} Strength\n" +
                    $"+{theLoot.Agility} Agility\n" +
                    $"+{theLoot.Intellect} Intellect\n" +
                    $"+{theLoot.Stamina} Stamina\n";
                if(theLoot.LootType == LootTypes.LootType.Armor)
                {
                    StatOutput.Text = $"{theLoot.ArmorValue} Armor\n{statOutput}";
                    LootType.Text = theLoot.ArmorType.ToString();
                }
                else
                {
                    StatOutput.Text = $"{theLoot.WeaponDamage} Damage\n{statOutput}";
                    LootType.Text = theLoot.WeaponType.ToString();
                }
                SellPrice.Text = $"Sell: {theLoot.SellPrice} coins";
            }
            else
            {
                BossType.BorderBrush = Brushes.Red;
            }
        }
        private Loot GenerateLoot(Rarity rarity)
        {
            Random rand = new Random();
            Loot myLoot;
            Array ArmorTypes = Enum.GetValues(typeof(ArmorType));
            Array WeaponTypes = Enum.GetValues(typeof(WeaponType));
            Array LootTypes = Enum.GetValues(typeof(LootType));
            var lootType = (LootType)LootTypes.GetValue(rand.Next(LootTypes.Length));
            ArmorType armorType = (ArmorType)ArmorTypes.GetValue(rand.Next(ArmorTypes.Length)); ;
            WeaponType weaponType = (WeaponType)WeaponTypes.GetValue(rand.Next(WeaponTypes.Length));
            int level = rand.Next(1, 100);
            string[] ItemNames =
            {
                "Paralyzing Arch",
                "Sacred Sandals",
                "Torture Statuette",
                "Lucky Crown",
                "Binding Ark",
                "Seal of Resistance",
                "Grimoire of Fear",
                "Goblet of Invocation",
                "Staff of Delusion",
                "Crown of Delusion",
                "Echo Symbols",
                "Dream Arch",
                "Doom Grail",
                "Paradise Texts",
                "Spite Disc",
                "Crown of Protection",
                "Fruit of Riddles",
                "Circlet of Worship",
                "Skull of Acrimony",
                "Hand of Collapse",
                "Staff of Dominance",
                "Sulfuras Hand of Ragnaros",
                "Azuresong Mageblade",
                "Life Sword",
                "Bonereaver's Edge",
                "Arcanite Reaper",
                "Ring of Spellpower",
                "Ring of Life",
                "Tablet of Speed",
                "Hide of Banishment",
                "Destiny's Stone",
                "Unholy Cloak",
                "Cube of the Cosmos",
                "Virtue Circlet",
                "Cube of Darkness",
                "Boots of Invincibility",
                "Hell's Ring",
                "Sandals of Dementia",
                "Robes of Longevity",
                "Archmage Robes",
                "Nemesis Leggings",
                "Nemesis Boots",
                "Nemesis Helmet",
                "Felheart Horns",
                "Felheart Gloves",
                "Giantstalker Chestplate",
                "Giantstalker Leggings"
            };
            string[] onEquip = {
                "Increases damage and healing done by magical spells and effects by up to XX.",
                "+XX ranged Attack Power.",
                "+XX Attack Power.",
                "Improves the chance to hit with spells by 1%.",
                "Improves the chance to get a critical strike with spells by 1%.",
                "Improves the chance to get a critical strike by 1%.",
                "Improves the chance to hit by 1%.",
                "Increased Defense +7."
            };
            string[] itemAbilities =
            {
                "Increases damage and healing done by magical spells and effects by up to XX for 15 sec. (1 Min, 30 Sec Cooldown)",
                "Restores 9 health every 5 sec and increases your Strength by 75.  Lasts 1 min. (6 Min Cooldown)",
                "Stuns target for 3 sec. (15 Min Cooldown)",
                "Increases run speed by 40% for 10 sec. (30 Min Cooldown)"
            };
            string[] tierSets =
            {
                "Cenarion Raiment",
                "Giantstalker Armor",
                "Arcanist Regalia",
                "Lawbringer Armor",
                "Vestments of Prophecy",
                "Nightslayer Armor",
                "The Earthfury",
                "Felheart Raiment",
                "Battlegear of Might"
            };
            string[] flavorTexts =
            {
                "Forged from the flames of Ragnaros himself.",
                "Feared by many.",
                "Glows faintly.",
                "Jesper Buch has wielded this one before.",
                "Not to be messed around with.",
                "Highly sought after.",
                "Pulsating with energy."
            };
            int statBonus = rand.Next(3, 21);
            switch (rarity)
            {
                case Rarity.Common:
                    myLoot = new Common();
                    myLoot.Rarity = Rarity.Common;
                    break;
                case Rarity.Uncommon:
                    myLoot = new Uncommon(onEquip[rand.Next(onEquip.Length)].Replace("XX", (rand.Next(1 * (int)rarity, 10 * (int)rarity) + level).ToString()), itemAbilities[rand.Next(itemAbilities.Length)].Replace("XX", (rand.Next(5 * (int)rarity, 15 * (int)rarity) + level).ToString()));
                    myLoot.Rarity = Rarity.Uncommon;
                    break;
                case Rarity.Rare:
                    myLoot = new Rare(onEquip[rand.Next(onEquip.Length)].Replace("XX", (rand.Next(1 * (int)rarity, 10 * (int)rarity) + level).ToString()), itemAbilities[rand.Next(itemAbilities.Length)].Replace("XX", (rand.Next(5 * (int)rarity, 15 * (int)rarity) + level).ToString()), "Set: " + tierSets[rand.Next(tierSets.Length)]);
                    myLoot.Rarity = Rarity.Rare;
                    break;
                case Rarity.Epic:
                    myLoot = new Epic(flavorTexts[rand.Next(flavorTexts.Length)], onEquip[rand.Next(onEquip.Length)].Replace("XX", (rand.Next(1 * (int)rarity, 10 * (int)rarity) + level).ToString()), itemAbilities[rand.Next(itemAbilities.Length)].Replace("XX", (rand.Next(5 * (int)rarity, 15 * (int)rarity) + level).ToString()), "Set: " + tierSets[rand.Next(tierSets.Length)]);
                    myLoot.Rarity = Rarity.Epic;
                    break;
                case Rarity.Legendary:
                    myLoot = new Legendary(flavorTexts[rand.Next(flavorTexts.Length)], onEquip[rand.Next(onEquip.Length)].Replace("XX", (rand.Next(1 * (int)rarity, 10 * (int)rarity) + level).ToString()), itemAbilities[rand.Next(itemAbilities.Length)].Replace("XX", (rand.Next(5 * (int)rarity, 15 * (int)rarity) + level).ToString()), "Set: " + tierSets[rand.Next(tierSets.Length)], statBonus);
                    myLoot.Rarity = Rarity.Legendary;
                    break;
                default:
                    myLoot = new Common();
                    myLoot.ItemName = $"Default {myLoot.Rarity}";
                    break;
            }
            myLoot.ItemName = ItemNames[rand.Next(ItemNames.Length)];
            myLoot.Level = level;
            myLoot.Intellect = rand.Next((int)(level / 2.0f * ((float)myLoot.Rarity / 2.0f)), (int)(level / 2.0f * (float)myLoot.Rarity));
            myLoot.Agility = rand.Next((int)(level / 2.0f * ((float)myLoot.Rarity / 2.0f)), (int)(level / 2.0f * (float)myLoot.Rarity));
            myLoot.Strength = rand.Next((int)(level / 2.0f * ((float)myLoot.Rarity / 2.0f)), (int)(level / 2.0f * (float)myLoot.Rarity));
            myLoot.Stamina = rand.Next((int)(level / 2.0f * ((float)myLoot.Rarity / 2.0f)), (int)(level / 2.0f * (float)myLoot.Rarity));
            myLoot.LootType = lootType;
            if (lootType == LootSimulator.LootTypes.LootType.Armor)
            {
                myLoot.ArmorType = armorType;
                myLoot.ArmorValue = rand.Next((int)(level / 2.0f * ((float)myLoot.Rarity / 2.0f) * (int)myLoot.ArmorType), (int)(level * (float)myLoot.Rarity * (int)myLoot.ArmorType));
                myLoot.SellPrice = (int)myLoot.LootType * ((int)myLoot.Rarity * 2) * (int)myLoot.ArmorType + myLoot.Intellect + myLoot.Agility + myLoot.Strength + myLoot.Stamina + myLoot.Level;
            }
            else
            {
                myLoot.WeaponType = weaponType;
                myLoot.WeaponDamage = rand.Next((int)(level / 2.0f * ((float)myLoot.Rarity / 2.0f) * ((float)myLoot.WeaponType / 5.0f)), (int)(level * (float)myLoot.Rarity * ((int)myLoot.WeaponType / 5.0f)));
                myLoot.SellPrice = (int)myLoot.LootType * ((int)myLoot.Rarity * 2) * (int)myLoot.WeaponType + myLoot.Intellect + myLoot.Agility + myLoot.Strength + myLoot.Stamina + myLoot.Level;
            }
            return myLoot;
        }
        private void BossType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private int GetTier(string tier)
        {
            int t = 0;
            switch (tier)
            {
                case "Tier 1":
                    t = 1;
                    break;
                case "Tier 2":
                    t = 2;
                    break;
                case "Tier 3":
                    t = 3;
                    break;
                case "Tier 4":
                    t = 4;
                    break;
                case "Tier 5":
                    t = 5;
                    break;
                default:
                    t = 0;
                    break;
            }
            return t;
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void OnEquipText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
