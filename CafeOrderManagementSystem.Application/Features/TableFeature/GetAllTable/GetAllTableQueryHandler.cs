using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable
{
    public class GetAllTableQueryHandler(IRepository<Table> repository) : IRequestHandler<GetAllTableQuery, List<Table>>
    {
        public async Task<List<Table>> Handle(GetAllTableQuery request, CancellationToken cancellationToken)
        {
            return await repository.WhereWithTracking(x => !x.IsDeleted).ToListAsync();
        }
    }
}
