using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dockway.Application.ViewModels
{

    public class DoctorViewModel : UserBaseViewModel
    {
        // informações profissionais
        [Display(Name = "CRM")]
        public string Crm { get; set; }
        [Display(Name = "UF CRM")]
        public string CrmUF { get; set; }

        // informações pessoais
        [Display(Name = "Bio")]
        public string Bio { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Display(Name = "Gênero")]
        public Gender Gender { get; set; }

        // informações de consultas
        [Display(Name = "Valor da Consulta")]
        public decimal AppointmentPrice { get; set; }
        [Display(Name = "Raio da Consulta")]
        public int AppointmentRadius { get; set; }

        //percentual docway no valor da consulta
        //[Display(Name = "Percentual Docway")]
        //public string CommissionPercent { get; set; }

        [Display(Name = "Docway")]
        public bool IsActive { get; set; }
        [Display(Name = "Payleven")]
        public bool IsPaylevenActive { get; set; }
        [Display(Name = "Iugu")]
        public bool IsIuguActive { get; set; }

        [Display(Name = "Habilitado pelo SUS")]
        public bool IsSUSEnabled { get; set; }

        [Display(Name = "Aceita Urgências")]
        public bool UrgencyEnable { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Data de Cadastro")]
        public string DataCriacao
        {
            get
            {
                if (CreateDate != null)
                {
                    DateTime data = Convert.ToDateTime(CreateDate);
                    return data.ToString("yyyy/MM/dd");
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        [Display(Name = "Endereço")]
        public AddressViewModel Address { get; set; }
        [Display(Name = "Dados Bancários")]
        public BankAccountViewModel BankAccount { get; set; }
        [Display(Name = "Documento de Identificação")]
        public DocumentViewModel Identification { get; set; }

        [Display(Name = "Especialidades")]
        public List<SpecialtyViewModel> Specialties { get; set; }
        public List<EvaluationViewModel> Evaluations { get; set; }
        public List<DocumentViewModel> Degrees { get; set; }

        public IuguCredentialViewModel IuguCredentials { get; set; }
    }
}