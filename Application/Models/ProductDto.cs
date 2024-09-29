using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }

        public static ProductDto Create(Product product)
        {
            var dto = new ProductDto();
            dto.Id = product.Id;
            dto.Name = product.Name;
            dto.Model = product.Model;
            dto.Color = product.Color;
            dto.Description = product.Description;
            dto.Price = product.Price;

            return dto;
        }

        public static List<ProductDto> CreateList(IEnumerable<Product> products)
        {
            List<ProductDto> listDto = [];
            foreach (var s in products)
            {
                listDto.Add(Create(s));
            }

            return listDto;
        }
    }
}
