using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.GetMenuById
{
    public class GetMenuByIdQueryHandler(IRepository<Domain.Entities.Menu> repository) : IRequestHandler<GetMenuByIdQuery, Domain.Entities.Menu>
    {
        public async Task<Domain.Entities.Menu> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);
        }
    }


}
