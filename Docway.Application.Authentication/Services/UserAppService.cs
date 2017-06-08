using Docway.Application.Authentication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docway.Domain.Models;
using Docway.Domain.Interfaces;
using Docway.Domain.Interfaces.Repository;

namespace Docway.Application.Authentication.Services
{
    public class UserAppService : IUserAppService
    {

        
        private readonly IUserRepository _userRepository;
     

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public UserBase FindByEmailAsync(string userName)
        {
            return _userRepository.FindByEmailAsync(userName);
        }

        public UserBase GetUserById(string id)
        {
            return _userRepository.GetUserById(id);
        }

        public bool ValidatePassword(string email, string password)
        {
            return true;
        }
    }
}
