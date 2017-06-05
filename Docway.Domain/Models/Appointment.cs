using Docway.Domain.Core.Models;
using Docway.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Appointment : Entity
    {
        protected Appointment() { }

        public Appointment(DateTime dateAppointment ,decimal price, AppointmentType type, Speciality speciality, Address address, List<Symptom> symptoms, List<Product> products, List<Transaction> transactions)
        {
            this.Symptoms = symptoms;
            this.Products = products;
            this.Transactions = transactions;
            this.DateAppointment = dateAppointment;
            this.Price = price;
            this.Type = type;
            this.Specialty = speciality;
            this.Address = address;
            this.CreateDate = DateTime.Now;
            this.IsUrgency = false;
        }

        public Appointment SetPromotionalCode(string promotionalCode)
        {
            this.PromotionalCode = promotionalCode;
            return this;
        }


        public Appointment SetIsUrgency(bool isUrgency)
        {
            this.IsUrgency = isUrgency;
            return this;
        }

        public Appointment SetHasHealthInsurance(bool hasHealthInsurance)
        {
            this.HasHealthInsurance = hasHealthInsurance;
            return this;
        }

        public Appointment SetPaymentMethod(PaymentMethod paymentMethod)
        {
            this.PaymentMethod = paymentMethod;
            return this;
        }


        public Appointment SetPaymentStatus(PaymentStatus paymentStatus)
        {
            this.PaymentStatus = paymentStatus;
            return this;
        }


        public Appointment SetCreditCard(CreditCard creditCard)
        {
            this.CreditCard = creditCard;
            return this;
        }


        public Appointment SetAppointmentStatus(AppointmentStatus appointmentStatus)
        {
            this.Status = appointmentStatus;
            return this;
        }

        public string PromotionalCode { get; set; }
        public decimal Price { get; set; }

        public bool HasHealthInsurance { get; set; }
        [Index]
        public bool IsUrgency { get; set; }

        public DateTime DateAppointment { get; private set; }
        public DateTime CreateDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public CreditCard CreditCard { get; set; }

        public AppointmentType Type { get; set; }
        [Index]
        public AppointmentStatus Status { get; set; }

        public Address Address { get; set; }
        [Index]
        public UserBase Seller { get; set; }
        [Index]
        public UserBase Buyer { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public Speciality Specialty { get; set; }

        public List<Symptom> Symptoms { get; set; }
        public List<Product> Products { get; set; }
        
        public List<Transaction> Transactions { get; set; }

        
    }
}
