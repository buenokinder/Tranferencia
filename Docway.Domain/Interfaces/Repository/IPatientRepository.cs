﻿using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Interfaces.Repository
{
    public interface IPatientRepository : IUserRepository<Patient>
    {
        Patient GetByEmail(string email);
        Patient GetByIdWithAggregate(Guid id);
    }
}
