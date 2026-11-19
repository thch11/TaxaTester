using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaxaStation
{
    public partial class DriverWindow : Window
    {
        TaxiStation s;
        public DriverWindow(TaxiStation station)
        {
            s = station;
            InitializeComponent();
            DriverListBoxDriver.ItemsSource = s.DriverList;
            this.Closed += new EventHandler(DriverWindow_Closed);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(s);
            mainWindow.Show();
            this.Close();
        }

        private void UnavilableButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriverListBoxDriver.SelectedItem != null)
            {
                Driver d = (Driver)DriverListBoxDriver.SelectedItem;
                d.ChangeAvailability("Unavailable");
                DriverListBoxDriver.Items.Refresh();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a driver from the driver list!", "MuteMotion");
            }
        }

        private void AvailableButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriverListBoxDriver.SelectedItem != null)
            {
                Driver d = (Driver)DriverListBoxDriver.SelectedItem;
                d.ChangeAvailability("Available");
                DriverListBoxDriver.Items.Refresh();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a driver from the driver list!", "MuteMotion");
            }
        }

        private void OnBreakButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriverListBoxDriver.SelectedItem != null)
            {
                Driver d = (Driver)DriverListBoxDriver.SelectedItem;
                d.ChangeAvailability("On break");
                DriverListBoxDriver.Items.Refresh();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a driver from the driver list!", "MuteMotion");
            }
        }

        private void NotWorkingButton_Click(object sender, RoutedEventArgs e)
        {
            if (DriverListBoxDriver.SelectedItem != null)
            {
                Driver d = (Driver)DriverListBoxDriver.SelectedItem;
                d.ChangeAvailability("Not working");
                DriverListBoxDriver.Items.Refresh();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a driver from the driver list!", "MuteMotion");
            }
        }
        void DriverWindow_Closed(object? sender, EventArgs e)
        {
            string filepath = "JSON/Save.json";
            string json = JsonSerializer.Serialize(s.DriverList);
            System.IO.File.WriteAllText(filepath, json);
        }

        private void BlackJackButton_Click(object sender, RoutedEventArgs e)
        {
            BlackJackWindow blackjackwindow = new BlackJackWindow();
            blackjackwindow.Show();
        }
    }
}
