using System;
using System.Collections.Generic;
using System.Net;

namespace Domain.Common.Exceptions
{
    public class ExceptionHandler : Exception
    {
        public HttpStatusCode Code { get; }
        public IList<string> Errors { get; }
        public ExceptionHandler(HttpStatusCode httpCode, IList<string> errors)
        {
            Code = httpCode;
            Errors = errors;
        }
    }
}
