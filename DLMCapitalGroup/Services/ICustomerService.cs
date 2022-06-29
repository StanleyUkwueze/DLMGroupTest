using DLMCapitalGroup.DTOs;
using System.Threading.Tasks;
using DLMCapitalGroup.Helper;

namespace DLMCapitalGroup.Services
{
    
    public interface ICustomerService
    {
        Task<Response<CustomerResponseDto>> CreateCustomer(CreateCustomerDto model);
    }
}
