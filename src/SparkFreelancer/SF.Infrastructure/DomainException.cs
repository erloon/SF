using System;

namespace SF.Infrastructure
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}