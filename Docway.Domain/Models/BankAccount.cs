using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankId { get; set; }
        public string BranchNumber { get; set; }
        public string BranchNumberDigit { get; set; }
        public string AccountNumber { get; set; }
        public string AccountNumberDigit { get; set; }
    }
}
