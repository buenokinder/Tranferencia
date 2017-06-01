using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class UserPasswordReset
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Code { get; set; }
        public bool WasUsed { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
