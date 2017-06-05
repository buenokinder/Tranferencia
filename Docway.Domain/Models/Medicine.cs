using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Medicine : Entity
    {
        
        public string Name { get; set; }

        public List<MedicalRecord> MedicalRecords { get; set; }
    }
}
