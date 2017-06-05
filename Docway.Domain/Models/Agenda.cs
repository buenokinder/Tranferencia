using Docway.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Models
{
    public class Agenda : Entity
    {
        protected Agenda() { }

        public Agenda(Doctor owner)
        {
            this.Owner = owner;
            
        }

        public Agenda SetObservacao(string observacao)
        {
            this.Observacao = Observacao;
            return this;
        }

        public Agenda SetIsDIsponible(bool isDisponible)
        {
            this.IsDisponible = isDisponible;
            return this;
        }
        [Index]
        public Doctor Owner { get;  set; }
        [Index]
        public bool IsDisponible { get;  set; }
        public DateTime LastUpdate { get;  set; }
        public string Observacao { get;  set; }
    }
}
