using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalEventApplication.Models
{
    public class Order
    {
        [Key]
        public virtual int RecordId { get; set; }

        public virtual string OrderId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual int Count { get; set; }
        public virtual int EventId { get; set; }
        public virtual Event EventSelected { get; set; }
        public virtual int TicketCount { get; set; }
    }
}