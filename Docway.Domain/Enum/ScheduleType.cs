using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum ProductScheduleType
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Criança")]
        Child = 1,
        [Display(Name = "Homem")]
        Men = 2,
        [Display(Name = "Mulher")]
        Woman = 3,
        [Display(Name = "Idoso")]
        Elderly = 4
    }
}
