using Konzole.InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Konzole.InventorySystem.Web.Models
{
    public class ProductCategoryViewModel
    {
        [Key]
        public int Id { get; set; }
        public Category category { get; set; }       
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