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
            var menuProduct = await repository.GetByExpressionWithTrackingAsync(x=>x.MenuId == request.MenuId && x.ProductId==request.ProductId);
            if (menuProduct == null)
                throw new Exception("MenuProduct not found");
            repository.Delete(menuProduct);
            await unitOfWork.SaveChangesAsync();
            return "MenuProduct deleted successfully";
        }
    }

}
