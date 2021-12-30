using AutoMapper;
using E_Commerce.Api.Dtos.ProductDto;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Spesifications;
using E_Commerce.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Api.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> productRepository;
        private readonly IMapper mapper;
        public ProductController(IGenericRepository<Product> productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet("GetProducts")]
        public async Task<ActionResult<IReadOnlyList<ProductListDto>>> GetProducts()
        {
            var spec = new ProductSpecification();
            var data = await productRepository.ListAsync(spec);
            return Ok(mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductListDto>>(data));
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<ProductListDto>> GetProductById(int id)
        {
            var spec = new ProductSpecification(id);
            var product = await productRepository.GetEntityWithSpec(spec);
            return mapper.Map<Product, ProductListDto>(product);
            // return await productRepository.GetEntityWithSpec(spec);
        }

    }
}
