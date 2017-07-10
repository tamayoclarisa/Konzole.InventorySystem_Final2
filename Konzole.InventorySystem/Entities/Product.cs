﻿using Konzole.InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem
{
    [Table("Product", Schema = "IV")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public Category CategoryId { get; set; }
        public int UOM { get; set; }
        public string RecUser { get; set; }
        public DateTime RecDate { get; set; }
        public string ModUser { get; set; }
        public DateTime? ModDate { get; set; }
        public int IsActive { get; set; }

    }
}
