using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
            try
            {
                // step 1: Establish Connection
                establishConnect();
                // step 2: open the connection
                con.Open();
                // step 3: Generating the query
                string Query = "insert into students values(@name, default, @email, @dept, @regYr)";
                // step 4: Pass the query to Command adapter
                cmd = new NpgsqlCommand(Query, con); // dynamic memory allocation of the command

                // step 4.1 : add/define values for the variables in the query
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@dept", dept.Text);
                cmd.Parameters.AddWithValue("@regYr", int.Parse(year.Text));
                /*
                 * We always need to focus on the data type the destination database has, for each 
                 * column. Here, registration year column has int datatype. SO, you need to convert 
                 * the year.Text string format data to the integer one.
                 */
                //step 5: Execute the Command
                cmd.ExecuteNonQuery();
                // step 6: send/set a successful message
                MessageBox.Show("Student Created Successfully");
                // step 7: close the connection
                con.Close();
            } catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void show_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /*
                 * We are going to read all the database entries in this method, to read all the
                 * data from the table
                 */
                // step 1: establish connection
                establishConnect();
                // step 2: OPen the connection
                con.Open();
                // step 3: create the Query
                string Query = "select * from students";
                // step 4: initialize the command Adapter with connection & Query
                cmd= new NpgsqlCommand(Query, con);
                // step 5: We need to create a SQL dataAdapter and SQL a datatable, read the data at time 
                // of executing the select command and set it in the datatable and then push it to
                // the dataAdapter to set it back to DataGrid
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //step 6: send the dataTable information to dataGrid itemsource
                dataGrid.ItemsSource = dt.AsDataView(); // this line is going to copy the whole
                // datatable it gets from the adapter to the dataGrid view. And with AsDataView()4
                // we are ensuring that, dataGrid is getting the full table data Itself as it is.
                //step 7: Reinitialize our wpf controls data, speially for dataGrid
                DataContext = da;
                //step 8: close the connection
                con.Close();
            }catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // step 1: establish connection
                establishConnect();
                // step 2: OPen the connection
                con.Open();
                // step 3: create the Query
                string Query = "select * from students where std_id=@Id";
                // step 4: initialize the command Adapter with connection & Query
                cmd = new NpgsqlCommand(Query, con);
                //step 4.1: need to initialize the query variable
                cmd.Parameters.AddWithValue("@Id", int.Parse(search.Text));
                //step 4.2 put a checker/boolean to see whether the data is present or not
                bool noData = true;
                // step 5: Data Reader adapter
                NpgsqlDataReader dr = cmd.ExecuteReader();// this line is going to 
                // read all the data matches with the query and return a list of database
                // entries
               // step 6: checking all the pulled up entries from the database one by one
               while(dr.Read())
                {
                    noData = false;
                    name.Text = dr["std_name"].ToString();
                    stdid.Text = dr["std_id"].ToString();
                    email.Text = dr["std_email"].ToString();
                    dept.Text = dr["std_dept"].ToString();
                    year.Text = dr["std_year"].ToString();
                }
               if(noData)// checking the data Retrival
                {
                    MessageBox.Show("No student with that id is present");
                }
               con.Close();
            }
            catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try { 
            //step 1: establishment connection
            establishConnect();
            //step 2: open the connection
            con.Open();
            // step 3: Query Generation
            string Query = "Update students set std_name=@name, std_email=@email, std_dept=@dept, std_year=@year where std_id=@ID";
            // step 4: initialize the command adapter of the database
            cmd = new NpgsqlCommand(Query,con);
            // step 4.1: initialize the parameters in the variables of command 
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@email", email.Text);
            cmd.Parameters.AddWithValue("@dept", dept.Text);
            cmd.Parameters.AddWithValue("@year", int.Parse(year.Text));
            cmd.Parameters.AddWithValue("@ID", int.Parse(search.Text));
            // step 5: Executing the query
            cmd.ExecuteNonQuery();
            // step 6: Successful Message
            MessageBox.Show("Update successful");

            // step 7: Close the connection
            con.Close();
            } catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try { 
            // step 1: establish the connection
            establishConnect();
            // step 2: Open the connection
            con.Open();
            // step 3: Generate the query
            string Query = "delete from students where std_id=@ID";
            // step 4: initialize the command adapter
            cmd = new NpgsqlCommand(Query, con);
            // step 4.1 initialize the parameter
            cmd.Parameters.AddWithValue("@ID", int.Parse(search.Text));
            // step 5: execute the query
            cmd.ExecuteNonQuery();
            // step 6: success message
            MessageBox.Show("Delete Successful");
            // step 7: Closing the connection
            con.Close();
            } catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
