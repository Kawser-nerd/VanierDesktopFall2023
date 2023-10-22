using Npgsql;
using System.Data;

namespace RestAPIStudent2023.Models
{
    public class DBApplication
    {
        // GetAllStudents Method to Query to the Database
        public Response GetAllStudents(NpgsqlConnection con)
        {
            // Step 1: Query Generation
            string Query = "Select * from student";

            // step 2: Need an adapter to execute the Query with Connection
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // step 3: The server is going to send the retrieved data entries as response
            // message to the Client

            Response response = new Response();
            // The students will be retrieved as a list of Entries, we need to configure
            // Our list of student parameter of the Response Class
            List<Student> students = new List<Student>(); // empty for now

            if (dt.Rows.Count > 0)   // to check if the table is empty or not
            {
                // need a loop to add entries one by one to the Student List
                for(int i = 0; i< dt.Rows.Count; i++)
                {
                    Student student = new Student();  // to catch one student information

                    student.std_name = (string)dt.Rows[i]["std_name"]; // here "std_id" is the
                                                                       // database table column
                                                                       // name
                    student.std_id = (int)dt.Rows[i]["std_id"];
                    student.std_email = (string)dt.Rows[i]["std_email"];
                    student.std_dept = (string)dt.Rows[i]["std_dept"];
                    student.std_reg_year = (int)dt.Rows[i]["std_year"];

                    students.Add(student);
                }
            }

            // Now we need to Configure the Response
            if (students.Count > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Data Retrieved Successfully";
                response.student = null;
                response.students = students;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data failed to Retrieve or may be table is empty";
                response.student = null;
                response.students = null;
            }
            return response;
        }
    }
}
