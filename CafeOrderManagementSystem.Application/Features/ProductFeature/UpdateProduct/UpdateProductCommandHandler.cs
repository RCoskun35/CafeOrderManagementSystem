﻿using AutoMapper;
using CafeOrderManagementSystem.Application.Features.ProductFeature.CreateProduct;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.ProductFeature.UpdateProduct
{
    public class UpdateProductCommandHandler(IRepository<Product> repository,IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, string>
    {
        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByExpressionAsync(x => x.Id == request.Id);
            if (product == null)
                throw new Exception("Ürün bulunamadı");

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = decimal.Parse(request.Price.Replace(".", ","));
            product.CategoryId = request.CategoryId;
            product.UpdatedDate = DateTime.Now;
            repository.Update(product);
            await unitOfWork.SaveChangesAsync();
            return "Ürün başarıyla güncellendi";
        }
    }
}
