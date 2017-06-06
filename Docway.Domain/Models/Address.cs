using Docway.Domain.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Docway.Domain.Models
{
	public class Address : Entity
	{
        protected Address() { }

        public Address( string street, string number, string cep, string state, string city, bool isPrimary)
        {
            this.Street = street;
            this.Number = number;
            this.Cep = cep;
            this.State = state;
            this.City = city;
            this.IsPrimary = isPrimary;
        }

        public Address SetComplement(string complement) {
            this.Complement = complement;
            return this;
        }
        public Address SetNeighborhood(string neighborhood)
        {
            this.Neighborhood = neighborhood;
            return this;
        }
        public Address SetLatitude(double latitude)
        {
            this.Latitude = latitude;
            return this;
        }
        public Address SetLongitude(double longitude)
        {
            this.Longitude = longitude;
            return this;
        }

        public string Street { get;  set; }
		public string Number { get;  set; }
		public string Complement { get;  set; }
		public string Neighborhood { get;  set; }
        [Index]
        public string Cep { get;  set; }
        [Index]
        public string City { get;  set; }
        [Index]
        public string State { get;  set; }
		public string Landmark { get;  set; }
		public double Latitude { get;  set; }
		public double Longitude { get;  set; }

        public DbGeography Location { get; set; }

        [Index]
        public bool IsPrimary { get;  set; }

		[NotMapped]
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
