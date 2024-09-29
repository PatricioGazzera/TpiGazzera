using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllFullData()
        {
            return _productRepository.GetAll();
        }

        public ProductDto GetById(int id)
        {
            var obj = _productRepository.GetById(id)
                ?? throw new NotFoundException(nameof(Product), id);
            var dto = ProductDto.Create(obj);
            return dto;
        }

        public List<ProductDto> GetAll()
        {
            var list = _productRepository.GetAll();
            return ProductDto.CreateList(list);
        }

        public Product Create(ProductCreateRequest productCreateRequest)
        {
            var obj = new Product();
            obj.Name = productCreateRequest.Name;
            obj.Model = productCreateRequest.Model;
            obj.Color = productCreateRequest.Color;
            obj.Description = productCreateRequest.Description;
            obj.Price = productCreateRequest.Price;

            return _productRepository.Add(obj);
        }

        public void Update(int id, ProductUpdateRequest productUpdateRequest)
        {
            var obj = _productRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Product), id);

            if (productUpdateRequest.Name != string.Empty) obj.Name = productUpdateRequest.Name;
            if (productUpdateRequest.Model != string.Empty) obj.Model = productUpdateRequest.Model;
            if (productUpdateRequest.Color != string.Empty) obj.Color = productUpdateRequest.Color;
            if (productUpdateRequest.Description != string.Empty) obj.Description = productUpdateRequest.Description;
            if (productUpdateRequest.Price != 0) obj.Price = productUpdateRequest.Price;

            _productRepository.Update(obj);
        }

        public void Delete(int id)
        {
            var obj = _productRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Product), id);

            _productRepository.Delete(obj);
        }
    }
}
