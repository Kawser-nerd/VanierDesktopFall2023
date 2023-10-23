using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using week4Student.Models;

namespace week4Student
{
    /// <summary>
    /// Interaction logic for WPFwithRESTApi.xaml
    /// </summary>
    public partial class WPFwithRESTApi : Window
    {
        // We need a REST API client which will help us to communicate with the backend Rest API
        HttpClient client = new HttpClient();

        public WPFwithRESTApi()
        {
            /**
             * Initialize the client with the Rest API connection with proper server initialization
             * 
             * step 01: Setup the base address for our created REST API
             * 
             */
            client.BaseAddress = new Uri("https://localhost:7031/Student/");

            //Step 02: we need to clear the default network packet header informaiton
            client.DefaultRequestHeaders.Accept.Clear();

            // Step 03: Add our packet information to the http request
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")

                );

            InitializeComponent();
        }

        private async void show_Click(object sender, RoutedEventArgs e)
        {
            //Step 01: Create/ Call the method to get all the students
            var server_response = await client.GetStringAsync("GetAllStudents");
            // step 02: Decrypt/extract the server_response

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            dataGrid.ItemsSource = response_JSON.students;
            DataContext = this;
        }

        private async void Select_Click(object sender, RoutedEventArgs e)
        {
            // Step 01: Create/ Call the method to search out one student from the database
            var server_response = 
                await client.GetStringAsync("GetStudentbyId/" + int.Parse(search.Text));

            Response response_JSON = JsonConvert.DeserializeObject<Response>(server_response);

            name.Text = response_JSON.student.std_name;
            stdid.Text = response_JSON.student.std_id.ToString();
            email.Text = response_JSON.student.std_email;
            dept.Text = response_JSON.student.std_dept;
            year.Text = response_JSON.student.std_reg_year.ToString();

        }
    }
}
