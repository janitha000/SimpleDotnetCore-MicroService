using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Basket.Models
{
    public class ProductPriceChangedIntegrationEvent 
    {
        public string ProductId { get; set; }
        public decimal OldPrince { get; set; }
        public decimal NewPrice { get; set; }

        public ProductPriceChangedIntegrationEvent(string productId, decimal oldPrice, decimal newPrice)
        {
            ProductId = productId;
            OldPrince = oldPrice;
            NewPrice = newPrice;
        }
    }
}
