using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{
    public class SpecialtyViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Especialidade")]
        public string Name { get; set; }
    }
}
