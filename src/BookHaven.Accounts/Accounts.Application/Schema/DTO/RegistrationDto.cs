namespace BookHaven.Accounts.Application.Schema.DTO
{
    public record RegistrationDto
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public AddressDto Address { get; set; }
        public string Phonenumber { get; set; }
    }
}
