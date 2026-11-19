using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using TaxaStation;

namespace TaxaStation
{
    public class Game
    {
        List<Card> playerCardsList;

        List<Card> NPCCardsList;

        Random rand = new Random();

        public Game()
        {
            playerCardsList = new List<Card>();
            NPCCardsList = new List<Card>();
        }

        public Card GenerateCard()
        {

            int value = rand.Next(1, 14);
            int type = rand.Next(1, 5);
            Card card = new Card(value, type);

            return card;
        }

        public System.Windows.Controls.Image GenerateImage(Card c)
        {
            System.Windows.Controls.Image billede = new System.Windows.Controls.Image();
            billede.Width = 140;
            billede.Height = 200;
            billede.Margin = new Thickness(0, 0, 10, 0);
            billede.Source = new BitmapImage(new Uri(c.URL, UriKind.Relative));
            billede.Tag = c;

            return billede;
        }

    }
}
