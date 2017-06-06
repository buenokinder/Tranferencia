using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Rua")]
        public string Street { get; set; }
        [Display(Name = "Número")]
        public string Number { get; set; }
        [Display(Name = "Complemento")]
        public string Complement { get; set; }
        [Display(Name = "Bairro")]
        public string Neighborhood { get; set; }
        [Display(Name = "Cep")]
        public string Cep { get; set; }
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Display(Name = "Estado")]
        public string State { get; set; }
        [Display(Name = "Ponto de referência")]
        public string Landmark { get; set; }
        [Display(Name = "Latitude")]
        public double? Latitude { get; set; }
        [Display(Name = "Longitude")]
        public double? Longitude { get; set; }
        [Display(Name = "Principal")]
        public bool IsPrimary { get; set; }

        [NotMapped]
        [Display(Name = "Endereço")]
        public string FullAddress
        {
            get
            {
                return string.Format("{0}, {1} {2} - {3} | {4} - {5}", Street, Number, Complement, Neighborhood, City, State);
            }
            private set { }
        }
    }
}
