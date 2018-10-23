using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Items
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AmmountInKgs { get; set; }
        public string Supplier { get; set; }
        public DateTime UseBy { get; set; }
        public int LowerThreshhold { get; set; }

    }
}