using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
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
            var instance = new Transaction();

            instance.CreateDate = DateTime.UtcNow;

            var taxaIUGU = ((totalAmount * 0.0299M) + 0.3M);
            var recebiveisComDescontoTaxaIUGU = (totalAmount - taxaIUGU);
            var recebiveisDocway = totalAmount * 0.15M;
            var recebiveisSeller = recebiveisComDescontoTaxaIUGU - recebiveisDocway;

            instance.TotalAmount = totalAmount;
            instance.FeeAmount = taxaIUGU;
            instance.SellerAmount = recebiveisSeller;
            instance.StartupAmount = recebiveisDocway;

            return instance;
        }

        public static Transaction CreateSUS(decimal totalAmount)
        {
            var instance = new Transaction();

            instance.CreateDate = DateTime.UtcNow;
            instance.TotalAmount = totalAmount;
            instance.FeeAmount = 0M;
            instance.SellerAmount = 0M;
            instance.StartupAmount = totalAmount;

            return instance;
        }

        public static Transaction CreateAntecipate(decimal totalAmount, decimal feeAmount, decimal sellerAmount, decimal startupAmount)
        {
            var instance = new Transaction();

            instance.CreateDate = DateTime.UtcNow;

            instance.TotalAmount = totalAmount;
            instance.FeeAmount = feeAmount;
            instance.SellerAmount = sellerAmount;
            instance.StartupAmount = startupAmount;

            return instance;
        }
    }
}
