using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum PaymentStatus
    {
        [Display(Name = "Não Selecionado")]
        None = 0,

        [Display(Name = "Aguardando Pré-Aprovação")]
        WaitingPreApproval = 1,
        [Display(Name = "Aguardando Pagamento")]
        WaitingPayment = 2,
        [Display(Name = "Aguardando Estorno")]
        WaitingRefund = 3,

        [Display(Name = "Pré-Aprovado")]
        PreApproved = 4,
        [Display(Name = "Pago")]
        Pay = 5,
        [Display(Name = "Estornado")]
        Refunded = 6,

        [Display(Name = "Erro na Pré-Aprovação")]
        PreApprovalError = 7,
        [Display(Name = "Erro no Pagamento")]
        PaymentError = 8,
        [Display(Name = "Erro no Estorno")]
        RefundError = 9
    }
}
