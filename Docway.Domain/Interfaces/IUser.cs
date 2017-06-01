using System.Collections.Generic;
using System.Security.Claims;

namespace Docway.Domain.Interfaces
{
	public interface IUser
	{
		string Name { get; }
		bool IsAuthenticated();
		IEnumerable<Claim> GetClaimsIdentity();
	}
}