using E_Commerce.Api.Errors;
using E_Commerce.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{
    [Route("Error/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        public ActionResult Index(int statusCode)
        {
            return new ObjectResult(new ApiResponse(statusCode));
        }

    }
}
