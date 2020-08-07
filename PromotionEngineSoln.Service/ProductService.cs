using PromotionEngineSoln.Model;
using PromotionEngineSoln.Service.Interface;
using System;
using System.Collections.Generic;


namespace PromotionEngineSoln.Service
{
    public class ProductService: IProductService
    {
        public Product GetPriceByType(Product product)
        {
            switch (product.Id)
            {
                case "A":
                    product.Price = 50;
                    break;
                case "B":
                    product.Price = 30;
                    break;
                case "C":
                    product.Price = 20;
                    break;
                case "D":
                    product.Price = 15;
                    break;
            }
            return product;
        }

        public decimal GetTotalPrice(List<Product> products)
        {
            int counterOfA = 0, counterOfB = 0, counterOfC = 0, counterOfD = 0;
            decimal priceOfA = 0, priceOfB = 0, priceOfC = 0, priceOfD = 0;

            foreach (Product pr in products)
            {
                switch (pr.Id)
                {
                    case "A":
                    case "a":
                        counterOfA = Int32.Parse(pr.ProductCount);
                        priceOfA = pr.Price;
                        break;
                    case "B":
                    case "b":
                        counterOfB = Int32.Parse(pr.ProductCount);
                        priceOfB = pr.Price;
                        break;
                    case "C":
                    case "c":
                        counterOfC = Int32.Parse(pr.ProductCount);
                        priceOfC = pr.Price;
                        break;
                    case "D":
                    case "d":
                        counterOfD = Int32.Parse(pr.ProductCount);
                        priceOfD = pr.Price;
                        break;
                }
            }

            //Business Rules Start, these count can be moved to a storage.
            decimal totalPriceOfA = (counterOfA / 3) * 130 + (counterOfA % 3 * priceOfA);
            decimal totalPriceOfB = (counterOfB / 2) * 45 + (counterOfB % 2 * priceOfB);
            decimal totalPriceOfC = 0;
            decimal totalPriceOfD = 0;

            decimal totalPriceOfCD = 0;

            int remainingCount = 0;
            if (counterOfC > counterOfD)
            {
                remainingCount = counterOfC - counterOfD;
                totalPriceOfCD = counterOfD * 30;
                totalPriceOfC = remainingCount * 20;
            }
            else if (counterOfD > counterOfC)
            {
                remainingCount = counterOfD - counterOfC;
                totalPriceOfCD = counterOfC * 30;
                totalPriceOfD = remainingCount * 15;
            }
            else
            {
                totalPriceOfCD = counterOfC * 30;
            }
            //Business Rules End


            return totalPriceOfA + totalPriceOfB + totalPriceOfC + totalPriceOfD + totalPriceOfCD;
        }
    }
}
