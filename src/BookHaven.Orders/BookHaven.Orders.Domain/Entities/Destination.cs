using System;

namespace BookHaven.Orders.Domain.Entities
{
    public record Destination
    {
        public string City { get; init; }
        public string StreetName { get; init; }
        public string HouseAddress { get; init; }
        public string Recipient { get; init; }

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
