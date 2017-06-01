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
		
		public string Name { get; set; }
		
		public override string Email { get; set; }
		public string DeviceToken { get; set; }
		public string MerchantReference { get; set; }
		public string TimeZone { get; set; }
		public Address Address { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsSUSEnabled { get; set; }
		public DateTime? CreateDate { get; set; }
		
		//public List<Appointment> Appointments { get; set; }
		//public List<Promotion> Promotions { get; set; }

		public string MailChimpId { get; set; }

		
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserBase> manager)
		{
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			return userIdentity;
		}
	}
}
