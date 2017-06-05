using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum Gender
    {
        [Display(Name = "Masculino")]
        Male = 0,
        [Display(Name = "Feminino")]
        Female = 1
    }
}
