using Dockway.Application.ViewModels;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Application.Appointment.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Comprador")]
        public string BuyerId { get; set; }

        [Display(Name = "Vendedor")]
        public string SellerId { get; set; }

        [Display(Name = "Cartão de Crédito")]
        public int? CreditCardId { get; set; }

        [Display(Name = "Código Promocional")]
        public string PromotionalCode { get; set; }
        [Display(Name = "Preço")]
        public decimal Price { get; set; }
        [Display(Name = "Tem Plano de Saúde")]
        public bool HasHealthInsurance { get; set; }
        [Display(Name = "É Urgência")]
        public bool IsUrgency { get; set; }

        [Display(Name = "Data do Atendimento")]
        public DateTime DateAppointment { get; set; }
        [Display(Name = "Data do Atendimento")]
        public string DataAtendimento
        {
            get
            {
                if (DateAppointment != null)
                {
                    var appointmentDateUtc = DateTime.SpecifyKind(
                                    DateAppointment,
                                    DateTimeKind.Utc);

                    var timeZoneString = "E. South America Standard Time";

                    var timeZone = System.TimeZoneInfo.FindSystemTimeZoneById(timeZoneString);

                    var appointmentDateLocal = System.TimeZoneInfo.ConvertTimeFromUtc(appointmentDateUtc, timeZone);

                    return appointmentDateLocal.ToString("yyyy/MM/dd");
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        [Display(Name = "Data do Atendimento")]
        public DateTime DataHoraAtendimento
        {
            get
            {
                var appointmentDateUtc = DateTime.SpecifyKind(
                                    DateAppointment,
                                    DateTimeKind.Utc);

                var timeZoneString = "E. South America Standard Time";

                var timeZone = System.TimeZoneInfo.FindSystemTimeZoneById(timeZoneString);

                var appointmentDateLocal = System.TimeZoneInfo.ConvertTimeFromUtc(appointmentDateUtc, timeZone);

                return appointmentDateLocal;
            }
        }

        [Display(Name = "Data do Pedido")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Data do Pedido")]
        public DateTime DataPedido
        {
            get
            {
                var appointmentDateUtc = DateTime.SpecifyKind(
                                    CreateDate,
                                    DateTimeKind.Utc);

                var timeZoneString = "E. South America Standard Time";

                var timeZone = System.TimeZoneInfo.FindSystemTimeZoneById(timeZoneString);

                var appointmentDateLocal = System.TimeZoneInfo.ConvertTimeFromUtc(appointmentDateUtc, timeZone);

                return appointmentDateLocal;
            }
        }

        [Display(Name = "Método de Pagamento")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Status Pagamento")]
        public PaymentStatus PaymentStatus { get; set; }
        [Display(Name = "Tipo")]
        public AppointmentType Type { get; set; }
        [Display(Name = "Status")]
        public AppointmentStatus Status { get; set; }

        [Display(Name = "Endereço")]
        public AddressViewModel Address { get; set; }
        [Display(Name = "Vendedor")]
        public UserBaseViewModel Seller { get; set; }
        [Display(Name = "Comprador")]
        public UserBaseViewModel Buyer { get; set; }

        //[Display(Name = "Porntuário")]
        //public MedicalRecordViewModel Medicalrecord { get; set; }

        [Display(Name = "Especialidade")]
        public SpecialtyViewModel Specialty { get; set; }

        //public List<Transaction> Transactions { get; set; }
        //public List<SymptomViewModel> Symptoms { get; set; }
        //public List<ExamViewModel> Exams { get; set; }
        //public List<VaccineViewModel> Vaccines { get; set; }
    }
}
