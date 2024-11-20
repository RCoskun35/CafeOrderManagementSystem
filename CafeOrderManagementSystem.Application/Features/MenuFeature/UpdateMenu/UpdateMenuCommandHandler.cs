using AutoMapper;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.UpdateMenu
{
    public class UpdateMenuCommandHandler(IRepository<Domain.Entities.Menu> repository,IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<UpdateMenuCommand, string>
    {
        public async Task<string> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await repository.GetByExpressionAsync(x => x.Id == request.Id);
            if (menu == null)
                throw new Exception("Menu not found");

            menu.Name = request.Name;
            menu.UpdatedDate = DateTime.Now;
            repository.Update(menu);
            await unitOfWork.SaveChangesAsync();
            return "Menu updated successfully";
        }
    }
}
