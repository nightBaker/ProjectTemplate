using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.APPLICATION.Dtos.Exceptions
{
    public class SomeException : Exception
    {
        public SomeException() { }

        public SomeException(string message) : base(message) { }
    }
}
