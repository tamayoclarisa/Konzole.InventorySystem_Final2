using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Entities
{
   
        [Table("Category", Schema = "IV")]
        public class Category
        {
            [Key]
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string RecUser { get; set; }
            public DateTime Recdate { get; set; }
            public string ModUser { get; set; }
            public DateTime? Moddate { get; set; }

       
    }
}
