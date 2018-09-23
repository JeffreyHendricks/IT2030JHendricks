﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enrollmentApplication.Models
{
    public class Enrollment
    {
        public virtual int enrollmentID { get; set; }
        public virtual int studentID { get; set; }
        public virtual int courseID { get; set; }
        public virtual string grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}