using Ambev.Poc.Dev.Domain.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmBev.Poc.Dev.API.Controllers
{
    public class ApiControlleBase : ControllerBase
    {
        internal ObjectResult GetResponse<T>(T data)
        {
            var type = typeof(T);

            if (type.Name == typeof(ResponseBaseModel<T>).Name)
                return Ok(data);

            if (data == null)
                return NotFound(new ResponseBaseModel<T>().NotFound());

            return Ok(new ResponseBaseModel<T>().Ok(data));
        }
    }
}
