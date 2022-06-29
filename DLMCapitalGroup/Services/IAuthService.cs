using DLMCapitalGroup.DTOs;
using System.Threading.Tasks;

namespace DLMCapitalGroup.Services
{
    public interface IAuthService
    {
        Task<LoginCredResponse> Login(LoginCred model);
    }
}
