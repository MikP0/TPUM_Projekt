using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPUM.ClientData;
using TPUM.ClientData.Repositiories;
using TPUM.ClientLogic.DTOs;
using TPUM.Dependencies.Model;

namespace TPUM.ClientLogic.Services
{
    public class ProductService
    {
        private readonly SProductRepository _sproductRepository;

        public ProductService()
        {
            _sproductRepository = new SProductRepository(DbContext.Instance);
        }

        public ProductService(SProductRepository productRepository)
        {
            _sproductRepository = productRepository;
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            SProduct product = _sproductRepository.Get(id);
            return Mappings.MapProduct(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            DbContext.Instance.ToString();
            IEnumerable<SProduct> products = _sproductRepository.Get();

            return products.Select(c => Mappings.MapProduct(c)).ToList();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsFromAge(int age)
        {
            IEnumerable<SProduct> products = _sproductRepository.Get(c => c.MinimalAge >= age);

            return products.Select(c => Mappings.MapProduct(c)).ToList();
        }
    }
}
