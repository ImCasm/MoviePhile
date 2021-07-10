using System;

namespace Application.Common.Exceptions
{
    public class AuthCredentialsException : Exception
    {
        public AuthCredentialsException(string message) : base(message)
        {
        }
    }
}
