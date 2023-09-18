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

namespace week4cls1
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            /* Create variables and hold the values from the front end*/
            double firstVariable = double.Parse(textBoxOne.Text); // this will return the input from the textbox to the program
            // Any front-end control will return String values to the program. We have to covert/parse
            // the values to their destinated format.

            double secondVaribable = double.Parse(textBoxTwo.Text);

            //comboBox.SelectedItem == "Addition"

            /*
             * Now we need to see the selected Item of the ComboBox and then need to perform the
             * operation
             */
            
            #region

            // we use region to tag and define one block of code... it works as a comment
            //if(comboBox.SelectedIndex == 0)
            if (comboBox.Text == "Addition")
            {
                //MessageBox.Show(comboBox.SelectedItem.ToString());
               MessageBox.Show( (firstVariable + secondVaribable).ToString());
            }
            //else if(comboBox.SelectedIndex == 1)
            else if(comboBox.Text == "Substraction")
            {
                MessageBox.Show((firstVariable - secondVaribable).ToString());
            }
            ////else if(comboBox.SelectedIndex == 2)
            else if (comboBox.Text == "Multiplication")
            {
                MessageBox.Show((firstVariable * secondVaribable).ToString());
            }
            ////else if(comboBox.SelectedIndex == 3)
            else if (comboBox.Text == "Division")
            {
                MessageBox.Show((firstVariable / secondVaribable).ToString());
            }
            else
            {
                MessageBox.Show("Select proper option: ");
            }
            #endregion
            
            

        }

        private void button_radio_Click(object sender, RoutedEventArgs e)
        {
            /* Create variables and hold the values from the front end*/
            double firstVariable = double.Parse(textBoxOne.Text); // this will return the input from the textbox to the program
            // Any front-end control will return String values to the program. We have to covert/parse
            // the values to their destinated format.

            double secondVaribable = double.Parse(textBoxTwo.Text);
            #region radiobutton
            if (radioButton.IsChecked == true)
            {
                MessageBox.Show((firstVariable + secondVaribable).ToString());
            }
            else if (radioButton1.IsChecked == true)
            {
                MessageBox.Show((firstVariable - secondVaribable).ToString());
            }
            else if (radioButton2.IsChecked == true)
            {
                MessageBox.Show((firstVariable * secondVaribable).ToString());
            }
            else if (radioButton3.IsChecked == true)
            {
                MessageBox.Show((firstVariable / secondVaribable).ToString());
            }
            else
            {
                MessageBox.Show("Please select proper option");
            }
            #endregion
        }

        private void checkBoxOne_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxTwo.IsChecked = false;
            checkBoxThree.IsChecked = false;
            checkBoxFour.IsChecked = false;
        }

        private void checkBoxTwo_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxOne.IsChecked = false;
            checkBoxThree.IsChecked= false;
            checkBoxFour.IsChecked= false;
        }

        private void checkBoxThree_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxOne.IsChecked= false;
            checkBoxTwo.IsChecked= false;
            checkBoxFour.IsChecked = false;
        }

        private void checkBoxFour_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxOne.IsChecked = false;
            checkBoxTwo.IsChecked= false;
            checkBoxThree.IsChecked= false;
        }

        private void buttonChkBx_Click(object sender, RoutedEventArgs e)
        {
            double variableFirst = double.Parse(textBoxOne.Text);
            double variableSecond = double.Parse(textBoxTwo.Text);

            if (checkBoxOne.IsChecked == true)
            {
                MessageBox.Show((variableFirst + variableSecond).ToString());
            }
            else if(checkBoxTwo.IsChecked == true)
            {
                MessageBox.Show((variableFirst - variableSecond).ToString());
            }
            else if(checkBoxThree.IsChecked == true)
            {
                MessageBox.Show((variableFirst * variableSecond).ToString());
            }
            else if(checkBoxFour.IsChecked == true)
            {
                MessageBox.Show((variableFirst/variableSecond).ToString());
            }
            else
            {
                MessageBox.Show("Please select one option");
            }
        }
    }
}
