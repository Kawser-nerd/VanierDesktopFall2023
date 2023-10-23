using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestAPIStudent2023.Models;
using System.Security.Cryptography;

namespace RestAPIStudent2023.Controllers
{
    // need to add the base controller name over here, before the controller executes
    [Route("[controller]")]
    [ApiController]//charactertistics: what type of controller
    public class StudentController : ControllerBase
    {
        // this class object helps to create a state receiver in the progra,
        // this will hold the connection information from the remote database server
        // to the local one/ client one
        private readonly IConfiguration _configuration;

        // StudentController Constructor
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Now our target is to create our first API wrapper for the database itself
        // We are going to generate the GetAllStudents API

        [HttpGet] // the GetAllStudents API is going to generate a Get Request
        [Route("GetAllStudents")] // give api a name/path

        /// Now need to create GetAllStudent API
        /// When we create API, we always get the query response from the remote server
        /// To catch that properly, we need a response Class which can get all the 
        /// students as well as the Response Methods
        /// That means, we need to create a Response model and a Student Model based
        /// On the data they are retrieving
        // Create the API method
        public Response GetAllStudent()
        {
            // Step 1: Creating Response Object
            Response response = new Response(); // create the instance of the Response Class

            // Step 2: Need to create the SQL Connection, with the Rest API Configuration
            // variable.. We need to pass the connectionString to the appSettings
            // WE need to pass the Configuration to the SQL Connection Adapter, for this 
            // case NpgSQLConnection

            NpgsqlConnection con = 
                new NpgsqlConnection(_configuration.GetConnectionString("studentConnection"));

            // Step 3: Need to Query to database with the command and Connection.. we
            // can do this inside a seperate class, name DBApplication
            DBApplication dbA = new DBApplication(); // Creating the instance of DB application
            // step 4: Getting Response
            response = dbA.GetAllStudents(con);

            // Step 5: Returning the Response to the Client or Web Browser
            return response;
        }

        // Search one Student from the Database using Student ID

        [HttpGet] // because we are going to generate Get request to the database
        [Route("GetStudentbyId/{id}")]
        public Response GetStudentbyId(int id) { 
            // Step 1: Creating the instance of the Response Class
            Response response = new Response();
            // Step 2: Create the Connection for the Database
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("studentConnection"));
            // Step 3: Creating the query with the Id passed to the system as well as
            // connect to the database and execute the query
            DBApplication dbA = new DBApplication();
            // Step 4: Call the method which is going to search the student by id
            response = dbA.GetStudentbyId(con, id);
            // step 5: Return the Response 
            return response;
        }

        // insert a new student
        [HttpPost] // to update/send something from client machine to the remote machine/server
        [Route("AddStudent")]
        public Response AddStudent(Student student) // we are passing full student information
            // from local client machine to the remote machine/server
        {
            // step 1: Create Response Instance
            Response response = new Response();
            // Step 2: Create the Connection
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("studentConnection"));
            // Step 3: Generate the Query and pass it to the Method
            DBApplication dbA = new DBApplication();
            // step 4: Call the Method
            response = dbA.AddStudent(con, student);
            return response;
        }

        // update the student information
        [HttpPut] // to update any information in server, we either use put or post request
        [Route("UpdateStudent")]
        public Response UpdateStudent(Student student) // to update the attributes of the student itself
        {
            Response response = new Response();
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("studentConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.UpdateStudent(con, student);
            return response;
        }

        // Delete the student information
        [HttpDelete]
        [Route("DeleteStudentbyId/{id}")]
        public Response DeleteStudentbyId(int id) 
        {
            Response response = new Response();
            NpgsqlConnection con =
                new NpgsqlConnection(_configuration.GetConnectionString("studentConnection"));
            DBApplication dbA = new DBApplication();
            response = dbA.DeleteStudentbyId(con, id);
            return response;
        }
    }
}
