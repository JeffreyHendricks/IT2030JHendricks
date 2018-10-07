using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace enrollmentApplication.Models
{
    public class Course
    {
        [Display(Name ="Course ID")]
        public virtual int courseID { get; set; }

        [Display(Name ="Course Title")]
        [Required]
        [StringLength(150)]
        public virtual string courseTitle { get; set; }

        [Display(Name ="Description")]
        public virtual string courseDescription { get; set; }

        [Display(Name ="Number Of Credits")]
        [Required]
        [Range(1,4, ErrorMessage = "Your credit hours must be between 1 and 4")]
        public virtual int courseCredits { get; set; }
    }
}