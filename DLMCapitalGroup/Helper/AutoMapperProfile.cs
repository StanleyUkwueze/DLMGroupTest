using AutoMapper;
using DLMCapitalGroup.DTOs;
using DLMCapitalGroup.Model;

namespace DLMCapitalGroup.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CreateCustomerDto>();
            CreateMap<CustomerResponseDto, Customer>();
        }
    }
}
