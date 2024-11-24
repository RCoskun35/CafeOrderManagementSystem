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
            var isExistMenu = await repository.GetByExpressionWithTrackingAsync(x => x.Name == request.Name, cancellationToken);
            if (isExistMenu != null)
                throw new Exception("Menü zaten mevcut");
            var menu = mapper.Map<Domain.Entities.Menu>(request);
            await repository.AddAsync(menu, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return menu.Name;
        }
    }
}
