using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.ReservationTableById
{
    public class ReservationTableByIdCommandHandler(IRepository<Table> repository,IUnitOfWork unitOfWork) : IRequestHandler<ReservationTableByIdCommand, string>
    {
        public async Task<string> Handle(ReservationTableByIdCommand request, CancellationToken cancellationToken)
        {
            var table =  await repository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id,cancellationToken);
            if (table == null)
                throw new Exception("Table not found");

            if (table.State == 2)
                throw new Exception("Table is already reserved");

            table.State = 2;
            repository.Update(table);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Table is reserved successfully";
        }
    }


}
