using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class PushMessage
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int Type { get; set; }
        public string DeviceToken { get; set; }
        public string[] DeviceTokens { get; set; }
        public string PhoneNumber { get; set; }
        public string[] PhoneNumbers { get; set; }
        public dynamic Data { get; set; }
        //public UserType UserType { get; set; }
        public bool NovaConsulta { get; set; }
    }
}
