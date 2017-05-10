using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Models
{
    public class Fabrikant
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FabrikantNaam { get; set; }
    }
}
