using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum ProductType
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Exame")]
        Exam = 1,
        [Display(Name = "Vacina")]
        Vaccine = 2,
       
    }
}
