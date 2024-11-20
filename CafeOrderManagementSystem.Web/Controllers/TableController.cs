using CafeOrderManagementSystem.Application.Features.TableFeature.CreateTable;
using CafeOrderManagementSystem.Application.Features.TableFeature.DeleteTableById;
using CafeOrderManagementSystem.Application.Features.TableFeature.GetAllTable;
using CafeOrderManagementSystem.Application.Features.TableFeature.GetTableById;
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
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] GetAllTableQuery request,CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTableCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTableCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById([FromBody] DeleteTableByIdCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
