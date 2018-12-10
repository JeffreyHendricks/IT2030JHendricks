using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalEventApplication.Models
{
    public class EventType
    {
        public virtual int EventTypeId { get; set; }
        public virtual string EventTypeTitle { get; set; }
        public virtual string EventTypeDescription { get; set; }
        public virtual Event Event { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}