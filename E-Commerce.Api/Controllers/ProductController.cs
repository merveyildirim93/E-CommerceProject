using AutoMapper;
using E_Commerce.Api.Dtos.ProductDto;
using E_Commerce.Api.Helper;
using E_Commerce.Business.Interfaces;
using E_Commerce.Business.Spesifications;
using E_Commerce.Business.Spesifications.ProductDto;
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
        public async Task<ActionResult<Pagination<ProductListDto>>> GetProducts([FromQuery] ProductSpecDto dto)
        {
            var spec = new ProductSpecification(dto);
            var countSpec = new ProductWithFiltersForCountSpec(dto);
            var totalItems = await productRepository.CountAsync(spec);
            var products = await productRepository.ListAsync(spec);
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductListDto>>(products);
            return Ok(new Pagination<ProductListDto>(dto.PageIndex, dto.PageSize, totalItems, data));
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
