using AutoMapper;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.CreateMenu
{
    public class CreateMenuCommandHandler(
            IRepository<Domain.Entities.Menu> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRequestHandler<CreateMenuCommand, string>
    {
        public async Task<string> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var isExistMenu = await repository.GetByExpressionWithTrackingAsync(x => x.Name == request.Name);
            if (isExistMenu != null)
                throw new Exception("Menu already exist");
            var menu = mapper.Map<Domain.Entities.Menu>(request);
            await repository.AddAsync(menu);
            await unitOfWork.SaveChangesAsync();
            return menu.Name;
        }
    }
}
