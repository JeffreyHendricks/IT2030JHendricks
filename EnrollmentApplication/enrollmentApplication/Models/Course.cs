using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace enrollmentApplication.Models
{
    public class Course: IValidatableObject
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
        public virtual string courseCredits { get; set; }

       public virtual string InstructorName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int maxCredits = 4;
            int maxWords = 5;

            // Validation 1 - Description cannot exceed 5 words

            if(courseDescription.Split(' ').Length > maxWords)
            {
                //error
                yield return (new ValidationResult("Description must be 5 words or less", new[] { "CourseDescription" }));
            }

            // Validation 2 - Credits has to be 1-4

            if (int.Parse(courseCredits) > maxCredits)
            {
                // error 
                yield return (new ValidationResult("Credits must be between 1 and 4", new[] { "CourseCredits" }));
            }


           

        }
    }
}