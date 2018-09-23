using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enrollmentApplication.Models
{
    public class Course
    {
        public virtual int courseID { get; set; }
        public virtual string courseTitle { get; set; }
        public virtual string courseDescription { get; set; }
        public virtual int courseCredits { get; set; }
    }
}