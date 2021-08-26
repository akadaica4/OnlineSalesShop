using OnlineSelling.Models;
using System.Collections.Generic;

namespace OnlineSelling.Services
{
    interface IProductService
    {
        bool Add(Product product);
        List<Product> Get();
        List<Product> Find(string keyword);
    }
}
