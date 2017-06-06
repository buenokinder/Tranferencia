using Docway.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Infra.Data
{
   
    public class DocwayContextFactory : IDbContextFactory<DocwayContext>
    {
        public DocwayContext Create()
        {
            return new DocwayContext(@"Integrated Security=SSPI;Persist Security Info=False;User ID=SA;Initial Catalog=Docway;Data Source=localhost\SQLEXPRESS");
        }
    }
}
