using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{
    public class IuguCredentialViewModel
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string CustomerId { get; set; }
        public string ApiTokenLive { get; set; }
        public string ApiTokenDev { get; set; }
        public string UserToken { get; set; }
    }
}
