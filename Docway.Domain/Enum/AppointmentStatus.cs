using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum AppointmentStatus
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Criado")]
        Created = 1,
        [Display(Name = "Aguardando Aceite")]
        WaitingAccept = 2,
        [Display(Name = "Aguardando Aprovação")]
        WaitingApproval = 3,
        [Display(Name = "Aceito")]
        Accepted = 4,
        [Display(Name = "Aprovado")]
        Approved = 5,
        [Display(Name = "Em Andamento")]
        InProgress = 6,
        [Display(Name = "Finalizado")]
        Finalized = 7,
        [Display(Name = "Cancelado")]
        Canceled = 8
    }
}
