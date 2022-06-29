using DLMCapitalGroup.Commons;
using DLMCapitalGroup.DTOs;
using DLMCapitalGroup.Helper;
using DLMCapitalGroup.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DLMCapitalGroup.Services
{
    public class LoanService : ILoanService
    {
        static readonly HttpClient _httpClient = new HttpClient();
        public IConfiguration _Configuration { get; }
        public LoanService(IConfiguration Configuration)
        {
            
            _Configuration = Configuration;
        }
        private async Task<IncomeResponseDto> GetIncomeData(string AccountId, decimal CustomerIncome)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{_Configuration["IncomeSettings:BaseUrl"]}/{AccountId}/{CustomerIncome}"),
                Headers =
                {
                    { "Accept", "application/json" },
                     { "secret-Key", $"{_Configuration["IncomeSettings:secret-Key"]}" },
                },
            };
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IncomeResponseDto>(res);

            return result;
        }

        public async Task<Response<decimal>> GetLoan(string AccountId, decimal RequestedAmount, decimal CustomerIncome)
        {
            var response = new Response<decimal>();
            var loan = new Loan();
            var incomeData = await GetIncomeData(AccountId, CustomerIncome);
            var maxMonthlyRepayment = (60 / 100) * (incomeData.MonthlyIncome);
            var duration = loan.DurationInMonths;
            

            if (maxMonthlyRepayment * duration  >= RequestedAmount)
            {
                response.StatusCode = 200;
                response.Message = "Loan successfully granted";
                response.Data = Convert.ToDecimal(RequestedAmount.ToString());
                response.Succeeded = true;
            }
            else
            {
                response.StatusCode = 400;
                response.Message = "You are not qualified to be granted this amount of loan";
                response.Succeeded = false;
            }
            return response;


        }
    }
}
