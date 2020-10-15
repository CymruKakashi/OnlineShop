using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace OnlineShop.ObjectResults
{
    public class ServerErrorObjectResult : ObjectResult
    {
        public ServerErrorObjectResult(object value) : base(value)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }

        public ServerErrorObjectResult() : this(null)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
