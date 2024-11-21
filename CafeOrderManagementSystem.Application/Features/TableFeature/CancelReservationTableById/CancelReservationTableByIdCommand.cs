using MediatR;

namespace CafeOrderManagementSystem.Application.Features.TableFeature.CancelReservationTableById
{
    public sealed record CancelReservationTableByIdCommand(int Id) : IRequest<string>;


}
