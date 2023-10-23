using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4Student.Models
{
    // This class will provide us the structure the remote server is going to maintain and
    // send us in this application
    internal class Response
    {
        public int statusCode { get; set; }
        public string messageCode { get; set;  }
        public Student student { get; set; }
        public List<Student> students { get; set;}
    }
}
