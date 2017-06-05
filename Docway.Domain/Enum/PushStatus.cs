using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum PushStatus
    {
        [Display(Name = "Nenhum")]
        NotSend = 0,

        [Display(Name = "Criado")]
        Send = 1,
    }
}
