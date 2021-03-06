﻿using Docway.Domain.Interfaces.Repository;
using Docway.Domain.Models;
using Docway.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Infra.Data.Repository
{

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private DocwayContext _context;
        public PatientRepository(DocwayContext context)
            : base(context)
        {
            _context = context;
        }

        public Patient GetByEmail(string email)
        {
            return Find(c => c.User.Email == email).FirstOrDefault();
        }

        public IEnumerable<Patient> GetByFilter(string cpf, string insuranceName, string insuranceNumber)
        {
            return _context.Patients.Where(x => x.Cpf.Equals(cpf)).Include(x => x.Parent).Include(x => x.User).Include(x => x.Dependents).ToList();
        }

        public Patient GetByIdWithAggregate(Guid id)
        {
           return   _context.Patients.Where(x => x.Id.Equals(id)).Include(x=>x.Parent).Include(x => x.User).Include(x=>x.Dependents).SingleOrDefault();
            
        }
    }
}
