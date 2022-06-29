using AutoMapper;
using DLMCapitalGroup.DataAccess;
using DLMCapitalGroup.DataAccess.Repository.Interfaces;
using DLMCapitalGroup.DTOs;
using DLMCapitalGroup.Helper;
using DLMCapitalGroup.Model;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace DLMCapitalGroup.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly UserManager<Customer> _userManager;

        //private readonly IMapper _mapper;
        private readonly ICustomerRepo _customerRepo;
        private readonly AppDbContext _context;

        public CustomerService( ICustomerRepo customerRepo, AppDbContext context, UserManager<Customer> userManager)
        {

            _userManager = userManager;
            _customerRepo = customerRepo;
            _context = context;
            //_mapper = mapper;
        }
        public async Task<Response<CustomerResponseDto>> CreateCustomer(CreateCustomerDto model)
        {
            //var customer = _mapper.Map<Customer>(model);
            var customer = new Customer();
            customer.UserName = model.UserName ;
            customer.Email = model.Email;
            customer.MonthlyIncome = model.MonthlyIncome;
            customer.YearlyIncome = model.YearlyIncome;
            customer.AverageMonthlyIncome = model.AverageMonthlyIncome;
            customer.PhoneNumber = model.PhoneNumber;
            customer.Password = model.Password;
            customer.IncomeSources = model.IncomeSources;
            customer.BankName = model.BankName;
            customer.RequestedAmount = model.RequestedAmount;
         
            var response = await _userManager.CreateAsync(customer,model.Password);

            if (!response.Succeeded) return Response<CustomerResponseDto>.Fail($"{response.Errors.First()}", 400);

            var customerToReturn =   _context.Customers.First(c => c.Email == customer.Email);
            if (customerToReturn != null)
            {
              var mappedResult = new CustomerResponseDto();
                mappedResult.CustomerId = customerToReturn.Id;
                mappedResult.CustomerName = customerToReturn.UserName;
                mappedResult.MonthlyIncome = customerToReturn.MonthlyIncome;
                mappedResult.YearlyIncome=customerToReturn.YearlyIncome;
                mappedResult.IncomeSources = customerToReturn.IncomeSources;
                mappedResult.AverageMonthlyIncome=customerToReturn.AverageMonthlyIncome;
                return Response<CustomerResponseDto>.Success($"Customer created successfully", mappedResult, 200);
            }

            return Response<CustomerResponseDto>.Fail($"Customer with the Email: {customer.Email} is not found", 404);
        }
    }
}
