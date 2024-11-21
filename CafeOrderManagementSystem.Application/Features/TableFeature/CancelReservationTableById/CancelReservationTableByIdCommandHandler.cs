using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.CancelReservationTableById
{
    public class CancelReservationTableByIdCommandHandler(IRepository<Table> repository,IUnitOfWork unitOfWork) : IRequestHandler<CancelReservationTableByIdCommand, string>
    {
        public async Task<string> Handle(CancelReservationTableByIdCommand request, CancellationToken cancellationToken)
        {
            var table =  await repository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id,cancellationToken);
            if (table == null)
                throw new Exception("Table not found");

            if (table.State != 2)
                throw new Exception("Table is not reserved");

            table.State = 0;
            repository.Update(table);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "The table reservation has been successfully canceled.";
        }
    }


}
