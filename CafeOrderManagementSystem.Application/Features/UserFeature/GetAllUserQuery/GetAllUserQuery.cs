using CafeOrderManagementSystem.Domain.Entities;
using MediatR;

namespace CafeOrderManagementSystem.Application.Features.UserFeature.GetAllUser
{
    public sealed record GetAllUserQuery() : IRequest<List<User>>;
}
