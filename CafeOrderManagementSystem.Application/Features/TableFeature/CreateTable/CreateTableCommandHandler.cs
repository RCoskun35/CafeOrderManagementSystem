using AutoMapper;
using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.CreateTable
{
    public class CreateTableCommandHandler(
            IRepository<Table> repository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        ) : IRequestHandler<CreateTableCommand, string>
    {
        public async Task<string> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var isExistTable = await repository.GetByExpressionWithTrackingAsync(x => x.TableNumber == request.TableNumber);
            if (isExistTable != null)
                throw new Exception("Masa zaten mevcut");
            var table = mapper.Map<Table>(request);
            table.State = 0;
            await repository.AddAsync(table);
            await unitOfWork.SaveChangesAsync();
            return table.TableNumber;
        }
    }
}
