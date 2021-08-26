using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSelling.Models
{
    class BillDetail
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Amount => Price * Quantity;
        public override string ToString()
        {
            return $"\t\t{ProductId}\t\t{ProductName}\t\t{Price}\t\t{Quantity}\t\t{string.Format("{0:0,0}", Amount)}vnd\n";
        }
    }
}
