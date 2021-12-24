using E_Commerce.Business.Interfaces;
using E_Commerce.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> productRepository;
        public ProductController(IGenericRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var data = await productRepository.ListAllAsync();
            return Ok(data);
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            return await productRepository.GetByIdAsync(id);
        }

    }
}
