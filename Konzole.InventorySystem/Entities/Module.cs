using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzole.InventorySystem.Entities
{
    [Table("Module", Schema = "IV")]
    public class Module
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public bool IsActive { get; set; }
    }
}
