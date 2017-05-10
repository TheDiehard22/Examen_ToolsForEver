using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Models
{
    public class Locatie
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string LocatieNaam { get; set; }

        public List<ProductLocatie> ProductLocaties { get; set; }
    }
}
