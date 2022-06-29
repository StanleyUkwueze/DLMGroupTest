using DLMCapitalGroup.Model;
using System.Collections.Generic;

namespace DLMCapitalGroup.Services
{
    
        public interface IJwtService
        {
            public string GenerateJWTToken(Customer customer, List<string> userRoles);
        }
    
}
