using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Models
{
    public class OrderDetailsDTO
    {
        public OrderDTO Order;

        public IEnumerable<ProductDetailsDTO> Products;

        public double TotalPrice;

        public void CountPrice()
        {
            this.TotalPrice = Math.Round(this.Products.Sum(prod => prod.ExtendedPrice),2);//todo pn хардкод. мне приходится останавливаться на этой строке и думать, что за 2ка.
        }
    }
}
