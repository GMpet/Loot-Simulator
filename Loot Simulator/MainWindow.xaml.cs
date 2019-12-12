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

namespace Loot_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int totalKills = 0;
        int commonDrops = 0;
        int uncommonDrops = 0;
        int rareDrops = 0;
        int epicDrops = 0;
        int legendaries = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void submit_Click(object sender, RoutedEventArgs e)
        {
            if (NumKills.Text != "")
            {
                int numKills = int.Parse(NumKills.Text);
                if (numKills > 0)
                {
                    int tier = GetTier(BossType.Text);
                    if (tier > 0)
                    {
                        Random rand = new Random();
                        float RNG = 0;
                        totalKills += numKills;
                        for (int i = 0; i < numKills; i++)
                        {
                            RNG = rand.Next(0, 100);
                            commonDrops += rand.Next(tier * 10, tier * 25);
                            if (RNG <= 15.0f * tier)
                            {
                                uncommonDrops += rand.Next(3 * tier, 8 * tier);
                            }
                            if (RNG <= 7.0f * tier)
                            {
                                rareDrops += rand.Next(2 * tier, 3 * tier);
                            }
                            if (RNG <= 1.0f * tier)
                            {
                                epicDrops += rand.Next(1, 2);
                            }
                            if (RNG <= 1.0f * (tier / 2.0f))
                            {
                                legendaries += 1;
                            }
                        }
                        output.Content = $"Total Kills: {totalKills}" +
                            $"\nCommon Drops: {commonDrops}" +
                            $"\nUncommon Drops: {uncommonDrops}" +
                            $"\nRare Drops: {rareDrops}" +
                            $"\nEpic Drops: {epicDrops}" +
                            $"\nLegendaries: {legendaries}";
                    }
                    else
                    {
                        BossType.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    NumKills.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                NumKills.BorderBrush = Brushes.Red;
            }
        }
        private void BossType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(NumKills.Text, out int result))
            {
                NumKills.Text = Regex.Replace(NumKills.Text, @"[^0-9]", "");
            }
            
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
            totalKills = 0;
            commonDrops = 0;
            uncommonDrops = 0;
            rareDrops = 0;
            epicDrops = 0;
            legendaries = 0;
            output.Content = "";
        }
    }
}
