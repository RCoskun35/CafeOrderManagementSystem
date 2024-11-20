using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.GetTableById
{
    public class GetTableByIdQueryHandler(IRepository<Table> repository) : IRequestHandler<GetTableByIdQuery, Table>
    {
        public async Task<Table> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id);
        }
    }


}
