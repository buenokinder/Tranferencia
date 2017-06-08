using Docway.Domain.Interfaces;
using Docway.Domain.Interfaces.Repository;
using Docway.Domain.Models;
using Docway.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Infra.Data.Repository
{
    public class UserRepository : Repository<UserBase>, IUserRepository
    {
        private DocwayContext _context;
        public UserRepository(DocwayContext context)
            : base(context)
        {
            _context = context;
        }

        public UserBase FindByEmailAsync(string email)
        {
            return this._context.Users.Where(x => x.Email.Equals(email)).SingleOrDefault();
        }

        public UserBase GetUserById(string Id)
        {
            return this._context.Users.Where(x => x.Id.Equals(Id)).SingleOrDefault();
        }
    }
}
