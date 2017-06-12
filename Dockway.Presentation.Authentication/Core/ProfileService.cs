using Docway.Application.Authentication.Interfaces;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dockway.Presentation.Authentication.Core
{
    public class ProfileService : IProfileService
    {
        private IUserAppService _repository;

        public ProfileService(IUserAppService rep)
        {
            this._repository = rep;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                var user = _repository.GetUserById(subjectId);

                var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(JwtClaimTypes.Role, user.Roles.ToString()),


            };
                var properties = new Dictionary<string, string>
            {
                { "userId", user.Id }, { "type", "patient" }
            };

                //var ticket = new AuthenticationTicket(claims, new AuthenticationProperties(properties));
                //context.Validated(ticket);

                context.IssuedClaims = claims;
                return Task.FromResult(0);
            }
            catch (Exception x)
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _repository.GetUserById(context.Subject.GetSubjectId());
            context.IsActive = (user != null);
            return Task.FromResult(0);
        }
    }
}
