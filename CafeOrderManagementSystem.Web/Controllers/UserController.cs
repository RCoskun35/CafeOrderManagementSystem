﻿
using CafeOrderManagementSystem.Application.Features.UserFeature.GetAllUser;
using CafeOrderManagementSystem.Application.Features.UserFeature.Login;
using CafeOrderManagementSystem.Application.Features.UserFeature.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await HandleRequestAsync(request, cancellationToken);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return await HandleRequestAsync(new GetAllUserQuery(), CancellationToken.None);
        }
        
    }
}
