using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{
    public class UserBaseViewModel
    {
        //public string Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Nick Name")]
        public string UserName { get; set; }
        public string FacebookId { get; set; }
        public string FacebookToken { get; set; }
        [Display(Name = "Foto de Perfil")]
        public string ProfilePhotoUrl { get; set; }
        [Display(Name = "Senha")]
        public string Password { get; set; }
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Timezone")]
        public string TimeZone { get; set; }

        [Display(Name = "Payleven ID")]
        public string PaylevenId { get; set; }

        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        [Display(Name = "Foto do Facebook")]
        public string FacebookPhotoUrl
        {
            get
            {
                if (string.IsNullOrEmpty(FacebookId)) { return null; }
                else { return string.Format("https://graph.facebook.com/{0}/picture?width=500&height=500", FacebookId); }
            }
        }

    }
}
