using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class MobileInformation
    {
        public int Id { get; set; }

        public string OperatingSystem { get; set; }

        public string VersionOperatingSystem { get; set; }

        public string AppVersion { get; set; }

        public string BuildVersion { get; set; }

        public DateTime LastUseDate { get; set; }

        public UserBase Owner { get; set; }

    }
}
