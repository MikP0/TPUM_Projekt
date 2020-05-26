using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPUM.ClientData.Repositiories;
using TPUM.Dependencies.Model;

namespace TPUM.ClientData.UnitTests
{
    [TestClass]
    public class ProductRepositoryUnitTest
    {
        [TestMethod]
        public void CreateTest()
        {
            DataContext dataContext = new DataContext { SProducts = new List<SProduct>() };
            SProductRepository productRepository = new SProductRepository(dataContext);
            Assert.IsNotNull(productRepository);
        }
        [TestMethod]
        public void GetTest()
        {
            DataContext dataContext = new DataContext { SProducts = new List<SProduct>() };
            SProductRepository productRepository = new SProductRepository(dataContext);
            IEnumerable<SProduct> products = productRepository.Get();
            Assert.IsNotNull(products);
        }

        [TestMethod]
        public void AddTest()
        {
            DataContext dataContext = new DataContext { SProducts = new List<SProduct>() };
            SProductRepository productRepository = new SProductRepository(dataContext);
            productRepository.Add(new SProduct
            {
                Id = 1,
                MinimalAge = 19,
                Author = "21Studios",
                Name = "Game 1",
                Price = 20.4f
            });

            Assert.IsNotNull(productRepository.Get(1));

        }

        [TestMethod]
        public void DeleteTest()
        {
            DataContext dataContext = new DataContext { SProducts = new List<SProduct>() };
            SProductRepository productRepository = new SProductRepository(dataContext);
            productRepository.Add(new SProduct
            {
                Id = 1,
                MinimalAge = 19,
                Author = "21Studios",
                Name = "Game 1",
                Price = 20.4f
            });
            productRepository.Delete(1);

            Assert.IsNull(productRepository.Get(1));
        }

        [TestMethod]
        public void UpdateTest()
        {
            DataContext dataContext = new DataContext { SProducts = new List<SProduct>() };
            SProductRepository productRepository = new SProductRepository(dataContext);
            productRepository.Add(new SProduct
            {
                Id = 1,
                MinimalAge = 19,
                Author = "21Studios",
                Name = "Game 1",
                Price = 20.4f
            });
            string newAuthor = "TSA";

            SProduct product2 = new SProduct
            {
                Id = 1,
                MinimalAge = 19,
                Author = newAuthor,
                Name = "Game 1",
                Price = 20.4f
            };
            productRepository.Update(1, product2);

            Assert.AreEqual(newAuthor, productRepository.Get(1).Author);

        }

        [TestMethod]
        public void FilterTest()
        {
            DataContext dataContext = new DataContext { SProducts = new List<SProduct>() };
            SProductRepository productRepository = new SProductRepository(dataContext);
            productRepository.Add(new SProduct
            {
                Id = 1,
                MinimalAge = 19,
                Author = "21Studios",
                Name = "Game 1",
                Price = 20.4f
            });


            productRepository.Add(new SProduct
            {
                Id = 1,
                MinimalAge = 17,
                Author = "12Studios",
                Name = "Game 2",
                Price = 20.4f
            });

            List<SProduct> products = productRepository.Get(c => c.MinimalAge ==  19).ToList();
            Assert.AreEqual(1, products.Count());
        }
    }
}
