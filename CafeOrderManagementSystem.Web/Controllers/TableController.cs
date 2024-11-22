using CafeOrderManagementSystem.Application.Features.TableFeature.CancelReservationTableById;
using CafeOrderManagementSystem.Application.Features.TableFeature.CreateTable;
using CafeOrderManagementSystem.Application.Features.TableFeature.DeleteTableById;
using CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable;
using CafeOrderManagementSystem.Application.Features.TableFeature.GetTableById;
using CafeOrderManagementSystem.Application.Features.TableFeature.ReservationTableById;
using CafeOrderManagementSystem.Application.Features.TableFeature.UpdateTable;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class TableController : BaseController
    {
        public TableController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(new GetAllTableQuery(), cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById( GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create( CreateTableCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Update( UpdateTableCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteTableByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> ReservationById( ReservationTableByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> CancelReservationById( CancelReservationTableByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
