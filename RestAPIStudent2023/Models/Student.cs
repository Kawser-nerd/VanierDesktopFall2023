namespace RestAPIStudent2023.Models
{
    public class Student
    {
        // this class is made to get all the information properly from the database
        // that's why we need to have same number of variables as the database table has
        // its better to maintain the sequence as well.
        public string std_name { get; set; }
        public int std_id { get; set; }
        public string std_email { get; set; }
        public string std_dept { get; set; }
        public int std_reg_year { get; set; }
    }
}
