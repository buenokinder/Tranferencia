using Docway.Domain.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;



namespace Docway.Domain.Models
{


    public class UserBase : IdentityUser
    {
        protected UserBase() { }

        public UserBase(string name, string email, string userName, string phoneNumber, string password)
        {
            this.Name = name;
            this.UserName = userName;
            this.Email = email;
            this.PasswordHash = new PasswordHasher().HashPassword(password);
            this.PhoneNumber = phoneNumber;
        }

        public void Update(string name,  string phoneNumber) {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }

        public override string Email { get; set; }
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public string DeviceToken { get; set; }
        public string MerchantReference { get; set; }
        public string TimeZone { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSUSEnabled { get; set; }
        public DateTime? CreateDate { get; set; }

        public ICollection<Patient> Patients { get; set; }
        public ICollection<Doctor> Doctors { get; set; }

        public string MailChimpId { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserBase> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
