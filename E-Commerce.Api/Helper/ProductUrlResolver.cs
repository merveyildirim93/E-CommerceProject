using E_Commerce.Api.Dtos.ProductDto;
using E_Commerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;

namespace E_Commerce.Api.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductListDto, string>
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration config;
        public ProductUrlResolver(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            this.config = config;
        }
        public string Resolve(Product source, ProductListDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl))
            {
                return config["ApiUrl"] + source.ImageUrl;
            }
            return null;
        }
    }
}
