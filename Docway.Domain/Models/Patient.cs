﻿using Docway.Domain.Core.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Docway.Domain.Models
{
    public class Patient : EntityGuid
    {
        protected Patient() { }

        public Patient(Guid id, string cpf, UserBase user)
        {
            Id = id;
            this.Cpf = cpf;
            this.User = user;
        }

        public void Update(string cpf, string healthProblems,  decimal height, decimal weight, DateTime? dateOfBirth, string allergiesAndReactions,
            string medicines, string bloodType)
        {
            this.Cpf = cpf;
            this.HealthProblems = healthProblems;
            this.Height = height;
            this.Weight = weight;
            this.DateOfBirth = dateOfBirth;
            this.AllergiesAndReactions = allergiesAndReactions;
            this.Medicines = medicines;
            this.BloodType = bloodType;

        }

        public string Cpf { get; set; }


        public Guid UserBaseId { get; set; }

        public UserBase User { get; set; }



        #region Dados Fisiologicos
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public DateTime? DateOfBirth { get; set; }
        #endregion

        #region Dados de Histórico Médico
        public string HealthProblems { get; set; }
        public string AllergiesAndReactions { get; set; }
        public string Medicines { get; set; }
        [Index]
        public string BloodType { get; set; }
        public List<ProductScheduler> ProductSchedulers { get; set; }
        #endregion


        #region Dados de Pagamento
        public List<CreditCard> CreditCards { get; set; }
        public List<Address> Addresses { get; set; }

        public ClientGatewayPayment GatewayPayment { get; set; }
        #endregion

        #region Multi-Usuario
        public Patient Parent { get; set; }
        public List<Patient> Dependents { get; set; }
        #endregion

    }
}
