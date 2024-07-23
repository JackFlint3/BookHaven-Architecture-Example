using BookHaven.Core.Domain.Entities;
using System;

namespace BookHaven.Accounts.Domain.Entities
{
    public class Address : Entity<Guid>
    {
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseAddress { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(City, StreetName, HouseAddress);
        }

        public override string ToString()
        {
            return $"{{{nameof(City)}: {City}, {nameof(StreetName)}: {StreetName}, {nameof(HouseAddress)}: {HouseAddress}}}";
        }
    }
}
