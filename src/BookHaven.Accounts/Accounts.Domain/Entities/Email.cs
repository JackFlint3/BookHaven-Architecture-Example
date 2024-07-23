using System;

namespace BookHaven.Core.Domain.Entities
{
    public record Email
    {
        public string Value { get; private set; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email FromString(string str)
        {
            return new Email(str);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
