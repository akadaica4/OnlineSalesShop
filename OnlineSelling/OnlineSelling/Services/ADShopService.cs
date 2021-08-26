using OnlineSelling.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineSelling.Services
{
    public class ADShopService
    {
        private BillService billService;
        private readonly ProductService productService;
        private List<CartItem> cartItems = new List<CartItem>();
        public ADShopService()
        {
            productService = new ProductService();
            billService = new BillService();
        }
        public bool CreateProduct(Product product)
        {
            return productService.Add(product);
        }
        public void ShowProduct()
        {
            foreach (Product product in productService.Get())
            {
                Console.WriteLine(product.ToString());
            }
        }
        public void FindProduct(string keyword)
        {
            var products = productService.Find(keyword);
            if (products == null || products.Count == 0)
            {
                Console.Write("Not found.");
            }
            else
            {
                foreach (Product product in products)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }

        public void ShowCart()
        {
            double Total = 0;
            foreach (CartItem cartItem in cartItems)
            {
                Console.WriteLine(cartItem.ToString());
                Total += cartItem.Amount;
            }
            Console.WriteLine($"Tổng Tiền: {string.Format("{0:0,0}", Total)}vnd");
        }

        public void AddCart(int productId, int quantity)
        {
            foreach (var item in productService.ProductList.products)
            {
                if (item.productId == productId)
                {
                    cartItems.Add(new CartItem()
                    {
                        CartId = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                        Product = item,
                        Quantity = quantity,
                        Amount = quantity * item.price

                    }); ;
                }
            }
        }
        public void Edit(int productId, int quantity)
        {
            foreach (var item in cartItems)
            {
                if (item.Product.productId == productId)
                {
                    item.Quantity = quantity;
                    item.Amount = quantity * item.Product.price;
                }
            }
        }

        public void Pay()
        {
            List<BillDetail> details = new List<BillDetail>();
            foreach (var item in cartItems)
            {
                //do du lieu tu cartItem sang Billdell

                details.Add(new BillDetail
                {
                    ProductId = item.Product.productId,
                    ProductName = item.Product.productName,
                    Price = item.Product.price,
                    Quantity = item.Quantity,

                });
            }
            billService.CreateBill(details);
        }
        public void RemoveCart(int producId)
        {
            foreach (var item in cartItems)
            {
                if (item.Product.productId == producId)
                {
                    cartItems.Remove(item);
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sản phẩm trong giỏ hàng! Vui lòng kiểm tra lại");
                }
            }
        }

    }
}
