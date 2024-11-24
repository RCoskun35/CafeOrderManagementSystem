using CafeOrderManagementSystem.Application.Features.MenuProductFeature.DeleteMenuProductByMenuIdAndProductId;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
namespace CafeOrderManagementSystem.Application.MenuProductFeature.DeleteMenuProductByMenuIdAndProductId.Menu
{
    public class MenuCommandHandler 
        (
            IRepository<MenuProduct> repository, 
            IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteMenuProductByMenuIdAndProductIdCommand, string>
    {
        public async Task<string> Handle(DeleteMenuProductByMenuIdAndProductIdCommand request, CancellationToken cancellationToken)
        {
            var menuProduct = await repository.GetByExpressionWithTrackingAsync(x=>x.MenuId == request.MenuId && x.ProductId==request.ProductId, cancellationToken);
            if (menuProduct == null)
                throw new Exception("Menü Ürün eşleştirmesi bulunamadı");
            repository.Delete(menuProduct);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Menü ürün eşleştirmesi başarıyla silindi";
        }
    }

}
