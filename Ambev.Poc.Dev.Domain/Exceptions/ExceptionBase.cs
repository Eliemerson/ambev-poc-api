using System.Net;

namespace Ambev.Poc.Dev.Domain.Exceptions
{
    public class ExceptionBase : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ExceptionBase(string message) : base(message) { }

        public ExceptionBase(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ExceptionBase()
        {

        }
    }
}
