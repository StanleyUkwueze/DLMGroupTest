using DLMCapitalGroup.DTOs;
using DLMCapitalGroup.Helper;
using DLMCapitalGroup.Model;
using DLMCapitalGroup.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DLMCapitalGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IAuthService _authService;
        private readonly UserManager<Customer> _userManager;
        private readonly IJwtService _jwtService;
        public CustomerController(ICustomerService service, IAuthService authService, UserManager<Customer> userManager,
            IJwtService jwtService)
        {
            _service = service;
            _authService = authService;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginCred model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("Invalid", "Credentials provided but the user is invalid");
                return BadRequest(Response<object>.Fail("Invalid credentials", 400));
            }

                // check if user's email is confirmed
                if (await _userManager.IsEmailConfirmedAsync(user))
                {
                    var result = await _authService.Login(model);

                    if (!result.Status)
                    {
                        ModelState.AddModelError("Invalid", "Invalid credentials");
                        return BadRequest(Response<object>.Fail( "Invalid credentials",400));
                    }
                    return Ok(Response<object>.Success("Login is sucessful!", result,200));

                }
                ModelState.AddModelError("Invalid", "User must first confirm email before attempting to login");
                return BadRequest(Response<object>.Fail("Email not confirmed", 400));
           
        }

        [HttpPost]
        [Route("CreateCustomer")]
        [Authorize]
        public async Task<IActionResult> CreateCuster([FromQuery] CreateCustomerDto model)
        {
            if (!ModelState.IsValid) return BadRequest(model);

            var customer = await _service.CreateCustomer(model);
            return StatusCode(customer.StatusCode, customer);
        }
    }
}
