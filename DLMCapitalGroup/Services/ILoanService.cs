using DLMCapitalGroup.DTOs;
using DLMCapitalGroup.Helper;
using System.Threading.Tasks;

namespace DLMCapitalGroup.Services
{
    public interface ILoanService
    {
        Task<Response<decimal>> GetLoan(string AccountId, decimal RequestedAmount, decimal CustomerIncome);
    }
}