using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using Services.Interfaces;
using Services.Models;

namespace Services.Services
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private readonly ICustomerInfoRepository _customerInfoRepository;

        public CustomerInfoService()
        {
            _customerInfoRepository = new CustomerInfoRepository();
        }
        public CustomerInfo GetCustomerInfoByEmail(string email)
        {
            return _customerInfoRepository.GetCustomerInfoByEmail(email);
        }

        public ServiceResponse CreateCustomerInfo(string userId)
        {
            var response = new ServiceResponse
            {
                Success = _customerInfoRepository.CreateCustomerInfo(userId)
            };
            return response;
        }
    }
}
