using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
namespace Russian_Robotics.Models
{
    class PriceItems
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string Vendor {get;set;}

        [Column(TypeName = "varchar(64)")]
        public string Number { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string SearchVendor { get; set; }

        [Column(TypeName = "varchar(64)")]
        public string SearchNumber { get; set; }

        [Column(TypeName = "varchar(512)")]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
