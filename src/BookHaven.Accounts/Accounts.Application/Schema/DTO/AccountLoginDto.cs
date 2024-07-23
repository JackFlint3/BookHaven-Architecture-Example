namespace BookHaven.Accounts.Application.Schema.DTO
{
    public record AccountLoginDto
    {
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}
