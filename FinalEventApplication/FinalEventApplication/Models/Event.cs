using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalEventApplication.Models
{
    public class Event
    {
        public virtual int EventId { get; set; }

        [Required(ErrorMessage = "Event must be given a {0}.")]
        [StringLength(50, ErrorMessage = "Title is too long.")]
        public virtual string Title { get; set; }

        [Required(ErrorMessage = "Description must be entered for event.")]
        [StringLength(150, ErrorMessage = "Your description is too long.")]
        [Display(Name = "Description")]
        public virtual string EventDescription { get; set; }

        [Display(Name ="Event List")]
        public virtual List<Event> Eventlist { get; set; }

        [Required(ErrorMessage ="Event type must be selected.")]
        [Display(Name = "Event Type")]
        [StringLength(50, ErrorMessage ="The type can not be longer than 50 characters.")]
        public virtual string EventTypeTitle { get; set; }

        [Required(ErrorMessage = "Event must have a start date.")]
        [Display(Name = "Start Date")]
        [StartNotInPast()]
        public virtual DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Event must have an end date.")]
        [Display(Name = "End Date")]
        [EndNotInPast()]
        public virtual DateTime EndDate { get; set; }

        [Required(ErrorMessage = "{0} must be filled out.")]
        public virtual string Location { get; set; }

        [Required(ErrorMessage = "Organizer name must be filled out.")]
        [Display(Name ="Organizer Name")]
        [InvalidChars("0123456789#$%^&*()!@#", ErrorMessage = "Name must contain only letters.")]
        public virtual string OrganizerName { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Please check that your {0} address is correct.")]
        public virtual string Email { get; set; }

        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual int Zipcode { get; set; }

        [Required(ErrorMessage = "This field cannot be empty.")]
        [Display(Name ="Max Tickets")]
        [Range(typeof(int),"1", "30", ErrorMessage = "There cannot be more than 30 tickets or less than 1 allowed per event.")]
        public virtual int MaxTickets { get; set; }

        [Required(ErrorMessage = "This field cannot be empty.")]
        [Display(Name = "Available Tickets")]
        [Range(typeof(int),"1","30", ErrorMessage = "There cannot be more than30 tickets or less than 1 available.")]
        public virtual int AvailableTickets { get; set; }

        [Display(Name ="Event Art Url")]
        public virtual string EventArtUrl { get; set; }

    }
}