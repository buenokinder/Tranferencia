using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do Banco")]
        public string BankName { get; set; }

        [Display(Name = "Agência")]
        public string BranchNumber { get; set; }

        [Display(Name = "Conta Corrente")]
        public string AccountNumber { get; set; }

        [Display(Name = "Código do Banco")]
        public string BankId { get; set; }

        [Display(Name = "Dígito da Agência")]
        public string BranchNumberDigit { get; set; }

        [Display(Name = "Dígito da CC")]
        public string AccountNumberDigit { get; set; }
    }
}
