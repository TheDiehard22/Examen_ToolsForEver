using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string Naam { get; set; }

        public string Type { get; set; }

        public string Fabriek { get; set; }

        public string Locatie { get; set; }

        public decimal InkoopWaarde { get; set; }

        public decimal VerkoopWaarde { get; set; }

        public int Voorraad { get; set; }
    }
}
