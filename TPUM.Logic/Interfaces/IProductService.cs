using System;
using System.Collections.Generic;
using System.Text;
using TPUM.Logic.DTOs;

namespace TPUM.Logic.Interfaces
{
    interface IProductService
    {
        ProductDTO GetProduct(int id);
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsByMinAge(int age);
    }
}
