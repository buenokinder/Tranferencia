using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class BankAccount : Entity
    {

        protected BankAccount() { }

        public BankAccount(String bankName, String bankId, String branchNumber, String branchNumberDigit, String accountNumber, String accountNumberDigit)
        {
            this.BankName = bankName;
            this.BankId = bankId;
            this.BranchNumber = branchNumber;
            this.BranchNumberDigit = branchNumberDigit;
            this.AccountNumber = accountNumber;
            this.AccountNumberDigit = accountNumberDigit;
        }

        public string BankName { get; set; }
        public string BankId { get; set; }
        public string BranchNumber { get; set; }
        public string BranchNumberDigit { get; set; }
        public string AccountNumber { get; set; }
        public string AccountNumberDigit { get; set; }
    }
}
