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

        
        public  Appointment(DateTime dateAppointment ,decimal price, Patient buyer, ServiceProvider seller  , AppointmentType type,  Address address)
        {
            this.Buyer =  buyer;
            this.Seller = seller;
            this.DateAppointment = dateAppointment;
            this.Price = price;
            this.Type = type;
            this.Address = address;
            this.CreateDate = DateTime.Now;
            this.IsUrgency = false;
        }

        public  Appointment BuildMedicalAppointment(Speciality speciality, List<Symptom> symptoms, PaymentMethod paymentMethod) {
            return this.SetSpecialty(speciality).SetSymptoms(symptoms).SetPaymentMethod(paymentMethod);
        }


        public Appointment SetSpecialty(Speciality speciality)
        {
            this.Specialty = speciality;
            return this;
        }

        public Appointment SetSymptoms(List<Symptom> symptoms)
        {
            this.Symptoms = symptoms;
            return this;
        }


        public Appointment SetProducts(List<Product> products)
        {
            this.Products = products;
            return this;
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
        public ServiceProvider Seller { get; set; }

        
        [Index]
        public Patient Buyer { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public Speciality Specialty { get; set; }

        public List<Symptom> Symptoms { get; set; }
        public List<Product> Products { get; set; }
        
        public List<Transaction> Transactions { get; set; }

        
    }
}
