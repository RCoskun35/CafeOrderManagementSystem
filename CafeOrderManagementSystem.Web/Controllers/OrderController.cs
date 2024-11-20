using CafeOrderManagementSystem.Application.Features.OrderFeature.AddOrderDetail;
using CafeOrderManagementSystem.Application.Features.OrderFeature.CreateOrder;
using CafeOrderManagementSystem.Application.Features.OrderFeature.GetAllOrder;
using CafeOrderManagementSystem.Application.Features.OrderFeature.GetOrderById;
using CafeOrderManagementSystem.Application.Features.OrderFeature.RemoveOrderDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] GetAllOrderQuery request,CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderDetail([FromBody] AddOrderDetailCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveOrderDetail([FromBody] RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
    }
}
