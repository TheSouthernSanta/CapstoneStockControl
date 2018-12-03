using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Base Quantity")]
        public int BaseQuantity { get; set; }  //filter by "Base Quantity"
        public DateTime CreationDate { get; set; }
        [Display(Name = "Use By")]
        public DateTime UseBy { get; set; } //filter by "Expiration Date"
        public bool IsDeleted { get; set; }
    }
}