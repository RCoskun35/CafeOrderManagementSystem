using AutoMapper;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuProductFeature.CreateMenuProduct
{
    public class CreateMenuProductCommandHandler(
            IRepository<MenuProduct> repository,
            IUnitOfWork unitOfWork
        ) : IRequestHandler<CreateMenuProductCommand, string>
    {
        public async Task<string> Handle(CreateMenuProductCommand request, CancellationToken cancellationToken)
        {
            var isExistmenuProduct = await repository.GetByExpressionWithTrackingAsync(x => x.MenuId == request.MenuId && x.ProductId == request.ProductId, cancellationToken);
            if (isExistmenuProduct != null)
                throw new Exception("Menü Ürün ilişkisi zaten mevcut");
            var menuProduct = new MenuProduct
            {
                MenuId = request.MenuId,
                ProductId = request.ProductId
            };
            await repository.AddAsync(menuProduct, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Menü-Ürün eşleştirmesi yapıldı";
        }
    }
}
