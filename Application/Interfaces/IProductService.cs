using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService
    {
        Product Create(ProductCreateRequest productCreateRequest);
        void Delete(int Id);
        List<ProductDto> GetAll();
        List<Product> GetAllFullData();
        ProductDto GetById(int Id);
        void Update(int Id, ProductUpdateRequest productUpdateRequest);
    }
}
