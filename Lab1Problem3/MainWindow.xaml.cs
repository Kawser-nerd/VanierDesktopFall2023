using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Lab1Problem3
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

        private void selection_Click(object sender, RoutedEventArgs e)
        {
            if (radioOne.IsChecked == true)
            {
                PopulationPrediction populationPrediction = new PopulationPrediction();
                populationPrediction.Show(); // this will active the wpf of the
                // class you created instance over here
                //this.Close(); if you want to close the current window
            }
            else if (radioTwo.IsChecked == true)
            {
                PrimeDetection primeDetection = new PrimeDetection();
                primeDetection.Show();
            }
        }
        // THis is event trigger method which is going to act when
        // the button will be clicked from GUI

    }
}
