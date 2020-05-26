using System;
using System.Collections.Generic;
using System.Linq;
using TPUM.Dependencies.Model;

namespace TPUM.ClientData.Repositiories
{
    public class SProductRepository
    {
        private readonly DataContext _dataContext;
        private readonly object m_SyncObject = new object();

        public SProductRepository()
        {
            _dataContext = DbContext.Instance;
        }

        public SProductRepository(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        public SProduct Add(SProduct entity)
        {
            _dataContext.SProducts.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            SProduct product = _dataContext.SProducts.FirstOrDefault(c => c.Id == id);
            _dataContext.SProducts.Remove(product);
        }

        public IEnumerable<SProduct> Get()
        {
            return _dataContext.SProducts;
        }

        public SProduct Get(int id)
        {
            return _dataContext.SProducts.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<SProduct> Get(Func<SProduct, bool> filter)
        {
            return _dataContext.SProducts.Where(filter).ToList();
        }

        public SProduct Update(int id, SProduct entity)
        {
            lock (m_SyncObject)
            {
                SProduct product = _dataContext.SProducts.FirstOrDefault(c => c.Id == id);

                product.Author = entity.Author;
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.MinimalAge = entity.MinimalAge;

                return product;
            }
        }
    }
}
