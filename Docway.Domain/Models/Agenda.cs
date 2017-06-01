using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string PromotionalCode { get; set; }
        public decimal Price { get; set; }

        public bool HasHealthInsurance { get; set; }
        public bool IsUrgency { get; set; }

        public DateTime DateAppointment { get; set; }
        public DateTime CreateDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public CreditCard CreditCard { get; set; }

        public AppointmentType Type { get; set; }
        public AppointmentStatus Status { get; set; }

        public Address Address { get; set; }
        public UserBase Seller { get; set; }
        public UserBase Buyer { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public Speciality Specialty { get; set; }

        public List<Symptom> Symptoms { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Vaccine> Vaccines { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Appointment()
        {
            Symptoms = new List<Symptom>();
            Exams = new List<Exam>();
            Vaccines = new List<Vaccine>();
            Transactions = new List<Transaction>();
        }
    }
}
