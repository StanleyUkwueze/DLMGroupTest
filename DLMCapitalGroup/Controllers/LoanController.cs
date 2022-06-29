using DLMCapitalGroup.DTOs;
using DLMCapitalGroup.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DLMCapitalGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        [Route("GetLoan")]
        [Authorize]
        public async Task<IActionResult> GetLoan(string AccountId, decimal RequestedAmount, decimal CustomerIncome)
        {
            var response = await _loanService.GetLoan(AccountId, RequestedAmount, CustomerIncome);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
