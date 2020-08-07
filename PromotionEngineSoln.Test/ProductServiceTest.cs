using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngineSoln.Service.Interface;
using PromotionEngineSoln.Model;
using PromotionEngineSoln.Service;
using System.Collections.Generic;

namespace PromotionEngineSoln.Test
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void GetPriceByTypeTest()
        {
            IProductService Iprodservice = new ProductService();
            //Create a Product and assign the type.
            Product prod = new Product();
            prod.Id = "A";
            prod.ProductCount = "5";
            prod = Iprodservice.GetPriceByType(prod);

            Assert.AreEqual(50, prod.Price);
        }

        [TestMethod]
        public void GetTotalPriceTest()
        {
            IProductService Iprodservice = new ProductService();
            //Create a Product and assign the type.
            List<Product> products = new List<Product>();

            Product prod1 = new Product();
            prod1.Id = "A";
            prod1.ProductCount = "3";
            prod1 = Iprodservice.GetPriceByType(prod1);

            Product prod2 = new Product();
            prod2.Id = "B";
            prod2.ProductCount = "5";
            prod2 = Iprodservice.GetPriceByType(prod2);

            Product prod3 = new Product();
            prod3.Id = "C";
            prod3.ProductCount = "1";
            prod3 = Iprodservice.GetPriceByType(prod3);

            Product prod4 = new Product();
            prod4.Id = "D";
            prod4.ProductCount = "1";
            prod4 = Iprodservice.GetPriceByType(prod4);

            products.Add(prod1);
            products.Add(prod2);
            products.Add(prod3);
            products.Add(prod4);
            
            Assert.AreEqual(280, Iprodservice.GetTotalPrice(products));
        }
    }
}
