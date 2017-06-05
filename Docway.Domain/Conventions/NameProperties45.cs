using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Conventions
{
    public class NameProperties45 : Convention
    {
        public NameProperties45() {
            Properties<String>().Where(x => x.Name == "Name").Configure(s=>s.HasMaxLength(45));
        }
    }
}
