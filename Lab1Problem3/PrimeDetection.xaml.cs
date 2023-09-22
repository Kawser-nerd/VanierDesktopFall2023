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
using System.Windows.Shapes;

namespace Lab1Problem3
{
    /// <summary>
    /// Interaction logic for PrimeDetection.xaml
    /// </summary>
    public partial class PrimeDetection : Window
    {
        public PrimeDetection()
        {
            InitializeComponent();
        }

        private void Prime_Detection_Click(object sender, RoutedEventArgs e)
        {
            int variable = int.Parse(primeInput.Text);
            bool flag = true; // the reason of this bool value is 
            // to have a flog. We are considering at the beginning the given variable 
            // is prime, so we put flag true

            for(int div = 2; div <= (int) (variable / 2); div++)
            {
                if(variable % div == 0)
                {
                    flag = false;
                    result.IsEnabled = true;
                    result.Content = "Non Prime Number !!!!";
                    break;
                }

            }
            if(flag)
            {
                result.IsEnabled = true;
                result.Content = "Prime Number !!!";
            }
        }
    }
}
