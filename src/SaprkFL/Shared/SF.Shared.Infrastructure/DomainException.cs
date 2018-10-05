using System;

namespace SF.Shared.Infrastructure
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}