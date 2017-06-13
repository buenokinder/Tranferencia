using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Enum
{
    public enum PaymentMethod
    {
        [Display(Name = "Nenhum")]
        None = 0,
        [Display(Name = "Cartão de Crédito")]
        CreditCard = 1,
        [Display(Name = "Dinheiro")]
        Money = 2,
        [Display(Name = "SUS")]
        SUS = 3,
        [Display(Name = "Seguradora")]
        Insurance = 4
    }
}
