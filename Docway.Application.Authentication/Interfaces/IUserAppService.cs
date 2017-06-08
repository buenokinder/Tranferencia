using Docway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Application.Authentication.Interfaces
{
    

    public interface IUserAppService : IDisposable
    {
        UserBase FindByEmailAsync(string userName);
        bool ValidatePassword(string email, string password);
        UserBase GetUserById(string id);
        

    }
}
