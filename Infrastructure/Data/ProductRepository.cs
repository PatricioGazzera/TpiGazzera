using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        static int LastIdAssigned = 0;
        static List<Product> products = [];

        public Product Add(Product product)
        {
            product.Id = LastIdAssigned++;
            products.Add(product);
            return product;
        }

        public void Delete(Product product) 
        {
            products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return products.ToList();
        }

        public Product? GetById(int Id)
        {
            return products.FirstOrDefault(p => p.Id == Id);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            var obj = products.FirstOrDefault(p => p.Id == product.Id)
                ?? throw new NotFoundException(nameof(Product), product.Id);

            obj.Name = product.Name;
        }
    }
}
