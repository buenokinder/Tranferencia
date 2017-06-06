using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{
    public class EvaluationViewModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public DoctorViewModel Doctor { get; set; }
        public PatientViewModel Owner { get; set; }
    }
}
