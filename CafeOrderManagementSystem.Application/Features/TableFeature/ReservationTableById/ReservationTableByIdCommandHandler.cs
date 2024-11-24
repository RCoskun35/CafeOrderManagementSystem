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
                throw new Exception("Masa bulunamadı");

            if (table.State == 2)
                throw new Exception("Masa zaten rezerve edilmiş");

            table.State = 2;
            table.UpdatedDate = DateTime.Now;
            repository.Update(table);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Rezervasyon başarılı";
        }
    }


}
