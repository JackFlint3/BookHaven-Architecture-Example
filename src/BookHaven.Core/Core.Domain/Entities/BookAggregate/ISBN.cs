using System;

namespace BookHaven.Core.Domain.Entities.BookAggregate
{
    public abstract record ISBN
    {
        string Value { get; set; }

        public static TISBN FromString<TISBN>(string str)
            where TISBN : ISBN, new()
        {
            return new TISBN() with { Value = str };
        }

        public override string ToString()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }

    public record EPUB : ISBN { protected EPUB(ISBN original) : base(original) { } }

    public record PDF : ISBN { protected PDF(ISBN original) : base(original) { } }

    public record Print : ISBN { protected Print(ISBN original) : base(original) { } }

}
