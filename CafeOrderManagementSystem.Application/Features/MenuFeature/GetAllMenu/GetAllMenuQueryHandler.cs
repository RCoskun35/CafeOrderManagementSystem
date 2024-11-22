using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.MenuFeature.GetAllMenu
{
    public class GetAllMenuQueryHandler(IRepository<Domain.Entities.Menu> repository) : IRequestHandler<GetAllMenuQuery, List<Domain.Entities.Menu>>
    {
        public async Task<List<Domain.Entities.Menu>> Handle(GetAllMenuQuery request, CancellationToken cancellationToken)
        {
            return await repository.WhereWithTracking(x => !x.IsDeleted).OrderByDescending(a=>a.CreatedDate).ToListAsync(cancellationToken);
        }
    }
}
