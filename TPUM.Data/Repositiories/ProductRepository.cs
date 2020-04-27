using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;

namespace TPUM.Data.Repositiories
{
    class ProductRepository : IRepository<Product>
    {
        private readonly DbContext _dbContext;
        private readonly object m_SyncObject = new object();
        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Add(Product entity)
        {
            _dbContext.Products.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Product product = _dbContext.Products.FirstOrDefault(c => c.Id == id);
            _dbContext.Products.Remove(product);
        }

        public IEnumerable<Product> Get()
        {
            return _dbContext.Products;
        }

        public Product Get(int id)
        {
            return _dbContext.Products.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Product> Get(Func<Product, bool> filter)
        {
            return _dbContext.Products.Where(filter).ToList();
        }

        public Product Update(int id, Product entity)
        {
            lock(m_SyncObject)
            {
                Product product = _dbContext.Products.FirstOrDefault(c => c.Id == id);

                product.Author = entity.Author;
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.AllowedFromDate = entity.AllowedFromDate;
                product.IsLocked = entity.IsLocked;

                return product;
            }
        }
    }
}
