using System.Collections.Generic;
using TPUM.ClientLogic.DTOs;

namespace TPUM.ClientLogic.Interfaces
{
    interface IProductService
    {
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsByMinAge(int age);
    }
}
