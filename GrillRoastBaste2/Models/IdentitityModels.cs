using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GrillRoastBaste2.Models
{
 
    public partial class CustomerDbContext : DbContext
    {
        public DbSet<CustomerSubmition> Customers { get; set; }

    }


}