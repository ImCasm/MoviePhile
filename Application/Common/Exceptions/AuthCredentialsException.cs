using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class AuthCredentialsException : Exception
    {
        public AuthCredentialsException(string message) : base(message)
        {
        }
    }
}
