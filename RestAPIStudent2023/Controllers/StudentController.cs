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
    }
}
