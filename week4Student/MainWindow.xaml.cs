using Npgsql;
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

namespace week4Student
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

        /*
             * to establish the connection, we need to install the PostGRESQL adapter/library
             * from the packageManager.
             * 
             * adapter name is NpgSQL
             * 
             */
        //subprocess One: Connection Adapter/connection
        public static NpgsqlConnection con; // creating object of connection adapter.

        //subprocess Two: command Adapter/Execute Query
        public static NpgsqlCommand cmd; // creating object of the Command adapter
        private void insert_Click(object sender, RoutedEventArgs e)
        {
            establishConnect();

        }

        private void establishConnect()
        {
            // Step 1.. Connect to the PostGreSQL database
            // substep: generate the connection string
            // substep: create the instances of the Connector and Command adapter
            // substep: Establish the connection and check/verify

            // we need to pass the connectionString inside the NpgsqlConnection adapter
            // to do so, our connection string will be returned by the getConnectionString()
            // method. So, we pass the getConnectionString() method inside the adapter Constructor
            // WE SHOULD do exception handling
            try { 
                con = new NpgsqlConnection(get_ConnectionString());
                MessageBox.Show("Connection Established");
            }catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string get_ConnectionString()
        {
            /*
             * For PostGreSQL connectionString, we need to pass five values: They are:
             * host, port, dbName, userName, password
             */

            string host = "Host=localhost;";
            string port ="Port=5432;";
            string dbName = "Database=vanierAECFall2023;";
            string userName = "Username=postgres;";
            string password = "Password=1234;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}",host,port,dbName, userName, password);
            return connectionString;


        }
    }
}
