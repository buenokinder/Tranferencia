using Docway.Domain.Core.Models;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class SocialLogin : Entity
    {
        public SocialNetworks SocialId { get; set; }
        public string Token { get; set; }
        public string PriflePhotoUrl { get; set; }
        public string SocialUserId { get; set; }
    }
}
