using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace enrollmentApplication.Models
{
    public class Student
    {
        [Display(Name = "Student ID")]
        public virtual int studentID {get; set;}

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name must be entered")]
        [StringLength(50, ErrorMessage ="Your name is too long!")]
        public virtual string studentLastName { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First name must be entered")]
        [StringLength(50, ErrorMessage ="Your name is too long!")]
        public virtual string studentFirstName { get; set; }
    }
}