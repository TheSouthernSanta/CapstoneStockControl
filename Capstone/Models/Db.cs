using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class DB : DbContext
    {
        public DbSet<Items> Item { get; set; }
    }
}