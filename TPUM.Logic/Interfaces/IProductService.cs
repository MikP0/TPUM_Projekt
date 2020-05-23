using System.Collections.Generic;
using TPUM.Dependencies.Model;

namespace TPUM.Logic.Interfaces
{
    interface IProductService
    {
        SProduct GetProduct(int id);
        IEnumerable<SProduct> GetProducts();
        IEnumerable<SProduct> GetProductsByMinAge(int age);
    }
}
