using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Conventions
{
    public class StringProperties
     : Convention
    {
        public StringProperties()
        {
            Properties<String>().Configure(s => s.HasMaxLength(150));
        }
    }
}
