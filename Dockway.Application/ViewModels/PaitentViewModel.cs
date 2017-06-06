using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{
    public class PatientViewModel : UserBaseViewModel
    {
        public PatientViewModel AddParent(Guid id) {
            this.ParentId = id;
            return this;
        }
        public Guid? ParentId { get; set; }

        //[Display(Name = "E-mail")]
        //public string EmailCorreto
        //{
        //    get
        //    {
        //        if (this.Parent != null)
        //        {
        //            return this.Parent.Email;
        //        }
        //        else
        //        {
        //            return this.Email;
        //        }
        //    }
        //}

        [Display(Name = "Data de Nascimento")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        // dados fisiológicos
        [Display(Name = "Peso")]
        public decimal Weight { get; set; }
        [Display(Name = "Altura")]
        public decimal Height { get; set; }

        // dados de histórico médico
        [Display(Name = "Problemas de Saúde")]
        public string HealthProblems { get; set; }
        [Display(Name = "Alergias")]
        public string AllergiesAndReactions { get; set; }
        [Display(Name = "Medicamentos")]
        public string Medicines { get; set; }
        [Display(Name = "Tipo Sanguíneo")]
        public string BloodType { get; set; }

        // dados de convênio
        [Display(Name = "Plano de Saúde")]
        public string HealthInsurance { get; set; }
        [Display(Name = "Número do Plano")]
        public string HealthInsuranceNumber { get; set; }

        //public List<VaccineScheduleViewModel> Vaccines { get; set; }
        //public List<CreditCardViewModel> CreditCards { get; set; }

        //public List<AddressViewModel> Addresses { get; set; }
        public string IuguClientId { get; set; }

        [Display(Name = "Habilitado pelo SUS")]
        public bool IsSUSEnabled { get; set; }

        // multi-usuário
        //public PatientViewModel Parent { get; set; }
        public List<PatientViewModel> Dependents { get; set; }
    }
}
