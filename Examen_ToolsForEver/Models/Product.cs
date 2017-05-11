using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int ProductLocatieID { get; set; }

        [Required]
        public int FabrikantID { get; set; }

        //[Required]
        //public int LocatieID { get; set; }

        [Required]
        public string Naam { get; set; }

        public string Type { get; set; }

        [Required]
        public decimal InkoopWaarde { get; set; }

        [Required]
        public decimal VerkoopWaarde { get; set; }

        public Fabrikant Fabrikant { get; set; }
        public List<ProductLocatie> ProductLocaties { get; set; }

    }
}
