using DLMCapitalGroup.DataAccess.Repository.Interfaces;
using DLMCapitalGroup.Model;
using System.Threading.Tasks;

namespace DLMCapitalGroup.DataAccess.Repository.Implementation
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _context;

        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Add<T>(T entity)
        {
            
           _context.Add(entity);
            return SaveChanges();
        }    
    }
}
