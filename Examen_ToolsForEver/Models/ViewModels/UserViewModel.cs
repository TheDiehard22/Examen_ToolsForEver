using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_ToolsForEver.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
