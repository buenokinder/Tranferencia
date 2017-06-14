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
            return new DocwayContext(@"Server=tcp:docwaymicroservices.database.windows.net,1433;Initial Catalog=docway_microservices;Persist Security Info=False;User ID=docwaymicroservices;Password=@G08uCaEdDocW@yDev;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
