using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enrollmentApplication.Models
{
    public class Student
    {
        public virtual int studentID {get; set;}
        public virtual string studentLastName { get; set; }
        public virtual string studentFirstName { get; set; }
    }
}