using PromotionEngineSoln.Model;
using System.Collections.Generic;


namespace PromotionEngineSoln.Service.Interface
{
    public interface IProductService
    {
        Product GetPriceByType(Product product);
        decimal GetTotalPrice(List<Product> products);
    }
}
