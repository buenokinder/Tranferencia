using Docway.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Events.Patient
{
    public class PatientUpdatedEvent : Event
    {
        public PatientUpdatedEvent(Guid id, string name, string email, string cpf, string telefone)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Cpf { get; private set; }

        public string Telefone { get; private set; }

    }
}
