using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace enrollmentApplication.Models
{
    public class Student:IValidatableObject
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

        [MinimumAge(20, ErrorMessage ="Age does not meet minimum requirements!")]
        public int Age { get; set; }

        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }
        public virtual string City { get; set; }
        public virtual string Zipcode { get; set; }
        public virtual string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            

            //Validation 1 - Checking if Address 1 is the same as Address 2
            if (Address1.Equals(Address2))
            {
                yield return (new ValidationResult("Address2 cannot be the same as Address1", new[] { "Address2" }));
            }

            //Validation 2 - Checking if state is Two digits long
            if(State.Length != 2)
            {
                yield return (new ValidationResult("Enter a 2 digit state code", new[] { "State" }));
            }

            //Validation 3 - Zip code checking
            if(Zipcode.Length != 5)
            {
                yield return (new ValidationResult("Enter a 5 digit Zipcode", new[] { "Zipcode" }));
            }
        }
    }
}