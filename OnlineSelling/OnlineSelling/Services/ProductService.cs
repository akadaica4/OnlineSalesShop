using OnlineSelling.Helper;
using OnlineSelling.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace OnlineSelling.Services
{
    class ProductService : BaseService, IProductService
    {
        private string fileName = "product.json";
        private ProductList productList = new ProductList();
        public ProductList ProductList => productList;
        public ProductService()
        {
            productList = FileHelper.ReadFile<ProductList>(Path.Combine(path, fileName));
        }
        public bool Add(Product product)
        {
            int productId = productList.products.Max(p => p.productId) + 1;
            product.productId = productId;
            productList.products.Add(product);
            FileHelper.WriteFile<ProductList>(Path.Combine(path, fileName), productList);
            return true;
        }

        public List<Product> Get()
        {
            return productList.products;
        }

        public List<Product> Find(string keyword)
        {
            var productId = 0;
            int.TryParse(keyword, out productId);
            if (productId == 0)
            {
                return productList.products.Where(p => p.productName.ToLower().Contains(keyword.ToLower())).ToList();
            }
            return productList.products.Where(p => p.productName.Contains(keyword) || p.productId == productId).ToList();
        }
    }
}
