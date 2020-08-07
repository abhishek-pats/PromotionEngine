using PromotionEngineSoln.Model;
using PromotionEngineSoln.Service;
using PromotionEngineSoln.Service.Interface;
using System;
using System.Collections.Generic;

namespace PromotionEngineSoln
{

    class Program
    {
        static void Main(string[] args)
        {
            /* This is a console program, it can be improvised by making use of the 
            dependency injection and application of the SOLID principles, due to time
            constraints presently uploading the code as required.*/

            List<Product> products = new List<Product>();

            Console.WriteLine("Total whole number of order's ::");
            int totalOrders = Convert.ToInt32(Console.ReadLine());

            IProductService Iprodservice = new ProductService();
            for (int i = 0; i < totalOrders;)
            {
                Console.WriteLine("enter the type of product:A,B,C or D::");

                //Create a Product and assign the type.
                Product prod = new Product();
                prod.Id = Console.ReadLine();

                Console.WriteLine("Enter the quantity of product::");
                prod.ProductCount = Console.ReadLine();

                i += int.Parse(prod.ProductCount);

                prod = Iprodservice.GetPriceByType(prod);

                //Add products to the list.
                products.Add(prod);
            }

            decimal totalPrice = Iprodservice.GetTotalPrice(products);
            Console.WriteLine("\nThe Total cost of the Order is ::" + totalPrice);
            Console.ReadLine();

        }
    }
}
