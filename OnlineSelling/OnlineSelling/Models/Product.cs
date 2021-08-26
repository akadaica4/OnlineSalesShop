using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSelling.Models
{
   public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public override string ToString()
        {
            
            return $"{productId}\t\t{productName}\t\t{quantity}\t\t{string.Format("{0:0,0}", price)}vnd";
        }
    }
}
