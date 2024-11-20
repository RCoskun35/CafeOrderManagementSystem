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
            var Menu =await repository.GetByExpressionWithTrackingAsync(x=>x.Id == request.Id);
            if (Menu == null)
                throw new Exception("Menu not found");

            Menu.IsDeleted = true;
            Menu.DeletedDate = DateTime.Now;
            repository.Update(Menu);
            await unitOfWork.SaveChangesAsync();
            return "Menu deleted successfully";
        }
    }

}
