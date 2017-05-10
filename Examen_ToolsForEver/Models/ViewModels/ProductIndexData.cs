using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Models.ViewModels
{
    public class ProductIndexData
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductLocatie> ProductLocaties { get; set; }
        public IEnumerable<Locatie> Locaties { get; set; }
        public IEnumerable<Fabrikant> Fabrikanten { get; set; }
    }
}
