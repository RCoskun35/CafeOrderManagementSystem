using CafeOrderManagementSystem.Application.Features.UserFeature.Login;
using CafeOrderManagementSystem.Application.UserManagement;
using CafeOrderManagementSystem.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CafeOrderManagementSystem.Web.Controllers
{
    public class AccountController(IMediator mediator) : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            try
            {
                var loginResult = await mediator.Send(request);
                LogService.Log(loginResult.Info, "", 0);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }
    }
}
