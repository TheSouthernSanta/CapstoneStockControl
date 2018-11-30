using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Items
    {
        public int ID { get; set; }
        public string Name { get; set; }  //filter by "Item"
        public int Quantity{ get; set; }  //filter by "Quantity Remaining"
        public string QuantityType { get; set; } //filter by "Quantity Type" eg: kg, mg, number
        public int BaseQuantity { get; set; }  //filter by "Base Quantity"
        public DateTime CreationDate { get; set; }
        public DateTime UseBy { get; set; } //filter by "Expiration Date"
        public bool IsDeleted { get; set; }
    }
}