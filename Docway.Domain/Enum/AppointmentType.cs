using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum AppointmentType
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Consulta")]
        Consult = 1,
        [Display(Name = "Exame")]
        Exam = 2,
        [Display(Name = "Vacina")]
        Vaccine = 3,
        [Display(Name = "Emergência")]
        Emergency = 4
    }
}
