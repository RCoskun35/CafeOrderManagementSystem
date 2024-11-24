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
                throw new Exception("Masa bulunamadı");

            if (table.State != 2)
                throw new Exception("Masa rezerve değil iptal edilemez");

            table.State = 0;
            repository.Update(table);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Masa rezervasyonu iptal işlemi başarılı";
        }
    }


}
