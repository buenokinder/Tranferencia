using Docway.Domain.Models;
using Docway.Infra.Data.Extensions;

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Docway.Infra.Data.Mappings
{
    public class PatientMap : EntityTypeConfiguration<Patient>
    {

        public PatientMap()
        {
            //ToTable("Patients");
        

        }
    }
}
