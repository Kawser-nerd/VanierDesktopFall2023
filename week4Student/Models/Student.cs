using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4Student.Models
{
    // This class will help us to get the structure from the database, which is going to be
    // encrypted inside the Response the server is sending
    internal class Student
    {
        public string std_name { get; set; }
        public int std_id { get; set; }
        
        public string std_email { get; set;}
        public string std_dept { get; set; }
        public int std_reg_year { get; set; }
    }
}
