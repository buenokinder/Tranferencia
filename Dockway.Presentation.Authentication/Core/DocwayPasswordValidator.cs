using Docway.Application.Authentication.Interfaces;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dockway.Presentation.Authentication
{
    public class DocwayPasswordValidator : IResourceOwnerPasswordValidator
    {

        private IUserAppService _userAppService { get; set; }
        public DocwayPasswordValidator(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            
            PasswordHasher pass = new PasswordHasher();
            
            if (pass.VerifyHashedPassword(_userAppService.FindByEmailAsync(context.UserName).PasswordHash, context.Password) == PasswordVerificationResult.Success)
            {
                context.Result = new GrantValidationResult(_userAppService.FindByEmailAsync(context.UserName).Id, "password", null, "local", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return Task.FromResult(context.Result);
        }
    }
}
