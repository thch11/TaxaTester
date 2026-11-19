using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaxaStation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BlackJackWindow : Window
    {
        private Game game;

        private int points = 10;
        public BlackJackWindow()
        {
            InitializeComponent();
            game = new Game();
            //NPCPanel.Orientation = Orientation.Horizontal;
            //PlayerPanel.Orientation = Orientation.Horizontal;

            Start();
        }

        private void Start()
        {
            BustLabel.Text = "";
            NPCPanel.Children.Clear();
            PlayerPanel.Children.Clear();
            NPCPanel.Children.Add(game.GenerateImage(game.GenerateCard()));
            NPCPanel.Children.Add(game.GenerateImage(game.GenerateCard()));
            PlayerPanel.Children.Add(game.GenerateImage(game.GenerateCard()));
            PlayerPanel.Children.Add(game.GenerateImage(game.GenerateCard()));
            PlayerLabel.Content = "PLAYER: " + CalculatePanelTotal(PlayerPanel);
            NPCLabel.Content = "DEALER: " + CalculatePanelTotal(NPCPanel);


        }
        private async void HitButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerPanel.Children.Add(game.GenerateImage(game.GenerateCard()));
            PlayerLabel.Content = "PLAYER: " + CalculatePanelTotal(PlayerPanel);
            if (CalculatePanelTotal(PlayerPanel) > 21)
            {
                BustLabel.Foreground = System.Windows.Media.Brushes.Red;
                BustLabel.Text = "BUST!";
                PointLabel.Content = "Points: " + (points - 1);
                points--;
                await Task.Delay(2000);
                Start();
            }
        }

        private async void StandButton_Click(object sender, RoutedEventArgs e)
        {
            while (CalculatePanelTotal(NPCPanel) < 17)
            {
                NPCPanel.Children.Add(game.GenerateImage(game.GenerateCard()));
                NPCLabel.Content = "DEALER: " + CalculatePanelTotal(NPCPanel);
                await Task.Delay(500);
            }

            if (CalculatePanelTotal(NPCPanel) > 21)
            {
                PointLabel.Content = "Points: " + (points + 1);
                BustLabel.Foreground = System.Windows.Media.Brushes.Green;
                BustLabel.Text = "DEALER BUST!";
                points++;
                await Task.Delay(2000);
                Start();
            }
            else if (CalculatePanelTotal(NPCPanel) > CalculatePanelTotal(PlayerPanel) && CalculatePanelTotal(NPCPanel) < 22)
            {
                PointLabel.Content = "Points: " + (points - 1);
                BustLabel.Foreground = System.Windows.Media.Brushes.Red;
                BustLabel.Text = "DEALER WINS!";
                points--;
                await Task.Delay(2000);
                Start();
            }
            else if (CalculatePanelTotal(NPCPanel) < CalculatePanelTotal(PlayerPanel))
            {
                PointLabel.Content = "Points: " + (points + 1);
                BustLabel.Foreground = System.Windows.Media.Brushes.Green;
                BustLabel.Text = "WIN!";
                points++;
                await Task.Delay(2000);
                Start();
            }
            else
            {
                BustLabel.Foreground = System.Windows.Media.Brushes.Blue;
                BustLabel.Text = "DRAW!";
                await Task.Delay(2000);
                Start();
            }


        }

        private int CalculatePanelTotal(StackPanel panel)
        {
            int total = 0;
            int aceCount = 0;

            foreach (UIElement child in panel.Children)
            {
                if (child is System.Windows.Controls.Image img && img.Tag is Card card)
                {
                    if (card.value == 11)
                    {
                        aceCount++;
                    }
                    total += card.value;
                }
            }

            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }
            return total;
        }

    }
}
