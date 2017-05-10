using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Models
{
    public class ProductLocatie
    {
        [Required]
        public int Aantal { get; set; }

        public int MinVoorraad { get; set; }
        
        public int LocatieID { get; set; }
        public int ProductID { get; set; }
        public Locatie Locatie { get; set; }
        public Product Product { get; set; }

        public string VoorraadCheck()
        {
            if (Aantal < MinVoorraad)
            {
                return "danger";
            }
            return "";
        }

        public int LocatieWaarde { get; }
    }
}
