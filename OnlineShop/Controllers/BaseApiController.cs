using Microsoft.AspNetCore.Mvc;
using OnlineShop.ObjectResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        public ServerErrorObjectResult ServerError(object value)
        {
            return new ServerErrorObjectResult(value);
        }
    }
}
