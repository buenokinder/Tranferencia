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
            return new DocwayContext("Server=(localdb)\\mssqllocaldb;Database=DocWay_v1;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
