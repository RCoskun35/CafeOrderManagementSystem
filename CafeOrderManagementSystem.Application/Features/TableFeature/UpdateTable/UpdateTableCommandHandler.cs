using AutoMapper;
using CafeOrderManagementSystem.Application.Features.TableFeature.CreateTable;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.UpdateTable
{
    public class UpdateTableCommandHandler(IRepository<Table> repository,IUnitOfWork unitOfWork) : IRequestHandler<UpdateTableCommand, string>
    {
        public async Task<string> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            var table = await repository.GetByExpressionAsync(x => x.Id == request.Id);
            if (table == null)
                throw new Exception("Table not found");

            table.TableNumber = request.TableNumber;
            table.UpdatedDate = DateTime.Now;
            repository.Update(table);
            await unitOfWork.SaveChangesAsync();
            return "Table updated successfully";
        }
    }
}
