using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace enrollmentApplication.Models
{
    public class enrollmentdb : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public enrollmentdb() : base("name=enrollmentdb")
        {
        }

        public System.Data.Entity.DbSet<enrollmentApplication.Models.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<enrollmentApplication.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<enrollmentApplication.Models.Student> Students { get; set; }
    }
}
