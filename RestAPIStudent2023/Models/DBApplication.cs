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
            string Query = "Select * from students";

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
    
    
        public Response GetStudentbyId(NpgsqlConnection con, int id)
        {
            // step 1: Configure/ Create Response instance
            Response response = new Response();
            // Generate the Query
            string Query = "Select * from students where std_id='"+ id +"'"; // inline parameter
                                                                             // with query
            // Step 3: Create the data adapter
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Step 4: Need to verify the search query result
            if(dt.Rows.Count > 0) // this condition satisfies whether the data/entry is properly
                // searched out from the database
            {
                Student student = new Student(); // to catch the student retrieved from DB
                student.std_id = (int)dt.Rows[0]["std_id"];
                student.std_name = (string)dt.Rows[0]["std_name"];
                student.std_email = (string)dt.Rows[0]["std_email"];
                student.std_dept = (string)dt.Rows[0]["std_dept"];
                student.std_reg_year = (int)dt.Rows[0]["std_year"];

                // configure the response message
                response.statusCode = 200;
                response.messageCode = "Successfully Retrieved";
                response.student = student;
                response.students = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Data couldn't found.. check the id";
                response.students = null;
                response.student = null;
            }
            // step 5: return the response
            return response;

        }
    
        public Response AddStudent(NpgsqlConnection con, Student student)
        {
            con.Open();
            Response response = new Response();
            string Query = "insert into students values(@std_name, default, @std_email, " +
                "@std_dept, @std_year )";
            // step 3: need the command to execute
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@std_name", student.std_name);
            //cmd.Parameters.AddWithValue("@std_id", student.std_id);
            cmd.Parameters.AddWithValue("@std_email", student.std_email);
            cmd.Parameters.AddWithValue("@std_dept", student.std_dept);
            cmd.Parameters.AddWithValue("@std_year", student.std_reg_year);

            int i = cmd.ExecuteNonQuery();

            if (i > 0) // that means, the command is executed successfully
            {
                response.statusCode = 200;
                response.messageCode = "Successfully inserted";
                response.student = student;
                response.students = null;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Insertion is not successfull";
                response.student = null;
                response.students = null;
            }
            con.Close();
            return response;
        }
    
        public Response UpdateStudent(NpgsqlConnection con, Student student)
        {
            con.Open() ;
            Response response = new Response();
            string Query = "Update students set std_name=@name, std_email=@email" +
                ", std_dept=@dept, std_year=@YearofReg where std_id=@ID";
            NpgsqlCommand cmd = new NpgsqlCommand( Query, con);
            cmd.Parameters.AddWithValue("@name", student.std_name);
            cmd.Parameters.AddWithValue("@email", student.std_email);
            cmd.Parameters.AddWithValue("@dept", student.std_dept);
            cmd.Parameters.AddWithValue("@YearofReg", student.std_reg_year);
            cmd.Parameters.AddWithValue("@ID", student.std_id);

            int i = cmd.ExecuteNonQuery() ;

            if (i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Updated Successfully";
                response.student = student;
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Update failed or id wasn't in correct form";
            }
            con.Close();
            return response;
        }
    
        public Response DeleteStudentbyId(NpgsqlConnection con, int id)
        {
            con.Open();
            Response response = new Response();
            string Query = "Delete from students where std_id='" + id + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);

            int i = cmd.ExecuteNonQuery() ;
            if(i > 0)
            {
                response.statusCode = 200;
                response.messageCode = "Student Delected Successfully";
            }
            else
            {
                response.statusCode = 100;
                response.messageCode = "Student not found!!! Could perform delete Ops";
            }
            con.Close();
            return response;
        }
    }
}
