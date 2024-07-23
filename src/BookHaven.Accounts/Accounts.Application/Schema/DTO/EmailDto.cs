namespace BookHaven.Accounts.Application.Schema.DTO
{
    public record EmailDto
    {
        public required string Email { get; set; }
        public required string Content { get; set; }
    }
}
