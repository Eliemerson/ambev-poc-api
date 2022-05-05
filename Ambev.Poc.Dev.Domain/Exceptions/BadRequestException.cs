using System.Net;


namespace Ambev.Poc.Dev.Domain.Exceptions
{
    public class BadRequestException : ExceptionBase
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest) { }
        public BadRequestException(string message, object validations) : base(message, HttpStatusCode.BadRequest)
        {
            Validations = validations;
        }

        public object Validations { get; set; }
    }
}
