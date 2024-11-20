using CafeOrderManagementSystem.Application.Features.MenuFeature.DeleteMenuById;
using GenericRepository;
using MediatR;
namespace CafeOrderManagementSystem.Application.Features.MenuFeature.Menu
{
    public class MenuCommandHandler 
        (
            IRepository<Domain.Entities.Menu> repository, 
            IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteMenuByIdCommand, string>
    {
        public async Task<string> Handle(DeleteMenuByIdCommand request, CancellationToken cancellationToken)
        {
            var menu = await repository.GetByExpressionWithTrackingAsync(x=>x.Id == request.Id, cancellationToken);
            if (menu == null)
                throw new Exception("Menu not found");

            menu.IsDeleted = true;
            menu.DeletedDate = DateTime.Now;
            repository.Update(menu);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Menu deleted successfully";
        }
    }

}
