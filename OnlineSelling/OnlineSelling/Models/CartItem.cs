using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSelling.Models
{
   public class CartItem
    {
        private int quantity;
        private Product product;
        private long cartId;
        private double amount;
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public long CartId
        {
            get { return cartId; }
            set { cartId = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public override string ToString()
        {
            return $"{product.productId}\t{product.productName}\t\t\t{quantity}\t\t\t{product.price}\t\t{string.Format("{0:0,0}", Amount)}vnd";
        }

    }
}
