using System;

namespace ProjectTemplate.DOMAIN.Dtos.Exceptions
{
    public class SomeDomainException : Exception
    {
        public SomeDomainException()
        { }

        public SomeDomainException(string message)
            : base(message)
        { }

        public SomeDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
