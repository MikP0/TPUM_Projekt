﻿using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.Data;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;
using TPUM.Data.Repositiories;
using TPUM.Dependencies.Model;

namespace TPUM.Logic.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository(DbContext.Instance);
        }

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public SProduct GetProduct(int id)
        {
            Product product = _productRepository.Get(id);
            return Mappings.MapProduct(product);
        }

        public IEnumerable<SProduct> GetProducts()
        {
            IEnumerable<Product> products = _productRepository.Get();

            return products.Select(c => Mappings.MapProduct(c)).ToList();
        }

        public IEnumerable<SProduct> GetProductsFromAge(int age)
        {
            IEnumerable<Product> products = _productRepository.Get(c => c.AllowedFromDate.Year >= DateTime.Now.Year - age);

            return products.Select(c => Mappings.MapProduct(c)).ToList();
        }
    }
}
