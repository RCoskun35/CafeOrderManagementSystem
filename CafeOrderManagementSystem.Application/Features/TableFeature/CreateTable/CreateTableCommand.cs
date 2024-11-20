using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.CreateTable
{
    public sealed record CreateTableCommand(string TableNumber) : IRequest<string>;
}
