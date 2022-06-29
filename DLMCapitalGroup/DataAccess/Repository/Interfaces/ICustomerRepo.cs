using DLMCapitalGroup.Model;
using System.Threading.Tasks;

namespace DLMCapitalGroup.DataAccess.Repository.Interfaces
{
    public interface ICustomerRepo 
    {
        Task<bool> Add<T>(T entity);
    }
}
