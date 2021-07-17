using System;
using System.Collections.Generic;
using System.Net;

namespace Domain.Common.Exceptions
{
    public class HandlerException : Exception
    {
        public HttpStatusCode Code { get; }
        public IList<string> Errors { get; }

        /// <summary>
        /// Manejos de excepciones personalizadas, lo utilizará el Middleware Exception
        /// para manejar los mensajes y códigos de error http
        /// </summary>
        /// <param name="httpCode">Cósigo http del error</param>
        /// <param name="errors">Mensajes de errores</param>
        public HandlerException(HttpStatusCode httpCode, IList<string> errors)
        {
            Code = httpCode;
            Errors = errors;
        }
    }
}
