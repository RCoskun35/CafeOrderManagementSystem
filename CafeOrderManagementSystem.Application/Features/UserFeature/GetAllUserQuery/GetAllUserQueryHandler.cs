using CafeOrderManagementSystem.Domain.Entities;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.GetAllUser
{
    public class GetAllUserQueryHandler(IRepository<User> repository) : IRequestHandler<GetAllUserQuery, List<User>>
    {
        public async Task<List<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result =  await repository.WhereWithTracking(x => !x.IsDeleted).OrderByDescending(a=>a.CreatedDate).ToListAsync();
            return result;
        }
    }
}
