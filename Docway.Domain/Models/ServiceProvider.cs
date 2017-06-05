using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public  class ServiceProvider
    {

        public Guid UserBaseId { get; set; }

        public UserBase User { get; set; }
    }
}
