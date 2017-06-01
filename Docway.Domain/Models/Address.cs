using Docway.Domain.Core.Models;
using System;


namespace Docway.Domain.Models
{
	public class Address : Entity
	{

		public string Street { get; set; }
		public string Number { get; set; }
		public string Complement { get; set; }
		public string Neighborhood { get; set; }
		public string Cep { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Landmark { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public bool IsPrimary { get; set; }

		//[NotMapped]
		public string FullAddress
		{
			get
			{
				return string.Format("{0}, {1} {2} - {3} | {4} - {5}", Street, Number, Complement, Neighborhood, City, State);
			}
			private set { }
		}
	}
}
