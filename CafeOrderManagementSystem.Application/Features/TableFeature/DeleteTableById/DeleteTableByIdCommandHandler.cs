using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.DeleteTableById
{
    public class DeleteTableByIdCommandHandler 
        (
            IRepository<Table> repository, 
            IUnitOfWork unitOfWork
        ) : IRequestHandler<DeleteTableByIdCommand, string>
    {
        public async Task<string> Handle(DeleteTableByIdCommand request, CancellationToken cancellationToken)
        {
            var table =await repository.GetByExpressionWithTrackingAsync(x=>x.Id == request.Id);
            if (table == null)
                throw new Exception("Masa bulunamadı");

            table.IsDeleted = true;
            table.DeletedDate = DateTime.Now;
            repository.Update(table);
            await unitOfWork.SaveChangesAsync();
            return "Masa silme işlemi başarılı";
        }
    }

}
