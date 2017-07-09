using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Entities
{
    [Table("WarehouseLoc", Schema = "IV")]
    public class WarehouseLoc
    {
        [Key]
        public int WarehouseLocId { get; set; }
        public string LocationAddress { get; set; }
        public string RecUser { get; set; }
        public DateTime Recdate { get; set; }
        public string ModUser { get; set; }
        public DateTime? Moddate { get; set; }
    }
}
