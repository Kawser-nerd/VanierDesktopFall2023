namespace RestAPIStudent2023.Models
{
    public class Response
    {
        /// <summary>
        /// THis is the response message we want our database server should provide us
        /// as response
        /// </summary>
        // response starts with a code
        public int statusCode { get; set; }

        // response has a message
        public string messageCode { get; set; }

        // response can have only one student retrive from the databse
        public Student student { get; set; }

        // response can have list of students from the database
        public List<Student> students { get; set;}
    }
}
