using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace enrollmentApplication.Models
{
    public class Enrollment
    {
        public virtual int enrollmentID { get; set; }

        [Display(Name ="Student ID")]
        public virtual int studentID { get; set; }

        [Display(Name ="Course ID")]
        public virtual int courseID { get; set; }

        [Required]
        [RegularExpression(@"[A-Fa-f]",ErrorMessage ="The letter grade must be between A and F")]
        public virtual string grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual bool IsActive { get; set; }

        [Display(Name ="Assigned Campus")]
        [Required]
        public virtual string AssignedCampus { get; set; }

        [Display(Name ="Enrolled In Semester")]
        [Required]
        public virtual string EnrollmentSemester { get; set; }

        [Required]
        [Display(Name="Enrollment Year")]
        [Range(typeof(int),"2018","2020")]
        public virtual int EnrollmentYear { get; set; }
    }
}