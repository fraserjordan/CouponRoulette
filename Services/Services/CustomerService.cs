using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using Services.Interfaces;
using Services.Models;

namespace Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public CustomerInfo GetCustomerInfoByEmail(string email)
        {
            return _customerRepository.GetCustomerInfoByEmail(email);
        }

        public ServiceResponse CreateCustomerInfo(string userId)
        {
            var response = new ServiceResponse
            {
                Success = _customerRepository.CreateCustomerInfo(userId)
            };
            return response;
        }
    }
}
