using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Transaction : Entity
    {
        protected Transaction() { }

        private Transaction( decimal totalAmount,decimal feeAmount, decimal sellerAmount, decimal startupAmount) {
            this.CreateDate = DateTime.UtcNow;
            this.TotalAmount = totalAmount;
            this.FeeAmount = feeAmount;
            this.SellerAmount =sellerAmount;
            this.StartupAmount = totalAmount;
        }

        public string ReferenceId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SellerAmount { get; set; }
        public decimal StartupAmount { get; set; }
        public decimal FeeAmount { get; set; }
        public string RawResponseData { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsFinalized { get; set; }
        public Appointment Appointment { get; set; }
        
        public static Transaction Create(decimal totalAmount)
        {
            return  new Transaction(totalAmount, ((totalAmount * 0.0299M) + 0.3M),  ((totalAmount - ((totalAmount * 0.0299M) + 0.3M)) - (totalAmount * 0.15M)), (totalAmount * 0.15M) );
        }

        public static Transaction CreateSUS(decimal totalAmount)
        {
            return new Transaction(totalAmount, 0M, 0M, totalAmount);
        }

        public static Transaction CreateAntecipate(decimal totalAmount, decimal feeAmount, decimal sellerAmount, decimal startupAmount)
        {
            return  new Transaction(totalAmount, feeAmount, sellerAmount, startupAmount);
        }
    }
}
