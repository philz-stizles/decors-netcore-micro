using Auth.Application.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthService.API.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {

        public AuthController(IMediator mediator) : base(mediator) { }


        [HttpPost("register-customer")]
        public async Task<ActionResult> RegisterCustomer(RegisterCustomer.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("/register-customer-with-verification")]
        public async Task<ActionResult> RegisterCustomerWithVerification(RegisterCustomer.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("/verify-customer/{token}")]
        public async Task<ActionResult> VerifyCustomer([FromRoute] string token)
        {
            var result = await Mediator.Send(new VerifyCustomer.Query { Token = token });
            return Ok(result);
        }

        [HttpPost("register-vendor")]
        // [ServiceFilter(typeof(ApiValidationFilterAttribute))]
        public async Task<ActionResult> RegisterVendor(RegisterVendor.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("/register-vendor-with-verification")]
        public async Task<ActionResult> RegisterVendorWithVerification(RegisterVendor.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("/verify-business")]
        public async Task<ActionResult> VerifyBusiness([FromRoute] string token)
        {
            var result = await Mediator.Send(new VerifyVendor.Query { Token = token });
            return Ok(result);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult> Login(Login.Query query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("/login-with-cookie")]
        public async Task<ActionResult> LoginWithCookie(Login.Query query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("/current-user")]
        public async Task<ActionResult> CurrentUser(CurrentUser.Query query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
