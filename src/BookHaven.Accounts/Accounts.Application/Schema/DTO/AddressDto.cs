namespace BookHaven.Accounts.Application.Schema.DTO
{
    public record AddressDto
    {
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseAddress { get; set; }
    }
}
