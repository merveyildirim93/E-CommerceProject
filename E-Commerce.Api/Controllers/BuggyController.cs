using E_Commerce.Api.Errors;
using E_Commerce.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext context;
        public BuggyController(StoreContext context)
        {
            this.context = context;
        }

        [HttpGet("GetNotFoundRequest")]
        public ActionResult GetNotFoundRequest()
        {
            var product = context.Product.Find(5);
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("GetServerError")]
        public ActionResult GetServerError()
        {
            var product = context.Product.Find(5);

            var productToReturn = product.ToString();

            return Ok();
        }

        [HttpGet("GetBadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("GetNotFoundRequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
