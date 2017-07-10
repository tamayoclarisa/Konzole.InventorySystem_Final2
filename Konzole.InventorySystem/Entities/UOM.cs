using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Entities
{

    [Table("UOM", Schema = "IV")]
    public class UOM
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Abbreviation { get; set; }
    }


   
}
